using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Control_Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           // Userinfo ouserinf = new Userinfo();
        if (Session["signeduser"] != null)
        {
            //ouserinf = (Userinfo)Session["signeduser"];
            Label2.Text = "Welcome" + " " + Session["signeduser"]+", Date: " + DateTime.Now.ToShortDateString();
        }
        else
        {
            Label2.Visible = false;

        }
        }
        catch (Exception ex)
        {

            WriteLogFile.LogError(ex);
        }
    }
}
