<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="User_Control_Header" %>
<%--<table width="100%" height="60" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td height="59" bgcolor="#99CC33" align="left" valign="middle">
            
            <span style="color: rgb(255, 255, 255); font-family: 'Trebuchet MS', arial, sans-serif;
                font-size: 30px; font-style: normal; font-variant: normal; font-weight: normal;
                letter-spacing: normal; line-height: normal; orphans: auto; text-align: start;
                text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px;
                -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; display: inline !important;
                float: none;">Sumadhva Technologies</span>
        </td>
        <td height="59" bgcolor="#99CC33" align="center" valign="bottom">
            <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Label" Font-Names="Verdana"></asp:Label>
            <asp:HyperLink ID="HyperLinkLogout" runat="server" ForeColor="Red" Text="Logout"
                NavigateUrl="~/Login/LogoutPage.aspx"></asp:HyperLink>
        </td>
    </tr>
</table>--%>
<table width="100%" height="60" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td height="59" bgcolor="#99CC33" align="left">
            <img src="../Images/Logo_Caps.gif" width="50px" height="50px">
            <%--</td>
        <td height="59" bgcolor="#99CC33" align="center">--%>
            <img src="../Images/TCPSS.gif" height="59">
        </td>
        <td height="59" bgcolor="#99CC33" align="center" valign="bottom">
            <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Label" Font-Names="Verdana"></asp:Label>
            <asp:HyperLink ID="HyperLinkLogout" runat="server" ForeColor="Red" Text="Logout"
                NavigateUrl="~/Login/LogoutPage.aspx"></asp:HyperLink>
        </td>
    </tr>
</table>
<%--<table border="0" width="100%" bgcolor="#2554C7">
    <tr>
        <td align="center" bgcolor="#2554C7">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="White"
                Text=" Cauvery Public School, &lt;/br&gt;Mandya– 571402" 
                Font-Size="XX-Small"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right" bgcolor="#2554C7" valign="top">
            <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Label" Font-Names="Verdana"></asp:Label>
            <asp:HyperLink ID="HyperLinkLogout" runat="server" ForeColor="Red" Text="Logout"
                NavigateUrl="~/Login/LogoutPage.aspx"></asp:HyperLink>
        </td>
    </tr>
</table>--%>