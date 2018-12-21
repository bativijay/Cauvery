<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Clinic.master"
    CodeFile="PaymentReceiptReport.aspx.cs" Inherits="Transactions_PaymentReceiptReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        .style19
        {
            width: 22px;
        }
        .style20
        {
            width: 25px;
        }
        .style21
        {
            width: 146px;
        }
        .style22
        {
            width: 145px;
        }
        .style23
        {}
        .style24
        {
            width: 50px;
        }
    </style>

    <script type="text/javascript" language="javascript">


        function ValidateText(i) {
            if (i.value.length > 0) {
                i.value = i.value.replace(/[^\d,]+/g, '');
                //i.value = i.value.replace(/^(?:\d+(?:,|$))+$/, '');

            }
        }

        function popup(pageURL, title, popupWidth, popupHeight) {
            var left = (screen.width / 2) - (popupWidth / 2);
            var top = (screen.height / 2) - (popupHeight / 2);
            var targetPop = window.open(pageURL, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=YES, resizable=YES, copyhistory=no, width=' + popupWidth + ', height=' + popupHeight + ', top=' + top + ', left=' + left);
        }
        function OpenPopup(url) {
 
            var width = 840;
            var height = 760;
            var left = (screen.width - width) / 2;
            var top = (screen.height - height) / 2;
            var params = 'width=' + width + ', height=' + height;
            params += ', top=' + top + ', left=' + left;
            params += ', directories=no';
            params += ', location=no';
            params += ', menubar=no';
            params += ', resizable=yes';
            params += ', scrollbars=yes';
            params += ', status=yes';
            params += ', toolbar=no';
            newwin = window.open(url, 'windowname5', params);
            if (window.focus) { newwin.focus() }
        }

        function GetSelectedRow(lnk) {

            var row = lnk.parentNode.parentNode;
            var rowIndex = row.rowIndex - 1;
            alert("RowIndex: " + rowIndex);
            return false;
        }

        function PositionPopup(url) {

            var ResourceId = document.getElementById("txtResourceId");

            var width = 840;
            var height = 760;
            var left = (screen.width - width) / 2;
            var top = (screen.height - height) / 2;
            var params = 'width=' + width + ', height=' + height;
            params += ', top=' + top + ', left=' + left;
            params += ', directories=no';
            params += ', location=no';
            params += ', menubar=no';
            params += ', resizable=yes';
            params += ', scrollbars=yes';
            params += ', status=yes';
            params += ', toolbar=no';
            newwin = window.open(url + '&uniqueid=' + ResourceId.value, 'windowname5', params);
            if (window.focus) { newwin.focus() }
        }             
        
    </script>

    <table width="100%">
        <tr>
            <td align="center" colspan="2" style="width: 100%" class="cpHeader">
                <asp:Label ID="Label23" runat="server" CssClass="LabelBold" Text="Daily Collection"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Label ID="ErrMsg" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td class="style23">
                From Date <span style="color: rgb(255, 0, 0)">*</span>
            </td>
            <td class="style22">
                <asp:TextBox ID="txtFromDate" runat="server" Width="140px" Enabled="false"></asp:TextBox>
                <cc1:CalendarExtender ID="DOBCE" TargetControlID="txtFromDate" PopupButtonID="FromIB"
                    Format="dd/MM/yyyy" runat="server">
                </cc1:CalendarExtender>
            </td>
            <td class="style19">
                <asp:ImageButton ID="FromIB" runat="server" ImageUrl="~/Images/Calendar.png" Height="15px"
                    ImageAlign="Middle" Width="15px" />
            </td>
            <td class="style24">
                To Date <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td class="style21">
                <asp:TextBox ID="txtToDate" runat="server" Width="140px" Enabled="false"></asp:TextBox>
                <cc1:CalendarExtender ID="txtToDate_CalendarExtender" TargetControlID="txtToDate"
                    PopupButtonID="ToIB" Format="dd/MM/yyyy" runat="server">
                </cc1:CalendarExtender>
            </td>
            <td class="style20">
                <asp:ImageButton ID="ToIB" runat="server" ImageUrl="~/Images/Calendar.png" Height="15px"
                    ImageAlign="Middle" Width="15px" />
            </td>
            <td>
                Academic Year <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlAcedamic" runat="server" Height="21px" Width="170px" AutoPostBack="True"
                    Enabled="False" style="margin-left: 5px; margin-right: 5px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style23" colspan="9">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style23" colspan="9">
                <asp:Button ID="btnGenerateReport" runat="server" Text="Generate Report" OnClick="btnGenerateReport_Click"
                    Width="106px" />
            </td>
        </tr>
    </table>
</asp:Content>
