<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Clinic.master"
    CodeFile="DailyCollectionReport.aspx.cs" Inherits="Transactions_DailyCollectionReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="maincontent" runat="Server">
    <style type="text/css">
        .uppercase {
            text-transform: uppercase;
        }

        .cpHeader {
            color: white;
            background-color: #336666;
            font: bold 11px auto;
            font-size: 12px;
            width: 150px;
            height: 14px;
            padding: 5px;
        }

        .Body {
            background-color: #DCE4F9;
            font: normal 11px auto Verdana, Arial;
            border: 1px gray;
            padding: 5px;
        }

        .style19 {
            width: 22px;
        }

        .style20 {
            width: 25px;
        }

        .style21 {
            width: 146px;
        }

        .style22 {
            width: 145px;
        }

        .style23 {
        }

        .style24 {
            width: 50px;
        }

        .style25 {
            height: 32px;
        }

        .style26 {
            width: 145px;
            height: 32px;
        }

        .style28 {
            width: 146px;
            height: 32px;
        }

        .style29 {
            height: 30px;
        }

        .style30 {
            width: 145px;
            height: 30px;
        }

        .style31 {
            width: 75px;
            height: 30px;
        }

        .style32 {
            width: 146px;
            height: 30px;
        }

        .style33 {
            width: 56px;
            height: 32px;
        }

        .style12 {
            width: 87px;
        }

        .style11 {
            width: 189px;
            margin-left: 40px;
        }

        .style37 {
            width: 197px;
            margin-left: 40px;
            height: 28px;
        }

        .style38 {
            width: 80px;
            height: 22px;
        }

        .style41 {
            width: 91px;
            margin-left: 40px;
            height: 28px;
        }

        .style42 {
            width: 91px;
            height: 22px;
        }

        .style43 {
            width: 80px;
        }

        .style44 {
            width: 80px;
            height: 28px;
        }

        .style45 {
            height: 28px;
        }

        .style46 {
            height: 22px;
        }

        .style47 {
            width: 87px;
            height: 22px;
        }

        .style48 {
            width: 75px;
            height: 32px;
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
                <asp:Label ID="Label1" runat="server" CssClass="LabelBold" Text="Reports"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="RBDailyCollection" runat="server" Checked="True" GroupName="Reports"
                    Text="Daily Collection" AutoPostBack="True" OnCheckedChanged="RBDailyCollection_CheckedChanged" />
                <asp:RadioButton ID="RBPayReceipt" runat="server" GroupName="Reports" Text="Payment Receipt"
                    AutoPostBack="True" OnCheckedChanged="RBPayReceipt_CheckedChanged" />
                <asp:RadioButton ID="RBRegister" runat="server" GroupName="Reports" Text="School Register"
                    AutoPostBack="True" OnCheckedChanged="RBRegister_CheckedChanged" />
                <asp:RadioButton ID="RBStandardwise" runat="server" GroupName="Reports" Text="Standardwise Student Register"
                    AutoPostBack="True" OnCheckedChanged="RBStandardwise_CheckedChanged" />
                &nbsp;
                <asp:RadioButton ID="RBPending" runat="server" GroupName="Reports" Text="Pending Collection"
                    AutoPostBack="True" OnCheckedChanged="RBPending_CheckedChanged" />
            </td>
        </tr>
    </table>
    <asp:Label ID="ErrMsg" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
    <div id="DailyCollection" runat="server" visible="false">
        <table width="100%">
            <tr>
                <td align="center" colspan="2" style="width: 100%" class="cpHeader">
                    <asp:Label ID="lblHeader" runat="server" CssClass="LabelBold" Text="Daily Collection"></asp:Label>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="style23">From Date <span style="color: rgb(255, 0, 0)">*</span>
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
                <td class="style24">To Date <span style="color: rgb(255, 0, 0);">*</span>
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
                <td>Academic Year <span style="color: rgb(255, 0, 0);">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAcedamic" runat="server" Height="21px" Width="170px"
                        AutoPostBack="True" Style="margin-left: 5px; margin-right: 5px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;
                    <asp:CheckBox ID="ChkHeadwise" runat="server" Text="Headwise Summary" />
                </td>
            </tr>
            <tr>
                <td align="center" class="style23" colspan="9">&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" class="style23" colspan="9">
                    <asp:Button ID="btnGenerateReport" runat="server" Text="Generate Report" OnClick="btnGenerateReport_Click"
                        Width="106px" />
                </td>
            </tr>
        </table>
    </div>
    <div id="PendingDiv" runat="server" visible="false">
        <table width="100%">
            <tr>
                <td align="center" colspan="2" style="width: 100%" class="cpHeader">
                    <asp:Label ID="Label5" runat="server" CssClass="LabelBold" Text="Pending Collection"></asp:Label>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="style23">&nbsp;</td>
                <td class="style33">Standard <span style="color: rgb(255, 0, 0);">*</span>
                </td>
                <td class="style28">
                    <asp:DropDownList ID="ddlPendingStandard" runat="server" Height="21px"
                        Width="170px" AutoPostBack="True"
                        Style="margin-left: 5px; margin-right: 5px">
                    </asp:DropDownList>
                </td>
                <td class="style24">&nbsp;</td>
                <td class="style21">&nbsp;</td>
                <td class="style20">&nbsp;</td>
                <td>Academic Year <span style="color: rgb(255, 0, 0);">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPendingAcademic" runat="server" Height="21px"
                        Width="170px" AutoPostBack="True"
                        Style="margin-left: 5px; margin-right: 5px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" class="style23" colspan="9">&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" class="style23" colspan="9">
                    <asp:Button ID="Button2" runat="server" Text="Generate Report" OnClick="btnGenerateReport_Click"
                        Width="106px" />
                </td>
            </tr>
        </table>
    </div>
    <div id="PaymentReceipt" runat="server" visible="false">
        <table width="100%">
            <tr>
                <td align="center" colspan="2" style="width: 100%" class="cpHeader">
                    <asp:Label ID="Label2" runat="server" CssClass="LabelBold" Text="Payment Receipt"></asp:Label>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="style38">Registration No <span style="color: rgb(255, 0, 0)">*</span>
                </td>
                <td class="style46">
                    <asp:TextBox ID="txtRegNoForReceipt" runat="server" Width="132px" ReadOnly="True"></asp:TextBox>
                    <asp:LinkButton ID="lbtnReceiptSearch" runat="server" OnClick="lbtnRegionSearch_Click">
                <img alt="Search" src="../Images/Search.gif"  style="border:none"/>
                    </asp:LinkButton>
                </td>
                <td class="style42">Academic Year <span style="color: rgb(255, 0, 0);">*</span>
                </td>
                <td class="style47">
                    <asp:UpdatePanel ID="up1" UpdateMode="Always" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="PRddlAcademicYear" runat="server" Height="21px" Width="134px"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:CheckBox ID="AdhocCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="AdhocCheckBox_CheckedChanged" Text="Adhoc" />
                </td>
            </tr>
            <tr>
                <td class="style44">Student Name
                </td>
                <td class="style45">
                    <asp:TextBox ID="txtStudentName" runat="server" Width="132px" ReadOnly="True" Enabled="False"></asp:TextBox>
                </td>
                <td align="char" class="style41">Father Name
                </td>
                <td align="char" class="style37">
                    <asp:TextBox ID="txtFatherName" runat="server" Width="133px" ReadOnly="True" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style43">&nbsp;
                </td>
                <td class="style12">&nbsp;
                </td>
                <td align="char" class="style11" colspan="2">&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" class="style23" colspan="4">&nbsp;
                    <asp:Button ID="PRbtnGenerate" runat="server" Text="Get Details" OnClick="PRbtnGenerate_Click"
                        Width="106px" />
                </td>
            </tr>
            <tr>
                <td align="center" class="style23" colspan="4">&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" class="style23" colspan="4">
                    <asp:GridView ID="GVReceipt" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False"
                        GridLines="None" Width="100%" AllowPaging="True" DataKeyNames="ReportFormatId">
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                            <asp:TemplateField HeaderText="Receipt No">
                                <ItemTemplate>
                                    <asp:LinkButton ID="ReceiptNo" ToolTip="Click here tp re-Print receipt" runat="server"
                                        Text='<%# Eval("ReceiptNo") %>' OnClick="chkSelect_OnClick" />
                                    <%--<asp:HyperLinkField DataTextField="ReceiptNo" HeaderText="ReceiptNo" 
                                Text="ReceiptNo" />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CreatedOn" HeaderText="Receipt Date" />
                            <asp:BoundField DataField="PayType" HeaderText="Payment Type" />
                            <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                            <asp:BoundField DataField="FatherName" HeaderText="Father Name" />
                            <asp:BoundField DataField="DOB" HeaderText="DOB" />
                            <asp:BoundField DataField="TotalAmountPaid" DataFormatString="{0:0.00}" HeaderText="Amount Paid" />
                        </Columns>
                        <FooterStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        <EditRowStyle BackColor="#336666" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="SRDiv" runat="server" visible="false">
        <table width="100%">
            <tr>
                <td align="center" colspan="2" style="width: 100%" class="cpHeader">
                    <asp:Label ID="Label3" runat="server" CssClass="LabelBold" Text="School Register"></asp:Label>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="style25">Gender <span style="color: rgb(255, 0, 0)">*</span>
                </td>
                <td class="style26">
                    <asp:DropDownList ID="ddlGender" runat="server" Height="21px" Width="170px" AutoPostBack="True"
                        Style="margin-left: 5px; margin-right: 5px">
                    </asp:DropDownList>
                </td>
                <td class="style48">Age <span style="color: rgb(255, 0, 0);">*</span>
                </td>
                <td class="style28">
                    <asp:DropDownList ID="ddlAge" runat="server" Height="21px" Width="170px" AutoPostBack="True"
                        Style="margin-left: 5px; margin-right: 5px">
                    </asp:DropDownList>
                </td>
                <td class="style25">Academic Year <span style="color: rgb(255, 0, 0);">*</span>
                </td>
                <td class="style25">
                    <asp:DropDownList ID="ddlSRAcademicYear" runat="server" Height="21px" Width="170px"
                        AutoPostBack="True" Style="margin-left: 5px; margin-right: 5px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style29">Caste
                </td>
                <td class="style30">
                    <asp:DropDownList ID="ddlCaste" runat="server" Height="21px" Width="170px" AutoPostBack="True"
                        Style="margin-left: 5px; margin-right: 5px">
                    </asp:DropDownList>
                </td>
                <td class="style31">Belong To</td>
                <td class="style32">
                    <asp:DropDownList ID="ddlBelongsTo" runat="server" Height="21px" Width="170px" AutoPostBack="True"
                        Style="margin-left: 5px; margin-right: 5px">
                    </asp:DropDownList>
                </td>
                <td class="style29"></td>
                <td class="style29"></td>
            </tr>
            <tr>
                <td align="center" class="style23" colspan="6">&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" class="style23" colspan="6">
                    <asp:Button ID="Button1" runat="server" Text="Generate Report" OnClick="btnGenerateReport_Click"
                        Width="106px" />
                </td>
            </tr>
        </table>
    </div>
    <div id="SWDiv" runat="server" visible="false">
        <table width="100%">
            <tr>
                <td align="center" colspan="2" style="width: 100%" class="cpHeader">
                    <asp:Label ID="Label4" runat="server" CssClass="LabelBold" Text="Standardwise Student Register"></asp:Label>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="style33">Standard <span style="color: rgb(255, 0, 0);">*</span>
                </td>
                <td class="style28">
                    <asp:DropDownList ID="ddlStandard" runat="server" Height="21px" Width="170px" AutoPostBack="True"
                        Style="margin-left: 5px; margin-right: 5px">
                    </asp:DropDownList>
                </td>
                <td class="style25">Academic Year <span style="color: rgb(255, 0, 0);">*</span>
                </td>
                <td class="style25">
                    <asp:DropDownList ID="ddlSWAcademicYear" runat="server" Height="21px" Width="170px"
                        AutoPostBack="True" Style="margin-left: 5px; margin-right: 5px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" class="style23" colspan="6">&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" class="style23" colspan="6">
                    <asp:Button ID="SWBtnGenerate" runat="server" Text="Generate Report" OnClick="btnGenerateReport_Click"
                        Width="106px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
