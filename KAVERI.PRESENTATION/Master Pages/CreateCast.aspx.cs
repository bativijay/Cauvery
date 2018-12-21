using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KAVERI.BLL;
using KAVERI.DO.Masters;
using System.Data;

public partial class Admin_CreateCast : System.Web.UI.Page
{
    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ErrMsg.Visible = false;
            if (!IsPostBack)
            {
                CastMasterBLL CastMasterBLL = new CastMasterBLL();
                chkIsActive.Visible = false;
                lblIsActive.Visible = false;
                CastMasterDO CastMasterDO = new CastMasterDO();
                CastMasterDO.CastCode = "";
                GvCastMaster.DataSource = CastMasterBLL.GetCastMasterDetails(CastMasterDO);
                GvCastMaster.DataBind();
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    #endregion

    #region CONTROL EVENTS
    /// <summary>
    /// btnSave_Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateCastMster())
            {
                CastMasterBLL CastMasterBLL = new CastMasterBLL();
                CastMasterDO CastMasterDO = new CastMasterDO();
                if (!txtCastCode.Enabled)
                {
                    CastMasterDO.CastId = Convert.ToInt32(hdnCastId.Value);
                }
                CastMasterDO.CastCode = txtCastCode.Text.ToUpper();
                CastMasterDO.CastName = txtCastName.Text.ToUpper();
                CastMasterDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
                CastMasterDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString());
                if (!txtCastCode.Enabled)
                {
                    if (chkIsActive.Checked)
                    {
                        CastMasterDO.IsActive = false;
                    }
                    else
                    {
                        CastMasterDO.IsActive = true;
                    }
                }
                else
                {
                    CastMasterDO.IsActive = true;
                }
                CastMasterBLL.InsertCastMasterDetails(CastMasterDO);
                CastMasterDO.CastCode = "";
                GvCastMaster.DataSource = CastMasterBLL.GetCastMasterDetails(CastMasterDO);
                GvCastMaster.DataBind();
                if (!txtCastCode.Enabled)
                {
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Text = "Caste code " + txtCastCode.Text + " updated successfully.";
                }
                else
                {
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Text = "Caste code " + txtCastCode.Text + " saved successfully.";
                }
                btnClear_Click(null, null);
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }

    /// <summary>
    /// txtCastCode_TextChanged
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtCastCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CastMasterBLL CastMasterBLL = new CastMasterBLL();
            CastMasterDO CastMasterDO = new CastMasterDO();
            DataTable DtCastMaster = new DataTable();
            CastMasterDO.CastCode = txtCastCode.Text;
            DtCastMaster = CastMasterBLL.GetCastMasterDetails(CastMasterDO);
            if ((DtCastMaster != null) && (DtCastMaster.Rows.Count > 0))
            {
                ErrMsg.Visible = true;
                ErrMsg.ForeColor = System.Drawing.Color.Red;
                ErrMsg.Text = "Cast code already exists, you can either edit the cast code or click on clear to create a new cast code.";
                txtCastCode.Text = DtCastMaster.Rows[0]["CastCode"].ToString();
                txtCastName.Text = DtCastMaster.Rows[0]["CastName"].ToString();
                hdnCastId.Value = DtCastMaster.Rows[0]["CastId"].ToString();
                if (DtCastMaster.Rows[0]["IsActive"].ToString().ToUpper() == "TRUE")
                {
                    chkIsActive.Checked = false;
                }
                else
                {
                    chkIsActive.Checked = true;
                }
                chkIsActive.Visible = false;
                lblIsActive.Visible = false;
                txtCastCode.Enabled = false;
            }
            else
                txtCastName.Focus();
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }

    /// <summary>
    /// btnClear_Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            txtCastCode.Enabled = true;
            txtCastCode.Text = string.Empty;
            txtCastName.Text = string.Empty;

            chkIsActive.Checked = false;
            chkIsActive.Visible = false;
            lblIsActive.Visible = false;
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }

    /// <summary>
    /// GvCastMaster_PageIndexChanged
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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

    /// <summary>
    /// GvCastMaster_PageIndexChanging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GvCastMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            CastMasterBLL CastMasterBLL = new CastMasterBLL();
            CastMasterDO CastMasterDO = new CastMasterDO();

            GvCastMaster.PageIndex = e.NewPageIndex;
            CastMasterDO.CastCode = "";
            GvCastMaster.DataSource = CastMasterBLL.GetCastMasterDetails(CastMasterDO);
            GvCastMaster.DataBind();
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }

    /// <summary>
    /// lnkname_OnClick
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkname_OnClick(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int ID = row.RowIndex;

            txtCastCode.Text = GvCastMaster.Rows[ID].Cells[1].Text;
            txtCastName.Text = GvCastMaster.Rows[ID].Cells[2].Text;

            hdnCastId.Value = GvCastMaster.DataKeys[ID].Values["CastId"].ToString();

            chkIsActive.Visible = false;
            if (GvCastMaster.Rows[ID].Cells[3].Text.ToUpper() == "TRUE")
            {
                chkIsActive.Checked = false;
            }
            else
            {
                chkIsActive.Checked = false;
            }
            chkIsActive.Visible = true;
            lblIsActive.Visible = true;
            txtCastCode.Enabled = false;
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// ValidateCastMster
    /// </summary>
    /// <returns></returns>
    private Boolean ValidateCastMster()
    {
        Boolean Result = true;
        string strMsg = string.Empty;
        try
        {
            if (txtCastCode.Text.Trim() == string.Empty)
            {
                Result = false;
                strMsg = "Caste code cannot be empty.</br>";
            }

            if ((txtCastName.Text.Trim() == string.Empty))
            {
                Result = false;
                Result = false;
                strMsg = strMsg + "Caste name cannot be empty.</br>";
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
