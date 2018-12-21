<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu.ascx.cs" Inherits="User_Control_LwftMenu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    a:link
    {
        color: MenuText;
    }
    .cpHeader
    {
        color: white;
        background-color: #336666;
        font: bold 11px auto;
        font-size: 12px;
        width: 150px;
        height: 15px;
        padding: 5px;
    }
    .cpBody
    {
        background-color: #DCE4F9;
        font: normal 11px auto Verdana, Arial;
        border: 1px gray;
        width: 150px;
        height: 57px;
        padding: 5px;
    }
    
    
    .cpBodyAdmin
    {
        background-color: #DCE4F9;
        font: normal 11px auto Verdana, Arial;
        border: 1px gray;
        width: 150px;
        height: 170px;
        padding: 5px;
    }
    .cpBodyTrans
    {
        background-color: #DCE4F9;
        font: normal 11px auto Verdana, Arial;
        border: 1px gray;
        width: 150px;
        height: 190px;
        padding: 5px;
    }
    .style1
    {
        height: 451px;
    }
</style>
<div>
    <table style="border: solid 1px Black">
        <tr>
            <td class="style1">
                <asp:Panel ID="AdminPanel" runat="server" Height="520px">
                    <asp:Panel ID="pAdminHeader" runat="server" CssClass="cpHeader">
                        <asp:Label ID="lblText" runat="server" Text="Admin" />
                    </asp:Panel>
                    <asp:Panel ID="pAdminBody" runat="server" CssClass="cpBodyAdmin">
                        <asp:GridView ID="MasterGv" runat="server" AutoGenerateColumns="false" Width="100%"
                            BorderStyle="None" ShowFooter="false" ShowHeader="false" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="ImageAdminID" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Image ID="ImageAdmin" runat="server" ImageUrl='<%# Eval("ImageUrl")%>' Height="20px"
                                            Width="20px"></asp:Image>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="HyperLinkAdminID" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLinkAdmin" runat="server" Text='<%# Eval("MenuName")%>' NavigateUrl='<%# Eval("MenuUrl")%>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <asp:Panel ID="TransactionHeader" runat="server" CssClass="cpHeader">
                        <asp:Label ID="TransactionLabel" runat="server" Text="Transactions" />
                    </asp:Panel>
                    <asp:Panel ID="TransactionBody" runat="server" CssClass="cpBodyTrans">
                        <asp:GridView ID="TransactionGV" runat="server" AutoGenerateColumns="false" Width="100%"
                            BorderStyle="None" ShowFooter="false" ShowHeader="false" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="ImageAdminID" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Image ID="ImageAdmin" runat="server" ImageUrl='<%# Eval("ImageUrl")%>' Height="20px"
                                            Width="20px"></asp:Image>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="HyperLinkAdminID" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLinkAdmin" runat="server" Text='<%# Eval("MenuName")%>' NavigateUrl='<%# Eval("MenuUrl")%>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <asp:Panel ID="ReportsHeader" runat="server" CssClass="cpHeader">
                        <asp:Label ID="lblReports" runat="server" Text="Reports" />
                    </asp:Panel>
                    <asp:Panel ID="ReportsBody" runat="server" CssClass="cpBody">
                        <asp:GridView ID="ReportsGV" BorderWidth="0px" runat="server" AutoGenerateColumns="false"
                            Width="100%" BorderStyle="None" ShowFooter="false" ShowHeader="false" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="ImageReportID">
                                    <ItemTemplate>
                                        <asp:Image ID="ImageReport" runat="server" ImageUrl='<%# Eval("ImageUrl")%>' Height="20px"
                                            Width="20px"></asp:Image>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="HyperLinkReportsID">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLinkReports" runat="server" Text='<%# Eval("MenuName")%>'
                                            NavigateUrl='<%# Eval("MenuUrl")%>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <%--<asp:Panel ID="Panel1" runat="server" CssClass="cpHeader">
                                <asp:HyperLink ID="HyperLinkLogout" runat="server" ForeColor="Red" Text="Logout"
                                    NavigateUrl="~/Login/LogoutPage.aspx"></asp:HyperLink>
                            </asp:Panel>--%>
                </asp:Panel>
            </td>
        </tr>
    </table>
</div>
