<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Clinic.master" AutoEventWireup="true"
    CodeFile="CreateCast.aspx.cs" Inherits="Admin_CreateCast" %>

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
            font-size: 12px;
            height: 14px;
            padding: 5px;
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            line-height: normal;
            font-family: auto;
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
            width: 80px;
        }
    </style>
    <table width="100%" border="1">
        <tr>
            <td align="center" class="cpHeader" style="width: 100%" dir="ltr">
                <asp:Label ID="Label23" runat="server" CssClass="LabelBold" Text="Cast"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="left" class="cpHeader" colspan="1">
                <asp:Label ID="Label3" runat="server" CssClass="LabelBold" Text="Cast Details"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Label ID="ErrMsg" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
    <table width="100%">
        <tr>
            <td>
                <asp:GridView ID="GvCastMaster" runat="server" CellPadding="4" ForeColor="#333333"
                    AutoGenerateColumns="False" GridLines="None" Width="100%" AllowPaging="True"
                    DataKeyNames="CastId" OnPageIndexChanged="GvCastMaster_PageIndexChanged" 
                    OnPageIndexChanging="GvCastMaster_PageIndexChanging">
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
                                <asp:LinkButton ID="lnkname" runat="server" Text="Select" OnClick="lnkname_OnClick"
                                    CommandName="Select" CommandArgument='<%# Eval("CastCode" )%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CastCode" HeaderText="Cast Code" ItemStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CastName" HeaderText="Cast Name" ItemStyle-HorizontalAlign="Left">
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
                <asp:Label ID="Label2" runat="server" CssClass="LabelBold" Text="Cast Maintenance"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%" class="Body">
        <tr>
            <td class="style3">
                Cast Code <span style="color: rgb(255, 0, 0)">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtCastCode" runat="server" Width="181px" AutoPostBack="True" OnTextChanged="txtCastCode_TextChanged"
                    CssClass="uppercase"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Cast Name <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtCastName" runat="server" Width="181px" CssClass="uppercase"></asp:TextBox>
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
                <asp:HiddenField ID="hdnCastId" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
