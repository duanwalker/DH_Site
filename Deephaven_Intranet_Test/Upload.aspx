<%@ Page Title="Upload Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="Deephaven_Intranet_Test.Upload" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
       <h4>Select a file to upload:</h4>

       <asp:FileUpload id="FileUpload1"                 
           runat="server" AccessKey>
       </asp:FileUpload>

       <br /><br />

       <asp:Button id="UploadButton" 
           Text="Upload File"
           OnClick="UploadButton_Click"
           runat="server"
           style="color:black">
       </asp:Button>    

       <hr />

       <asp:Label id="UploadStatusLabel"
           runat="server">
       </asp:Label>        
    </div>
   
    

</asp:Content>
