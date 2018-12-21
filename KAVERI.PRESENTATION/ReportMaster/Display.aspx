<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ReportMaster.master" AutoEventWireup="true"
    CodeFile="Display.aspx.cs" Inherits="Report_Master_Display" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Button ID="BackButton" runat="server" Text="Back" OnClick="BackButton_Click" />
    <br />
    <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
        PrintMode="ActiveX" />--%>

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%">
    </rsweb:ReportViewer>
</asp:Content>
