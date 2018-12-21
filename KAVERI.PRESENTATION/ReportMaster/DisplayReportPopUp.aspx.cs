using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Reflection;
using System.IO;
using Microsoft.Reporting.WebForms;

using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
public partial class Report_Master_Display : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) //check if the webpage is loaded for the first time.
        {
            ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState

            string myPath = "";
            DataSet ds = new DataSet();
            //CrystalDecisions.CrystalReports.Engine.ReportDocument rptReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            ReportDataSource datasource;
            switch (Request.QueryString["print"])
            {
                case "1":
                    ds = (DataSet)Session["dspendingcollection"];
                    /* myPath = Server.MapPath("").Replace("ReportMaster", "Reports") + @"\" + "Collection.rpt";
                     rptReport.Load(myPath);
                     rptReport.SetDatabaseLogon("loginid", "password");
                     rptReport.Database.Tables["DtFeeCollection"].SetDataSource(ds);
                     CrystalReportViewer1.DisplayGroupTree = false;
                     CrystalReportViewer1.ReportSource = rptReport;
                     CrystalReportViewer1.DataBind();*/
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Collection.rdlc");
                    datasource = new ReportDataSource("DtCollection", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    break;
                case "2":
                    ds = (DataSet)Session["dspendingcollection"];
                    //myPath = Server.MapPath("").Replace("ReportMaster", "Reports") + @"\" + "DirectCollectionDFFeeReport.rpt";
                    //rptReport.Load(myPath);
                    //rptReport.SetDatabaseLogon("loginid", "password");
                    //rptReport.Database.Tables["DtFeeCollection"].SetDataSource(ds);
                    //CrystalReportViewer1.ReportSource = rptReport;
                    //CrystalReportViewer1.DataBind();
                    break;
                case "3":
                    ds = (DataSet)Session["dspendingcollection"];
                    //myPath = Server.MapPath("").Replace("ReportMaster", "Reports") + @"\" + "DirectCollectionSMCFeeReport.rpt";
                    //rptReport.Load(myPath);
                    //rptReport.SetDatabaseLogon("loginid", "password");
                    //rptReport.Database.Tables["DtFeeCollection"].SetDataSource(ds);
                    //CrystalReportViewer1.ReportSource = rptReport;
                    //CrystalReportViewer1.DataBind();
                    break;
                case "4":
                    ds = (DataSet)Session["dspendingcollection"];
                    //myPath = Server.MapPath("").Replace("ReportMaster", "Reports") + @"\" + "DirectCollectionPDFeeReport.rpt";
                    //rptReport.Load(myPath);
                    //rptReport.SetDatabaseLogon("loginid", "password");
                    //rptReport.Database.Tables["DtFeeCollection"].SetDataSource(ds);
                    //CrystalReportViewer1.ReportSource = rptReport;
                    //CrystalReportViewer1.DataBind();
                    break;
                case "5":
                    ds = (DataSet)Session["dspendingcollection"];
                    /* myPath = Server.MapPath("").Replace("ReportMaster", "Reports") + @"\" + "CollectionReport.rpt";
                     rptReport.Load(myPath);
                     rptReport.SetDatabaseLogon("loginid", "password");
                     rptReport.Database.Tables["DtCollection"].SetDataSource(ds);
                     CrystalReportViewer1.ReportSource = rptReport;
                     CrystalReportViewer1.DataBind();
                     CrystalReportViewer1.RefreshReport();*/
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/CollectionReport.rdlc");
                    datasource = new ReportDataSource("DtCollection", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    break;
                case "6":
                    ds = (DataSet)Session["dspendingcollection"];
                    /* myPath = Server.MapPath("").Replace("ReportMaster", "Reports") + @"\" + "SchoolRegister.rpt";
                     rptReport.Load(myPath);
                     rptReport.SetDatabaseLogon("loginid", "password");
                     rptReport.Database.Tables["DtSchoolRegister"].SetDataSource(ds);
                     CrystalReportViewer1.ReportSource = rptReport;
                     CrystalReportViewer1.DataBind();
                     CrystalReportViewer1.RefreshReport();*/
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/SchoolRegister.rdlc");
                    datasource = new ReportDataSource("DtSchoolRegister", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    break;
                case "7":
                    ds = (DataSet)Session["dspendingcollection"];
                    /*myPath = Server.MapPath("").Replace("ReportMaster", "Reports") + @"\" + "StandardRegister.rpt";
                    rptReport.Load(myPath);
                    rptReport.SetDatabaseLogon("loginid", "password");
                    rptReport.Database.Tables["DtSchoolRegister"].SetDataSource(ds);
                    CrystalReportViewer1.ReportSource = rptReport;
                    CrystalReportViewer1.DataBind();
                    CrystalReportViewer1.RefreshReport();*/
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/StandardRegister.rdlc");
                    datasource = new ReportDataSource("DtSchoolRegister", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    break;
                case "8":
                    ds = (DataSet)Session["dspendingcollection"];
                    /*DataTable DtTemp = ds.Tables[0].Clone();
                    myPath = Server.MapPath("").Replace("ReportMaster", "Reports") + @"\" + "PendingCollectionReport.rpt";
                    rptReport.Load(myPath);
                    rptReport.SetDatabaseLogon("loginid", "password");
                    rptReport.Database.Tables["DtCollection"].SetDataSource(ds);
                    CrystalReportViewer1.DisplayGroupTree = false;
                    CrystalReportViewer1.ReportSource = rptReport;
                    CrystalReportViewer1.DataBind();*/
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/PendingCollectionReport.rdlc");
                    datasource = new ReportDataSource("DtCollection", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    break;
                case "9":
                    ds = (DataSet)Session["dspendingcollection"];
                    /*myPath = Server.MapPath("").Replace("ReportMaster", "Reports") + @"\" + "CollectionSummaryHeadwiseReport.rpt";
                    rptReport.Load(myPath);
                    rptReport.SetDatabaseLogon("loginid", "password");
                    rptReport.Database.Tables["DtCollection"].SetDataSource(ds);
                    CrystalReportViewer1.ReportSource = rptReport;
                    CrystalReportViewer1.DataBind();
                    CrystalReportViewer1.RefreshReport();*/
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/CollectionSummaryHeadwiseReport.rdlc");
                    datasource = new ReportDataSource("DtCollection", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    break;
                default:
                    break;
            }
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        //CrystalReportViewer1.DisplayToolbar = true;
        //CrystalReportViewer1.HasSearchButton = false;
        //CrystalReportViewer1.HasExportButton = true;
        //CrystalReportViewer1.HasPrintButton = true;
        //CrystalReportViewer1.HasToggleGroupTreeButton = false;
        //CrystalReportViewer1.DisplayGroupTree = false;
    }
    private void customizeToolbar()
    {
        //System.Web.UI.Control oControl = CrystalReportViewer1.Controls[2];
        //Button oButton = new Button();
        //oButton.ID = "newButton";
        //oButton.Text = "My New Button";
        //oControl.Controls.Add(oButton);
    }
    protected void BtnExport_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void BackButton_Click(object sender, EventArgs e)
    {
        if (ViewState["PreviousPage"] != null)	//Check if the ViewState 
        //contains Previous page URL
        {
            Response.Redirect(ViewState["PreviousPage"].ToString());//Redirect to 
            //Previous page by retrieving the PreviousPage Url from ViewState.
        }
    }
    protected void ImgButtonPrint_Click(object sender, ImageClickEventArgs e)
    {
        PrintButton_Click();
    }

    protected void PrintButton_Click()
    {
        // PrintReportFromPDF(this.CurrentUser, mainReportViewer, frmPrint);
        string documentsFolder = Server.MapPath("Documents");
        string reportOutputFilePath = Path.Combine(documentsFolder, "ReportOutput_" + this.UniqueID + ".pdf");
        string reportPrintFilePath = Path.Combine(documentsFolder, "ReportPrint_" + this.UniqueID + ".pdf");
        Warning[] warnings;
        string[] streamids;
        string mimeType;
        string encoding;
        string extension;
        PrintReport.PrintToPrinter(ReportViewer1.LocalReport);
        /*
                byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
                FileStream fs = new FileStream(reportOutputFilePath, FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();

                //Open exsisting pdf
                Document document = new Document(PageSize.LETTER);
                PdfReader reader = new PdfReader(reportOutputFilePath);
                //Getting a instance of new pdf wrtiter
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(reportPrintFilePath, FileMode.Create));
                document.Open();
                PdfContentByte cb = writer.DirectContent;

                int i = 0;
                int p = 0;
                int n = reader.NumberOfPages;
                Rectangle psize = reader.GetPageSize(1);

                float width = psize.Width;
                float height = psize.Height;

                //Add Page to new document
                while (i < n)
                {
                    document.NewPage();
                    p++;
                    i++;

                    PdfImportedPage page1 = writer.GetImportedPage(reader, i);
                    cb.AddTemplate(page1, 0, 0);
                }

                //Attach javascript to the document
                PdfAction jAction = PdfAction.JavaScript("this.print(true);\r", writer);
                writer.AddJavaScript(jAction);
                document.Close();

                //Attach pdf to the iframe
                frmPrint.Attributes["src"] = "../ReportMAster/Documents/" + "ReportPrint_" + this.UniqueID + ".pdf";
         */
    }
}
