﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Clinic.master" AutoEventWireup="true"
    CodeFile="CreateReligion.aspx.cs" Inherits="Admin_CreateReligion" %>

<asp:Content ID="Content4" ContentPlaceHolderID="maincontent" runat="Server">
    <style type="text/css">
        .uppercase
        {
            text-transform: uppercase;
        }
        .cpHeader
        {
            color: white;
            background-color: #336666;
            font: bold 11px auto;
            font-size: 12px;
            width: 150px;
            height: 14px;
            padding: 5px;
        }
        .Body
        {
            background-color: #DCE4F9;
            font: normal 11px auto Verdana, Arial;
            border: 1px gray;
            padding: 5px;
        }
        .style3
        {
            width: 83px;
        }
    </style>
    <table width="100%">
        <tr>
            <td align="center" style="width: 100%" class="cpHeader">
                <asp:Label ID="Label23" runat="server" CssClass="LabelBold" Text="Religion"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="left" class="cpHeader" colspan="2">
                <asp:Label ID="Label3" runat="server" CssClass="LabelBold" Text="Religion Details"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Label ID="ErrMsg" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
    <table width="100%">
        <tr>
            <td>
                <asp:GridView ID="GvReligionMaster" runat="server" CellPadding="4" ForeColor="#333333"
                    AutoGenerateColumns="false" GridLines="None" Width="100%" AllowPaging="True"
                    DataKeyNames="ReligionId" OnPageIndexChanged="GvReligionMaster_PageIndexChanged"
                    OnPageIndexChanging="GvReligionMaster_PageIndexChanging">
                    <RowStyle BackColor="#EFF3FB" />
                    <FooterStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" 
                        HorizontalAlign="Left" />
                    <EditRowStyle BackColor="#336666" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkname" runat="server" Text="Select" OnClick="lnkname_OnClick"
                                    CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ReligionCode" HeaderText="Religion Code" ItemStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="ReligionName" HeaderText="Religion Name" ItemStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="IsActive" HeaderText="Is Active" ItemStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="left" class="cpHeader">
                <asp:Label ID="Label2" runat="server" CssClass="LabelBold" Text="Religion Maintenance"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%" class="Body">
        <tr>
            <td class="style3">
                Religion Code <span style="color: rgb(255, 0, 0)">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtReligionCode" runat="server" Width="181px" AutoPostBack="True"
                    OnTextChanged="txtReligionCode_TextChanged" CssClass="uppercase"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Religion Name <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtReligionName" runat="server" Width="181px" CssClass="uppercase"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblIsActive" runat="server" Text="In Active"></asp:Label>
            </td>
            <td align="char">
                <asp:CheckBox ID="chkIsActive" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;
            </td>
            <td align="char">
                &nbsp;
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                &nbsp;<asp:Button ID="btnClear" runat="server" Text="Clear" Width="55px" OnClick="btnClear_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
                <asp:HiddenField ID="hdnReligionId" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
