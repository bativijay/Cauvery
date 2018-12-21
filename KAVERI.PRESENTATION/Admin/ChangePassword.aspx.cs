using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KAVERI.DO;
using KAVERI.BLL;
using System.Data;
public partial class Login_ChangePassword : System.Web.UI.Page
{
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateUser())
            {
                int Result = 0;
                UserInfoDO UserInfoDO = new UserInfoDO();
                UserInfoBLL UserInfoBLL = new UserInfoBLL();
                UserInfoDO.UserName = Session["UserName"].ToString();
                UserInfoDO.Password = txtnewpwd.Text;
                UserInfoDO.ModifiedBy = 1;

                Result = UserInfoBLL.ChangeUserPassword(UserInfoDO);
                if (Result > 0)
                {
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Visible = true;
                    ErrMsg.Text = "Password changed succesfully for the user " + Session["UserName"].ToString() + ".";
                }
                else
                {
                    ErrMsg.ForeColor = System.Drawing.Color.Red;
                    ErrMsg.Visible = true;
                    ErrMsg.Text = "Failed to change the password for the user " + Session["UserName"].ToString() + ".";
                }
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }

    private Boolean ValidateUser()
    {
        string strMsg = string.Empty;
        Boolean Result = true;
        try
        {
            if (txtpwd.Text.Trim() == string.Empty)
            {
                Result = false;
                strMsg = "Password cannot be blank.</br>";
            }
            if (txtnewpwd.Text.Trim() == string.Empty)
            {
                Result = false;
                strMsg = strMsg + "New password cannot be blank.</br>";
            }
            if (txtreenterpwd.Text.Trim() == string.Empty)
            {
                Result = false;
                strMsg = strMsg + "Confirm New Password cannot be blank.</br>";
            }
            if (txtnewpwd.Text != txtreenterpwd.Text)
            {
                Result = false;
                strMsg = strMsg + "New Password and Confirm New Password are not matching.</br>";
            }

            UserInfoDO UserInfoDO = new UserInfoDO();
            UserInfoBLL UserInfoBLL = new UserInfoBLL();
            DataTable DtUser = new DataTable();

            UserInfoDO.UserName = Session["UserName"].ToString();
            DtUser = UserInfoBLL.GetLoginDetails(UserInfoDO);
            
            if ((DtUser != null) && (DtUser.Rows.Count > 0))
            {
                if (DtUser.Rows[0]["Password"].ToString() != txtpwd.Text)
                {
                    Result = false;
                    strMsg = strMsg + "Old Password is incorrect.";
                }
            }
            if (!Result)
            {
                Result = false;
                ErrMsg.ForeColor = System.Drawing.Color.Red;
                ErrMsg.Visible = true;
                ErrMsg.Text = strMsg;
            }
            
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
        return Result;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ErrMsg.Visible = false;
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        try
        {
            txtpwd.Text = string.Empty;
            txtnewpwd.Text = string.Empty;
            txtreenterpwd.Text = string.Empty;
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
}
