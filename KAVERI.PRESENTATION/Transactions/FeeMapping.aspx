<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Clinic.master" AutoEventWireup="true"
    CodeFile="FeeMapping.aspx.cs" Inherits="Transactions_FeeMapping" %>

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
        .style3
        {
        }
        .style4
        {
        }
        .style5
        {
            width: 153px;
        }
        .style6
        {
            width: 75px;
        }
        .style7
        {
            width: 51px;
        }
        .style8
        {
            width: 72px;
        }
        .style9
        {
            width: 59px;
        }
        .style10
        {
            width: 153px;
            height: 18px;
        }
        .style11
        {
            width: 51px;
            height: 18px;
        }
        .style12
        {
            width: 59px;
            height: 18px;
        }
        .style13
        {
            width: 72px;
            height: 18px;
        }
        .style14
        {
            width: 75px;
            height: 18px;
        }
        .style15
        {
            height: 18px;
        }
    </style>
    <table width="100%">
        <tr>
            <td align="center" colspan="2" class="cpHeader">
                <asp:Label ID="Label23" runat="server" CssClass="LabelBold" Text="Fee Mapping"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Label ID="ErrMsg" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
    <table width="100%">
        <tr>
            <td align="left" class="cpHeader" colspan="2">
                <asp:Label ID="Label3" runat="server" CssClass="LabelBold" Text="Fee Mapping Details"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <asp:GridView ID="GvFeeMappingHeader" runat="server" CellPadding="4" ForeColor="#333333"
                    AutoGenerateColumns="False" GridLines="None" Width="100%" AllowPaging="True"
                    DataKeyNames="FeeMappingId,StandardId" OnPageIndexChanged="GvCastMaster_PageIndexChanged"
                    OnPageIndexChanging="GvCastMaster_PageIndexChanging">
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
                                    CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MappingTemplateName" HeaderText="Template Name" ItemStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="StandardName" HeaderText="Standard Name" ItemStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="FeeMode" HeaderText="Fee Mode" />
                        <asp:BoundField DataField="ReportFormatId" HeaderText="Report Format" />
                        <asp:BoundField DataField="IsActive" HeaderText="Is Active" ItemStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="left" class="cpHeader">
                <asp:Label ID="Label2" runat="server" CssClass="LabelBold" Text="Fee Mapping Maintenance"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%" class="Body">
        <tr>
            <td class="style5">
                Fee Mapping Template Name <span style="color: rgb(255, 0, 0)">*</span>
            </td>
            <td style="margin-left: 40px" class="style7">
                <asp:TextBox ID="txtTemplateName" runat="server" Width="176px" CssClass="uppercase"></asp:TextBox>
            </td>
            <td class="style9">
                Mode <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td class="style8">
                <asp:DropDownList ID="ddlMode" runat="server" Height="21px" Width="154px" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlMode_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="style6">
                <asp:Label ID="lblrf" runat="server" 
                    Text="Report Format &lt;span style=&quot;color: rgb(255, 0, 0);&quot;&gt;*&lt;/span&gt;"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlReportFormat" runat="server" Height="21px" Width="112px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Template For Standard <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td style="margin-left: 40px" class="style7">
                <asp:DropDownList ID="ddlStandard" runat="server" Height="21px" Width="180px" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="style9">
                <asp:Label ID="lblfn" runat="server" 
                    Text="Fee Name &lt;span style=&quot;color: rgb(255, 0, 0);&quot;&gt;*&lt;/span&gt;"></asp:Label>
            </td>
            <td class="style8">
                <asp:DropDownList ID="ddlFeeName" runat="server" Height="21px" Width="154px">
                </asp:DropDownList>
            </td>
            <td class="style6">
                <asp:Label ID="lblda" runat="server" 
                    Text="Amount &lt;span style=&quot;color: rgb(255, 0, 0);&quot;&gt;*&lt;/span&gt;"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDirectFeeAmount" runat="server" Width="101px" CssClass="uppercase"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style10">
                <asp:Label ID="lblIsActive" runat="server" Text="In Active"></asp:Label>
            </td>
            <td align="char" class="style11">
                <asp:CheckBox ID="chkIsActive" runat="server" />
            </td>
            <td align="char" class="style12">
            </td>
            <td align="char" class="style13">
            </td>
            <td align="char" class="style14">
            </td>
            <td align="char" class="style15">
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="6">
                <asp:GridView ID="GvFeeMaster" runat="server" CellPadding="4" ForeColor="#333333"
                    AutoGenerateColumns="False" GridLines="None" Width="100%" DataKeyNames="FeeId"
                    ShowFooter="True" OnPageIndexChanged="GvCastMaster_PageIndexChanged" OnPageIndexChanging="GvCastMaster_PageIndexChanging">
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
                                <asp:CheckBox ID="ChkFee" runat="server" Enabled="true" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FeeName" HeaderText="Fee Name" ItemStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Amount">
                            <ItemTemplate>
                                <asp:TextBox ID="txtamount" runat="server" Width="150px" Text='<%# Bind("Amount","{0:N2}") %>'
                                    Style="text-align: right;"></asp:TextBox>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtSumamount" runat="server" Width="150px" Style="text-align: right;"
                                    ReadOnly="true" Text="0.00"></asp:TextBox>
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
            <td class="style4" align="center" colspan="6">
                &nbsp; &nbsp;
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                &nbsp;<asp:Button ID="btnClear" runat="server" Text="Clear" Width="55px" OnClick="btnClear_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
                <asp:HiddenField ID="hdnCastId" runat="server" />
            </td>
            <td class="style9">
                &nbsp;
            </td>
            <td class="style8">
                &nbsp;
            </td>
            <td class="style6">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
