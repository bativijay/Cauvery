<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" MasterPageFile="~/Master/ClinicHome.master"
    Inherits="Login_LoginPage" %>

<asp:Content ID="Content3" ContentPlaceHolderID="maincontent" runat="server">
    <table align="center" style="width: 100%; height: 540px">
        <tr>
            <td align="center" bgcolor="#336666">
                <asp:Label ID="Label10" runat="server" CssClass="LabelBold" Text="Log In"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" bgcolor="#DCE4F9">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr bgcolor="#336666">
                        <td width="20%" height="19" align="left" valign="bottom">
                            &nbsp;
                        </td>
                        <td width="59%" bgcolor="#336666">
                            &nbsp;
                        </td>
                        <td width="21%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%">
                            <table width="100%" height="325" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                                <tr bgcolor="#F8FFEC">
                                    <td height="92" valign="bottom" bgcolor="#F8FFEC">
                                        <div align="left">
                                            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
                                                width="150" height="80">
                                                <param name="movie" value="../images/xx.swf">
                                                <param name="quality" value="high">
                                                <embed src="../images/xx.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                                    type="application/x-shockwave-flash" width="150" height="80"></embed></object>
                                        </div>
                                    </td>
                                    <td rowspan="4" align="right" valign="middle" bgcolor="#F8FFEC">
                                        <img src="../images/bd.gif">
                                    </td>
                                </tr>
                                <tr bgcolor="#F8FFEC">
                                    <td height="86" valign="bottom" bgcolor="#F8FFEC">
                                        <div align="left">
                                            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
                                                width="150" height="80">
                                                <param name="movie" value="../images/faci.swf">
                                                <param name="quality" value="high">
                                                <embed src="../images/faci.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                                    type="application/x-shockwave-flash" width="150" height="80"></embed></object>
                                        </div>
                                    </td>
                                </tr>
                                <tr bgcolor="#F8FFEC">
                                    <td height="88" valign="bottom" bgcolor="#F8FFEC">
                                        <div align="left">
                                            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
                                                width="150" height="80">
                                                <param name="movie" value="../images/add.swf">
                                                <param name="quality" value="high">
                                                <embed src="../images/add.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                                    type="application/x-shockwave-flash" width="150" height="80"></embed></object>
                                        </div>
                                    </td>
                                </tr>
                                <tr bgcolor="#F8FFEC">
                                    <td height="19" valign="bottom" bgcolor="#F8FFEC">
                                        &nbsp;
                                        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
                                            width="125" height="125">
                                            <param name="movie" value="../images/motto.swf">
                                            <param name="quality" value="high">
                                            <embed src="../images/motto.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                                type="application/x-shockwave-flash" width="125" height="125"></embed></object>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 50%">
                            <table border="0" width="100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="User Name" CssClass="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtusrname" runat="server" Width="159px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Password" CssClass="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtpwd" runat="server" Width="159px" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" valign="bottom">
                                        <asp:Button ID="Button1" runat="server" Text="Log In" BorderColor="Black" BorderStyle="Solid"
                                            Font-Names="Verdana" OnClick="Button1_Click" />
                                        <asp:Button ID="Button2" runat="server" Text="Cancel" Font-Names="Verdana" Font-Overline="False"
                                            ForeColor="Black" BorderStyle="Solid" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr bgcolor="#336666">
                        <td width="20%" height="19" align="left" valign="bottom">
                            &nbsp;
                        </td>
                        <td width="59%" bgcolor="#336666">
                            &nbsp;
                        </td>
                        <td width="21%" bgcolor="#336666">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
