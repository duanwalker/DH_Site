<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Download2.aspx.cs" Inherits="Deephaven_Intranet_Test.Download2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Documents</h2>
            <p>
                Select a document to download.
            </p>
            <%--<p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>--%>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="HomeBtn" />
            <!--grid control to view documents in repository -->
            <asp:GridView ID="GridView2" runat="server" 
                AutoGenerateColumns="true" EmptyDataText = "No files uploaded"
                GridLines="None"
                AllowPaging="false"
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt">
                <Columns>
                    <asp:BoundField DataField="Text" HeaderText="File Name"/>               
                    <asp:TemplateField HeaderText="Download">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDownload" Text = "Open" CommandArgument = '<%# Eval("Text") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
                            <%--<asp:LinkButton ID="lnkDownload" Text = "Open" runat="server" OnClick = "DownloadFile"></asp:LinkButton>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeleteFile" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
</asp:Content>
