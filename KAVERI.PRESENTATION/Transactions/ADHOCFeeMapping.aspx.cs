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

public partial class Transactions_ADHOCFeeMapping : System.Web.UI.Page
{
    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrMsg.Visible = false;
        lblda.Visible = false;
        txtDirectFeeAmount.Visible = false;
        if (!IsPostBack)
        {
            CastMasterBLL CastMasterBLL = new CastMasterBLL();
            chkIsActive.Visible = false;
            lblIsActive.Visible = false;
            //txtDirectFeeAmount.Text = "0.00";

            FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
            FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();

            FeeMappingHeaderDO.MappingTemplateName = "";
            if ((FeeMappingBLL.GetFeeMappingHeaderDetails(FeeMappingHeaderDO).Select("FeeMode IS NULL") != null) && (FeeMappingBLL.GetFeeMappingHeaderDetails(FeeMappingHeaderDO).Select("FeeMode IS NULL").Length > 0))
            {
                GvFeeMappingHeader.DataSource = FeeMappingBLL.GetFeeMappingHeaderDetails(FeeMappingHeaderDO).Select("FeeMode IS NULL").CopyToDataTable();
            }
            else
                GvFeeMappingHeader.DataSource = null;
            GvFeeMappingHeader.DataBind();


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
                //FeeMappingHeaderDO.StandardId = Convert.ToInt32(ddlStandard.SelectedValue);
                if (chkIsActive.Checked)
                    FeeMappingHeaderDO.IsActive = false;
                else
                    FeeMappingHeaderDO.IsActive = true;
                FeeMappingHeaderDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
                FeeMappingHeaderDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString());
                //FeeMappingHeaderDO.FeeMode = Convert.ToInt32(ddlMode.SelectedValue);
                //FeeMappingHeaderDO.ReportFormatId = Convert.ToInt32(ddlReportFormat.SelectedValue);
                #endregion
                FeeMappingDetailsDO FeeMappingDetailsDO;
                FeeMappingDetailsDO = new FeeMappingDetailsDO();
                FeeMappingHeaderDO.FeeMappingDetailsList = new List<FeeMappingDetailsDO>();
                // FeeMappingDetailsDO.FeeAmount = Convert.ToDouble(txtDirectFeeAmount.Text);
                FeeMappingHeaderDO.FeeMappingDetailsList.Add(FeeMappingDetailsDO);
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
                    if ((FeeMappingBLL.GetFeeMappingHeaderDetails(FeeMappingHeaderDO).Select("FeeMode IS NULL") != null) && (FeeMappingBLL.GetFeeMappingHeaderDetails(FeeMappingHeaderDO).Select("FeeMode IS NULL").Length > 0))
                    {
                        GvFeeMappingHeader.DataSource = FeeMappingBLL.GetFeeMappingHeaderDetails(FeeMappingHeaderDO).Select("FeeMode IS NULL").CopyToDataTable();
                    }
                    else
                        GvFeeMappingHeader.DataSource = null;
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
            //lblda.Visible = true;

            //txtDirectFeeAmount.Text = "";
            txtTemplateName.Text = "";
            txtTemplateName.Enabled = true;
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
        if ((FeeMappingBLL.GetFeeMappingHeaderDetails(FeeMappingHeaderDO).Select("FeeMode IS NULL") != null) && (FeeMappingBLL.GetFeeMappingHeaderDetails(FeeMappingHeaderDO).Select("FeeMode IS NULL").Length > 0))
        {
            GvFeeMappingHeader.DataSource = FeeMappingBLL.GetFeeMappingHeaderDetails(FeeMappingHeaderDO).Select("FeeMode IS NULL").CopyToDataTable();
        }
        else
            GvFeeMappingHeader.DataSource = null;
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

            hdnCastId.Value = GvFeeMappingHeader.DataKeys[ID].Values["FeeMappingId"].ToString();
            chkIsActive.Visible = true;
            lblIsActive.Visible = true;
            txtTemplateName.Enabled = false;


            //lblda.Visible = true;
            //txtDirectFeeAmount.Visible = true;
            FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
            int HeaderId = 0;
            HeaderId = Convert.ToInt32(hdnCastId.Value.ToString());
            //txtDirectFeeAmount.Enabled = true;
            //txtDirectFeeAmount.Text = DtFeeDetails.Rows[0]["Amount"].ToString();

        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }

    #endregion

    #region Private Methods
    private Boolean ValidateMapping()
    {
        string ErrMessage = string.Empty;
        bool Result = true;
        try
        {
            if ((txtTemplateName.Text.Trim() == string.Empty))
            {
                Result = false;
                ErrMessage = "Template Name cannot be blank</br>";
            }

            //if ((txtDirectFeeAmount.Text.Trim() == string.Empty) || (txtDirectFeeAmount.Text.Trim() == "0.00"))
            //{
            //    Result = false;
            //    ErrMessage = ErrMessage + "Fee Amount cannot be blank Or 0.00</br>";
            //}
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

}
