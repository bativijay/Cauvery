using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KAVERI.BLL.Transactions;


using System.ComponentModel;


using KAVERI.DO.Transactions;
using KAVERI.DO;
using System.Data;
using KAVERI.BLL;
using KAVERI.DO.Masters;
using System.Globalization;
using System.Web.UI.HtmlControls;

public partial class Transactions_PaymentReceiptReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrMsg.Visible = false;
        try
        {
            if (!IsPostBack)
            {
                CommonBLL CommonBLL = new CommonBLL();
                CommonClass.LoadDropdownListWithoutSelect(ddlAcedamic, CommonBLL.GetParameterDetails("Acedemic"), "ParameterName", "ParameterValue");

                txtFromDate.Text = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString(), new CultureInfo("en-GB", true)).ToShortDateString();
                txtToDate.Text = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString(), new CultureInfo("en-GB", true)).ToShortDateString();

            }

        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }


    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable DtReport = new DataTable();
            FeeCollectionBLL FeeCollectionBLL = new FeeCollectionBLL();
            FeeCollectionDO FeeCollectionDO = new FeeCollectionDO();
            FeeCollectionDO.FromDate = Convert.ToDateTime(txtFromDate.Text, new CultureInfo("en-GB", true)).ToString("MM-dd-yyyy hh:mm:ss");
            FeeCollectionDO.ToDate = Convert.ToDateTime(txtToDate.Text, new CultureInfo("en-GB", true)).ToString("MM-dd-yyyy hh:mm:ss");
            FeeCollectionDO.AcademicYearId = Convert.ToInt32(ddlAcedamic.SelectedValue);

            DtReport = FeeCollectionBLL.GetRptFeeCollectionDetails(FeeCollectionDO);

            DtReport.TableName = "DtCollection";
            DtReport.AcceptChanges();


            DataSet DsReport = new DataSet();
            DsReport.Tables.Add(DtReport);
            Session["dspendingcollection"] = DsReport;

            Response.Redirect("~/ReportMaster/Display.aspx?print=5");
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
}
