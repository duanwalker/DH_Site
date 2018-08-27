using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Security.AccessControl;
using System.Runtime.Caching;
using System.Web;

namespace Deephaven_Intranet_Test
{
    public partial class Download : Page
    {
        string path = "";
        public string CurrentDir { get; set; } = ConfigurationManager.AppSettings["TestFolderLoc"];
        public static string currentFolder = null;
        HttpCookie cookie = new HttpCookie(currentFolder);
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getFiles(CurrentDir);
            }
            
        }

        public void getFiles(string loc)
        {
                loc = ConfigurationManager.AppSettings["TestFolderLoc"];
                string[] entries = Directory.GetFileSystemEntries(Server.MapPath(loc), "*", SearchOption.TopDirectoryOnly);
                List<ListItem> dirItems = new List<ListItem>();

                foreach (string items in entries)
                {
                    //dirItems.Add(new ListItem(Path.GetDirectoryName(dir), "*", searchOption));
                    dirItems.Add(new ListItem(items.Remove(0, items.LastIndexOf(Path.DirectorySeparatorChar) + 1)));
                }
                GridView1.DataSource = dirItems;
                GridView1.DataBind();
            UpdateDir(loc);
        }            
        public void getFiles2(string loc)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();

            string[] entries = Directory.GetFileSystemEntries(Server.MapPath(loc), "*", SearchOption.TopDirectoryOnly);
            List<ListItem> dirItems = new List<ListItem>();

            foreach (string items in entries)
            {
                //dirItems.Add(new ListItem(Path.GetDirectoryName(dir), "*", searchOption));
                dirItems.Add(new ListItem(items.Remove(0, items.LastIndexOf(Path.DirectorySeparatorChar) + 1)));
            }
            GridView1.DataSource = dirItems;
            GridView1.DataBind();
        }
        protected void DownloadFile(object sender, EventArgs e)
        {
            string file = (sender as LinkButton).CommandArgument;
            //var path = Path.GetFullPath(file);

            if (file.Contains("."))
            {
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" +file);
                Response.WriteFile(path);
                Response.End();
            }
            else
            {
                //CurrentDir += file;
                UpdateDir(file);
               
            }
        }
        public void UpdateDir(string folder)
        {
            CurrentDir += folder;
            //var fullPath = Path.GetFullPath(folder);

           
            cookie.Value = CurrentDir;
            cookie.Expires = DateTime.MinValue;
            Response.Cookies.Add(cookie);

            if (Request.Cookies["currentFolder"] == null)
            {
                HttpCookie _cookie = Request.Cookies["currentFolder"];
                string cf = _cookie["currentFolder"][0].ToString();
                getFiles2(cf);
            }

            
        }
        protected void DeleteFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            File.Delete(filePath);
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        public void HomeBtn(object sender, EventArgs e)
        {
            getFiles(ConfigurationManager.AppSettings["TestFolderLoc"]);
        }
    }
}