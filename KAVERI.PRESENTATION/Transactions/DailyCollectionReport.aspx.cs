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
using KAVERI.UTILITY;
public partial class Transactions_DailyCollectionReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrMsg.Visible = false;
        try
        {
            if (!IsPostBack)
            {
                CommonBLL CommonBLL = new CommonBLL();

                CommonClass.LoadDropdownListWithoutSelect(ddlPendingAcademic, CommonBLL.GetParameterDetails("Acedemic"), "ParameterName", "ParameterValue");
                CommonClass.LoadDropdownListWithoutSelect(ddlAcedamic, CommonBLL.GetParameterDetails("Acedemic"), "ParameterName", "ParameterValue");
                CommonClass.LoadDropdownListWithoutSelect(ddlSWAcademicYear, CommonBLL.GetParameterDetails("Acedemic"), "ParameterName", "ParameterValue");
                CommonClass.LoadDropdownListWithoutSelect(ddlSRAcademicYear, CommonBLL.GetParameterDetails("Acedemic"), "ParameterName", "ParameterValue");
                CommonClass.LoadDropdownListWithoutSelect(PRddlAcademicYear, CommonBLL.GetParameterDetails("Acedemic"), "ParameterName", "ParameterValue");

                CommonClass.LoadDropdownList(ddlAge, CommonBLL.GetParameterDetails("Age"), "ParameterName", "ParameterValue");
                CommonClass.LoadDropdownList(ddlBelongsTo, CommonBLL.GetParameterDetails("BelongsTo"), "ParameterName", "ParameterValue");

                CastMasterBLL CastMasterBLL = new CastMasterBLL();
                CastMasterDO CastMasterDO = new CastMasterDO();
                CastMasterDO.CastCode = "";

                CommonClass.LoadDropdownList(ddlCaste, CastMasterBLL.GetActiveCastMasterDetails(CastMasterDO), "CastName", "CastId");

                CommonClass.LoadDropdownList(ddlGender, CommonBLL.GetParameterDetails("Gender"), "ParameterName", "ParameterValue");

                StandardMasterBLL StandardMasterBLL = new StandardMasterBLL();
                StandardMasterDO StandardMasterDO = new StandardMasterDO();
                StandardMasterDO.StandardCode = "";

                CommonClass.LoadDropdownList(ddlStandard, StandardMasterBLL.GetActiveStandardMasterDetails(StandardMasterDO), "StandardName", "StandardId");
                CommonClass.LoadDropdownList(ddlPendingStandard, StandardMasterBLL.GetActiveStandardMasterDetails(StandardMasterDO), "StandardName", "StandardId");

                txtFromDate.Text = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString(), new CultureInfo("en-GB", true)).ToShortDateString();
                txtToDate.Text = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString(), new CultureInfo("en-GB", true)).ToShortDateString();

                //PRtxtFromDate.Text = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString(), new CultureInfo("en-GB", true)).ToShortDateString();
                //PRtxtToDate.Text = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString(), new CultureInfo("en-GB", true)).ToShortDateString();


                if (RBDailyCollection.Checked)
                {
                    DailyCollection.Visible = true;
                    PaymentReceipt.Visible = false;
                }


            }
            #region Registration Number Load
            if (Session["Selected_Student"] != null)
            {
                txtRegNoForReceipt.Text = Session["Selected_Student"].ToString();
                txtStudentName.Text = Session["StudentName"].ToString();
                txtFatherName.Text = Session["FatherName"].ToString();
                Session["Selected_Student"] = null;
                Session["StudentName"] = null;
                Session["FatherName"] = null;
            }
            #endregion

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
            if (RBDailyCollection.Checked)
            {
                #region DAILY COLLECTION
                DataTable DtReport = new DataTable();
                FeeCollectionBLL FeeCollectionBLL = new FeeCollectionBLL();
                FeeCollectionDO FeeCollectionDO = new FeeCollectionDO();
                FeeCollectionDO.FromDate = Convert.ToDateTime(txtFromDate.Text, new CultureInfo("en-GB", true)).ToString("MM-dd-yyyy hh:mm:ss");
                FeeCollectionDO.ToDate = Convert.ToDateTime(txtToDate.Text, new CultureInfo("en-GB", true)).ToString("MM-dd-yyyy hh:mm:ss");
                FeeCollectionDO.AcademicYearId = Convert.ToInt32(ddlAcedamic.SelectedValue);

                DtReport = FeeCollectionBLL.GetRptFeeCollectionDetails(FeeCollectionDO);

                if (DtReport.Rows.Count > 0)
                {
                    DtReport.Columns.Add("FromDate");
                    DtReport.Columns.Add("ToDate");
                    for (int i = 0; i < DtReport.Rows.Count; i++)
                    {
                        DtReport.Rows[i]["FromDate"] = txtFromDate.Text;
                        DtReport.Rows[i]["ToDate"] = txtToDate.Text;
                    }
                    DtReport.TableName = "DtCollection";
                    DtReport.AcceptChanges();


                    DataSet DsReport = new DataSet();
                    DsReport.Tables.Add(DtReport);
                    Session["dspendingcollection"] = DsReport;

                    //Response.Redirect("~/ReportMaster/Display.aspx?print=5");

                    string navigateURL = string.Empty;
                    //navigateURL = @"." + "/" + "Display.aspx?print=5";
                    if (!ChkHeadwise.Checked)
                        navigateURL = "~/ReportMaster/DisplayReportPopUp.aspx?print=5";
                    else
                        navigateURL = "~/ReportMaster/DisplayReportPopUp.aspx?print=9";
                    navigateURL = Page.ResolveClientUrl(navigateURL);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:OpenPopup('" + navigateURL + "')", true);
                }
                else
                {
                    ErrMsg.Visible = true;
                    ErrMsg.Text = "No records to display";
                }
                #endregion
            }
            else if (RBPayReceipt.Checked)
            {
                #region PAYMENT RECEIPT DUPLICATE
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
                #endregion
            }
            else if (RBRegister.Checked)
            {
                #region SCHOOL REGISTER
                DataTable DtReport = new DataTable();
                FeeCollectionBLL FeeCollectionBLL = new FeeCollectionBLL();
                AdmissionReportDO AdmissionReportDO = new AdmissionReportDO();
                if (ddlGender.SelectedValue != "-1")
                    AdmissionReportDO.Sex = Convert.ToInt32(ddlGender.SelectedValue);
                if (ddlAge.SelectedValue != "-1")
                    AdmissionReportDO.Age = Convert.ToInt32(ddlAge.SelectedItem.Text);
                if (ddlCaste.SelectedValue != "-1")
                    AdmissionReportDO.Caste = Convert.ToInt32(ddlCaste.SelectedValue);
                if (ddlStandard.SelectedValue != "-1")
                    AdmissionReportDO.StandardId = Convert.ToInt32(ddlStandard.SelectedValue);

                if (ddlBelongsTo.SelectedValue != "-1")
                    AdmissionReportDO.BelongsTo = Convert.ToInt32(ddlBelongsTo.SelectedValue);

                AdmissionReportDO.AcademicYear = Convert.ToInt32(ddlSRAcademicYear.SelectedValue);

                DtReport = FeeCollectionBLL.GetRptRegistrationDetails(AdmissionReportDO);

                DtReport.TableName = "DtSchoolRegister";
                DtReport.AcceptChanges();


                DataSet DsReport = new DataSet();
                DsReport.Tables.Add(DtReport);
                Session["dspendingcollection"] = DsReport;

                string navigateURL = string.Empty;
                //navigateURL = @"." + "/" + "Display.aspx?print=5";
                navigateURL = "~/ReportMaster/DisplayReportPopUp.aspx?print=6";
                //Response.Redirect(navigateURL);
                navigateURL = Page.ResolveClientUrl(navigateURL);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:OpenPopup('" + navigateURL + "')", true);

                ddlGender.SelectedValue = "-1";
                ddlAge.SelectedValue = "-1";
                ddlCaste.SelectedValue = "-1";
                ddlStandard.SelectedValue = "-1";
                ddlBelongsTo.SelectedValue = "-1";
                #endregion
            }
            else if (RBStandardwise.Checked)
            {
                #region STANDARDWISE STUDENT REGISTER
                DataTable DtReport = new DataTable();
                FeeCollectionBLL FeeCollectionBLL = new FeeCollectionBLL();
                AdmissionReportDO AdmissionReportDO = new AdmissionReportDO();
                if (ddlGender.SelectedValue != "-1")
                    AdmissionReportDO.Sex = Convert.ToInt32(ddlGender.SelectedValue);
                if (ddlAge.SelectedValue != "-1")
                    AdmissionReportDO.Age = Convert.ToInt32(ddlAge.SelectedValue);
                if (ddlCaste.SelectedValue != "-1")
                    AdmissionReportDO.Caste = Convert.ToInt32(ddlCaste.SelectedValue);
                if (ddlStandard.SelectedValue != "-1")
                    AdmissionReportDO.StandardId = Convert.ToInt32(ddlStandard.SelectedValue);

                AdmissionReportDO.AcademicYear = Convert.ToInt32(ddlSWAcademicYear.SelectedValue);

                DtReport = FeeCollectionBLL.GetRptRegistrationDetails(AdmissionReportDO);


                DtReport.TableName = "DtSchoolRegister";
                DtReport.AcceptChanges();

                DataSet DsReport = new DataSet();
                DsReport.Tables.Add(DtReport);

                Session["dspendingcollection"] = DsReport;

                string navigateURL = string.Empty;
                //navigateURL = @"." + "/" + "Display.aspx?print=5";
                navigateURL = "~/ReportMaster/DisplayReportPopUp.aspx?print=7";
                //Response.Redirect(navigateURL);
                navigateURL = Page.ResolveClientUrl(navigateURL);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:OpenPopup('" + navigateURL + "')", true);


                ddlGender.SelectedValue = "-1";
                ddlAge.SelectedValue = "-1";
                ddlCaste.SelectedValue = "-1";
                ddlStandard.SelectedValue = "-1";
                #endregion
            }
            else if (RBPending.Checked)
            {
                #region PENDING COLLECTION
                DataTable DtReport = new DataTable();
                FeeCollectionBLL FeeCollectionBLL = new FeeCollectionBLL();
                FeeCollectionDO FeeCollectionDO = new FeeCollectionDO();
                FeeCollectionDO.StandardId = Convert.ToInt32(ddlPendingStandard.SelectedValue);
                FeeCollectionDO.AcademicYearId = Convert.ToInt32(ddlPendingAcademic.SelectedValue);

                DtReport = FeeCollectionBLL.GetRptPendingCollectionDetails(FeeCollectionDO);

                if (DtReport.Rows.Count > 0)
                {
                    DtReport.TableName = "DtCollection";
                    DtReport.AcceptChanges();

                    DataSet DsReport = new DataSet();
                    DsReport.Tables.Add(DtReport);
                    Session["dspendingcollection"] = DsReport;

                    //Response.Redirect("~/ReportMaster/Display.aspx?print=5");

                    string navigateURL = string.Empty;
                    //navigateURL = @"." + "/" + "Display.aspx?print=5";
                    navigateURL = "~/ReportMaster/DisplayReportPopUp.aspx?print=8";
                    navigateURL = Page.ResolveClientUrl(navigateURL);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:OpenPopup('" + navigateURL + "')", true);
                }
                else
                {
                    ErrMsg.Visible = true;
                    ErrMsg.Text = "No records to display";
                }
                #endregion
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    protected void RBDailyCollection_CheckedChanged(object sender, EventArgs e)
    {
        if (RBDailyCollection.Checked)
        {
            PendingDiv.Visible = false;
            DailyCollection.Visible = true;
            PaymentReceipt.Visible = false;
            SRDiv.Visible = false;
            SWDiv.Visible = false;
        }
    }
    protected void RBPayReceipt_CheckedChanged(object sender, EventArgs e)
    {
        if (RBPayReceipt.Checked)
        {
            PendingDiv.Visible = false;
            DailyCollection.Visible = false;
            PaymentReceipt.Visible = true;
            SRDiv.Visible = false;
            SWDiv.Visible = false;
        }
    }
    protected void RBRegister_CheckedChanged(object sender, EventArgs e)
    {
        if (RBRegister.Checked)
        {
            DailyCollection.Visible = false;
            PaymentReceipt.Visible = false;
            SRDiv.Visible = true;
            SWDiv.Visible = false;
            PendingDiv.Visible = false;
        }
    }
    protected void RBStandardwise_CheckedChanged(object sender, EventArgs e)
    {
        if (RBStandardwise.Checked)
        {
            DailyCollection.Visible = false;
            PaymentReceipt.Visible = false;
            SRDiv.Visible = false;
            PendingDiv.Visible = false;
            SWDiv.Visible = true;
        }
    }
    protected void RBPending_CheckedChanged(object sender, EventArgs e)
    {
        if (RBPending.Checked)
        {
            DailyCollection.Visible = false;
            PaymentReceipt.Visible = false;
            SRDiv.Visible = false;
            SWDiv.Visible = false;
            PendingDiv.Visible = true;
        }
    }
    protected void lbtnRegionSearch_Click(object sender, EventArgs e)
    {
        string navigateURL = string.Empty;
        Session["StandardId"] = null;
        //Convert.ToInt32(txtRegistrationNo.Text.Split('/')[0].ToString())
        navigateURL = @"." + "/" + "StudentSearch.aspx";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:OpenPopup('" + navigateURL + "')", true);
    }
    public static DataTable CreateTable(string Query, DataTable DataTableOriginal)
    {
        DataTable DataTableDuplicate = new DataTable();
        // the clone method copies the structer of datatableorginal to datatableduplicate
        DataTableDuplicate = DataTableOriginal.Clone();
        foreach (DataRow dr in DataTableOriginal.Select(Query))
        {
            //importrow method copies the datarow to datatableduplicate which has the correct structure
            DataTableDuplicate.ImportRow(dr);
        }

        return DataTableDuplicate;
    }
    protected void PRbtnGenerate_Click(object sender, EventArgs e)
    {
        if (!AdhocCheckBox.Checked)
        {
            if (txtRegNoForReceipt.Text == "")
            {
                ErrMsg.Visible = true;
                ErrMsg.Text = "Please select the registration No.";
            }
            else
            {
                DataTable DtReceipts = new DataTable();
                FeeCollectionBLL FeeCollectionBLL = new FeeCollectionBLL();
                DtReceipts = FeeCollectionBLL.GetReportReceiptDetails(Convert.ToInt32(txtRegNoForReceipt.Text.Split('/')[0].ToString()), "", "", Convert.ToInt32(PRddlAcademicYear.SelectedValue));


                GVReceipt.DataSource = CreateTable("ACademicYearId = " + PRddlAcademicYear.SelectedValue, DtReceipts);
                GVReceipt.DataBind();
            }
        }
        else
        {
            if ((txtStudentName.Text == "") || (txtFatherName.Text == ""))
            {
                ErrMsg.Visible = true;
                ErrMsg.Text = "Please enter the student name and father name.";
            }
            else
            {
                DataTable DtReceipts = new DataTable();
                FeeCollectionBLL FeeCollectionBLL = new FeeCollectionBLL();
                DtReceipts = FeeCollectionBLL.GetReportReceiptDetails(0, txtStudentName.Text, txtFatherName.Text, Convert.ToInt32(PRddlAcademicYear.SelectedValue));


                GVReceipt.DataSource = CreateTable("ACademicYearId = " + PRddlAcademicYear.SelectedValue, DtReceipts);
                GVReceipt.DataBind();
            }
        }
    }
    protected void chkSelect_OnClick(Object sender, EventArgs e)
    {
        try
        {

            #region CREATE DATATABLE FOR PRINT
            DataTable DtPrint = new DataTable();
            DtPrint.Columns.Add("FeeName", typeof(string));
            DtPrint.Columns.Add("Amount", typeof(decimal));
            DtPrint.Columns.Add("PendingAmount", typeof(decimal));
            DtPrint.Columns.Add("TotalFeeAmount", typeof(decimal));
            DtPrint.Columns.Add("Standard", typeof(string));
            DtPrint.Columns.Add("StudentName", typeof(string));
            DtPrint.Columns.Add("FatherName", typeof(string));
            DtPrint.Columns.Add("AdmissionNo", typeof(string));
            DtPrint.Columns.Add("PayMode", typeof(string));
            DtPrint.Columns.Add("AcademicYear", typeof(string));
            DtPrint.Columns.Add("AmountInWords", typeof(string));
            DtPrint.Columns.Add("ReceiptNo", typeof(string));


            DtPrint.Columns.Add("ChequeNo", typeof(string));
            DtPrint.Columns.Add("ChequeDate", typeof(string));
            DtPrint.Columns.Add("ChequeBank", typeof(string));
            DtPrint.Columns.Add("ReceiptDate", typeof(string));
            #endregion


            FeeCollectionBLL FeeCollectionBLL = new FeeCollectionBLL();
            DataTable DtReceipt = new DataTable();
            if (!AdhocCheckBox.Checked)
                DtReceipt = FeeCollectionBLL.GetReportReceiptDetails(Convert.ToInt32(txtRegNoForReceipt.Text.Split('/')[0].ToString()), ((System.Web.UI.WebControls.LinkButton)(sender)).Text);
            else
                DtReceipt = FeeCollectionBLL.GetReportReceiptDetails(0, ((System.Web.UI.WebControls.LinkButton)(sender)).Text);
            string strType = "";
            string ReportFormatId = "";
            Int64 SumAmount = 0;
            foreach (DataRow drReceipt in DtReceipt.Rows)
            {

                SumAmount += Convert.ToInt64(drReceipt["TotalAmountPaid"]);

                Converter converter = new Converter(Convert.ToInt64(SumAmount), KAVERI.UTILITY.Converter.ConvertStyle.Asian);
                strType = drReceipt["PayType"].ToString();
                ReportFormatId = drReceipt["ReportFormatId"].ToString();
                DtPrint.Rows.Add(drReceipt["FeeName"].ToString(),
                                             drReceipt["TotalAmountPaid"],
                                             0,
                                             0,
                                             drReceipt["StandardName"],
                                             drReceipt["StudentName"],
                                             drReceipt["FatherName"],
                                             (AdhocCheckBox.Checked ? "" : Convert.ToInt32(txtRegNoForReceipt.Text.Split('/')[0].ToString()).ToString()),
                                             drReceipt["PaymentMode"],
                                             PRddlAcademicYear.SelectedItem.Text,
                                             converter.ConvertTo(),
                                             ((System.Web.UI.WebControls.LinkButton)(sender)).Text,
                                             drReceipt["ChequeNo"],
                                             drReceipt["ChequeDate"],
                                             drReceipt["ChequeBank"],
                                             drReceipt["CreatedOn"]);
            }
            DtPrint.TableName = "DtFeeCollection";
            DtPrint.AcceptChanges();

            #region PRINT
            DataSet DsReport = new DataSet();
            DsReport.Tables.Add(DtPrint);
            Session["dspendingcollection"] = DsReport;
            if ((strType == "Detailed") || (strType == "Adhoc"))
            {
                //Response.Redirect("~/ReportMaster/Display.aspx?print=1");
                string navigateURL = string.Empty;
                //navigateURL = @"." + "/" + "Display.aspx?print=5";
                navigateURL = "~/ReportMaster/DisplayReportPopUp.aspx?print=1";
                //Response.Redirect(navigateURL);
                navigateURL = Page.ResolveClientUrl(navigateURL);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:OpenPopup('" + navigateURL + "')", true);

            }
            else
            {
                if (Convert.ToString(ReportFormatId) == "1")
                {
                    string navigateURL = string.Empty;

                    navigateURL = "~/ReportMaster/DisplayReportPopUp.aspx?print=2";
                    //Response.Redirect(navigateURL);
                    navigateURL = Page.ResolveClientUrl(navigateURL);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:OpenPopup('" + navigateURL + "')", true);
                }
                //Response.Redirect("~/ReportMaster/Display.aspx?print=2");
                else if (Convert.ToString(ReportFormatId) == "2")
                {
                    string navigateURL = string.Empty;
                    //navigateURL = @"." + "/" + "Display.aspx?print=5";
                    navigateURL = "~/ReportMaster/DisplayReportPopUp.aspx?print=3";
                    //Response.Redirect(navigateURL);
                    navigateURL = Page.ResolveClientUrl(navigateURL);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:OpenPopup('" + navigateURL + "')", true);

                }
                else if (Convert.ToString(ReportFormatId) == "3")
                {
                    string navigateURL = string.Empty;
                    //navigateURL = @"." + "/" + "Display.aspx?print=5";
                    navigateURL = "~/ReportMaster/DisplayReportPopUp.aspx?print=4";
                    //Response.Redirect(navigateURL);
                    navigateURL = Page.ResolveClientUrl(navigateURL);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:OpenPopup('" + navigateURL + "')", true);

                }
            }
            #endregion

        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }

    protected void AdhocCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (AdhocCheckBox.Checked)
        {
            txtRegNoForReceipt.Text = "";
            txtRegNoForReceipt.Enabled = false;
            txtStudentName.Enabled = true;
            txtFatherName.Enabled = true;
            txtStudentName.ReadOnly = false;
            txtFatherName.ReadOnly = false;
            txtStudentName.Text = "";
            txtFatherName.Text = "";
        }
        else
        {
            txtRegNoForReceipt.Text = "";
            txtRegNoForReceipt.Enabled = true;
            txtStudentName.Enabled = false;
            txtFatherName.Enabled = false;
            txtStudentName.ReadOnly = true;
            txtFatherName.ReadOnly = true;
        }
    }
}
