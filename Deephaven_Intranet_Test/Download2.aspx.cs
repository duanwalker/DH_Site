using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Security.AccessControl;
using System.Runtime.Caching;
using System.Web;
using System.Linq;
using System.ComponentModel;

namespace Deephaven_Intranet_Test
{
    public partial class Download2 : Page
    {
        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
        string rootDir = new DirectoryInfo(ConfigurationManager.AppSettings["TestFolderLoc"]).ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Directory.SetCurrentDirectory(Server.MapPath(rootDir));
                string testDir = Directory.GetCurrentDirectory();
                WalkDirectoryTree(rootDir);
            }
        }

        public  void WalkDirectoryTree(string root)
        {
            string[] files = null;
            //DirectoryInfo[] subDirs = null;
            List<string> itemList = new List<string>();
            BindingList<MyList> Categories = new BindingList<MyList>();

            // First, get all the files and folders directly under this folder
            try
            {
                //files = root.GetFiles("*.*");
                files = Directory.GetFileSystemEntries(Server.MapPath(root.ToString()), "*", SearchOption.TopDirectoryOnly);
               
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the error message to browser console
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                // This code just writes out the error message to browser console
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (string fi in files)
                {
                    
                    //truncate file path to show file name and add it to the list
                    Categories.Add(new MyList(fi) { Text = fi.Remove(0, fi.LastIndexOf(Path.DirectorySeparatorChar) + 1) } );
                    
                }

                //here bind data to gridview               
                //GridView2.DataSource = Categories.Select(x => new { Value = x }).ToList();
                //GridView2.DataSource = Categories[0].Text.ToString();
                GridView2.DataSource = Categories;
                GridView2.DataBind();

                //GridView2.DataSource = itemList.Select(x => new { Value = x }).ToList();
                // GridView2.DataSource = itemList.ConvertAll(x => new { Value = x });
                // GridView2.DataSource = itemList[1];
                //GridView2.DataSource = files;
                //GridView2.DataBind();
            }
            else
            {
                //else no files in this dir! display msg on label
            }
        }
        //method to download a coresponding file or open a folder
        public void DownloadFile(object sender, EventArgs e)
        {
            string file = (sender as LinkButton).CommandArgument;
            DirectoryInfo path = new DirectoryInfo(file);
            string path3 = Path.GetDirectoryName(Server.MapPath(path.ToString()));
            //string path = null;
            Directory.SetCurrentDirectory(Server.MapPath(path3));
            string path2 = Directory.GetCurrentDirectory();

            if (file.Contains("."))
            {
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + file);
                Response.WriteFile(file);
                Response.End();
            }
            else
            {
                //CurrentDir += file;
                
                WalkDirectoryTree(path2);

            }
        }
        // method to delete list items
        protected void DeleteFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            File.Delete(filePath);
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        // button to take user bk to root folder
        public void HomeBtn(object sender, EventArgs e)
        {
            WalkDirectoryTree(rootDir);
        }
        //stackoverflow wrk around to bind to gridview
        public class StringValue
        {
            public StringValue(string s)
            {
                Value = s;
            }
            public string Value { get; set; }
        }
        //my workaround to bind gridview
        public class MyList
        {
            public string Itemname;

            public MyList(string _ListItem)
            {
                Text = _ListItem;
            }
            public string Text
            {
                get { return Itemname; }
                set { Itemname = value; }
            }
        }


    }
}