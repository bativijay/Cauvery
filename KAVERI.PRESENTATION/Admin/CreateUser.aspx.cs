using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KAVERI.BLL;
using KAVERI.DO;
using System.Data;
using KAVERI.DO.Masters;
using System.Text.RegularExpressions;

public partial class Admin_CreateUser : System.Web.UI.Page
{
    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrMsg.Visible = false;
        if (!IsPostBack)
        {
            UserInfoBLL UserInfoBLL = new UserInfoBLL();
            UserInfoDO UserInfoDO = new UserInfoDO();
            UserInfoDO.UserName = "";
            CommonBLL CommonBLL = new CommonBLL();
            CommonClass.LoadDropdownList(ddlGender, CommonBLL.GetParameterDetails("Gender"), "ParameterName", "ParameterValue");

            GvStandardMaster.DataSource = UserInfoBLL.GetLoginDetails(UserInfoDO);
            GvStandardMaster.DataBind();
        }
    }
    #endregion

    #region CONTROL EVENTS
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            if (ValidateUserMaster())
            {
                UserInfoBLL UserInfoBLL = new UserInfoBLL();
                UserInfoDO UserInfoDO = new UserInfoDO();
                if (!txtUserName.Enabled)
                {
                    UserInfoDO.UserInfoId = Convert.ToInt32(hdnStandardId.Value);
                }
                UserInfoDO.FirstName = txtFirstName.Text.Trim().ToUpper();
                UserInfoDO.LastName = txtLastName.Text.Trim().ToUpper();
                UserInfoDO.UserName = txtUserName.Text.Trim();
                UserInfoDO.Password = txtPassword.Text.Trim();
                UserInfoDO.Address = txtAddress.Text.Trim();
                UserInfoDO.Email = txtEmail.Text.Trim();
                UserInfoDO.Gender = Convert.ToInt32(ddlGender.SelectedValue);

                if (chkIsAdmin.Checked)
                    UserInfoDO.RoleName = "Admin";
                else
                    UserInfoDO.RoleName = "User";

                UserInfoDO.CreatedBy =Convert.ToInt32( Session["LoginId"].ToString());
                UserInfoDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString());

                if (chkIsActive.Checked)
                {
                    UserInfoDO.IsActive = false;
                }
                else
                {
                    UserInfoDO.IsActive = true;
                }

                UserInfoBLL.InsertUserDetails(UserInfoDO);

                UserInfoDO.UserName = "";
                GvStandardMaster.DataSource = UserInfoBLL.GetLoginDetails(UserInfoDO);
                GvStandardMaster.DataBind();

                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;

                if (!txtUserName.Enabled)
                {
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Text = "User name " + txtUserName.Text + " updated successfully.";
                }
                else
                {
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Visible = true;
                    ErrMsg.Text = "User name " + txtUserName.Text + " saved successfully.";
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
            UserInfoBLL UserInfoBLL = new UserInfoBLL();
            UserInfoDO UserInfoDO = new UserInfoDO();
            DataTable DtStandardMaster = new DataTable();

            UserInfoDO.UserName = txtUserName.Text;
            DtStandardMaster = UserInfoBLL.GetLoginDetails(UserInfoDO);
            if ((DtStandardMaster != null) && (DtStandardMaster.Rows.Count > 0))
            {
                ErrMsg.ForeColor = System.Drawing.Color.Red;
                ErrMsg.Visible = true;
                ErrMsg.Text = "User Name already exists, you can edit the record. Click on clear to enter new record";

                txtFirstName.Text = DtStandardMaster.Rows[0]["FirstName"].ToString();
                txtLastName.Text = DtStandardMaster.Rows[0]["LastName"].ToString();

                txtAddress.Text = DtStandardMaster.Rows[0]["Address"].ToString();
                txtEmail.Text = DtStandardMaster.Rows[0]["Email"].ToString();
                txtPassword.Text = DtStandardMaster.Rows[0]["Password"].ToString();

                //txtPassword.Attributes["value"] = Request.Form[txtPassword.ClientID];
                txtPassword.Attributes.Add("value", DtStandardMaster.Rows[0]["Password"].ToString());
                ddlGender.SelectedValue = DtStandardMaster.Rows[0]["GenderId"].ToString().Trim();

                if (DtStandardMaster.Rows[0]["RoleName"].ToString() == "Admin")
                    chkIsAdmin.Checked = true;
                else
                    chkIsAdmin.Checked = false;

                chkIsActive.Visible = false;
                if (DtStandardMaster.Rows[0]["IsActive"].ToString().ToUpper() == "TRUE")
                {
                    chkIsActive.Checked = false;
                }
                else
                {
                    chkIsActive.Checked = false;
                }


                hdnStandardId.Value = DtStandardMaster.Rows[0]["Id"].ToString();


                txtUserName.Enabled = false;
            }
            else
            {
                txtEmail.Focus();
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
            txtUserName.Enabled = true;
            txtUserName.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtPassword.Attributes.Clear();
            ddlGender.SelectedIndex = 0;
            chkIsAdmin.Checked = false;
            chkIsActive.Checked = false;
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
        UserInfoBLL UserInfoBLL = new UserInfoBLL();
        UserInfoDO UserInfoDO = new UserInfoDO();

        GvStandardMaster.PageIndex = e.NewPageIndex;
        UserInfoDO.UserName = "";
        GvStandardMaster.DataSource = UserInfoBLL.GetLoginDetails(UserInfoDO);
        GvStandardMaster.DataBind();
    }
    protected void lnkname_OnClick(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;

            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int ID = row.RowIndex;
            txtFirstName.Text = GvStandardMaster.Rows[ID].Cells[1].Text;
            txtLastName.Text = GvStandardMaster.Rows[ID].Cells[2].Text;

            txtAddress.Text = GvStandardMaster.DataKeys[ID].Values["Address"].ToString();
            if (GvStandardMaster.Rows[ID].Cells[3].Text.Trim() == "&nbsp;")
                txtEmail.Text = "";
            else
                txtEmail.Text = GvStandardMaster.Rows[ID].Cells[3].Text.Trim();

            txtPassword.Attributes.Add("value", GvStandardMaster.DataKeys[ID].Values["Password"].ToString());
            txtUserName.Text = GvStandardMaster.DataKeys[ID].Values["UserName"].ToString();

            ddlGender.SelectedValue = GvStandardMaster.DataKeys[ID].Values["GenderId"].ToString().Trim();

            chkIsActive.Visible = false;
            if (GvStandardMaster.Rows[ID].Cells[5].Text.ToUpper() == "TRUE")
            {
                chkIsActive.Checked = false;
            }
            else
            {
                chkIsActive.Checked = false;
            }
            if (GvStandardMaster.DataKeys[ID].Values["RoleName"].ToString() == "Admin")
                chkIsAdmin.Checked = true;
            else
                chkIsAdmin.Checked = false;
            hdnStandardId.Value = GvStandardMaster.DataKeys[ID].Values["Id"].ToString();

            txtUserName.Enabled = false;
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    #endregion

    #region Private Methods
    private Boolean ValidateUserMaster()
    {
        string ErrorMsg = string.Empty;
        Boolean Result = true;
        try
        {
            if (txtFirstName.Text.Trim() == string.Empty)
            {
                Result = false;
                ErrorMsg = "First name cannot be empty. </br>";
            }

            if (txtLastName.Text.Trim() == string.Empty)
            {
                Result = false;
                ErrorMsg = ErrorMsg + "Last name cannot be empty. </br>";
            }

            if (txtUserName.Text.Trim() == string.Empty)
            {
                Result = false;
                ErrorMsg = ErrorMsg + "User name cannot be empty. </br>";
            }

            if (txtPassword.Text.Trim() == string.Empty)
            {
                Result = false;
                ErrorMsg = ErrorMsg + "Password cannot be empty. </br>";
            }
            if (isThereSpace(txtPassword.Text.Trim()))
            {
                Result = false;
                ErrorMsg = ErrorMsg + "Spaces not allowed in Password.</br>";
            }

            if (isThereSpace(txtUserName.Text.Trim()))
            {
                Result = false;
                ErrorMsg = ErrorMsg + "Spaces not allowed in user name.</br>";
            }

            if (ddlGender.SelectedValue == "-1")
            {
                Result = false;
                ErrorMsg = ErrorMsg + "Select Gender.</br>";
            }

            if (!Result)
            {
                ErrMsg.ForeColor = System.Drawing.Color.Red;
                ErrMsg.Visible = true;
                ErrMsg.Text = ErrorMsg;
            }
            
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }return Result;
    }

    bool isThereSpace(String s)
    {
        if (s.Contains(" "))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    #endregion

    #region GRIDVIEW EVENTS
    protected void GvStandardMaster_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Select")
            {

            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    #endregion
}
