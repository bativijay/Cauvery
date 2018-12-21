<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Clinic.master"
    CodeFile="Admission.aspx.cs" Inherits="Transactions_Admission" %>

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

    <script type="text/javascript">
        function checkDate(sender, args) {

            sender._textbox.set_Value(sender._selectedDate.format(sender._format))
        }


        function abc() {

            if ($get('<%=txtDOB.ClientID%>').value != "") {
                $get('<%=hf1.ClientID%>').value = $get('<%=txtDOB.ClientID%>').value;
            }
        }
    </script>

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

    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" OkControlID="b2"
        TargetControlID="b1" PopupControlID="Panel1" PopupDragHandleControlID="PopupHeader"
        Drag="true" BackgroundCssClass="ModalPopupBG">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" Width="75%" Style="display: none">
        <div class="HellowWorldPopup">
            <table border="0" style="width: 100%">
                <tr>
                    <td align="center" class="style24" colspan="2">
                        <asp:Label ID="Label2" runat="server" CssClass="LabelBold" Text=" Fee Collection"></asp:Label>
                    </td>
                    <td align="right" class="cpHeader" style="width: 5%; border: 0 0 0">
                        <asp:ImageButton ID="IM" ImageUrl="~/Images/Button-Close-icon.png" runat="server"
                            Height="15px" Width="15px" OnClick="IM_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="style25" colspan="2">
                        <asp:Label ID="ErrorFeelabel" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style25">
                        Payment Mode <span style="color: rgb(255, 0, 0)">*</span>
                    </td>
                    <td class="style21">
                        <asp:DropDownList ID="ddlPayMode" runat="server" AutoPostBack="True" Height="21px"
                            OnSelectedIndexChanged="ddlPayMode_SelectedIndexChanged" Width="159px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style25">
                        <asp:Label ID="ChequeNoLabel" runat="server" Text="Cheque No. &lt;span style=&quot;color: rgb(255, 0, 0)&quot;&gt;*&lt;/span&gt;"></asp:Label>
                    </td>
                    <td class="style21">
                        <asp:TextBox ID="txtChequeNo" runat="server" Width="156px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style25">
                        <asp:Label ID="ChequeDateLabel" runat="server" Text="Cheque Date &lt;span style=&quot;color: rgb(255, 0, 0)&quot;&gt;*&lt;/span&gt;"></asp:Label>
                    </td>
                    <td class="style21">
                        <asp:TextBox ID="txtChequeDate" runat="server" Width="156px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style26">
                        <asp:Label ID="ChequeBankLabel" runat="server" Text="Bank And Branch &lt;span style=&quot;color: rgb(255, 0, 0)&quot;&gt;*&lt;/span&gt;"></asp:Label>
                    </td>
                    <td class="style22">
                        <asp:TextBox ID="txtChequeBank" runat="server" Width="154px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style25">
                        &nbsp;
                    </td>
                    <td class="style21">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div class="Controls">
                            <asp:GridView ID="GvFeeMaster" runat="server" CellPadding="4" ForeColor="#333333"
                                AutoGenerateColumns="False" GridLines="None" Width="100%" DataKeyNames="FeeId,FeeCollectionId,FeeName"
                                ShowFooter="True">
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
                                            <asp:TextBox ID="txtFeeamount" ReadOnly="true" runat="server" Width="80px" Text='<%# Bind("Amount","{0:N2}") %>'
                                                Style="text-align: right;"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtSumFeeamount" ReadOnly="true" runat="server" Width="80px" Style="text-align: right;"
                                                Text="0.00"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Paid Amount">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtpaidamount" ReadOnly="true" Text='<%# Bind("PaidAmount","{0:N2}") %>'
                                                runat="server" Width="80px" Style="text-align: right;"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtpaidSumamount" runat="server" Width="80px" Style="text-align: right;"
                                                ReadOnly="true" Text="0.00"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtamount" runat="server" Width="80px" Style="text-align: right;"
                                                Text="0.00"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtSumamount" runat="server" Width="80px" Style="text-align: right;"
                                                ReadOnly="true" Text="0.00"></asp:TextBox>
                                            <asp:ImageButton ID="ImgBtnReCalculate" runat="server" ImageUrl="~/Images/Recalculate.png"
                                                Width="20px" Height="20px" ImageAlign="AbsMiddle" ToolTip="Click here to Re-Calculate"
                                                OnClick="ImgBtnReCalculate_OnClick" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pending Amount" Visible="False">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPendingamount" ReadOnly="true" runat="server" Width="80px" Style="text-align: right;"
                                                Text="0.00"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtSumPendingamount" ReadOnly="true" runat="server" Width="80px"
                                                Style="text-align: right;" Text="0.00"></asp:TextBox>
                                            <asp:ImageButton ID="ImgBtnReCalculate1" runat="server" ImageUrl="~/Images/Recalculate.png"
                                                Width="20px" Height="20px" ImageAlign="AbsMiddle" ToolTip="Click here to Re-Calculate"
                                                OnClick="ImgBtnReCalculate_OnClick" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="cpHeader" colspan="3" style="width: 100%">
                        <asp:Button ID="btnOkay" runat="server" Height="25px" OnClick="BtnOkay_Click" Text="Register & Fee Collect"
                            Width="250px" OnClientClick="this.disabled = true;" UseSubmitBehavior="false"/>
                    </td>
                </tr>
            </table>
            <div class="LabelBold">
                <input id="b1" runat="server" style="display: none" />
                <input id="b2" runat="server" style="display: none" />
            </div>
        </div>
    </asp:Panel>
    <table border="0" style="width: 100%">
        <tr>
            <td align="center" class="cpHeader" style="width: 100%">
                <asp:Label ID="Label23" runat="server" CssClass="LabelBold" Text="Admission"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Label ID="ErrMsg" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
    <asp:HiddenField ID="hf1" runat="server" />
    <table border="0" style="width: 100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" class="cpHeader" style="width: 80%">
                <asp:Label ID="Label1" runat="server" CssClass="LabelBold" Text="Candidate Details"></asp:Label>
            </td>
            <td align="right" class="cpHeader" style="width: 20%">
                <asp:Button ID="BtnSave" runat="server" Height="18px" OnClick="BtnSave_Click" Text="Save" />
                <asp:Button ID="BtnClear" runat="server" Height="18px" Text="Clear" Width="44px"
                    OnClick="BtnClear_Click" />
            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td class="style4">
                Admission No.<span style="color: rgb(255, 0, 0)">&nbsp; </span>
            </td>
            <td class="style3">
                <asp:TextBox ID="RegistrationNo" runat="server" Width="96px" AutoPostBack="true"
                    OnTextChanged="RegistrationNo_OnTextChanged" ReadOnly="True"></asp:TextBox>
                <%--&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="16px" ImageUrl="~/Images/Search-icon.png"
                    OnClick="ImageButton1_Click" Width="23px" />
                &nbsp;<a href="javascript:void(0);" onclick="popup('StudentSearch.aspx', 'Student Search',700,600);">Search</a>--%>
                <a id="positionLnk" runat="Server">
                    <asp:Label ID="lblPosition" runat="server" />
                    <img id="img" src="../Images/Search.gif" alt="Click here to select position number to refer"
                        style="border: none" />
                </a>
            </td>
            <td class="style8">
                Academic Year
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlAcedamic" runat="server" Height="21px" Width="140px">
                </asp:DropDownList>
            </td>
            <td align="char" colspan="2" rowspan="2">
                <table style="height: 90px; width: 64%">
                    <tr>
                        <td align="center" class="style9">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Image ID="StudentPhoto" runat="server" BorderWidth="1px" Height="65px" ImageUrl="~/Images/User.png"
                                        Width="65px" ImageAlign="Middle" />
                                    <br />
                                    <asp:FileUpload ID="PhotoUploader" runat="server" Width="126px" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="lnkPhoto" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="style9">
                            <asp:LinkButton ID="lnkPhoto" runat="server" OnClick="lnkPhoto_Click">Upload</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Name of the Pupil<span style="color: rgb(255, 0, 0)">*</span>
            </td>
            <td class="style3">
                <asp:TextBox ID="PupilTextBox" runat="server" Width="140px" CssClass="uppercase"></asp:TextBox>
            </td>
            <td class="style8">
                Nationality
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlNationality" runat="server" Height="22px" Width="140px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Date Of Birth<span style="color: rgb(255, 0, 0)">&nbsp; *</span>
            </td>
            <td class="style3">
                <asp:UpdatePanel ID="Up1" runat="server" EnableViewState="true">
                    <ContentTemplate>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtDOB" runat="server" Width="92px" onchange="abc();"></asp:TextBox>
                                    <cc1:CalendarExtender ID="DOBCE" TargetControlID="txtDOB" PopupButtonID="DOBIB" Format="dd/MM/yyyy"
                                        runat="server">
                                    </cc1:CalendarExtender>
                                </td>
                                <td align="left">
                                    <asp:ImageButton ID="DOBIB" runat="server" ImageUrl="~/Images/Calendar.png" Height="15px"
                                        ImageAlign="Middle" Width="15px" />
                                    <asp:CompareValidator ID="dateValidator" runat="server" Type="Date" Operator="DataTypeCheck"
                                        Display="Dynamic" ControlToValidate="txtDOB" ErrorMessage="Please enter a valid date.">
                                    </asp:CompareValidator>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="style8">
                Mother Tongue <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlMotherToungue" runat="server" Height="21px" Width="140px">
                </asp:DropDownList>
            </td>
            <td class="style7">
                Religion <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlReligion" runat="server" Height="21px" Width="140px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Cast<span style="color: rgb(255, 0, 0)"> *</span>
            </td>
            <td class="style3">
                <asp:DropDownList ID="ddlCaste" runat="server" Height="21px" Width="140px">
                </asp:DropDownList>
            </td>
            <td class="style8">
                Belongs To
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlBelongsTo" runat="server" Height="21px" Width="140px">
                </asp:DropDownList>
            </td>
            <td class="style7">
                Sex <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlSex" runat="server" Height="21px" Width="140px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Present School Address
            </td>
            <td class="style3">
                <asp:TextBox ID="txtPresentAdd" runat="server" Width="140px" Height="35px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="style8">
                Standard Studying
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlStandardStudying" runat="server" Height="21px" Width="140px">
                </asp:DropDownList>
            </td>
            <td class="style7">
                Standard Sought <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlStandardSought" runat="server" Height="21px" Width="140px"
                    AutoPostBack="True" OnTextChanged="ddlStandardSought_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                First Language<span style="color: rgb(255, 0, 0)"> </span>
            </td>
            <td class="style3">
                <asp:DropDownList ID="ddlFL" runat="server" Height="21px" Width="140px">
                </asp:DropDownList>
            </td>
            <td class="style8">
                Second Language<span style="color: rgb(255, 0, 0)"> *</span>
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlSL" runat="server" Height="21px" Width="140px">
                </asp:DropDownList>
            </td>
            <td class="style7">
                Third Language<span style="color: rgb(255, 0, 0)"> *</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlTL" runat="server" Height="21px" Width="140px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Previous TC No &amp; Issued Date
            </td>
            <td class="style3">
                <asp:TextBox ID="PreviousTCTextBox" runat="server" Width="140px" CssClass="uppercase"></asp:TextBox>
            </td>
            <td class="style8">
                Joining Academic Year
            </td>
            <td class="style6">
                <asp:TextBox ID="JoiningAcademicYearTextBox" runat="server" Width="140px" CssClass="uppercase"></asp:TextBox>
            </td>
            <td class="style7">
                Fee Template <span style="color: rgb(255, 0, 0)">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlFeeTemplate" runat="server" Height="21px" Width="140px"
                    AutoPostBack="True" OnTextChanged="ddlFeeTemplate_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" class="cpHeader" colspan="6" dir="ltr">
                <asp:Label ID="Label24" runat="server" CssClass="LabelBold" Text="Parents Information"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Fathers Name<span style="color: rgb(255, 0, 0)">*</span>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtFatherName" runat="server" Width="140px" CssClass="uppercase"></asp:TextBox>
            </td>
            <td class="style8">
                Occupation
            </td>
            <td class="style6">
                <asp:TextBox ID="txtFatherOccupation" runat="server" Width="140px" CssClass="uppercase"></asp:TextBox>
            </td>
            <td class="style7">
                Qualification
            </td>
            <td>
                <asp:TextBox ID="txtFatherQualification" runat="server" Width="140px" CssClass="uppercase"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Mothers Name<span style="color: rgb(255, 0, 0)">*</span>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtMotherName" runat="server" Width="140px" CssClass="uppercase"></asp:TextBox>
            </td>
            <td class="style8">
                Occupation
            </td>
            <td class="style6">
                <asp:TextBox ID="txtMotherOccupation" runat="server" Width="140px" CssClass="uppercase"></asp:TextBox>
            </td>
            <td class="style7">
                Qualification
            </td>
            <td>
                <asp:TextBox ID="txtMotherQualification" runat="server" Width="140px" CssClass="uppercase"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Postal Address For Correspondance
            </td>
            <td class="style3">
                <asp:TextBox ID="txtPermanantAdd" runat="server" Width="140px" Height="40px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="style8">
                Name and Address of Guardian
            </td>
            <td class="style6">
                <asp:TextBox ID="txtTemAdd" runat="server" Width="140px" Height="40px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="style7">
                Emergency Contact <span style="color: rgb(255, 0, 0)">*</span>
            </td>
            <td>
                <asp:TextBox ID="txtEmerAdd" runat="server" Width="140px" Height="40px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Tel.No(Res)<span style="color: rgb(255, 0, 0)"> </span>&nbsp;
            </td>
            <td class="style3">
                <asp:TextBox ID="txtPerTelNo" runat="server" Width="140px"></asp:TextBox>
            </td>
            <td class="style8">
                Tel.No(Res)<span style="color: rgb(255, 0, 0)"> </span>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtTempTelNo" runat="server" Width="140px"></asp:TextBox>
            </td>
            <td class="style7">
                Relationship<span style="color: rgb(255, 0, 0)"> </span>
            </td>
            <td>
                <asp:TextBox ID="txtRelation" runat="server" Width="140px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Tel.No(Off)<span style="color: rgb(255, 0, 0)"> </span>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtPerOffTelNo" runat="server" Width="140px"></asp:TextBox>
            </td>
            <td class="style8">
                Tel.No(Off)<span style="color: rgb(255, 0, 0)"> </span>&nbsp;
            </td>
            <td class="style6">
                <asp:TextBox ID="txtTemOffTelNo" runat="server" Width="140px"></asp:TextBox>
            </td>
            <td class="style7">
                Tel.No(Res)<span style="color: rgb(255, 0, 0)"> </span>
            </td>
            <td>
                <asp:TextBox ID="txtEmerTelNo" runat="server" Width="140px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Tel.No(Mob)<span style="color: rgb(255, 0, 0)"> *</span>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtPerMobNo" runat="server" Width="140px"></asp:TextBox>
            </td>
            <td class="style8">
                Tel.No(Mob)<span style="color: rgb(255, 0, 0)"> </span>&nbsp;
            </td>
            <td class="style6">
                <asp:TextBox ID="txtTemMobNo" runat="server" Width="140px"></asp:TextBox>
            </td>
            <td class="style7">
                Tel.No(Off)<span style="color: rgb(255, 0, 0)"> </span>
            </td>
            <td>
                <asp:TextBox ID="txtEmerOffTelNo" runat="server" Width="140px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Other Information<span style="color: rgb(255, 0, 0)"> </span>
            </td>
            <td colspan="5">
                <asp:TextBox ID="txtOtherInfo" runat="server" Width="409px" Height="40px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" class="cpHeader" colspan="6" dir="ltr">
                <asp:Label ID="Label25" runat="server" CssClass="LabelBold" Text="Office Use"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Application Rcvd On
            </td>
            <td class="style3">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtAppRcvdOn" runat="server" Enabled="false" Width="181px"></asp:TextBox>
                            <cc1:CalendarExtender ID="AppRcvdOnCE" TargetControlID="txtAppRcvdOn" PopupButtonID="ARIB"
                                Format="dd/MM/yyyy" runat="server">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                            <asp:ImageButton ID="ARIB" runat="server" ImageUrl="~/Images/Calendar.png" Height="15px"
                                Width="15px" />
                        </td>
                    </tr>
                </table>
            </td>
            <td class="style8">
                Rcpt.No &amp; Date
            </td>
            <td class="style6">
                <asp:TextBox ID="txtAppnNoAndDate" runat="server" Width="181px"></asp:TextBox>
            </td>
            <td class="style7">
                TC No &amp; Issued Date
            </td>
            <td>
                <asp:TextBox ID="txtAppnNoAndDate0" runat="server" Width="140px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Remarks<span style="color: rgb(255, 0, 0)"> </span>
            </td>
            <td colspan="5">
                <asp:TextBox ID="Remarks" runat="server" Width="412px" Height="40px" TextMode="MultiLine"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:CustomValidator runat="server" ID="valDateRange" ControlToValidate="txtDOB"
        OnServerValidate="valDateRange_ServerValidate" ErrorMessage="enter valid date" />
</asp:Content>
