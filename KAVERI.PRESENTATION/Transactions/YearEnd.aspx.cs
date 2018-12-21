using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KAVERI.BLL.Transactions;
using System.Data.SqlTypes;

using System.ComponentModel;


using KAVERI.DO.Transactions;
using KAVERI.DO;
using System.Data;
using KAVERI.BLL;
using KAVERI.DO.Masters;
using System.Globalization;
using System.Web.UI.HtmlControls;
using KAVERI.UTILITY;
public partial class Transactions_YearEnd : System.Web.UI.Page
{
    DataTable DtFee = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrMsg.Visible = false;
        try
        {
            if (!IsPostBack)
            {
                CommonBLL CommonBLL = new CommonBLL();
                CommonClass.LoadDropdownListWithoutSelect(ddlAcedamic, CommonBLL.GetParameterDetails("Acedemic"), "ParameterName", "ParameterValue");


                txtDOB.Text = CommonBLL.GetAcademicYear(ddlAcedamic.SelectedItem.Text).Rows[0]["AcademicStartDate"].ToString(); //"01/06/" + DateTime.Now.Year;
                EndDateTextBox.Text = CommonBLL.GetAcademicYear(ddlAcedamic.SelectedItem.Text).Rows[0]["AcademicEndDate"].ToString();//"31/05/" + DateTime.Now.AddYears(1).Year;
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }

    protected void BtnSave_OnClick(object sender, EventArgs e)
    {
        try
        {
            CommonBLL CommonBLL = new CommonBLL();
            if (CommonBLL.IsAcademicYear(ddlAcedamic.SelectedItem.Text).Rows.Count == 0)
            //if ((DateTime.Now.AddYears(1).Year.ToString() + " - " + DateTime.Now.AddYears(2).Year.ToString()).ToString() != ddlAcedamic.SelectedItem.Text)
            //if ((Convert.ToDateTime(txtDOB.Text).AddYears(1).Year.ToString() + " - " + Convert.ToDateTime(EndDateTextBox.Text).AddYears(1).Year.ToString()).ToString() != ddlAcedamic.SelectedItem.Text)
            {
                int Result = 0;

                Result = CommonBLL.InsertNewYear((Convert.ToDateTime(txtDOB.Text).AddYears(1).Year.ToString() + " - " + Convert.ToDateTime(EndDateTextBox.Text).AddYears(1).Year.ToString()).ToString(), Convert.ToInt32(ddlAcedamic.SelectedValue));
                ErrMsg.Visible = true;
                if (Result == 0)
                {
                    ErrMsg.ForeColor = System.Drawing.Color.Red;
                    ErrMsg.Text = "Year end already performed on the current year";
                }
                else
                {
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Text = "Year end completed";
                }
            }
            else
            {
                ErrMsg.Visible = true;
                ErrMsg.ForeColor = System.Drawing.Color.Red;
                ErrMsg.Text = "Year end already performed on the current year";
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
}
