<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Clinic.master" AutoEventWireup="true"
    CodeFile="CreateUser.aspx.cs" Inherits="Admin_CreateUser" %>

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
            width: 275px;
        }
        .style5
        {
            width: 66px;
        }
        .style6
        {
            width: 71px;
        }
    </style>

    <script language="javascript" type="text/javascript">
function validate()
{
if(event.keyCode>=48 && event.KeyCode<=57)||(event.keyCode>=65 && event.KeyCode<=90)||(event.keyCode>=97 && event.KeyCode<=122)
event.returnValue=true;
else
event.returnValue=false;
}
    </script>

    <table width="100%">
        <tr>
            <td align="center" class="cpHeader">
                <asp:Label ID="Label23" runat="server" CssClass="LabelBold" Text="User"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="left" class="cpHeader" colspan="2">
                <asp:Label ID="Label3" runat="server" CssClass="LabelBold" Text="User Details"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Label ID="ErrMsg" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
    <table width="100%">
        <tr>
            <td>
                <asp:GridView ID="GvStandardMaster" runat="server" CellPadding="4" ForeColor="#333333"
                    AutoGenerateColumns="false" GridLines="None" Width="100%" AllowPaging="True"
                    DataKeyNames="Id,UserName,Password,Address,RoleName,GenderId" OnPageIndexChanged="GvStandardMaster_PageIndexChanged"
                    OnPageIndexChanging="GvStandardMaster_PageIndexChanging" OnRowCommand="GvStandardMaster_OnRowCommand">
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
                                    CommandName="Select" CommandArgument='<%# Eval("UserName" )%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" ItemStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Gender" HeaderText="Gender" ItemStyle-HorizontalAlign="Left">
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
                <asp:Label ID="Label2" runat="server" CssClass="LabelBold" Text="User Maintenance"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%" class="Body">
        <tr>
            <td class="style5">
                First Name <span style="color: rgb(255, 0, 0)">*</span>
            </td>
            <td class="style4">
                <asp:TextBox ID="txtFirstName" runat="server" Width="181px" CssClass="uppercase"></asp:TextBox>
            </td>
            <td class="style6">
                Last Name <span style="color: rgb(255, 0, 0)">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" Width="181px" CssClass="uppercase"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                User Name <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td align="char" class="style4">
                <asp:TextBox ID="txtUserName" runat="server" Width="181px" OnTextChanged="txtStandardCode_TextChanged"
                    onkeypress="validate" AutoPostBack="True" MaxLength="15"></asp:TextBox>
            </td>
            <td class="style6">
                E-Mail
            </td>
            <td align="char">
                <asp:TextBox ID="txtEmail" runat="server" Width="181px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Password<span style="color: rgb(255, 0, 0);"> *</span>
            </td>
            <td align="char" class="style4">
                <asp:TextBox ID="txtPassword" runat="server" Width="181px" TextMode="Password"></asp:TextBox>
            </td>
            <td class="style6">
                Gender
                <span style="color: rgb(255, 0, 0)">*</span>
            </td>
            <td align="char">
                <asp:DropDownList ID="ddlGender" runat="server" Height="21px" Width="184px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style5" valign="top">
                Address
            </td>
            <td align="char" class="style4">
                <asp:TextBox ID="txtAddress" runat="server" Width="180px" Height="65px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="style6">
                &nbsp;
            </td>
            <td align="char">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                Is Admin
            </td>
            <td align="char" class="style4">
                <asp:CheckBox ID="chkIsAdmin" runat="server" />
                &nbsp;
                <asp:CheckBox ID="chkIsActive" runat="server" Text="In Active" Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="style3" align="center" colspan="4">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="55px" OnClick="btnClear_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
                <asp:HiddenField ID="hdnStandardId" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
