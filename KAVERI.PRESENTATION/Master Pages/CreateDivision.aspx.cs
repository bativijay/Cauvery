using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KAVERI.BLL;
using KAVERI.DO;
using System.Data;

public partial class Admin_CreateDivision : System.Web.UI.Page
{
    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrMsg.Visible = false;
        if (!IsPostBack)
        {
            DivisionMasterBLL DivisionMasterBLL = new DivisionMasterBLL();
            chkIsActive.Visible = false;
            lblIsActive.Visible = false;
            DivisionMasterDO DivisionMasterDO = new DivisionMasterDO();
            DivisionMasterDO.DivisionCode = "";
            GvDivisionMaster.DataSource = DivisionMasterBLL.GetDivisionMasterDetails(DivisionMasterDO);
            GvDivisionMaster.DataBind();
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
            ErrMsg.Visible = false;
            if (ValidateDivisionMster())
            {
                DivisionMasterBLL DivisionMasterBLL = new DivisionMasterBLL();
                DivisionMasterDO DivisionMasterDO = new DivisionMasterDO();
                if (!txtDivisionCode.Enabled)
                {
                    DivisionMasterDO.DivisionId = Convert.ToInt32(hdnDivisionId.Value);
                }
                DivisionMasterDO.DivisionCode = txtDivisionCode.Text.ToUpper();
                DivisionMasterDO.DivisionName = txtDivisionName.Text.ToUpper();

                DivisionMasterDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
                DivisionMasterDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString());
                if (!txtDivisionCode.Enabled)
                {
                    if (chkIsActive.Checked)
                    {
                        DivisionMasterDO.IsActive = false;
                    }
                    else
                    {
                        DivisionMasterDO.IsActive = true;
                    }
                }
                else
                {
                    DivisionMasterDO.IsActive = true;
                }

                DivisionMasterBLL.InsertDivisionMasterDetails(DivisionMasterDO);

                DivisionMasterDO.DivisionCode = "";
                GvDivisionMaster.DataSource = DivisionMasterBLL.GetDivisionMasterDetails(DivisionMasterDO);
                GvDivisionMaster.DataBind();

                if (!txtDivisionCode.Enabled)
                {
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Text = "Division code  " + txtDivisionCode.Text + " updated succesfully.";
                }
                else
                {
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Text = "Division code  " + txtDivisionCode.Text + " saved succesfully.";
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
    /// txtDivisionCode_TextChanged
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtDivisionCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DivisionMasterBLL DivisionMasterBLL = new DivisionMasterBLL();
            DivisionMasterDO DivisionMasterDO = new DivisionMasterDO();
            DataTable DtDivisionMaster = new DataTable();

            DivisionMasterDO.DivisionCode = txtDivisionCode.Text;
            DtDivisionMaster = DivisionMasterBLL.GetDivisionMasterDetails(DivisionMasterDO);
            if ((DtDivisionMaster != null) && (DtDivisionMaster.Rows.Count > 0))
            {
                ErrMsg.Visible = true;
                ErrMsg.ForeColor = System.Drawing.Color.Red;
                ErrMsg.Text = "Division code" + txtDivisionCode.Text + " </br>already exists. you can edit the division code or click on clear to create new division code.";
                txtDivisionCode.Text = DtDivisionMaster.Rows[0]["DivisionCode"].ToString();
                txtDivisionName.Text = DtDivisionMaster.Rows[0]["DivisionName"].ToString();
                hdnDivisionId.Value = DtDivisionMaster.Rows[0]["DivisionId"].ToString();
                if (DtDivisionMaster.Rows[0]["IsActive"].ToString().ToUpper() == "TRUE")
                {
                    chkIsActive.Checked = false;
                }
                else
                {
                    chkIsActive.Checked = false;
                }
                chkIsActive.Visible = false;
                lblIsActive.Visible = false;
                txtDivisionCode.Enabled = false;
            }
            else
                txtDivisionName.Focus();
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
            txtDivisionCode.Enabled = true;
            txtDivisionCode.Text = string.Empty;
            txtDivisionName.Text = string.Empty;

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
    /// GvDivisionMaster_PageIndexChanged
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GvDivisionMaster_PageIndexChanged(object sender, EventArgs e)
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
    /// GvDivisionMaster_PageIndexChanging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GvDivisionMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DivisionMasterBLL DivisionMasterBLL = new DivisionMasterBLL();
            DivisionMasterDO DivisionMasterDO = new DivisionMasterDO();

            GvDivisionMaster.PageIndex = e.NewPageIndex;
            DivisionMasterDO.DivisionCode = "";
            GvDivisionMaster.DataSource = DivisionMasterBLL.GetDivisionMasterDetails(DivisionMasterDO);
            GvDivisionMaster.DataBind();
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

            txtDivisionCode.Text = GvDivisionMaster.Rows[ID].Cells[1].Text;
            txtDivisionName.Text = GvDivisionMaster.Rows[ID].Cells[2].Text;

            hdnDivisionId.Value = GvDivisionMaster.DataKeys[ID].Values["DivisionId"].ToString();
            chkIsActive.Visible = true;
            if (GvDivisionMaster.Rows[ID].Cells[3].Text.ToUpper() == "TRUE")
            {
                chkIsActive.Checked = false;
            }
            else
            {
                chkIsActive.Checked = false;
            }
            lblIsActive.Visible = true;
            txtDivisionCode.Enabled = false;
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    #endregion

    #region Private Methods
    private Boolean ValidateDivisionMster()
    {
        Boolean Result = true;
        string strMsg = string.Empty;
        try
        {
            if (txtDivisionCode.Text.Trim() == string.Empty)
            {
                Result = false;
                strMsg = "Division code cannot be blank.</br>";
            }

            if (txtDivisionName.Text.Trim() == string.Empty)
            {
                Result = false;
                strMsg = "Division name cannot be blank.</br>";
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
