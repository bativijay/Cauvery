<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ReportMaster.master" AutoEventWireup="true"
    CodeFile="DisplayReportPopUp.aspx.cs" Inherits="Report_Master_Display" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function Print() {
            var report = document.getElementById("<%=ReportViewer1.ClientID %>");
            var div = report.getElementsByTagName("DIV");
            var reportContents;
            for (var i = 0; i < div.length; i++) {
                if (div[i].id.indexOf("VisibleReportContent") != -1) {
                    reportContents = div[i].innerHTML;
                    break;
                }
            }
            var frame1 = document.createElement('iframe');
            frame1.name = "frame1";
            frame1.style.position = "absolute";
            frame1.style.top = "-1000000px";
            document.body.appendChild(frame1);
            var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
            frameDoc.document.open();
            frameDoc.document.write('<html><head><title>RDLC Report</title>');
            frameDoc.document.write('</head><body style = "font-family:arial;font-size:10pt;">');
            frameDoc.document.write(reportContents);
            frameDoc.document.write('</body></html>');
            frameDoc.document.close();
            setTimeout(function () {
                window.frames["frame1"].focus();
                window.frames["frame1"].print();
                document.body.removeChild(frame1);
            }, 500);
        }
        // Linking the print function to the print button
        //$('#ImgButtonPrint').click(function () {
        //    printReport('ReportViewer1');
        //});
        // Print function (require the reportviewer client ID)
        function printReport(report_ID) {
            debugger;
            var rv1 = $('#' + report_ID);
            var iDoc = rv1.parents('html');

            // Reading the report styles
            var styles = iDoc.find("head style[id$='ReportControl_styles']").html();
            if ((styles == undefined) || (styles == '')) {
                iDoc.find('head script').each(function () {
                    var cnt = $(this).html();
                    var p1 = cnt.indexOf('ReportStyles":"');
                    if (p1 > 0) {
                        p1 += 15;
                        var p2 = cnt.indexOf('"', p1);
                        styles = cnt.substr(p1, p2 - p1);
                    }
                });
            }
            if (styles == '') { alert("Cannot generate styles, Displaying without styles.."); }
            styles = '<style type="text/css">' + styles + "</style>";

            // Reading the report html
            var table = rv1.find("div[id$='_oReportDiv']");
            if (table == undefined) {
                alert("Report source not found.");
                return;
            }

            // Generating a copy of the report in a new window
            var docType = '<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/loose.dtd">';
            var docCnt = styles + table.parent().html();
            var docHead = '<head><title>Printing ...</title><style>body{margin:5;padding:0;}</style></head>';
            var winAttr = "location=yes, statusbar=no, directories=no, menubar=no, titlebar=no, toolbar=no, dependent=no, width=720, height=600, resizable=yes, screenX=200, screenY=200, personalbar=no, scrollbars=yes";;
            var newWin = window.open("", "_blank", winAttr);
            writeDoc = newWin.document;
            writeDoc.open();
            writeDoc.write(docType + '<html>' + docHead + '<body onload="window.print();">' + docCnt + '</body></html>');
            writeDoc.close();

            // The print event will fire as soon as the window loads
            newWin.focus();
            // uncomment to autoclose the preview window when printing is confirmed or canceled.
            // newWin.close();
        };
       
    </script>
    <div>
        <asp:ImageButton ID="ImgButtonPrint" runat="server" ImageUrl="~/Images/print.gif" OnClick="ImgButtonPrint_Click" 
            Height="18px" Width="23px" ImageAlign="AbsMiddle" /><asp:Button
                ID="b1" runat="server" Text="b" Visible="false" />
    </div>
    <div>
        <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
            PrintMode="Pdf" />--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="600px">
        </rsweb:ReportViewer>--%>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="500px" Width="100%"
            InteractivityPostBackMode="AlwaysSynchronous" Font-Names="Verdana" Font-Size="8pt"
            ProcessingMode="Local" AsyncRendering="False" SizeToReportContent="true" ShowPrintButton="true">
           
        </rsweb:ReportViewer>
        <iframe id="frmPrint" name="IframeName" width="0" height="0" runat="server"></iframe>

    </div>
</asp:Content>
