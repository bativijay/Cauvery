using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using KAVERI.DO;
using KAVERI.BLL;
using System.Data;
using Microsoft.Win32;
using System.IO;
using System.Management;
public partial class Login_LoginPage : System.Web.UI.Page
{
    UserInfoDO ouserinfo = new UserInfoDO();

    /// <summary>
    /// Page_Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        txtusrname.Focus();
    }

    /// <summary>
    /// Button1_Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        #region License Information
        bool isValidLicensedUser = true;
        try
        {
            //Create license data and copy information in reistry accessing the CurrentUser root element and adding "OurSettings" subkey to the "SOFTWARE" subkey  

            //if (CommonClass.ReadSubKeyValue("SOFTWARE\\KAVERI", "InstalledOn") == string.Empty)
            //    CommonClass.WriteToRegistry("InstalledOn", DateTime.Now.ToShortDateString());

            //Capture Licensing information
            //if (getUniqueID("C") != "BFEBFBFF00020655")
            //{
            //  if (Convert.ToDateTime(CommonClass.ReadSubKeyValue("SOFTWARE\\KAVERI", "InstalledOn")).AddDays(15) <= DateTime.Now)
            //{
            //  string AlertMsg;
            //isValidLicensedUser = false;
            //AlertMsg = "<script language=javascript> alert('Your license period is expired, please contact an administrator');</script>";
            //ClientScript.RegisterStartupScript(typeof(String), "myscript", AlertMsg);
            //}
            // }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
        #endregion

        #region Validate User & Redirect
        try
        {
            if (isValidLicensedUser)
            {
                if (txtpwd.Text != "" && txtusrname.Text != "")
                {
                    if (userexists(txtusrname.Text.Trim(), txtpwd.Text.Trim()))
                    {
                        Response.Redirect("~/login/homepage.aspx");
                    }
                    else
                    {
                        string AlertMsg;
                        AlertMsg = "<script language=javascript> alert('Username And Password Does Not Exists');</script>";
                        ClientScript.RegisterStartupScript(typeof(String), "myscript", AlertMsg);
                    }
                }
                else
                {
                    string AlertMsg;
                    AlertMsg = "<script language=javascript> alert('Please Enter User Name And Password');</script>";
                    ClientScript.RegisterStartupScript(typeof(String), "myscript", AlertMsg);
                }
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
        #endregion
    }

    /// <summary>
    /// getUniqueID
    /// </summary>
    /// <param name="drive"></param>
    /// <returns></returns>
    private string getUniqueID(string drive)
    {
        string cpuID = string.Empty, volumeSerial = string.Empty;
        try
        {
            if (drive == string.Empty)
            {
                //Find first drive
                foreach (DriveInfo compDrive in DriveInfo.GetDrives())
                {
                    if (compDrive.IsReady)
                    {
                        drive = compDrive.RootDirectory.ToString();
                        break;
                    }
                }
            }

            if (drive.EndsWith(":\\"))
            {
                //C:\ -> C
                drive = drive.Substring(0, drive.Length - 2);
            }

            volumeSerial = getVolumeSerial(drive);
            cpuID = getCPUID();
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
        //Mix them up and remove some useless 0's
        return cpuID.Substring(13) + cpuID.Substring(1, 4) + volumeSerial + cpuID.Substring(4, 4);
    }

    /// <summary>
    /// getVolumeSerial
    /// </summary>
    /// <param name="drive"></param>
    /// <returns></returns>
    private string getVolumeSerial(string drive)
    {
        string volumeSerial = string.Empty;
        try
        {
            ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            disk.Get();

            volumeSerial = disk["VolumeSerialNumber"].ToString();
            disk.Dispose();

        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
        return volumeSerial;
    }

    /// <summary>
    /// getCPUID
    /// </summary>
    /// <returns></returns>
    private string getCPUID()
    {
        string cpuInfo = string.Empty;
        try
        {
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();
            foreach (ManagementObject managObj in managCollec)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = managObj.Properties["processorID"].Value.ToString();
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
        return cpuInfo;
    }

    /// <summary>
    /// userexists
    /// </summary>
    /// <param name="username"></param>
    /// <param name="pwd"></param>
    /// <returns></returns>
    private bool userexists(string username, string pwd)
    {
        UserInfoBLL _UserInfoBLL = new UserInfoBLL();
        string encryptpwd = pwd;
        try
        {
            int count = 0;
            UserInfoDO _UserInfoDO = new UserInfoDO();
            _UserInfoDO.UserName = username;
            _UserInfoDO.Password = pwd;
            count = _UserInfoBLL.AuthenticateUser(_UserInfoDO);
            if (count > 0)
            {
                DataTable DtLogin = new DataTable();
                DtLogin = _UserInfoBLL.GetLoginDetails(_UserInfoDO);

                Session["signeduser"] = DtLogin.Rows[0]["FirstName"].ToString() + ' ' + DtLogin.Rows[0]["LastName"].ToString();
                Session["RoleName"] = DtLogin.Rows[0]["RoleName"].ToString();
                Session["UserName"] = DtLogin.Rows[0]["UserName"].ToString();
                Session["LoginId"] = DtLogin.Rows[0]["Id"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            WriteLogFile.LogError(e);
            return false;
        }
    }
}
