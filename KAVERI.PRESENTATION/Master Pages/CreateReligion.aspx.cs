using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KAVERI.BLL;
using KAVERI.DO.Masters;
using System.Data;

public partial class Admin_CreateReligion : System.Web.UI.Page
{
    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrMsg.Visible = false;
        if (!IsPostBack)
        {
            ReligionMasterBLL ReligionMasterBLL = new ReligionMasterBLL();
            chkIsActive.Visible = false;
            lblIsActive.Visible = false;
            ReligionMasterDO ReligionMasterDO = new ReligionMasterDO();
            ReligionMasterDO.ReligionCode = "";
            GvReligionMaster.DataSource = ReligionMasterBLL.GetReligionMasterDetails(ReligionMasterDO);
            GvReligionMaster.DataBind();
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
            if (ValidateReligionMster())
            {
                ReligionMasterBLL ReligionMasterBLL = new ReligionMasterBLL();
                ReligionMasterDO ReligionMasterDO = new ReligionMasterDO();
                if (!txtReligionCode.Enabled)
                {
                    ReligionMasterDO.ReligionId = Convert.ToInt32(hdnReligionId.Value);
                }
                ReligionMasterDO.ReligionCode = txtReligionCode.Text.ToUpper();
                ReligionMasterDO.ReligionName = txtReligionName.Text.ToUpper();

                ReligionMasterDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
                ReligionMasterDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString());
                if (!txtReligionCode.Enabled)
                {
                    if (chkIsActive.Checked)
                    {
                        ReligionMasterDO.IsActive = false;
                    }
                    else
                    {
                        ReligionMasterDO.IsActive = true;
                    }
                }
                else
                {
                    ReligionMasterDO.IsActive = true;
                }

                ReligionMasterBLL.InsertReligionMasterDetails(ReligionMasterDO);

                ReligionMasterDO.ReligionCode = "";
                GvReligionMaster.DataSource = ReligionMasterBLL.GetReligionMasterDetails(ReligionMasterDO);
                GvReligionMaster.DataBind();
                 
                if (!txtReligionCode.Enabled)
                {
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Text = "Religion code " + txtReligionCode.Text + " updated successfully.";
                }
                else
                {
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Text = "Religion code " + txtReligionCode.Text + " saved successfully.";
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
    /// txtReligionCode_TextChanged
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtReligionCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ReligionMasterBLL ReligionMasterBLL = new ReligionMasterBLL();
            ReligionMasterDO ReligionMasterDO = new ReligionMasterDO();
            DataTable DtReligionMaster = new DataTable();

            ReligionMasterDO.ReligionCode = txtReligionCode.Text;
            DtReligionMaster = ReligionMasterBLL.GetReligionMasterDetails(ReligionMasterDO);
            if ((DtReligionMaster != null) && (DtReligionMaster.Rows.Count > 0))
            {
                ErrMsg.Visible = true;
                ErrMsg.ForeColor = System.Drawing.Color.Red;
                ErrMsg.Text = "Religion code " + txtReligionCode.Text + " already exists. You can edit the religion code or click clear to create new religion code.";
                txtReligionCode.Text = DtReligionMaster.Rows[0]["ReligionCode"].ToString();
                txtReligionName.Text = DtReligionMaster.Rows[0]["ReligionName"].ToString();
                hdnReligionId.Value = DtReligionMaster.Rows[0]["ReligionId"].ToString();
                chkIsActive.Visible = false;
                if (DtReligionMaster.Rows[0]["IsActive"].ToString().ToUpper() == "TRUE")
                {
                    chkIsActive.Checked = false;
                }
                else
                {
                    chkIsActive.Checked = false;
                }
                lblIsActive.Visible = true;
                txtReligionCode.Enabled = false;
            }
            else
                txtReligionName.Focus();
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
            txtReligionCode.Enabled = true;
            txtReligionCode.Text = string.Empty;
            txtReligionName.Text = string.Empty;

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
    /// GvReligionMaster_PageIndexChanged
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GvReligionMaster_PageIndexChanged(object sender, EventArgs e)
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
    /// GvReligionMaster_PageIndexChanging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GvReligionMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ReligionMasterBLL ReligionMasterBLL = new ReligionMasterBLL();
        ReligionMasterDO ReligionMasterDO = new ReligionMasterDO();

        GvReligionMaster.PageIndex = e.NewPageIndex;
        ReligionMasterDO.ReligionCode = "";
        GvReligionMaster.DataSource = ReligionMasterBLL.GetReligionMasterDetails(ReligionMasterDO);
        GvReligionMaster.DataBind();
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
            txtReligionCode.Text = GvReligionMaster.Rows[ID].Cells[1].Text;
            txtReligionName.Text = GvReligionMaster.Rows[ID].Cells[2].Text;

            hdnReligionId.Value = GvReligionMaster.DataKeys[ID].Values["ReligionId"].ToString();
            chkIsActive.Visible = false;
            if (GvReligionMaster.Rows[ID].Cells[3].Text.ToUpper() == "TRUE")
            {
                chkIsActive.Checked = false;
            }
            else
            {
                chkIsActive.Checked = false;
            }
            lblIsActive.Visible = true;
            txtReligionCode.Enabled = false;
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// ValidateReligionMster
    /// </summary>
    /// <returns></returns>
    private Boolean ValidateReligionMster()
    {
        Boolean Result = true;
        string strMsg = string.Empty;
        try
        {
            if ((txtReligionCode.Text.Trim() == string.Empty))
            {
                Result = false;
                strMsg = "Religion code cannot be empty.</br>";
            }
            if (txtReligionName.Text.Trim() == string.Empty)
            {
                Result = false;
                strMsg = strMsg + "Religion name cannot be empty.</br>";
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
