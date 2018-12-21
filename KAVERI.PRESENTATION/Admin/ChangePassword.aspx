<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" MasterPageFile="~/Master/Clinic.master"
    Inherits="Login_ChangePassword" %>

<asp:Content ID="Content4" ContentPlaceHolderID="maincontent" runat="server">
    <style type="text/css">
        .Header
        {
            color: white;
            background-color: #336666;
            font: bold 11px auto;
            font-size: 15px;
            padding: 5px;
        }
        .Body
        {
            background-color: #DCE4F9;
            font: normal 11px auto Verdana, Arial;
            border: 1px gray;
            padding: 5px;
        }
        .style4
        {
            width: 144px;
        }
    </style>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" class="Header">
                <asp:Label ID="Label1" runat="server" CssClass="Header" Text="Change Password"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="Body" align="center">
                <table border="0" width="100%">
                    <tr>
                        <td class="style4" align="left" colspan="2">
                            <asp:Label ID="ErrMsg" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="Left" class="style4">
                            <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Current Password"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtpwd" runat="server" Width="175px" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="Left" class="style4">
                            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="New Password"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtnewpwd" runat="server" Width="176px" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="Left" class="style4">
                            <asp:Label ID="Label4" runat="server" CssClass="Label" Text="Confirm Password"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtreenterpwd" runat="server" Width="175px" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" />
                            <asp:Button ID="BtnClear" runat="server" Text="Clear" 
                                onclick="BtnClear_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
