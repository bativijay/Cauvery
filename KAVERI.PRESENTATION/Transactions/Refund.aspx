<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Clinic.master" AutoEventWireup="true"
    CodeFile="Refund.aspx.cs" Inherits="Transactions_Refund" %>

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
        .style13
        {
            width: 83px;
            margin-left: 80px;
        }
        .style6
        {
            width: 16%;
            margin-left: 80px;
        }
        .style19
        {
        }
        .style22
        {
            width: 106px;
        }
        .style26
        {
            width: 17%;
        }
        .style27
        {
            width: 10%;
        }
        .style28
        {
            width: 14%;
        }
        .style29
        {
            width: 106px;
            margin-left: 160px;
        }
        .style30
        {
            margin-left: 240px;
            width: 17%;
        }
        .style31
        {
            width: 83px;
        }
        .style32
        {
            width: 16%;
        }
        .style33
        {
            width: 166px;
        }
        .style34
        {
            width: 1%;
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

    <script type="text/javascript">
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        //If the header checkbox is checked
                        //check all checkboxes
                        //and highlight all rows

                        inputList[i].checked = true;
                    }
                    else {
                        //If the header checkbox is checked
                        //uncheck all checkboxes
                        //and change rowcolor back to original
                        if (row.rowIndex % 2 == 0) {
                            //Alternating Row Color

                        }
                        else {

                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>

    <table width="100%">
        <tr>
            <td align="center" colspan="2" class="cpHeader" style="width: 100%; margin-left: 120px;">
                <asp:Label ID="Label23" runat="server" Text="Refund" Font-Bold="True" Font-Size="Small"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Label ID="ErrMsg" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
    <table width="100%" class="Body">
        <tr>
            <td class="style27" align="left" colspan="0" rowspan="0">
                &nbsp;
            </td>
            <td class="style28" align="left" colspan="0" rowspan="0" width="0">
                &nbsp;
            </td>
            <td align="char" class="style29">
                &nbsp;
            </td>
            <td align="char" class="style30">
                &nbsp;
            </td>
            <td align="char" class="style13">
                &nbsp;
            </td>
            <td align="char" class="style6">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style27">
                Academic Year <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td class="style28">
                <asp:DropDownList ID="ddlCurrentAcedamic" runat="server" Height="21px" Width="122px"
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="style22">
                Student Name &nbsp;
            </td>
            <td class="style26">
                <asp:TextBox ID="txtStudentName" runat="server" Width="155px" ReadOnly="True"></asp:TextBox>
                &nbsp;
            </td>
            <td class="style31">
                Father Name
            </td>
            <td class="style32">
                <asp:TextBox ID="txtFatherName" runat="server" Width="140px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style33">
                <asp:DropDownList ID="ddlAcedamic" runat="server" Height="21px" Width="34px" AutoPostBack="True"
                    Visible="False">
                </asp:DropDownList>
            </td>
            <td align="center" class="style26">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style27">
                Standard <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td class="style28">
                <asp:DropDownList ID="ddlStandard" runat="server" Height="21px" Width="122px" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="style29" __designer:mapid="146">
                &nbsp;Registration No <span style="color: rgb(255, 0, 0)" __designer:mapid="147">*</span>
            </td>
            <td class="style30" __designer:mapid="148">
                <asp:TextBox ID="txtRegistrationNo" runat="server" Width="132px" ReadOnly="True"></asp:TextBox>
                <asp:LinkButton ID="lbtnRegionSearch" runat="server" OnClick="lbtnRegionSearch_Click">
               <img alt="Search" src="../Images/Search.gif" style="border:none"/>
                </asp:LinkButton>
                <br __designer:mapid="14c" />
            </td>
            <td class="style31">
                Template <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td class="style32">
                <asp:DropDownList ID="ddlTemplate" runat="server" Height="21px" Width="144px" AutoPostBack="True"
                    Enabled="False">
                </asp:DropDownList>
            </td>
            <td align="center" class="style33">
                Refund Amount <span style="color: rgb(255, 0, 0);">&nbsp;*</span>
            </td>
            <td align="left">
                <asp:TextBox ID="txtRefundAmount" Style="text-align: right" runat="server" OnTextChanged="txtRefundAmount_TextChanged"
                    AutoPostBack="True" Width="140px">0.00</asp:TextBox>
            </td>
            <td align="center" class="style34">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style19" align="center" colspan="9">
                <asp:Button ID="btnGetDetails" runat="server" Text="Get Details" Width="73px" OnClick="btnGetDetails_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="55px" />
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="9">
                <asp:GridView ID="GvAdmission" runat="server" CellPadding="4" ForeColor="#333333"
                    AutoGenerateColumns="False" GridLines="None" Width="100%" AllowPaging="false"
                    DataKeyNames="FeeId,FeeCollectionId,FeeName" ShowFooter="True" Enabled="False">
                    <RowStyle BackColor="#EFF3FB" />
                    <FooterStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <EditRowStyle BackColor="#336666" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Fee Name">
                            <ItemTemplate>
                                <asp:Label ID="lblFeeName" runat="server" Width="150px" Text='<%# Bind("FeeName") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblSumFeeamount" runat="server" Width="150px" Text="Total"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fee Amount">
                            <ItemTemplate>
                                <asp:TextBox ID="txtFeeamount" ReadOnly="true" runat="server" Width="100px" Text='<%# Bind("Amount","{0:N2}") %>'
                                    Style="text-align: right;"></asp:TextBox>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtSumFeeamount" ReadOnly="true" runat="server" Width="100px" Style="text-align: right;"
                                    Text="0.00"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Paid Amount">
                            <ItemTemplate>
                                <asp:TextBox ID="txtpaidamount" ReadOnly="true" Text='<%# Bind("PaidAmount","{0:N2}") %>'
                                    runat="server" Width="100px" Style="text-align: right;"></asp:TextBox>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtpaidSumamount" runat="server" Width="100px" Style="text-align: right;"
                                    ReadOnly="true" Text="0.00"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount">
                            <ItemTemplate>
                                <asp:TextBox ID="txtamount" runat="server" Width="100px" Style="text-align: right;"
                                    Text="0.00"></asp:TextBox>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtSumamount" runat="server" Width="100px" Style="text-align: right;"
                                    ReadOnly="true" Text="0.00"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pending Amount">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPendingamount" ReadOnly="true" runat="server" Width="100px" Style="text-align: right;"
                                    Text="0.00"></asp:TextBox>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtSumPendingamount" ReadOnly="true" runat="server" Width="100px"
                                    Style="text-align: right;" Text="0.00"></asp:TextBox>
                                <asp:ImageButton ID="ImgBtnReCalculate" runat="server" ImageUrl="~/Images/Recalculate.png"
                                    Width="20px" Height="20px" ImageAlign="AbsMiddle" ToolTip="Click here to Re-Calculate"
                                    OnClick="ImgBtnReCalculate_OnClick" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style4" align="center" colspan="9">
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Visible="False" OnClick="btnSave_Click"
                    Width="100px" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                &nbsp;<asp:HiddenField ID="hdnCastId" runat="server" />
            </td>
            <td class="style32">
                &nbsp;
            </td>
            <td class="style33">
                &nbsp;
            </td>
            <td class="style26">
                &nbsp;
            </td>
            <td class="style34">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
