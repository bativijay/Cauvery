<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Clinic.master"
    CodeFile="YearEnd.aspx.cs" Inherits="Transactions_YearEnd" %>

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
            width: 149px;
            margin-left: 80px;
        }
        .style4
        {
            width: 153px;
        }
        .style6
        {
            width: 159px;
        }
        .style7
        {
            width: 73px;
        }
        .style8
        {
            width: 257px;
        }
        .style9
        {
            width: 155px;
        }
        .ModalPopupBG
        {
            background-color: #666699;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }
        .HellowWorldPopup
        {
            min-width: 200px;
            min-height: 150px;
            background: white;
        }
        .style21
        {
            width: 95px;
        }
        .style22
        {
            width: 95px;
            height: 23px;
        }
        .style24
        {
            color: white;
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 12px;
            line-height: normal;
            font-family: auto;
            height: 14px;
            padding: 5px;
            background-color: #336666;
        }
        .style25
        {
        }
        .style26
        {
            width: 94px;
            height: 23px;
        }
    </style>
    <table border="0" style="width: 100%">
        <tr>
            <td align="center" class="cpHeader" style="width: 100%">
                <asp:Label ID="Label23" runat="server" CssClass="LabelBold" Text="Year End"></asp:Label>
            </td>
        </tr>
    </table>
    </br>
    <asp:Label ID="ErrMsg" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
    <table cellspacing="0">
        </table>
    </br>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                Current Academic Year
            </td>
            <td style="padding-left: 10px">
                <asp:DropDownList ID="ddlAcedamic" Enabled="false" runat="server" Height="21px" Width="140px">
                </asp:DropDownList>
            </td>
            <td style="padding-left: 10px">
                Start Date<span style="color: rgb(255, 0, 0)">&nbsp; *</span>
            </td>
            <td style="padding-left: 10px">
                <asp:UpdatePanel ID="Up1" runat="server" EnableViewState="true">
                    <ContentTemplate>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtDOB" runat="server" Width="92px" onchange="abc();" ReadOnly="true"></asp:TextBox>
                                    <cc1:CalendarExtender ID="DOBCE" TargetControlID="txtDOB" PopupButtonID="DOBIB" Format="dd/MM/yyyy"
                                        Enabled="false" runat="server">
                                    </cc1:CalendarExtender>
                                </td>
                                <td>
                                    <asp:ImageButton ID="DOBIB" runat="server" ImageUrl="~/Images/Calendar.png" Height="15px"
                                        Enabled="false" ImageAlign="Middle" Width="15px" />
                                    <asp:CompareValidator ID="dateValidator" runat="server" Type="Date" Operator="DataTypeCheck"
                                        Display="Dynamic" ControlToValidate="txtDOB" ErrorMessage="Please enter a valid date.">
                                    </asp:CompareValidator>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="padding-left: 10px">
                End Date<span style="color: rgb(255, 0, 0)">&nbsp; *</span>
            </td>
            <td style="padding-left: 10px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="true">
                    <ContentTemplate>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="EndDateTextBox" runat="server" Width="92px" onchange="abc();" ReadOnly="true"></asp:TextBox>
                                    <cc1:CalendarExtender ID="EndDateCalendarExtender" TargetControlID="EndDateTextBox"
                                        Enabled="false" PopupButtonID="EndDateImageButton" Format="dd/MM/yyyy" runat="server">
                                    </cc1:CalendarExtender>
                                </td>
                                <td>
                                    <asp:ImageButton ID="EndDateImageButton" runat="server" ImageUrl="~/Images/Calendar.png"
                                        Enabled="false" Height="15px" ImageAlign="Middle" Width="15px" />
                                    <asp:CompareValidator ID="EndDateCompareValidator" runat="server" Type="Date" Operator="DataTypeCheck"
                                        Display="Dynamic" ControlToValidate="EndDateTextBox" ErrorMessage="Please enter a valid date.">
                                    </asp:CompareValidator>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </br>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="BtnSave" runat="server" Height="18px" Text="Save" OnClick="BtnSave_OnClick" />
            </td>
        </tr>
    </table>
</asp:Content>
