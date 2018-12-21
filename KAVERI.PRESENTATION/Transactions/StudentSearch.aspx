<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="StudentSearch.aspx.cs"
    Inherits="Transactions_StudentSearch" %>

<script type="text/javascript" src="../Scripts/Common.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title></title>
    <style type="text/css">
        .rich-panelbar
        {
            margin-top: 20px;
            margin-left: auto;
            margin-right: auto;
        }
        .rich-table
        {
            margin-top: 5px;
            margin-left: 4px;
            margin-right: auto;
        }
        .rich-panel
        {
            margin-top: 5px;
            margin-left: 4px;
            margin-right: 4px;
        }
        .a4j-status
        {
            color: #CC0033;
        }
        .rich-messages
        {
            background-color: #ebf3fd;
            margin-top: 5px;
            margin-left: 272px;
            width: 79.2%;
            padding: 10px;
            border: thin solid #99CCFF;
            line-height: 10px;
            z-index: 100000;
            position: absolute;
            cursor: pointer;
        }
        .rich-messages-marker img
        {
            padding-right: 7px;
        }
        .rich-table-footer
        {
            background-color: #e9eef2;
        }
        .toolbar-menu
        {
            color: white;
        }
        .toolbar-select
        {
            color: black;
        }
        #content
        {
            width: 79.8%;
            height: 100%;
            float: left; /*	background-color: #eeeeFF;
*/
            overflow: auto;
        }
        #webcam, #canvas
        {
            width: 320px;
            border: 20px solid #333;
            background: #eee;
            -webkit-border-radius: 20px;
            -moz-border-radius: 20px;
            border-radius: 20px;
        }
        #webcam
        {
            position: relative;
            margin-top: 50px;
            margin-bottom: 50px;
        }
        .ui-layout-west, /* has Accordion */ .ui-layout-east, /* has content-div ... */ .ui-layout-east
        {
            /* content-div has Accordion */
            padding: 0;
            overflow: hidden;
        }
        .ui-layout-center P.ui-layout-content
        {
            line-height: 1.4em;
            margin: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
        .style5
        {
            width: 88px;
        }
        .style6
        {
            width: 113px;
        }
        .style8
        {
            width: 188px;
        }
        .style9
        {
            width: 71px;
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
            <td align="center" colspan="2" class="cpHeader" style="width: 100%">
                <asp:Label ID="Label23" runat="server" Text="Admission Allocation" Font-Bold="True"
                    Font-Size="Small"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Label ID="ErrMsg" runat="server" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
    <table width="100%" class="Body">
        <tr>
            <td class="style5">
                Student Name
            </td>
            <td class="style8">
                <asp:TextBox ID="txtStudentName" runat="server" Width="150px"></asp:TextBox>
            </td>
            <td class="style9">
                Father Name
            </td>
            <td class="style6">
                <asp:TextBox ID="txtFatherName" runat="server" Width="150px"></asp:TextBox>
            </td>
            <td class="style8">
                Academic Year
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlAcedamic" runat="server" Height="21px" Width="140px">
                </asp:DropDownList>
            </td>
            <td align="center" class="style5">
                &nbsp;<asp:Button ID="btnGetDetails" runat="server" Text="Get Details" Width="73px"
                    OnClick="btnGetDetails_Click" />
            </td>
            <td>
                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="55px" OnClick="btnClear_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="8">
                <div >
                    <asp:GridView ID="GvAdmission" runat="server" CellPadding="4" ForeColor="#333333"
                        AutoGenerateColumns="False" GridLines="None" Width="100%" Font-Size="11px" 
                        PageSize="1000" DataKeyNames="FeeTemplateId">
                        <RowStyle BackColor="#EFF3FB" />
                        <FooterStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        <EditRowStyle BackColor="#336666" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField HeaderText="Admission Form No" ItemStyle-HorizontalAlign="Left" DataField="RegistrationId">
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Admission No">
                                <ItemTemplate>
                                    <asp:LinkButton ID="chkSelect" runat="server" Text='<%# Eval("AdmissionNo") %>' OnClick="chkSelect_OnClick" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField HeaderText="Admission No" ItemStyle-HorizontalAlign="Left" DataField="AdmissionNo">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>--%>
                            <asp:BoundField HeaderText="Student Name" DataField="StudentName">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="DOB" DataField="DOB"></asp:BoundField>
                            <asp:BoundField HeaderText="Sex" DataField="SexName" />
                            <asp:BoundField HeaderText="Standard Sought" DataField="StandardName" />
                            <asp:BoundField HeaderText="Fee Template" DataField="MappingTemplateName" />
                            <asp:BoundField HeaderText="Father Name" DataField="FatherName" />
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
