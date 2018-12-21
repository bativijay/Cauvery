using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Report_Master_Display : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) //check if the webpage is loaded for the first time.
        {
            ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState
        }
        string myPath = "";
        DataSet ds = new DataSet();
        //CrystalDecisions.CrystalReports.Engine.ReportDocument rptReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        
        switch (Request.QueryString["print"])
        {
            case "1":
                ds = (DataSet)Session["dspendingcollection"];
                myPath = Server.MapPath("").Replace("ReportMaster", "Reports") + @"\" + "Collection.rpt";
                //rptReport.Load(myPath);
                //rptReport.SetDatabaseLogon("loginid", "password");
                //rptReport.Database.Tables["DtFeeCollection"].SetDataSource(ds);
                //CrystalReportViewer1.DisplayGroupTree = false;

                //CrystalReportViewer1.ReportSource = rptReport;
                //CrystalReportViewer1.DataBind();
                break;
            case "2":
                ds = (DataSet)Session["dspendingcollection"];
                myPath = Server.MapPath("").Replace("ReportMaster", "Reports") + @"\" + "DirectCollectionDFFeeReport.rpt";
                //rptReport.Load(myPath);
                //rptReport.SetDatabaseLogon("loginid", "password");
                //rptReport.Database.Tables["DtFeeCollection"].SetDataSource(ds);
                //CrystalReportViewer1.ReportSource = rptReport;
                //CrystalReportViewer1.DataBind();
                break;            
            case "3":
                ds = (DataSet)Session["dspendingcollection"];
                myPath = Server.MapPath("").Replace("ReportMaster", "Reports") + @"\" + "DirectCollectionSMCFeeReport.rpt";
                //rptReport.Load(myPath);
                //rptReport.SetDatabaseLogon("loginid", "password");
                //rptReport.Database.Tables["DtFeeCollection"].SetDataSource(ds);
                //CrystalReportViewer1.ReportSource = rptReport;
                //CrystalReportViewer1.DataBind();
                break;
            case "4":
                ds = (DataSet)Session["dspendingcollection"];
                myPath = Server.MapPath("").Replace("ReportMaster", "Reports") + @"\" + "DirectCollectionPDFeeReport.rpt";
                //rptReport.Load(myPath);
                //rptReport.SetDatabaseLogon("loginid", "password");
                //rptReport.Database.Tables["DtFeeCollection"].SetDataSource(ds);
                //CrystalReportViewer1.ReportSource = rptReport;
                //CrystalReportViewer1.DataBind();
                break;
            case "5":
                ds = (DataSet)Session["dspendingcollection"];
                myPath = Server.MapPath("").Replace("ReportMaster", "Reports") + @"\" + "CollectionReport.rpt";
                //rptReport.Load(myPath);
                //rptReport.SetDatabaseLogon("loginid", "password");
                //rptReport.Database.Tables["DtCollection"].SetDataSource(ds);
                //CrystalReportViewer1.ReportSource = rptReport;
                //CrystalReportViewer1.DataBind();
                break;
            default:
                break;
        }
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
}
