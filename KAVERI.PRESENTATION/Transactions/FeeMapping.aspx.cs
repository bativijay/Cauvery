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

public partial class Transactions_FeeMapping : System.Web.UI.Page
{
    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrMsg.Visible = false;
        if (!IsPostBack)
        {
            CastMasterBLL CastMasterBLL = new CastMasterBLL();
            chkIsActive.Visible = false;
            lblIsActive.Visible = false;
            ddlFeeName.Enabled = false;
            txtDirectFeeAmount.Text = "0.00";
            txtDirectFeeAmount.Enabled = false;
            ddlReportFormat.Enabled = false;
            FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
            FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();

            CommonBLL CommonBLL = new CommonBLL();
            CommonClass.LoadDropdownList(ddlReportFormat, CommonBLL.GetParameterDetails("DirectCollection"), "ParameterName", "ParameterValue");

            FeeMappingHeaderDO.MappingTemplateName = "";
            GvFeeMappingHeader.DataSource = FeeMappingBLL.GetFeeMappingHeaderDetails(FeeMappingHeaderDO).Select("FeeMode IS NOT NULL").CopyToDataTable();
            GvFeeMappingHeader.DataBind();

            CommonClass.LoadDropdownList(ddlStandard, CommonBLL.GetStandardDetails(), "StandardName", "StandardId");

            CommonClass.LoadDropdownListWithoutSelect(ddlMode, CommonBLL.GetParameterDetails("FeeMode"), "ParameterName", "ParameterValue");
        }
    }
    #endregion

    #region CONTROL EVENTS
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateMapping())
            {
                FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
                #region HEADER DETAILS
                FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();

                if (!txtTemplateName.Enabled)
                    FeeMappingHeaderDO.FeeMappingId = Convert.ToInt32(hdnCastId.Value.ToString());
                FeeMappingHeaderDO.MappingTemplateName = txtTemplateName.Text.ToUpper().Trim();
                FeeMappingHeaderDO.StandardId = Convert.ToInt32(ddlStandard.SelectedValue);
                if (chkIsActive.Checked)
                    FeeMappingHeaderDO.IsActive = false;
                else
                    FeeMappingHeaderDO.IsActive = true;
                FeeMappingHeaderDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
                FeeMappingHeaderDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString());
                FeeMappingHeaderDO.FeeMode = Convert.ToInt32(ddlMode.SelectedValue);
                FeeMappingHeaderDO.ReportFormatId = Convert.ToInt32(ddlReportFormat.SelectedValue);
                #endregion
                #region DETAIL SECTION
                FeeMappingDetailsDO FeeMappingDetailsDO;
                FeeMappingHeaderDO.FeeMappingDetailsList = new List<FeeMappingDetailsDO>();
                if (ddlMode.SelectedValue == "1")
                {
                    foreach (GridViewRow gvrow in GvFeeMaster.Rows)
                    {
                        CheckBox CheckBox = (CheckBox)gvrow.FindControl("ChkFee");
                        if (CheckBox.Checked)
                        {
                            FeeMappingDetailsDO = new FeeMappingDetailsDO();
                            FeeMappingDetailsDO.FeeId = Convert.ToInt32(GvFeeMaster.DataKeys[gvrow.RowIndex].Values["FeeId"].ToString());
                            TextBox AmountTextBox = (TextBox)gvrow.FindControl("txtamount");
                            FeeMappingDetailsDO.FeeAmount = Convert.ToDouble(AmountTextBox.Text);
                            FeeMappingDetailsDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
                            FeeMappingDetailsDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString());

                            FeeMappingHeaderDO.FeeMappingDetailsList.Add(FeeMappingDetailsDO);
                        }
                    }
                }
                else
                {
                    FeeMappingDetailsDO = new FeeMappingDetailsDO();
                    FeeMappingDetailsDO.FeeId = Convert.ToInt32(ddlFeeName.SelectedValue);
                    FeeMappingDetailsDO.FeeAmount = Convert.ToDouble(txtDirectFeeAmount.Text);
                    FeeMappingDetailsDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
                    FeeMappingDetailsDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString());

                    FeeMappingHeaderDO.FeeMappingDetailsList.Add(FeeMappingDetailsDO);
                }
                #endregion
                int Result = 0;
                Result = FeeMappingBLL.InsertFeeMappingHeaderDetails(FeeMappingHeaderDO);

                if (Result > 0)
                {
                    if (FeeMappingHeaderDO.FeeMappingId > 0)
                    {
                        string ErrMessage = string.Empty;
                        ErrMsg.ForeColor = System.Drawing.Color.Green;
                        ErrMsg.Visible = true;
                        ErrMessage = "Data Updated succesfully.";
                        ErrMsg.Text = ErrMessage;
                    }
                    else
                    {
                        string ErrMessage = string.Empty;
                        ErrMsg.ForeColor = System.Drawing.Color.Green;
                        ErrMsg.Visible = true;
                        ErrMessage = "Data saved succesfully.";
                        ErrMsg.Text = ErrMessage;
                    }
                    btnClear_Click(null, null);
                    CastMasterBLL CastMasterBLL = new CastMasterBLL();
                    chkIsActive.Visible = false;
                    lblIsActive.Visible = false;

                    FeeMappingHeaderDO.MappingTemplateName = "";
                    GvFeeMappingHeader.DataSource = FeeMappingBLL.GetFeeMappingHeaderDetails(FeeMappingHeaderDO).Select("FeeMode IS NOT NULL").CopyToDataTable();
                    GvFeeMappingHeader.DataBind();
                }
                else
                {
                    string ErrMessage = string.Empty;
                    ErrMsg.ForeColor = System.Drawing.Color.Red;
                    ErrMsg.Visible = true;
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
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            lblda.Visible = true;
            lblfn.Visible = true;
            lblrf.Visible = true;
            ddlFeeName.Visible = true;
            ddlReportFormat.Visible = true;
            txtDirectFeeAmount.Visible = true;

            txtTemplateName.Enabled = true;
            ddlStandard.Enabled = true;
            ddlMode.Enabled = true;

            txtTemplateName.Text = string.Empty;
            ddlStandard.SelectedValue = "-1";
            txtDirectFeeAmount.Text = string.Empty;

            ddlMode.SelectedValue = "1";
            ddlFeeName.SelectedValue = "-1";
            ddlReportFormat.SelectedValue = "-1";

            ddlMode_SelectedIndexChanged(null, null);
            GvFeeMaster.DataSource = null;
            GvFeeMaster.DataBind();

            chkIsActive.Visible = false;
            chkIsActive.Checked = false;
            lblIsActive.Visible = false;
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

        GvFeeMappingHeader.PageIndex = e.NewPageIndex;
        FeeMappingHeaderDO.MappingTemplateName = "";
        GvFeeMappingHeader.DataSource = FeeMappingBLL.GetFeeMappingHeaderDetails(FeeMappingHeaderDO).Select("FeeMode IS NOT NULL").CopyToDataTable();
        GvFeeMappingHeader.DataBind();
    }
    protected void lnkname_OnClick(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int ID = row.RowIndex;
            //int ID = Convert.ToInt32(((LinkButton)sender).CommandArgument);

            txtTemplateName.Text = GvFeeMappingHeader.Rows[ID].Cells[1].Text;
            ddlStandard.SelectedValue = GvFeeMappingHeader.DataKeys[ID].Values["StandardId"].ToString();

            hdnCastId.Value = GvFeeMappingHeader.DataKeys[ID].Values["FeeMappingId"].ToString();
            chkIsActive.Visible = true;
            lblIsActive.Visible = true;
            txtTemplateName.Enabled = false;
            ddlStandard.Enabled = false;
            ddlMode.Enabled = false;
            ddlFeeName.Enabled = false;
            if (GvFeeMappingHeader.Rows[ID].Cells[3].Text == "Detailed")
            {
                GvFeeMaster.Visible = true;
                FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
                int HeaderId = 0;
                HeaderId = Convert.ToInt32(hdnCastId.Value.ToString());
                ddlMode.SelectedValue = "1";
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
                CalculateGridSum();
                #endregion

                txtDirectFeeAmount.Enabled = false;
                txtDirectFeeAmount.Text = "0.00";
                ddlFeeName.Visible = false;
                ddlReportFormat.Visible = false;
                txtDirectFeeAmount.Visible = false;
                lblda.Visible = false;
                lblfn.Visible = false;
                lblrf.Visible = false;
            }
            else
            {
                lblda.Visible = true;
                lblfn.Visible = true;
                lblrf.Visible = true;
                ddlFeeName.Visible = true;
                ddlReportFormat.Visible = true;
                txtDirectFeeAmount.Visible = true;
                FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
                int HeaderId = 0;
                HeaderId = Convert.ToInt32(hdnCastId.Value.ToString());
                ddlMode.SelectedValue = "2";
                DataTable DtFeeDetails = new DataTable();
                DtFeeDetails = FeeMappingBLL.GetFeeMasterDetails(HeaderId, 1);
                CommonClass.LoadDropdownList(ddlFeeName, FeeMappingBLL.GetFeeMasterDetails(0, Convert.ToInt32(ddlMode.SelectedValue)), "FeeName", "FeeId");

                CommonBLL CommonBLL = new CommonBLL();
                CommonClass.LoadDropdownList(ddlReportFormat, CommonBLL.GetParameterDetails("DirectCollection"), "ParameterName", "ParameterValue");

                if (DtFeeDetails.Rows.Count > 0)
                {
                    ddlFeeName.SelectedValue = DtFeeDetails.Rows[0]["FeeId"].ToString();
                    ddlReportFormat.SelectedValue = DtFeeDetails.Rows[0]["ReportFormatId"].ToString();
                }
                GvFeeMaster.Visible = false;
                txtDirectFeeAmount.Enabled = true;
                txtDirectFeeAmount.Text = DtFeeDetails.Rows[0]["Amount"].ToString();
            }

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
            if (txtTemplateName.Text.Trim() != string.Empty)
            {
                FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
                FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();
                FeeMappingHeaderDO.MappingTemplateName = txtTemplateName.Text.Trim();
                FeeMappingHeaderDO.StandardId = Convert.ToInt32(ddlStandard.SelectedValue);
                DataTable DtMappingHeader = new DataTable();
                int HeaderId = 0;
                if (Convert.ToInt32(FeeMappingBLL.GetFeeMappingHeaderDetailsByTempNameAndStd(FeeMappingHeaderDO).Rows.Count) > 0)
                {
                    DtMappingHeader = FeeMappingBLL.GetFeeMappingHeaderDetailsByTempNameAndStd(FeeMappingHeaderDO);
                    if (Convert.ToInt32(DtMappingHeader.Rows[0]["FMHId"]) > 0)
                    {
                        HeaderId = Convert.ToInt32(FeeMappingBLL.GetFeeMappingHeaderDetailsByTempNameAndStd(FeeMappingHeaderDO).Rows[0]["FMHId"]);
                    }
                }

                hdnCastId.Value = HeaderId.ToString();

                if ((DtMappingHeader != null) && (DtMappingHeader.Rows.Count > 0))
                {
                    if (Convert.ToInt32(DtMappingHeader.Rows[0]["FeeMode"]) == 1)
                    {
                        ddlFeeName.Enabled = false;
                        GvFeeMaster.Visible = true;
                        txtDirectFeeAmount.Text = "0.00";
                        txtDirectFeeAmount.Enabled = false;
                        ddlReportFormat.Enabled = false;
                        ddlReportFormat.SelectedValue = "-1";
                        ddlFeeName.SelectedValue = "-1";
                    }
                    else
                    {
                        ddlFeeName.Enabled = false;
                        ddlMode.SelectedValue = "2";
                        GvFeeMaster.Visible = false;
                        txtDirectFeeAmount.Text = "0.00";
                        txtDirectFeeAmount.Enabled = true;
                        ddlReportFormat.Enabled = false;
                        ddlReportFormat.SelectedValue = DtMappingHeader.Rows[0]["ReportFormatId"].ToString();
                        //ddlFeeName.SelectedValue = "-1";
                    }
                }
                //chkIsActive.Visible = true;
                //lblIsActive.Visible = true;
                //txtTemplateName.Enabled = false;
                //ddlStandard.Enabled = false;
                //
                if (GvFeeMaster.Visible)
                {

                    GvFeeMaster.DataSource = FeeMappingBLL.GetFeeMasterDetails(HeaderId, Convert.ToInt32(ddlMode.SelectedValue));
                    GvFeeMaster.DataBind();
                    CalculateGridSum();
                }
                else
                {
                    if ((DtMappingHeader != null) && (DtMappingHeader.Rows.Count > 0))
                    {
                        if (Convert.ToInt32(DtMappingHeader.Rows[0]["FeeMode"]) == 2)
                        {
                            CommonClass.LoadDropdownList(ddlFeeName, FeeMappingBLL.GetFeeMasterDetails(0, Convert.ToInt32(ddlMode.SelectedValue)), "FeeName", "FeeId");
                            txtDirectFeeAmount.Text = FeeMappingBLL.GetFeeMasterDetails(HeaderId, Convert.ToInt32(ddlMode.SelectedValue)).Rows[0]["Amount"].ToString();
                            ddlFeeName.SelectedValue = FeeMappingBLL.GetFeeMasterDetails(HeaderId, Convert.ToInt32(ddlMode.SelectedValue)).Rows[0]["FeeId"].ToString();
                        }
                    }
                    else
                        CommonClass.LoadDropdownList(ddlFeeName, FeeMappingBLL.GetFeeMasterDetails(HeaderId, Convert.ToInt32(ddlMode.SelectedValue)), "FeeName", "FeeId");
                }

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
            else
            {
                string ErrMessage = string.Empty;
                ErrMsg.Visible = true;
                ErrMsg.ForeColor = System.Drawing.Color.Red;
                ErrMessage = "Please enter the template name";
                ErrMsg.Text = ErrMessage;
                ddlStandard.SelectedValue = "-1";
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
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
    #endregion

    #region Private Methods
    private void CalculateGridSum()
    {
        double FeeAmountgrandtotal = 0;
        double Amountgrandtotal = 0;
        try
        {
            foreach (GridViewRow dr in GvFeeMaster.Rows)
            {
                //double price = Convert.ToDouble(((TextBox)dr.FindControl("txtFeeamount")).Text);
                //FeeAmountgrandtotal = FeeAmountgrandtotal + price;
                if (((TextBox)dr.FindControl("txtamount")).Text.Trim() != string.Empty)
                {
                    double Amountprice = Convert.ToDouble(((TextBox)dr.FindControl("txtamount")).Text);
                    Amountgrandtotal = Amountgrandtotal + Amountprice;
                }
                else
                    ((TextBox)dr.FindControl("txtamount")).Text = "0.00";

            }
            GridViewRow row = GvFeeMaster.FooterRow;
            ((TextBox)row.FindControl("txtSumamount")).Text = Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(Convert.ToString(Amountgrandtotal)))).ToString();
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    private Boolean ValidateMapping()
    {
        string ErrMessage = string.Empty;
        bool Result = true;


        try
        {

            if (ddlMode.SelectedValue == "1")
            {
                if ((txtTemplateName.Text.Trim() == string.Empty))
                {
                    Result = false;
                    ErrMessage = "Template Name cannot be blank</br>";
                }

                if (ddlStandard.SelectedValue == "-1")
                {
                    Result = false;
                    ErrMessage = ErrMessage + "Please select the standard</br>";
                }

                int ChkCount = 0;
                if (GvFeeMaster.Rows.Count > 0)
                {
                    foreach (GridViewRow gvrow in GvFeeMaster.Rows)
                    {
                        CheckBox CheckBox = (CheckBox)gvrow.FindControl("ChkFee");
                        if (CheckBox.Checked)
                        {
                            TextBox AmountTextBox = (TextBox)gvrow.FindControl("txtamount");
                            if (AmountTextBox.Text.Trim() != string.Empty)
                                ChkCount += 1;
                        }
                    }

                    if (ChkCount == 0)
                    {
                        Result = false;
                        ErrMessage = ErrMessage + "Please select the fee type and enter the amount</br>";
                    }
                }

                int ChkAmount = 0;
                if (GvFeeMaster.Rows.Count > 0)
                {
                    foreach (GridViewRow gvrow in GvFeeMaster.Rows)
                    {
                        CheckBox CheckBox = (CheckBox)gvrow.FindControl("ChkFee");
                        if (CheckBox.Checked)
                        {
                            TextBox AmountTextBox = (TextBox)gvrow.FindControl("txtamount");
                            if (Convert.ToDouble(AmountTextBox.Text.Trim()) > 0)
                                ChkAmount += 1;
                        }
                    }

                    if (ChkAmount == 0)
                    {
                        Result = false;
                        ErrMessage = ErrMessage + "Sum of Fee amount cannot be ZERO</br>";
                    }
                }
            }
            else
            {
                if ((txtDirectFeeAmount.Text.Trim() == string.Empty))
                {
                    Result = false;
                    ErrMessage = "Fee Amount cannot be blank</br>";
                }

                if (ddlReportFormat.SelectedValue == "-1")
                {
                    Result = false;
                    ErrMessage = ErrMessage + "Please select the report format</br>";
                }

                if (ddlFeeName.SelectedValue == "-1")
                {
                    Result = false;
                    ErrMessage = ErrMessage + "Please select the fee name</br>";
                }
                if (Convert.ToDouble(txtDirectFeeAmount.Text.Trim()) == 0)
                {
                    Result = false;
                    ErrMessage = ErrMessage + "Fee amount cannot be ZERO</br>";
                }
            }
            if (txtTemplateName.Enabled == true)
            {
                FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
                FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();
                FeeMappingHeaderDO.MappingTemplateName = txtTemplateName.Text;
                if (FeeMappingBLL.GetFeeMappingHeaderDetailsByTempNameAndStd(FeeMappingHeaderDO).Rows.Count > 0)
                {

                    Result = false;
                    ErrMessage = ErrMessage + "Template name is already in use</br>";
                }
            }
            if (!Result)
            {
                ErrMsg.ForeColor = System.Drawing.Color.Red;
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
    protected void ddlMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonBLL CommonBLL = new CommonBLL();
        FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
        if (ddlMode.SelectedValue == "1")
        {
            ddlFeeName.Enabled = false;
            GvFeeMaster.Visible = true;
            txtDirectFeeAmount.Text = "0.00";
            txtDirectFeeAmount.Enabled = false;
            ddlReportFormat.Enabled = false;
            ddlReportFormat.SelectedValue = "-1";
            ddlFeeName.SelectedValue = "-1";
            ddlStandard.SelectedValue = "-1";
        }
        else
        {
            ddlFeeName.Enabled = true;
            GvFeeMaster.Visible = false;
            ddlReportFormat.Enabled = true;
            txtDirectFeeAmount.Enabled = true;
            CommonClass.LoadDropdownList(ddlFeeName, FeeMappingBLL.GetFeeMasterDetails(0, Convert.ToInt32(ddlMode.SelectedValue)), "FeeName", "FeeId");
        }
        //ddlStandard_SelectedIndexChanged(null, null);
    }
}
