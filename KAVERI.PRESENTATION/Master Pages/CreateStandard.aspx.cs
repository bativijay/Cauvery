using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KAVERI.BLL;
using KAVERI.DO.Masters;
using System.Data;

public partial class Admin_CreateStandard : System.Web.UI.Page
{
    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrMsg.Visible = false;
        if (!IsPostBack)
        {
            StandardMasterBLL StandardMasterBLL = new StandardMasterBLL();
            chkIsActive.Visible = false;
            lblIsActive.Visible = false;
            StandardMasterDO StandardMasterDO = new StandardMasterDO();
            StandardMasterDO.StandardCode = "";
            GvStandardMaster.DataSource = StandardMasterBLL.GetStandardMasterDetails(StandardMasterDO);
            GvStandardMaster.DataBind();
        }
    }
    #endregion

    #region CONTROL EVENTS
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            if (ValidateStandardMster())
            {
                StandardMasterBLL StandardMasterBLL = new StandardMasterBLL();
                StandardMasterDO StandardMasterDO = new StandardMasterDO();
                if (!txtStandardCode.Enabled)
                {
                    StandardMasterDO.StandardId = Convert.ToInt32(hdnStandardId.Value);
                }
                StandardMasterDO.StandardCode = txtStandardCode.Text.ToUpper();
                StandardMasterDO.StandardName = txtStandardName.Text.ToUpper();

                StandardMasterDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
                StandardMasterDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString());
                if (!txtStandardCode.Enabled)
                {
                    if (chkIsActive.Checked)
                    {
                        StandardMasterDO.IsActive = false;
                    }
                    else
                    {
                        StandardMasterDO.IsActive = true;
                    }
                }
                else
                {
                    StandardMasterDO.IsActive = true;
                }

                StandardMasterBLL.InsertStandardMasterDetails(StandardMasterDO);

                StandardMasterDO.StandardCode = "";
                GvStandardMaster.DataSource = StandardMasterBLL.GetStandardMasterDetails(StandardMasterDO);
                GvStandardMaster.DataBind();

                if (!txtStandardCode.Enabled)
                {
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Text = "Standard code " + txtStandardCode.Text + " updated successfully.";
                }
                else
                {
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Text = "Standard code " + txtStandardCode.Text + " created successfully.";
                }
                btnClear_Click(null, null);
            }
        }
        catch (Exception ex)
        {

            WriteLogFile.LogError(ex);
        }
    }
    protected void txtStandardCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            StandardMasterBLL StandardMasterBLL = new StandardMasterBLL();
            StandardMasterDO StandardMasterDO = new StandardMasterDO();
            DataTable DtStandardMaster = new DataTable();
            if (txtStandardCode.Text.Trim() != string.Empty)
            {
                StandardMasterDO.StandardCode = txtStandardCode.Text;
                DtStandardMaster = StandardMasterBLL.GetStandardMasterDetails(StandardMasterDO);
                if ((DtStandardMaster != null) && (DtStandardMaster.Rows.Count > 0))
                {
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Text = "Standard code " + txtStandardCode.Text + " already exists. You can edit the standard code or click on clear to create new standard code.";

                    txtStandardCode.Text = DtStandardMaster.Rows[0]["StandardCode"].ToString();
                    txtStandardName.Text = DtStandardMaster.Rows[0]["StandardName"].ToString();


                    hdnStandardId.Value = DtStandardMaster.Rows[0]["StandardId"].ToString();

                    if (DtStandardMaster.Rows[0]["IsActive"].ToString().ToUpper() == "TRUE")
                    {
                        chkIsActive.Checked = false;
                    }
                    else
                    {
                        chkIsActive.Checked = false;
                    }
                    chkIsActive.Visible = false;
                    lblIsActive.Visible = false;
                    txtStandardCode.Enabled = false;
                }
                else
                    txtStandardName.Focus();
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
            txtStandardCode.Enabled = true;
            txtStandardCode.Text = string.Empty;
            txtStandardName.Text = string.Empty;

            chkIsActive.Checked = false;
            chkIsActive.Visible = false;
            lblIsActive.Visible = false;
        }
        catch (Exception ex)
        {

            WriteLogFile.LogError(ex);
        }
    }
    protected void GvStandardMaster_PageIndexChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }

    }
    protected void GvStandardMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        StandardMasterBLL StandardMasterBLL = new StandardMasterBLL();
        StandardMasterDO StandardMasterDO = new StandardMasterDO();

        GvStandardMaster.PageIndex = e.NewPageIndex;
        StandardMasterDO.StandardCode = "";
        GvStandardMaster.DataSource = StandardMasterBLL.GetStandardMasterDetails(StandardMasterDO);
        GvStandardMaster.DataBind();
    }
    protected void lnkname_OnClick(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int ID = row.RowIndex;
            txtStandardCode.Text = GvStandardMaster.Rows[ID].Cells[1].Text;
            txtStandardName.Text = GvStandardMaster.Rows[ID].Cells[2].Text;

            hdnStandardId.Value = GvStandardMaster.DataKeys[ID].Values["StandardId"].ToString();
            chkIsActive.Visible = false;
            if (GvStandardMaster.Rows[ID].Cells[3].Text.ToUpper() == "TRUE")
            {
                chkIsActive.Checked = false;
            }
            else
            {
                chkIsActive.Checked = false;
            }
            lblIsActive.Visible = true;
            txtStandardCode.Enabled = false;
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    #endregion

    #region Private Methods
    private Boolean ValidateStandardMster()
    {
        Boolean Result = true;
        string strMsg = string.Empty;
        try
        {
            if ((txtStandardCode.Text.Trim() == string.Empty))
            {
                Result = false;
                strMsg = "Standard code cannot be empty.</br>";
            }
            if (txtStandardName.Text.Trim() == string.Empty)
            {
                Result = false;
                strMsg = strMsg + "Standard name cannot be empty.</br>";
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
