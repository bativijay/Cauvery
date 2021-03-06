﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_LogoutPage : System.Web.UI.Page
{
    /// <summary>
    /// Page_Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session.RemoveAll();
            Response.Redirect("~/login/LoginPage.aspx");
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
}
