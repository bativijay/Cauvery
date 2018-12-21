using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KAVERI.BLL;
using KAVERI.DO;
using System.Data;
public partial class MasterPages_FeeMaster : System.Web.UI.Page
{
    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrMsg.Visible = false;
        if (!IsPostBack)
        {
            CommonBLL CommonBLL = new CommonBLL();
            FeeMasterBLL FeeMasterBLL = new FeeMasterBLL();
            CommonClass.LoadDropdownList(ddlFeeType, FeeMasterBLL.GetFeeType(), "FeeType", "FeeTypeId");

            chkIsActive.Visible = false;
            lblIsActive.Visible = false;
            FeeMasterDO FeeMasterDO = new FeeMasterDO();
            FeeMasterDO.FeeCode = "";
            GvFeeMaster.DataSource = FeeMasterBLL.GetFeeMasterDetails(FeeMasterDO);
            GvFeeMaster.DataBind();

            CommonClass.LoadDropdownListWithoutSelect(ddlFeeMode, CommonBLL.GetParameterDetails("FeeMode"), "ParameterName", "ParameterValue");
        }
    }
    #endregion

    #region CONTROL EVENTS
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            if (ValidateFeeMster())
            {
                FeeMasterBLL FeeMasterBLL = new FeeMasterBLL();
                FeeMasterDO FeeMasterDO = new FeeMasterDO();
                if (!txtFeeCode.Enabled)
                {
                    FeeMasterDO.FeeId = Convert.ToInt32(hdnFeeId.Value);
                }
                FeeMasterDO.FeeCode = txtFeeCode.Text.ToUpper();
                FeeMasterDO.FeeName = txtFeeName.Text.ToUpper();
                FeeMasterDO.FeeType = Convert.ToInt32(ddlFeeType.SelectedValue);
                FeeMasterDO.FeeMode = Convert.ToInt32(ddlFeeMode.SelectedValue);
                FeeMasterDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
                FeeMasterDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString());
                if (!txtFeeCode.Enabled)
                {
                    if (chkIsActive.Checked)
                    {
                        FeeMasterDO.IsActive = false;
                    }
                    else
                    {
                        FeeMasterDO.IsActive = true;
                    }
                }
                else
                {
                    FeeMasterDO.IsActive = true;
                }

                FeeMasterBLL.InsertFeeMasterDetails(FeeMasterDO);

                FeeMasterDO.FeeCode = "";
                GvFeeMaster.DataSource = FeeMasterBLL.GetFeeMasterDetails(FeeMasterDO);
                GvFeeMaster.DataBind();

                if (!txtFeeCode.Enabled)
                {
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Text = "Fee code " + txtFeeCode.Text + " updated successfully.";
                }
                else
                {
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Text = "Fee code " + txtFeeCode.Text + " saved successfully.";
                }
                btnClear_Click(null, null);
            }
        }
        catch (Exception ex)
        {

            WriteLogFile.LogError(ex);
        }
    }
    protected void txtFeeCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            FeeMasterBLL FeeMasterBLL = new FeeMasterBLL();
            FeeMasterDO FeeMasterDO = new FeeMasterDO();
            DataTable DtFeeMaster = new DataTable();

            FeeMasterDO.FeeCode = txtFeeCode.Text;
            DtFeeMaster = FeeMasterBLL.GetFeeMasterDetails(FeeMasterDO);
            if ((DtFeeMaster != null) && (DtFeeMaster.Rows.Count > 0))
            {
                ErrMsg.Visible = true;
                ErrMsg.ForeColor = System.Drawing.Color.Green;
                ErrMsg.Text = "Fee code " + txtFeeCode.Text + " already exists. You can edit the fee code or click on clear to create a new fee code.";

                txtFeeCode.Text = DtFeeMaster.Rows[0]["FeeCode"].ToString();
                txtFeeName.Text = DtFeeMaster.Rows[0]["FeeName"].ToString();
                ddlFeeType.SelectedValue = DtFeeMaster.Rows[0]["FeeTypeId"].ToString();
                ddlFeeMode.SelectedValue = DtFeeMaster.Rows[0]["FeeMode"].ToString();
                hdnFeeId.Value = DtFeeMaster.Rows[0]["FeeId"].ToString();

                chkIsActive.Visible = false;
                if (DtFeeMaster.Rows[0]["IsActive"].ToString().ToUpper() == "TRUE")
                {
                    chkIsActive.Checked = false;
                }
                else
                {
                    chkIsActive.Checked = false;
                }
                lblIsActive.Visible = false;
                txtFeeCode.Enabled = false;
            }
            else
                txtFeeName.Focus();
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
            txtFeeCode.Enabled = true;
            txtFeeCode.Text = string.Empty;
            txtFeeName.Text = string.Empty;
            ddlFeeType.SelectedIndex = 0;

            chkIsActive.Checked = false;
            chkIsActive.Visible = false;
            lblIsActive.Visible = false;
        }
        catch (Exception ex)
        {

            WriteLogFile.LogError(ex);
        }
    }
    protected void GvFeeMaster_PageIndexChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }

    }
    protected void GvFeeMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        FeeMasterBLL FeeMasterBLL = new FeeMasterBLL();
        FeeMasterDO FeeMasterDO = new FeeMasterDO();

        GvFeeMaster.PageIndex = e.NewPageIndex;
        FeeMasterDO.FeeCode = "";
        GvFeeMaster.DataSource = FeeMasterBLL.GetFeeMasterDetails(FeeMasterDO);
        GvFeeMaster.DataBind();
    }
    protected void lnkname_OnClick(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int ID = row.RowIndex;
            txtFeeCode.Text = GvFeeMaster.Rows[ID].Cells[1].Text;
            txtFeeName.Text = GvFeeMaster.Rows[ID].Cells[2].Text;
            ddlFeeType.SelectedValue = GvFeeMaster.DataKeys[ID].Values["FeeTypeId"].ToString();
            ddlFeeMode.SelectedValue = GvFeeMaster.DataKeys[ID].Values["FeeMode"].ToString();
            hdnFeeId.Value = GvFeeMaster.DataKeys[ID].Values["FeeId"].ToString();
            chkIsActive.Visible = false;
            if (GvFeeMaster.Rows[ID].Cells[5].Text.ToUpper() == "TRUE")
            {
                chkIsActive.Checked = false;
            }
            else
            {
                chkIsActive.Checked = false;
            }
            lblIsActive.Visible = false;
            txtFeeCode.Enabled = false;
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    #endregion

    #region Private Methods
    private Boolean ValidateFeeMster()
    {
        Boolean Result = true;
        string strMsg = string.Empty;
        try
        {
            if ((txtFeeCode.Text.Trim() == string.Empty))
            {
                Result = false;
                strMsg = "Fee code cannot be empty.</br>";
            }
            if (txtFeeName.Text.Trim() == string.Empty)
            {
                Result = false;
                strMsg = strMsg + "Fee name cannot be empty.</br>";
            }

            if (ddlFeeType.SelectedValue== "-1")
            {
                Result = false;
                strMsg = strMsg + "Please select Fee type.</br>";
            }

            if (!Result)
            {
                ErrMsg.Visible = true;
                ErrMsg.ForeColor = System.Drawing.Color.Red;
                ErrMsg.Text = strMsg;
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
