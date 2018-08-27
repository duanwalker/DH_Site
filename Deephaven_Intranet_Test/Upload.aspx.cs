using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace Deephaven_Intranet_Test
{
    public partial class Upload : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;

            // Specify the path to save the uploaded file to.
            String savePath = Server.MapPath(ConfigurationManager.AppSettings["TestFolderLoc"]);

            // Before attempting to perform operations on the file, verify that the FileUpload 
            // control contains a file.
            if (FileUpload1.HasFile)
            {
                // Get the name of the file to upload.
                String fileName = FileUpload1.FileName;

                // Append the name of the file to upload to the path.
                savePath += fileName;

                //check for accepted file extensions
                String fileExtension = Path.GetExtension(FileUpload1.FileName).ToLower();
                String[] allowedExtensions =
                    {".gif", ".png", ".jpeg", ".jpg", ".doc" , ".docx" , ".xls" , ".xlsx" , ".txt" , ".pdf" , ".chm"};
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                    else
                    {
                        UploadStatusLabel.Text = "Invalid File Type";
                    }
                }

                // Check to see if file already exists. 
                // If not call the SaveAs method to save 
                // the uploaded file to the specified path.

                if (!File.Exists(savePath) && fileOK == true)
                {
                    FileUpload1.SaveAs(savePath);
                    // Notify the user of the name the file was saved under.
                    UploadStatusLabel.Text = "Your file was saved as " + fileName;
                }
                else
                {
                    UploadStatusLabel.Text = "File with the name " + fileName +" already exists";
                }                
            }
            else
            {
                // Notify the user that a file was not uploaded.
                UploadStatusLabel.Text = "You did not specify a file to upload.";
            }

        }
    }
}