<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Clinic.master" AutoEventWireup="true"
    CodeFile="DivisionAllocation.aspx.cs" Inherits="Transactions_FeeMapping" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        }
        .style4
        {
        }
        .style5
        {
            width: 88px;
        }
        .style6
        {
            height: 27px;
        }
        .style8
        {
            width: 59px;
        }
        .style10
        {
            width: 76px;
        }
    </style>
    <table width="100%">
        <tr>
            <td align="center" colspan="2" class="cpHeader">
                <asp:Label ID="Label23" runat="server" CssClass="LabelBold" Text="Admission Allocation"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Label ID="ErrMsg" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
    <table width="100%" class="Body">
        <tr>
            <td class="style5">
                Academic Year <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td class="style8">
                <asp:DropDownList ID="ddlStandard" runat="server" Height="21px" Width="180px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="style10">
                Standard
            </td>
            <td>
                <asp:DropDownList ID="ddlStandard0" runat="server" Height="21px" Width="180px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style6" align="center" colspan="4">
                <asp:Button ID="btnSave0" runat="server" Text="Get Students" Width="101px" />
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="4">
                <asp:GridView ID="GvFeeMaster" runat="server" CellPadding="4" ForeColor="#333333"
                    AutoGenerateColumns="False" GridLines="None" Width="100%" AllowPaging="True">
                    <RowStyle BackColor="#EFF3FB" />
                    <FooterStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <EditRowStyle BackColor="#336666" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlDivision" runat="server" Height="21px" Width="180px" AutoPostBack="True">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="AdmissionNo" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                        <asp:BoundField HeaderText="Student Name">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Standard Sought" />
                        <asp:BoundField HeaderText="Father Name" />
                        <asp:BoundField HeaderText="Sex" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style4" align="center" colspan="4">
                &nbsp; &nbsp;
                <asp:Button ID="btnSave" runat="server" Text="Save" />
                &nbsp;<asp:Button ID="btnClear" runat="server" Text="Clear" Width="55px" />
            </td>
        </tr>
    </table>
</asp:Content>
