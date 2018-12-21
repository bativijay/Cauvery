using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KAVERI.DO;
using KAVERI.BLL;
using System.Data;

public partial class User_Control_LwftMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginId"] != null)
        {
            if (!Page.IsPostBack)
                try
                {
                    loadmenus();
                }
                catch (Exception ex)
                {
                }
        }
        else
        {
            Response.Redirect("~/login/LoginPage.aspx");
        }
    }
    private void loadmenus()
    {
        try
        {
            UserInfoBLL _UserInfoBLL = new UserInfoBLL();
            DataTable DtMasterMenu = new DataTable();
            DataTable DtTransactionMenu = new DataTable();
            DataTable DtReportsMenu = new DataTable();

            DtTransactionMenu = _UserInfoBLL.GetMenu("Transaction", Session["RoleName"].ToString());
            TransactionGV.DataSource = DtTransactionMenu;
            TransactionGV.DataBind();

            DtMasterMenu = _UserInfoBLL.GetMenu("Master", Session["RoleName"].ToString());
            MasterGv.DataSource = DtMasterMenu;
            MasterGv.DataBind();


            DtReportsMenu = _UserInfoBLL.GetMenu("Report", Session["RoleName"].ToString());
            ReportsGV.DataSource = DtReportsMenu;
            ReportsGV.DataBind();

        }
        catch (Exception e)
        {

        }
    }
}
