using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KAVERI.BLL.Transactions;

using KAVERI.DO.Transactions;
using KAVERI.DO;
using System.Data;
using KAVERI.BLL;
using KAVERI.DO.Masters;
using System.ComponentModel;
using System.Web.UI.HtmlControls;
using KAVERI.UTILITY;
using System.Configuration;
public partial class Transactions_FeeCollection : System.Web.UI.Page
{
    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrMsg.Visible = false;
        if (!IsPostBack)
        {
            ddlTemplate.Enabled = false;
            //HtmlAnchor htmlAnchor = positionLnk;
            //htmlAnchor.HRef = "javascript:OpenPopup('StudentSearch.aspx');";

            //positionLnk.Attributes.Add("onclick", "javascript:OpenPopup('StudentSearch.aspx');");
            btnSave.Visible = false;
            StandardMasterBLL StandardMasterBLL = new StandardMasterBLL();
            StandardMasterDO StandardMasterDO = new StandardMasterDO();
            StandardMasterDO.StandardCode = "";
            CommonClass.LoadDropdownList(ddlStandard, StandardMasterBLL.GetActiveStandardMasterDetails(StandardMasterDO), "StandardName", "StandardId");

            FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
            FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();
            FeeMappingHeaderDO.StandardId = Convert.ToInt32(ddlStandard.SelectedValue);
            if (RBDetailed.Checked)
                FeeMappingHeaderDO.FeeMode = 1;
            else
                FeeMappingHeaderDO.FeeMode = 2;
            CommonClass.LoadDropdownList(ddlTemplate, FeeMappingBLL.GetFeeMappingHeaderDetailsByStandardId(FeeMappingHeaderDO), "MappingTemplateName", "FeeMappingId");

            CommonBLL CommonBLL = new CommonBLL();
            CommonClass.LoadDropdownListWithoutSelect(ddlAcademic, CommonBLL.GetParameterDetails("Acedemic"), "ParameterName", "ParameterValue");
            CommonClass.LoadDropdownList(ddlPayMode, CommonBLL.GetParameterDetails("PaymentMode"), "ParameterName", "ParameterValue");

            ddlStandard.SelectedValue = "-1";
            if (RBDetailed.Checked)
            {
                btnGetDetails.Text = "Get Details";
                txtAmount.Visible = false;
                AmountLabel.Visible = false;
                ddlTemplate.Enabled = false;
            }
            else
            {
                btnGetDetails.Text = "Save";
                txtAmount.Visible = true;
                AmountLabel.Visible = true;
                ddlTemplate.Enabled = true;
            }
            txtChequeBank.Visible = false;
            txtChequeDate.Visible = false;
            txtChequeNo.Visible = false;
            ChequeDateLabel.Visible = false;
            ChequeNoLabel.Visible = false;
            ChequeBankLabel.Visible = false;

        }
        #region Registration Number Load
        if (Session["Selected_Student"] != null)
        {
            txtRegistrationNo.Text = Session["Selected_Student"].ToString();
            txtStudentName.Text = Session["StudentName"].ToString();
            txtFatherName.Text = Session["FatherName"].ToString();
            ddlAcademic.SelectedValue = Session["AcademicId"].ToString();
            if (RBDetailed.Checked)
            {
                ddlTemplate.SelectedValue = Session["TemplateId"].ToString();
            }
            Session["Selected_Student"] = null;
            Session["TemplateId"] = null;
            Session["StudentName"] = null;
            Session["FatherName"] = null;
        }
        #endregion
    }
    #endregion

    #region CONTROL EVENTS
    protected void lbtnRegionSearch_Click(object sender, EventArgs e)
    {
        if (ddlStandard.SelectedValue != "-1")
        {
            Session["StandardId"] = ddlStandard.SelectedValue;
            string navigateURL = string.Empty;
            navigateURL = @"." + "/" + "StudentSearch.aspx";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:OpenPopup('" + navigateURL + "')", true);
        }
        else
        {
            ErrMsg.Visible = true;
            ErrMsg.Text = "Select standard";
        }
    }
    protected void positionLnk_onclick(object sender, EventArgs e)
    {
        //Server side code here
    }
    protected void ImgBtnReCalculate_OnClick(object sender, ImageClickEventArgs e)
    {
        try
        {
            CalculateGridSum();
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateCollection())
            {
                int Result = 0;
                FeeCollectionBLL FeeCollectionBLL = new FeeCollectionBLL();
                FeeCollectionDO FeeCollectionDO = new FeeCollectionDO();

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

                #region COLLECTION HEADER
                FeeCollectionDO.AcademicYearId = Convert.ToInt32(ddlAcademic.SelectedValue);
                FeeCollectionDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
                FeeCollectionDO.FeeCollectionId = 0;
                FeeCollectionDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString());
                FeeCollectionDO.PaymentMode = Convert.ToInt32(ddlPayMode.SelectedValue);

                if (ddlPayMode.SelectedItem.Text != "Cash")
                {
                    FeeCollectionDO.ChequeDate = txtChequeDate.Text;
                    FeeCollectionDO.ChequeNo = txtChequeNo.Text;
                    FeeCollectionDO.ChequeBank = txtChequeBank.Text;
                }
                else
                {
                    FeeCollectionDO.ChequeDate = txtChequeDate.Text;
                    FeeCollectionDO.ChequeNo = txtChequeNo.Text;
                    FeeCollectionDO.ChequeBank = txtChequeBank.Text;
                }

                if ((!RBDirect.Checked) && (!RBAdhoc.Checked))
                {
                    FeeCollectionDO.PayType = "D";
                    FeeCollectionDO.ReceiptNo = FeeCollectionBLL.GetReceiptDetails(1).Rows[0]["Prefix"].ToString() + (Convert.ToInt32(FeeCollectionBLL.GetReceiptDetails(1).Rows[0]["RcptNo"].ToString()) + 1).ToString();
                }
                else
                {
                    if (RBAdhoc.Checked)
                    {
                        FeeCollectionDO.PayType = "A";
                    }
                    else
                    {
                        FeeCollectionDO.PayType = "N";
                    }
                    FeeCollectionDO.StudentName = txtStudentName.Text;
                    FeeCollectionDO.FatherName = txtFatherName.Text;

                    if (Convert.ToString(Session["ReportFormat"]) == "1")
                        FeeCollectionDO.ReceiptNo = FeeCollectionBLL.GetReceiptDetails(2).Rows[0]["Prefix"].ToString() + (Convert.ToInt32(FeeCollectionBLL.GetReceiptDetails(2).Rows[0]["RcptNo"].ToString()) + 1).ToString();
                    else if (Convert.ToString(Session["ReportFormat"]) == "2")
                        FeeCollectionDO.ReceiptNo = FeeCollectionBLL.GetReceiptDetails(3).Rows[0]["Prefix"].ToString() + (Convert.ToInt32(FeeCollectionBLL.GetReceiptDetails(3).Rows[0]["RcptNo"].ToString()) + 1).ToString();
                    else if (Convert.ToString(Session["ReportFormat"]) == "3")
                        FeeCollectionDO.ReceiptNo = FeeCollectionBLL.GetReceiptDetails(4).Rows[0]["Prefix"].ToString() + (Convert.ToInt32(FeeCollectionBLL.GetReceiptDetails(4).Rows[0]["RcptNo"].ToString()) + 1).ToString();

                    if (RBAdhoc.Checked)
                        FeeCollectionDO.ReceiptNo = FeeCollectionBLL.GetReceiptDetails(1).Rows[0]["Prefix"].ToString() + (Convert.ToInt32(FeeCollectionBLL.GetReceiptDetails(1).Rows[0]["RcptNo"].ToString()) + 1).ToString();

                }
                if (!RBAdhoc.Checked)
                    FeeCollectionDO.RegistrationId = Convert.ToInt32(txtRegistrationNo.Text.Split('/')[0].ToString());
                FeeCollectionDO.StandardId = Convert.ToInt32(ddlStandard.SelectedValue);
                FeeCollectionDO.TemplateId = Convert.ToInt32(ddlTemplate.SelectedValue);

                if ((!RBDirect.Checked) && (!RBAdhoc.Checked))
                {
                    CalculateGridSum();

                    GridViewRow row = GvFeeMaster.FooterRow;

                    FeeCollectionDO.TotalAmountPaid = Convert.ToDouble(((TextBox)row.FindControl("txtSumamount")).Text);
                    FeeCollectionDO.TotalFeeAmount = Convert.ToDouble(((TextBox)row.FindControl("txtSumFeeamount")).Text);
                    FeeCollectionDO.TotalPendingAmount = Convert.ToDouble(((TextBox)row.FindControl("txtSumPendingamount")).Text);
                }
                else
                {
                    FeeCollectionDO.TotalAmountPaid = Convert.ToDouble(txtAmount.Text);
                    FeeCollectionDO.TotalFeeAmount = Convert.ToDouble(txtAmount.Text);

                    FeeCollectionDetailsDO FeeCollectionDetailsDO;
                    FeeCollectionDO.FeeCollectionDetailsList = new List<FeeCollectionDetailsDO>();
                    FeeCollectionDetailsDO = new FeeCollectionDetailsDO();
                    FeeCollectionDetailsDO.FeeCollectionId = 0;
                    FeeCollectionDO.FeeCollectionDetailsList.Add(FeeCollectionDetailsDO);


                    Converter converter = new Converter(Convert.ToInt64(FeeCollectionDO.TotalAmountPaid), KAVERI.UTILITY.Converter.ConvertStyle.Asian);
                    FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();
                    FeeMappingHeaderDO.FeeMappingId = Convert.ToInt32(ddlTemplate.SelectedValue);
                    FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();

                    DtPrint.Rows.Add(FeeMappingBLL.GetFeeMappingDetailsByTempId(FeeMappingHeaderDO).Rows[0]["FeeName"].ToString(),
                                         FeeCollectionDO.TotalAmountPaid,
                                         0,
                                         FeeCollectionDO.TotalAmountPaid,
                                         ddlStandard.SelectedItem.Text,
                                         txtStudentName.Text,
                                         txtFatherName.Text,
                                         txtRegistrationNo.Text,
                                         ddlPayMode.SelectedItem.Text,
                                         ddlAcademic.SelectedItem.Text,
                                         converter.ConvertTo(),
                                         FeeCollectionDO.ReceiptNo,
                                         FeeCollectionDO.ChequeNo,
                                         FeeCollectionDO.ChequeDate,
                                         FeeCollectionDO.ChequeBank,
                                         DateTime.Now.ToShortDateString()
                                         );
                }
                FeeCollectionDO.TotalPendingAmount = FeeCollectionDO.TotalFeeAmount - FeeCollectionDO.TotalAmountPaid;

                #endregion

                if ((!RBDirect.Checked) && (!RBAdhoc.Checked))
                {
                    #region DETAIL SECTION
                    FeeCollectionDetailsDO FeeCollectionDetailsDO;
                    FeeCollectionDO.FeeCollectionDetailsList = new List<FeeCollectionDetailsDO>();

                    double TotalFeeAmount = 0;
                    foreach (GridViewRow gvrow in GvFeeMaster.Rows)
                    {
                        TotalFeeAmount += Convert.ToDouble(((TextBox)gvrow.FindControl("txtamount")).Text);
                    }
                    foreach (GridViewRow gvrow in GvFeeMaster.Rows)
                    {
                        FeeCollectionDetailsDO = new FeeCollectionDetailsDO();
                        FeeCollectionDetailsDO.FeeId = Convert.ToInt32(GvFeeMaster.DataKeys[gvrow.RowIndex].Values["FeeId"].ToString());
                        FeeCollectionDetailsDO.FeeCollectionId = Convert.ToInt32(GvFeeMaster.DataKeys[gvrow.RowIndex].Values["FeeCollectionId"].ToString());
                        FeeCollectionDetailsDO.FeeAmount = Convert.ToDouble(((TextBox)gvrow.FindControl("txtFeeamount")).Text);
                        FeeCollectionDetailsDO.PaidAmount = Convert.ToDouble(((TextBox)gvrow.FindControl("txtamount")).Text);
                        FeeCollectionDetailsDO.PendingAmount = FeeCollectionDetailsDO.FeeAmount - (FeeCollectionDetailsDO.PaidAmount + Convert.ToDouble(((TextBox)gvrow.FindControl("txtpaidamount")).Text));
                        FeeCollectionDetailsDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
                        FeeCollectionDetailsDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString());
                        FeeCollectionDetailsDO.ReceiptNo = FeeCollectionBLL.GetReceiptDetails(1).Rows[0]["Prefix"].ToString() + (Convert.ToInt32(FeeCollectionBLL.GetReceiptDetails(1).Rows[0]["RcptNo"].ToString()) + 1).ToString();
                        FeeCollectionDO.FeeCollectionDetailsList.Add(FeeCollectionDetailsDO);
                        Converter converter = new Converter(Convert.ToInt64(TotalFeeAmount), KAVERI.UTILITY.Converter.ConvertStyle.Asian);
                        if (FeeCollectionDetailsDO.PaidAmount > 0)
                        {
                            DtPrint.Rows.Add(((Label)gvrow.FindControl("lblFeeName")).Text,
                                             FeeCollectionDetailsDO.PaidAmount,
                                             FeeCollectionDetailsDO.PendingAmount,
                                             FeeCollectionDetailsDO.FeeAmount,
                                             ddlStandard.SelectedItem.Text,
                                             txtStudentName.Text,
                                             txtFatherName.Text,
                                             txtRegistrationNo.Text,
                                             ddlPayMode.SelectedItem.Text,
                                             ddlAcademic.SelectedItem.Text,
                                             converter.ConvertTo(),
                                             FeeCollectionDetailsDO.ReceiptNo,
                                             FeeCollectionDO.ChequeNo,
                                             FeeCollectionDO.ChequeDate,
                                             FeeCollectionDO.ChequeBank,
                                             DateTime.Now.ToShortDateString());
                        }
                    }

                    #endregion
                }



                DtPrint.TableName = "DtFeeCollection";
                DtPrint.AcceptChanges();
                Result = FeeCollectionBLL.InsertFeeCollection(FeeCollectionDO);

                if ((!RBDirect.Checked))
                {
                    FeeCollectionBLL.UpdateReceiptDetails(1);
                }
                else
                {
                    if (Convert.ToString(Session["ReportFormat"]) == "1")
                        FeeCollectionBLL.UpdateReceiptDetails(2);
                    else if (Convert.ToString(Session["ReportFormat"]) == "2")
                        FeeCollectionBLL.UpdateReceiptDetails(3);
                    else if (Convert.ToString(Session["ReportFormat"]) == "3")
                        FeeCollectionBLL.UpdateReceiptDetails(4);
                }
                if (Result > 0)
                {
                    string ErrMessage = string.Empty;
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMessage = "Data saved succesfully.";
                    ErrMsg.Text = ErrMessage;
                    btnSave.Enabled = false;
                    #region PRINT
                    DataSet DsReport = new DataSet();
                    DsReport.Tables.Add(DtPrint);
                    Session["dspendingcollection"] = DsReport;
                    if ((RBDetailed.Checked) || (RBAdhoc.Checked))
                    {
                        /*
                        Response.Redirect("~/ReportMaster/Display.aspx?print=1");*/
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
                        if (Convert.ToString(Session["ReportFormat"]) == "1")
                        /*Response.Redirect("~/ReportMaster/Display.aspx?print=2");*/
                        {
                            string navigateURL = string.Empty;

                            navigateURL = "~/ReportMaster/DisplayReportPopUp.aspx?print=2";
                            //Response.Redirect(navigateURL);
                            navigateURL = Page.ResolveClientUrl(navigateURL);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:OpenPopup('" + navigateURL + "')", true);
                        }
                        else if (Convert.ToString(Session["ReportFormat"]) == "2")
                        /*Response.Redirect("~/ReportMaster/Display.aspx?print=3");*/
                        {
                            string navigateURL = string.Empty;
                            //navigateURL = @"." + "/" + "Display.aspx?print=5";
                            navigateURL = "~/ReportMaster/DisplayReportPopUp.aspx?print=3";
                            //Response.Redirect(navigateURL);
                            navigateURL = Page.ResolveClientUrl(navigateURL);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:OpenPopup('" + navigateURL + "')", true);
                        }
                        else if (Convert.ToString(Session["ReportFormat"]) == "3")
                        /*Response.Redirect("~/ReportMaster/Display.aspx?print=4");*/
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
                    btnMainClear_Click(null, null);
                }
                else
                {
                    string ErrMessage = string.Empty;
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Red;
                    ErrMessage = "Error in saving data";
                    ErrMsg.Text = ErrMessage;
                }
            }

        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    protected void btnGetDetails_Click(object sender, EventArgs e)
    {
        try
        {
            try
            {
                if (ValidateGet())
                {
                    if ((RBDirect.Checked) || (RBAdhoc.Checked))
                    {
                        btnSave_Click(null, null);
                    }
                    else
                    {
                        FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
                        FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();
                        FeeCollectionBLL FeeCollectionBLL = new FeeCollectionBLL();
                        FeeCollectionDO FeeCollectionDO = new FeeCollectionDO();
                        DataTable DtCheck = new DataTable();

                        FeeCollectionDO.StandardId = Convert.ToInt32(ddlStandard.SelectedValue);
                        FeeCollectionDO.TemplateId = Convert.ToInt32(ddlTemplate.SelectedValue);
                        FeeCollectionDO.RegistrationId = Convert.ToInt32(txtRegistrationNo.Text.Split('/')[0]);
                        FeeCollectionDO.AcademicYearId = Convert.ToInt32(ddlAcademic.SelectedValue);
                        DtCheck = FeeCollectionBLL.CheckFeeCollectionDetails(FeeCollectionDO);
                        DataTable DtFee = new DataTable();
                        if (DtCheck.Rows.Count == 0)
                        {
                            DtFee = FeeMappingBLL.GetFeeMasterDetails(Convert.ToInt32(ddlTemplate.SelectedValue), 1);
                        }
                        else
                        {
                            DtFee = FeeCollectionBLL.GetFeeCollectionDetails(FeeCollectionDO);
                        }
                        GvFeeMaster.DataSource = DtFee;
                        GvFeeMaster.DataBind();
                        btnSave.Visible = true;
                        P1.Enabled = false;
                        LoadDefaultAmount();
                        CalculateGridSum();
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLogFile.LogError(ex);
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    protected void btnMainClear_Click(object sender, EventArgs e)
    {
        try
        {
            P1.Enabled = true;
            ddlTemplate.Enabled = false;
            btnSave.Visible = false;
            ddlStandard.SelectedValue = "-1";

            ddlTemplate.SelectedValue = "-1";
            txtRegistrationNo.Text = string.Empty;
            txtStudentName.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtChequeDate.Text = string.Empty;
            txtChequeNo.Text = string.Empty;
            txtChequeBank.Text = string.Empty;

            ddlPayMode.SelectedValue = "-1";
            if (!RBAdhoc.Checked)
            {
                ddlPayMode_SelectedIndexChanged(null, null);
                ddlStandard_SelectedIndexChanged(null, null);
                ddlTemplate_SelectedIndexChanged(null, null);
            }
            btnSave.Enabled = true;

            GvFeeMaster.DataSource = null;
            GvFeeMaster.DataBind();
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    protected void GvCastMaster_PageIndexChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }

    }
    protected void GvCastMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
        FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();


        FeeMappingHeaderDO.MappingTemplateName = "";

    }
    protected void lnkname_OnClick(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            int ID = Convert.ToInt32(((LinkButton)sender).CommandArgument);

            ddlTemplate.Enabled = false;

            FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
            int HeaderId = 0;
            HeaderId = Convert.ToInt32(hdnCastId.Value.ToString());
            GvFeeMaster.DataSource = FeeMappingBLL.GetFeeMasterDetails(HeaderId, 1);
            GvFeeMaster.DataBind();

            #region Make Checkbox checked
            if (GvFeeMaster.Rows.Count > 0)
            {
                foreach (GridViewRow gvrow in GvFeeMaster.Rows)
                {
                    CheckBox CheckBox = (CheckBox)gvrow.FindControl("ChkFee");
                    TextBox AmountTextBox = (TextBox)gvrow.FindControl("txtamount");
                    if (AmountTextBox.Text.Trim() != string.Empty)
                        CheckBox.Checked = true;

                }

            }
            #endregion

        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtFatherName.Text = "";
            txtStudentName.Text = "";
            txtRegistrationNo.Text = "";
            //if (RBDetailed.Checked)
            //{
            FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
            FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();

            if (RBDetailed.Checked)
                FeeMappingHeaderDO.FeeMode = 1;
            else
                FeeMappingHeaderDO.FeeMode = 2;
            if (!RBAdhoc.Checked)
            {
                FeeMappingHeaderDO.StandardId = Convert.ToInt32(ddlStandard.SelectedValue);
                CommonClass.LoadDropdownList(ddlTemplate, FeeMappingBLL.GetFeeMappingHeaderDetailsByStandardId(FeeMappingHeaderDO), "MappingTemplateName", "FeeMappingId");

            }
            else
            {
                FeeMappingHeaderDO.MappingTemplateName = "";
                CommonClass.LoadDropdownList(ddlTemplate, FeeMappingBLL.GetFeeMappingHeaderDetails(FeeMappingHeaderDO).Select("FeeMode IS NULL").CopyToDataTable(), "MappingTemplateName", "FeeMappingId");
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    protected void RBDetailed_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlStandard.SelectedValue = "-1";
            ddlTemplate.SelectedValue = "-1";
            txtFatherName.Text = "";
            txtStudentName.Text = "";
            txtRegistrationNo.Text = "";
            GvFeeMaster.DataSource = null;
            GvFeeMaster.DataBind();

            if (RBDetailed.Checked)
            {
                ddlTemplate.Visible = true;
                btnGetDetails.Text = "Get Details";
                txtAmount.Visible = false;
                AmountLabel.Visible = false;
                txtStudentName.ReadOnly = true;
                txtFatherName.ReadOnly = true;
                txtRegistrationNo.Visible = true;
                searchiCon.Visible = true;
                RegNo.Visible = true;
            }
            else
            {

                btnSave.Visible = false;
                btnGetDetails.Text = "Save";
                txtAmount.Visible = true;
                AmountLabel.Visible = true;
                ddlTemplate.Visible = false;
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    protected void RBDirect_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlStandard.SelectedValue = "-1";
            ddlTemplate.SelectedValue = "-1";
            txtFatherName.Text = "";
            txtStudentName.Text = "";
            txtRegistrationNo.Text = "";
            GvFeeMaster.DataSource = null;
            GvFeeMaster.DataBind();
            if (RBDetailed.Checked)
            {
                btnGetDetails.Text = "Get Details";
                txtAmount.Visible = false;
                AmountLabel.Visible = false;
            }
            else
            {
                txtStudentName.ReadOnly = true;
                txtFatherName.ReadOnly = true;
                txtRegistrationNo.Visible = true;
                searchiCon.Visible = true;
                RegNo.Visible = true;
                btnSave.Visible = false;
                btnGetDetails.Text = "Save";
                txtAmount.Visible = true;
                AmountLabel.Visible = true;
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    protected void RBAdhoc_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlStandard.SelectedValue = "-1";
            ddlTemplate.SelectedValue = "-1";
            txtFatherName.Text = "";
            txtStudentName.Text = "";
            txtRegistrationNo.Text = "";
            GvFeeMaster.DataSource = null;
            GvFeeMaster.DataBind();
            if (RBDetailed.Checked)
            {
                btnGetDetails.Text = "Get Details";
                txtAmount.Visible = false;
                AmountLabel.Visible = false;
            }
            else
            {
                txtRegistrationNo.Visible = false;
                searchiCon.Visible = false;
                RegNo.Visible = false;
                txtStudentName.ReadOnly = false;
                txtFatherName.ReadOnly = false;
                btnSave.Visible = false;
                btnGetDetails.Text = "Save";
                txtAmount.Visible = true;
                AmountLabel.Visible = true;
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (RBDirect.Checked)
            {
                if ((txtAmount.Text.Trim() == string.Empty) || (txtAmount.Text.Trim() == "0.00"))
                {
                    txtAmount.Text = "0.00";
                }
                txtAmount.Text = Convert.ToDouble(txtAmount.Text).ToString("#0.00");
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    protected void ddlTemplate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBDirect.Checked)
        {
            FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
            FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();
            FeeCollectionBLL FeeCollectionBLL = new FeeCollectionBLL();
            FeeCollectionDO FeeCollectionDO = new FeeCollectionDO();
            DataTable DtCheck = new DataTable();

            FeeCollectionDO.StandardId = Convert.ToInt32(ddlStandard.SelectedValue);
            FeeCollectionDO.TemplateId = Convert.ToInt32(ddlTemplate.SelectedValue);
            //FeeCollectionDO.RegistrationId = Convert.ToInt32(txtRegistrationNo.Text.Split('/')[0]);
            FeeCollectionDO.AcademicYearId = Convert.ToInt32(ddlAcademic.SelectedValue);
            DtCheck = FeeCollectionBLL.CheckFeeCollectionDetails(FeeCollectionDO);
            DataTable DtFee = new DataTable();
            if (DtCheck.Rows.Count == 0)
            {
                DtFee = FeeMappingBLL.GetFeeMasterDetails(Convert.ToInt32(ddlTemplate.SelectedValue), 2);
                txtAmount.Text = Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(Convert.ToString(DtFee.Compute("Sum(Amount)", ""))))).ToString();// Convert.ToDouble(DtFee.Compute("Sum(Amount)", "").ToString()).ToString();
                Session["ReportFormat"] = DtFee.Rows[0]["ReportFormatId"].ToString();
            }
        }
    }
    protected void lbtnRegionSearch0_Click(object sender, EventArgs e)
    {
        ddlTemplate.Enabled = true;
    }
    protected void ddlPayMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPayMode.SelectedValue != "-1")
        {
            if (ddlPayMode.SelectedItem.Text != "Cash")
            {
                txtChequeDate.Visible = true;
                txtChequeNo.Visible = true;
                txtChequeBank.Visible = true;
                ChequeDateLabel.Visible = true;
                ChequeNoLabel.Visible = true;
                ChequeBankLabel.Visible = true;
                switch (ddlPayMode.SelectedItem.Text.ToUpper())
                {
                    case "CASH":
                        break;
                    case "RTGS":
                        ChequeDateLabel.Text = "Transaction Date.";
                        ChequeNoLabel.Text = "Transaction No.";
                        break;
                    case "ONLINE":
                        ChequeDateLabel.Text = "Transaction Date.";
                        ChequeNoLabel.Text = "Transaction No.";
                        break;
                    case "CHEQUE":
                        ChequeDateLabel.Text = "Cheque Date.";
                        ChequeNoLabel.Text = "Cheque No.";
                        break;
                    case "DD":
                        ChequeDateLabel.Text = "DD Date.";
                        ChequeNoLabel.Text = "DD No.";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                txtChequeBank.Visible = false;
                txtChequeDate.Visible = false;
                txtChequeNo.Visible = false;
                ChequeDateLabel.Visible = false;
                ChequeNoLabel.Visible = false;
                ChequeBankLabel.Visible = false;
            }
        }
        else
        {
            txtChequeBank.Visible = false;
            txtChequeDate.Visible = false;
            txtChequeNo.Visible = false;
            ChequeDateLabel.Visible = false;
            ChequeNoLabel.Visible = false;
            ChequeBankLabel.Visible = false;
        }
    }
    #endregion

    #region PRIVATE METHODS
    #region NUMBER TO TEXT
    public static string NumberToText(double number, bool isUK)
    {
        if (number == 0) return "Zero";
        string and = isUK ? "and " : ""; // deals with UK or US numbering
        if (number == -2147483648) return "Minus Two Billion One Hundred " + and +
        "Forty Seven Million Four Hundred " + and + "Eighty Three Thousand " +
        "Six Hundred " + and + "Forty Eight";
        double[] num = new double[4];
        int first = 0;
        int u, h, t;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        if (number < 0)
        {
            sb.Append("Minus ");
            number = -number;
        }
        string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
        string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
        string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
        string[] words3 = { "Thousand ", "Million ", "Billion " };
        num[0] = Convert.ToDouble(Convert.ToInt32(number % 1000));           // units
        num[1] = Convert.ToDouble(Convert.ToInt32(number / 1000));
        num[2] = Convert.ToDouble(Convert.ToInt32(number / 1000000));
        num[1] = Convert.ToDouble(Convert.ToInt32(num[1] - 1000 * num[2]));  // thousands
        num[3] = Convert.ToDouble(Convert.ToInt32(number / 1000000000));     // billions
        num[2] = Convert.ToDouble(Convert.ToInt32(num[2] - 1000 * num[3]));  // millions
        for (int i = 3; i > 0; i--)
        {
            if (num[i] != 0)
            {
                first = i;
                break;
            }
        }
        for (int i = first; i >= 0; i--)
        {
            if (num[i] == 0) continue;
            u = Convert.ToInt32(num[i] % 10);              // ones
            t = Convert.ToInt32(num[i] / 10);
            h = Convert.ToInt32(num[i] / 100);             // hundreds
            t = t - 10 * h;               // tens
            if (h > 0) sb.Append(words0[h] + "Hundred ");
            if (u > 0 || t > 0)
            {
                if (h > 0 || i < first) sb.Append(and);
                if (t == 0)
                    sb.Append(words0[u]);
                else if (t == 1)
                    sb.Append(words1[u]);
                else
                    sb.Append(words2[t - 2] + words0[u]);
            }
            if (i != 0) sb.Append(words3[i - 1]);
        }
        return sb.ToString().TrimEnd();
    }


    #endregion
    private void LoadDefaultAmount()
    {
        try
        {
            foreach (GridViewRow dr in GvFeeMaster.Rows)
            {
                double price = Convert.ToDouble(((TextBox)dr.FindControl("txtFeeamount")).Text) - Convert.ToDouble(((TextBox)dr.FindControl("txtpaidamount")).Text);
                if (ConfigurationManager.AppSettings["AmountDisplay"] == "1")
                {
                    ((TextBox)dr.FindControl("txtamount")).Text = price.ToString("#.00");
                }
                else
                {
                    ((TextBox)dr.FindControl("txtamount")).Text = "0.00";
                }
                ((TextBox)dr.FindControl("txtPendingamount")).Text = price.ToString("#.00");
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    private void CalculateGridSum()
    {
        double FeeAmountgrandtotal = 0;
        double Amountgrandtotal = 0;
        double TotalPendingAmountgrandtotal = 0;
        double TotalPaidAmountgrandtotal = 0;
        try
        {
            foreach (GridViewRow dr in GvFeeMaster.Rows)
            {
                double price = Convert.ToDouble(((TextBox)dr.FindControl("txtFeeamount")).Text);
                FeeAmountgrandtotal = FeeAmountgrandtotal + price;
                if (((TextBox)dr.FindControl("txtamount")).Text.Trim() != string.Empty)
                {
                    double Amountprice = Convert.ToDouble(((TextBox)dr.FindControl("txtamount")).Text);
                    Amountgrandtotal = Amountgrandtotal + Amountprice;
                }
                else
                    ((TextBox)dr.FindControl("txtamount")).Text = "0.00";
                double Pendingprice = Convert.ToDouble(((TextBox)dr.FindControl("txtPendingamount")).Text);
                TotalPendingAmountgrandtotal = TotalPendingAmountgrandtotal + Pendingprice;

                double Paidgprice = Convert.ToDouble(((TextBox)dr.FindControl("txtpaidamount")).Text);
                TotalPaidAmountgrandtotal = TotalPaidAmountgrandtotal + Paidgprice;

            }
            GridViewRow row = GvFeeMaster.FooterRow;
            ((TextBox)row.FindControl("txtSumFeeamount")).Text = Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(Convert.ToString(FeeAmountgrandtotal)))).ToString();
            ((TextBox)row.FindControl("txtSumamount")).Text = Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(Convert.ToString(Amountgrandtotal)))).ToString();
            ((TextBox)row.FindControl("txtSumPendingamount")).Text = Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(Convert.ToString(TotalPendingAmountgrandtotal)))).ToString();
            ((TextBox)row.FindControl("txtpaidSumamount")).Text = Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(Convert.ToString(TotalPaidAmountgrandtotal)))).ToString();
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    private Boolean ValidateGet()
    {
        string ErrMessage = string.Empty;
        bool Result = true;
        try
        {
            if (ddlPayMode.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Please select payment mode.</br>";
            }
            if (ddlTemplate.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Please select the template</br>";
            }

            if (ddlStandard.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Please select the standard</br>";
            }

            if (ddlAcademic.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Please select the academic year</br>";
            }
            if (!RBAdhoc.Checked)
            {
                if (txtRegistrationNo.Text.Trim() == string.Empty)
                {
                    Result = false;
                    ErrMessage = ErrMessage + "Please enter the student admission number.</br>";
                }
            }
            else if ((txtStudentName.Text.Trim() == "") || (txtFatherName.Text.Trim() == ""))
            {
                Result = false;
                ErrMessage = ErrMessage + "Please enter the student name & father name.</br>";
            }

            if ((RBDirect.Checked) || (RBAdhoc.Checked))
            {
                if ((txtAmount.Text.Trim() == string.Empty) || (txtAmount.Text.Trim() == "0.00"))
                {
                    Result = false;
                    ErrMessage = ErrMessage + "Please enter the proper amount to collect.</br>";
                }
            }
            DataTable DtFee = new DataTable();
            FeeCollectionBLL FeeCollectionBLL = new FeeCollectionBLL();
            FeeCollectionDO FeeCollectionDO = new FeeCollectionDO();

            FeeCollectionDO.StandardId = Convert.ToInt32(ddlStandard.SelectedValue);



            if (!RBAdhoc.Checked)
            {
                FeeCollectionDO.TemplateId = Convert.ToInt32(ddlTemplate.SelectedValue);
                FeeCollectionDO.RegistrationId = Convert.ToInt32(txtRegistrationNo.Text.Split('/')[0]);
            }
            FeeCollectionDO.AcademicYearId = Convert.ToInt32(ddlAcademic.SelectedValue);


            DtFee = FeeCollectionBLL.GetFeeCollectionDetails(FeeCollectionDO);

            if ((!RBDirect.Checked) && (!RBAdhoc.Checked))
            {
                if (DtFee.Rows.Count == 0)
                {
                    Result = false;
                    ErrMessage = ErrMessage + "Please select the proper academic year as there are no fee payable is available for the selected year or student is promoted or year end done. </br>";
                }
            }
            if ((RBDirect.Checked) || (RBAdhoc.Checked))
            {
                if (ddlPayMode.SelectedValue != "-1")
                {
                    if (ddlPayMode.SelectedItem.Text != "Cash")
                    {
                        if (txtChequeDate.Text == string.Empty)
                        {
                            Result = false;
                            ErrMessage = ErrMessage + "Please enter the proper cheque date.</br>";
                        }
                        if (txtChequeNo.Text == string.Empty)
                        {
                            Result = false;
                            ErrMessage = ErrMessage + "Please enter the proper cheque No.</br>";
                        }
                        if (txtChequeBank.Text == string.Empty)
                        {
                            Result = false;
                            ErrMessage = ErrMessage + "Please enter the bank name.</br>";
                        }
                    }
                }
                else
                {
                    Result = false;
                    ErrMessage = ErrMessage + "Please select payment mode.</br>";
                }
            }

            if ((RBDirect.Checked) || (RBAdhoc.Checked))
            {
                if (Convert.ToDecimal(txtAmount.Text.Trim()) < 0)
                {
                    Result = false;
                    ErrMessage = ErrMessage + "Amount to collect cannot be negative.</br>";
                }
            }

            FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
            FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();
            DataTable DtCheck = new DataTable();

            FeeCollectionDO.StandardId = Convert.ToInt32(ddlStandard.SelectedValue);

            if (!RBAdhoc.Checked)
            {
                FeeCollectionDO.RegistrationId = Convert.ToInt32(txtRegistrationNo.Text.Split('/')[0]);
                FeeCollectionDO.TemplateId = Convert.ToInt32(ddlTemplate.SelectedValue);
            }
            FeeCollectionDO.AcademicYearId = Convert.ToInt32(ddlAcademic.SelectedValue);
            DtCheck = FeeCollectionBLL.CheckFeeCollectionDetails(FeeCollectionDO);
            //DataTable DtFee = new DataTable();
            if (RBDirect.Checked)
            {
                if (DtCheck.Rows.Count > 0)
                {
                    Result = false;
                    ErrMessage = ErrMessage + "There is already fee of amount " + DtCheck.Rows[0]["TotalAmountPaid"] + " collected from the studet " + txtStudentName.Text + " for the template " + ddlTemplate.SelectedItem.Text + " for the academic year " + ddlAcademic.SelectedItem.Text + ".</br>";
                }
            }

            if (!Result)
            {
                ErrMsg.Visible = true;
                ErrMsg.ForeColor = System.Drawing.Color.Red;
                ErrMsg.Text = ErrMessage;
            }
            
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
        return Result;
    }
    private Boolean ValidateCollection()
    {
        string ErrMessage = string.Empty;
        bool Result = true;
        try
        {
            if (ddlPayMode.SelectedValue != "-1")
            {
                if (ddlPayMode.SelectedItem.Text != "Cash")
                {
                    if (txtChequeDate.Text == string.Empty)
                    {
                        Result = false;
                        ErrMessage = ErrMessage + "Please enter the proper " + ChequeDateLabel.Text + ".</br>";
                    }
                    if (txtChequeNo.Text == string.Empty)
                    {
                        Result = false;
                        ErrMessage = ErrMessage + "Please enter the proper " + ChequeNoLabel.Text + ".</br>";
                    }
                    if (txtChequeBank.Text == string.Empty)
                    {
                        Result = false;
                        ErrMessage = ErrMessage + "Please enter the bank name.</br>";
                    }
                }
            }
            else
            {
                Result = false;
                ErrMessage = ErrMessage + "Please select payment mode.</br>";
            }
            if (ddlTemplate.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Please select the standard</br>";
            }
            if ((!RBDirect.Checked) && (!RBAdhoc.Checked))
            {
                CalculateGridSum();



                GridViewRow row = GvFeeMaster.FooterRow;

                Double AmountSum = Convert.ToDouble(((TextBox)row.FindControl("txtSumamount")).Text);
                Double FeeAmountSum = Convert.ToDouble(((TextBox)row.FindControl("txtSumFeeamount")).Text);
                Double Pending = FeeAmountSum - AmountSum;

                if (AmountSum == Convert.ToDouble("0"))
                {
                    Result = false;
                    ErrMessage = ErrMessage + "Fee payable is Zero.</br>";
                }

                if ((AmountSum == Convert.ToDouble("0")) && (Pending == Convert.ToDouble("0")))
                {
                    Result = false;
                    ErrMessage = ErrMessage + "Fee is already paid by the student.</br>";
                }
                int ChkCount = 0;
                if (GvFeeMaster.Rows.Count > 0)
                {
                    foreach (GridViewRow gvrow in GvFeeMaster.Rows)
                    {
                        TextBox txtFeeamount = (TextBox)gvrow.FindControl("txtFeeamount");
                        TextBox txtamount = (TextBox)gvrow.FindControl("txtamount");
                        TextBox txtPendingamount = (TextBox)gvrow.FindControl("txtPendingamount");
                        TextBox txtPaidamount = (TextBox)gvrow.FindControl("txtpaidamount");

                        if (((Convert.ToDouble(txtFeeamount.Text) - Convert.ToDouble(txtPaidamount.Text)) < Convert.ToDouble(txtamount.Text)))
                        {
                            ChkCount += 1;
                        }

                    }

                    if (ChkCount > 0)
                    {
                        Result = false;
                        ErrMessage = ErrMessage + "Amount paying is more than fee amount</br>";
                    }

                    foreach (GridViewRow gvrow in GvFeeMaster.Rows)
                    {
                        TextBox txtFeeamount = (TextBox)gvrow.FindControl("txtFeeamount");
                        TextBox txtamount = (TextBox)gvrow.FindControl("txtamount");
                        TextBox txtPendingamount = (TextBox)gvrow.FindControl("txtPendingamount");
                        TextBox txtPaidamount = (TextBox)gvrow.FindControl("txtpaidamount");

                        if ((Convert.ToDouble(txtamount.Text)) < 0)
                        {
                            ChkCount += 1;
                        }

                    }

                    if (ChkCount > 0)
                    {
                        Result = false;
                        ErrMessage = ErrMessage + "Amount paying cannot be a negative amount</br>";
                    }
                }
            }
            if (!Result)
            {
                ErrMsg.Visible = true;
                ErrMsg.Text = ErrMessage;
            }
            
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
        return Result;
    }
    #endregion
}
