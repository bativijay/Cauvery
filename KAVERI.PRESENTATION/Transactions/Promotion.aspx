<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Clinic.master" AutoEventWireup="true"
    CodeFile="Promotion.aspx.cs" Inherits="Transactions_Promotion" %>

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
    </style>

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
            <td align="center" colspan="2" class="cpHeader"
                style="width: 100%; margin-left: 120px;">
                <asp:Label ID="Label23" runat="server" Text="Promotion" Font-Bold="True" Font-Size="Small"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Label ID="ErrMsg" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
    <table width="100%" class="Body">
        <tr>
            <td class="style12">Previous
                Academic Year <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td class="style11">
                <asp:DropDownList ID="ddlAcedamic" runat="server" Height="21px" Width="180px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="style10">Current
                Academic Year <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td class="style10">
                <asp:DropDownList ID="ddlCurrentAcedamic" runat="server" Height="21px"
                    Width="180px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="style10">&nbsp;</td>
            <td class="style10">&nbsp;</td>
            <td align="center" class="style5">&nbsp;</td>
        </tr>
        <tr>
            <td class="style12">Standard <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td class="style11">
                <asp:DropDownList ID="ddlStandard" runat="server" Height="21px" Width="180px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="style10">Standard To Promote<span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td class="style10">
                <asp:DropDownList ID="ddlPromoteStandard" runat="server" Height="21px" Width="180px"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="style10">Template <span style="color: rgb(255, 0, 0);">*</span>
            </td>
            <td class="style10">
                <asp:DropDownList ID="ddlTemplate" runat="server" Height="21px" Width="180px"
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td align="center" class="style5">
                <asp:Button ID="btnGetDetails" runat="server" Text="Get Details" Width="73px"
                    OnClick="btnGetDetails_Click" />
                &nbsp;<asp:Button ID="btnClear" runat="server" Text="Clear" Width="55px" />
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="7">
                <asp:GridView ID="GvAdmission" runat="server" CellPadding="4" ForeColor="#333333"
                    AutoGenerateColumns="False" GridLines="None" Width="100%" PageSize="100"
                    EmptyDataText="No students available for promotion"
                    DataKeyNames="RegistrationId">
                    <RowStyle BackColor="#EFF3FB" />
                    <FooterStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <EditRowStyle BackColor="#336666" />
                    <AlternatingRowStyle BackColor="White" />
                    <EmptyDataRowStyle BackColor="White" ForeColor="Blue" />
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <HeaderTemplate>
                                <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkFee" runat="server" Enabled="true" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="#" ItemStyle-HorizontalAlign="Left" DataField="RegistrationId">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Student Name" DataField="StudentName">                            
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Father Name" DataField="FatherName" />
                        <asp:BoundField HeaderText="DOB" DataField="DOB"></asp:BoundField>
                        <asp:BoundField HeaderText="Sex" DataField="Sex" />
                        <asp:BoundField HeaderText="Standard Sought" DataField="StandardName" />
                        <asp:BoundField HeaderText="Fee Template" DataField="MappingTemplateName" />

                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style4" align="center" colspan="7">&nbsp;<asp:Button ID="btnSave" runat="server" Text="Re-Admission"
                Visible="False" OnClick="btnSave_Click"
                Width="100px" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" />
            </td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;<asp:HiddenField ID="hdnCastId" runat="server" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
