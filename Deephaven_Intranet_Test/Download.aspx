<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Download.aspx.cs" Inherits="Deephaven_Intranet_Test.Download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

    <h2>Documents</h2>
            <p>
                Select a document to download.
            </p>
            <%--<p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>--%>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="HomeBtn" />
            <!--grid control to view documents in repository -->
            <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="false" EmptyDataText = "No files uploaded"
                GridLines="None"
                AllowPaging="true"
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt">
                <Columns>
                    <asp:BoundField DataField="Text" HeaderText="File Name" />
                    <asp:TemplateField HeaderText="Download">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDownload" Text = "Open" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
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
