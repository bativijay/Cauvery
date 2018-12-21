<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Clinic.master" AutoEventWireup="true"
    CodeFile="FeeCollection.aspx.cs" Inherits="Transactions_FeeCollection" %>

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

        .style3 {
        }

        .style6 {
            width: 212px;
            margin-left: 80px;
        }

        .style10 {
        }

        .style11 {
            width: 189px;
            margin-left: 40px;
        }

        .style12 {
        }

        .style13 {
            width: 291px;
            margin-left: 80px;
        }

        .style15 {
            margin-left: 200px;
        }

        .style17 {
            margin-left: 240px;
            width: 166px;
        }

        .style18 {
            width: 260px;
            margin-left: 160px;
        }

        .style19 {
            width: 246px;
        }

        .auto-style1 {
            width: 244px;
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
        window.onbeforeunload = function () {
            var inputs = document.getElementsByTagName("INPUT");
            for (var i in inputs) {
                if (inputs[i].type == "button" || inputs[i].type == "submit") {
                    inputs[i].disabled = true;
                }
            }
        };
    </script>
    <table width="100%">
        <tr>
            <td align="center" colspan="2" style="width: 100%" class="cpHeader">
                <asp:Label ID="Label23" runat="server" CssClass="LabelBold" Text="Fee Collection"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Label ID="ErrMsg" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>

    <table width="100%" class="Body">
        <asp:Panel ID="P1" runat="server">
            <tr>
                <td class="style10" align="right" colspan="2">
                    <asp:RadioButton ID="RBDetailed" runat="server" GroupName="A" OnCheckedChanged="RBDetailed_CheckedChanged"
                        Text="Detailed Collection" AutoPostBack="True" Checked="True" />
                </td>
                <td class="style15">
                    <asp:RadioButton ID="RBDirect" runat="server" GroupName="A" OnCheckedChanged="RBDirect_CheckedChanged"
                        Text="Direct Collection" AutoPostBack="True" />
                </td>
                <td class="style15">
                    <asp:RadioButton ID="RBAdhoc" runat="server" GroupName="A" OnCheckedChanged="RBAdhoc_CheckedChanged"
                        Text="ADHOC Collection" AutoPostBack="True" />
                </td>
            </tr>
            <tr>
                <td class="style19">Standard <span style="color: rgb(255, 0, 0)">*</span>
                </td>
                <td class="style11">
                    <asp:DropDownList ID="ddlStandard" runat="server" Height="21px" Width="157px" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="style18">
                    <asp:Label ID="RegNo" runat="server" Text="Registration No"></asp:Label>
                    <span style="color: rgb(255, 0, 0)">*</span>
                </td>
                <td class="style17">
                    <asp:TextBox ID="txtRegistrationNo" runat="server" Width="132px" ReadOnly="True"></asp:TextBox>
                    <asp:LinkButton ID="lbtnRegionSearch" runat="server" OnClick="lbtnRegionSearch_Click">
                        <img alt="Search" src="../Images/Search.gif" style="border: none" id="searchiCon" runat="server" />
                    </asp:LinkButton>
                    <br />
                </td>
                <td class="style13">Academic Year <span style="color: rgb(255, 0, 0);">*</span>
                </td>
                <td class="style6">
                    <asp:DropDownList ID="ddlAcademic" runat="server" Height="21px" Width="142px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style19">Template <span style="color: rgb(255, 0, 0);">*</span>
                </td>
                <td align="char" class="style11">
                    <%--<a id="positionLnk" runat="Server" runat="server" onclick="positionLnk_onclick" >
                    <img id="img" src="../Images/Search.gif" alt="Click here to select position number to refer" />
                </a>--%>
                    <asp:DropDownList ID="ddlTemplate" runat="server" Height="21px" Width="140px" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlTemplate_SelectedIndexChanged" Enabled="False">
                    </asp:DropDownList>
                    <asp:LinkButton ID="lbtnRegionSearch0" runat="server" OnClick="lbtnRegionSearch0_Click"
                        ToolTip="Click here to enable fee template">
               <img alt="Click here to enable fee template" height=20px width=20px src="../Images/edit_icon.png" style="border:none"/>
                    </asp:LinkButton>
                </td>
                <td align="char" class="style18">Student Name
                </td>
                <td align="char" class="style17">
                    <asp:TextBox ID="txtStudentName" runat="server" Width="155px" ReadOnly="True"></asp:TextBox>
                </td>
                <td align="char" class="style13">Father Name
                </td>
                <td align="char" class="style6">
                    <asp:TextBox ID="txtFatherName" runat="server" Width="140px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td>Payment Mode <span style="color: rgb(255, 0, 0)">*</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlPayMode" runat="server" Height="21px" Width="159px" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlPayMode_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td align="char" class="style18">
                <asp:Label ID="AmountLabel" runat="server" Text="Amount &lt;span style=&quot;color: rgb(255, 0, 0)&quot;&gt;*&lt;/span&gt;"></asp:Label>
            </td>
            <td align="char" class="style17">
                <asp:TextBox ID="txtAmount" runat="server" Width="155px" Style="text-align: right"
                    AutoPostBack="True" OnTextChanged="txtAmount_TextChanged">0.00</asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">
                <asp:Label ID="ChequeNoLabel" runat="server" Text="Cheque No. &lt;span style=&quot;color: rgb(255, 0, 0)&quot;&gt;*&lt;/span&gt;"></asp:Label>
            </td>
            <td align="char" class="style11">
                <asp:TextBox ID="txtChequeNo" runat="server" Width="156px"></asp:TextBox>
            </td>
            <td align="char" class="style18">
                <asp:Label ID="ChequeDateLabel" runat="server" Text="Cheque Date &lt;span style=&quot;color: rgb(255, 0, 0)&quot;&gt;*&lt;/span&gt;"></asp:Label>
            </td>
            <td align="char" class="style17">
                <asp:TextBox ID="txtChequeDate" runat="server" Width="156px"></asp:TextBox>
            </td>
            <td align="char" class="style13">
                <asp:Label ID="ChequeBankLabel" runat="server" Text="Bank And Branch &lt;span style=&quot;color: rgb(255, 0, 0)&quot;&gt;*&lt;/span&gt;"></asp:Label>
            </td>
            <td align="char" class="style6">
                <asp:TextBox ID="txtChequeBank" runat="server" Width="137px"></asp:TextBox>
            </td>
        </tr>
    </table>


    <table width="100%" class="Body">
        <tr>
            <td class="style12" align="center" colspan="6">
                <asp:Button ID="btnGetDetails" runat="server" Text="Get Details" OnClick="btnGetDetails_Click" OnClientClick="this.disabled = true;" UseSubmitBehavior="false"
                    Width="80px" />
                &nbsp;<asp:Button ID="btnMainClear" runat="server" Text="Clear" Width="55px" OnClick="btnMainClear_Click" />
            </td>
        </tr>
    </table>
    <table width="100%" class="Body">
        <tr>
            <td class="style3" colspan="6">
                <asp:GridView ID="GvFeeMaster" runat="server" CellPadding="4" ForeColor="#333333"
                    AutoGenerateColumns="False" GridLines="None" Width="100%" AllowPaging="false"
                    DataKeyNames="FeeId,FeeCollectionId,FeeName" ShowFooter="True">
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
            <td colspan="6" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" />
                <%--<input type="button" id="Button1" runat="server" value="Save" onserverclick="btnSave_Click" onclick="this.disabled = true;" ondblclick="this.disabled=true;" />--%>
                &nbsp;<asp:HiddenField ID="hdnCastId" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
