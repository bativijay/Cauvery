using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KAVERI.BLL.Transactions;

using KAVERI.DO.Transactions;
using KAVERI.DO;
using System.Data;
using KAVERI.BLL;
using KAVERI.DO.Masters;

public partial class Transactions_ReceiptSearch : System.Web.UI.Page
{
    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrMsg.Visible = false;
        if (!IsPostBack)
        {
            CommonBLL CommonBLL = new CommonBLL();
            AdmissionBLL AdmissionBLL = new AdmissionBLL();
            CandidateInfoDO CandidateInfoDO = new CandidateInfoDO();

            CandidateInfoDO.RegistrationId = Convert.ToInt32("0");
            CandidateInfoDO.StudentName = txtStudentName.Text.Trim();

            ParentsInfoDO ParentsInfoDO = new ParentsInfoDO();
            ParentsInfoDO.FatherName = txtFatherName.Text.Trim();

            CandidateInfoDO.ParentsInfoDO = ParentsInfoDO;

            DataTable DtAdmission = new DataTable();
            DtAdmission = AdmissionBLL.GetAdmissionDetails(CandidateInfoDO);
            if (Session["StandardId"] != "")
            {
                GvAdmission.DataSource = CreateTable("standardId = " + Session["StandardId"].ToString(), DtAdmission);
                Session["StandardId"] = "";
            }
            else
                GvAdmission.DataSource = CreateTable("", DtAdmission);
            GvAdmission.DataBind();
        }
    }
    #endregion
    protected void btnGetDetails_Click(object sender, EventArgs e)
    {
        try
        {
            AdmissionBLL AdmissionBLL = new AdmissionBLL();
            CandidateInfoDO CandidateInfoDO = new CandidateInfoDO();

            CandidateInfoDO.RegistrationId = Convert.ToInt32("0");
            CandidateInfoDO.StudentName = txtStudentName.Text.Trim();

            ParentsInfoDO ParentsInfoDO = new ParentsInfoDO();
            ParentsInfoDO.FatherName = txtFatherName.Text.Trim();

            CandidateInfoDO.ParentsInfoDO = ParentsInfoDO;

            DataTable DtAdmission = new DataTable();
            DtAdmission = AdmissionBLL.GetAdmissionDetails(CandidateInfoDO);

            GvAdmission.DataSource = CreateTable("standardId = " + Session["StandardId"].ToString(), DtAdmission);
            GvAdmission.DataBind();
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    protected void chkSelect_OnClick(Object sender, EventArgs e)
    {
        try
        {
            Session["Selected_Student"] = null;
            Session["StudentName"] = null;
            Session["FatherName"] = null;

            GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
            LinkButton lblID = (LinkButton)clickedRow.FindControl("chkSelect");

            Session["Selected_Student"] = lblID.Text;
            Session["StudentName"] = GvAdmission.Rows[clickedRow.RowIndex].Cells[2].Text;
            Session["FatherName"] = GvAdmission.Rows[clickedRow.RowIndex].Cells[6].Text;
            Session["StandardId"] = "";
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "JavaScript", "Javascript: postbackParent()", true);
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtStudentName.Text = string.Empty;
        txtFatherName.Text = string.Empty;
    }

    public static DataTable CreateTable(string Query, DataTable DataTableOriginal)
    {
        DataTable DataTableDuplicate = new DataTable();
        // the clone method copies the structer of datatableorginal to datatableduplicate
        DataTableDuplicate = DataTableOriginal.Clone();
        foreach (DataRow dr in DataTableOriginal.Select(Query))
        {
            //importrow method copies the datarow to datatableduplicate which has the correct structure
            DataTableDuplicate.ImportRow(dr);
        }

        return DataTableDuplicate;
    }
}
