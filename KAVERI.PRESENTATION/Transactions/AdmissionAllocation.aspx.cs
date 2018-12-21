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
using System.Collections;
using System.Diagnostics;

public partial class Transactions_AdmissionAllocation : System.Web.UI.Page
{
    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrMsg.Visible = false;
        if (!IsPostBack)
        {
            CommonBLL CommonBLL = new CommonBLL();
            CommonClass.LoadDropdownListWithoutSelect(ddlAcedamic, CommonBLL.GetParameterDetails("Acedemic"), "ParameterName", "ParameterValue");

            AdmissionBLL AdmissionBLL = new AdmissionBLL();
            CandidateInfoDO CandidateInfoDO = new CandidateInfoDO();

            CandidateInfoDO.AcademicYear = Convert.ToInt32(ddlAcedamic.SelectedValue);

            DataTable DtAdmission = new DataTable();
            DtAdmission = AdmissionBLL.GetAdmissionAcademicDetails(CandidateInfoDO);

            GvAdmission.DataSource = CreateTable("Status IS null", DtAdmission);
            GvAdmission.DataBind();

            if (CreateTable("Status IS null", DtAdmission).Rows.Count > 0)
                btnSave.Visible = true;
            else
                btnSave.Visible = false;
        }
    }
    #endregion

    protected void btnGetDetails_Click(object sender, EventArgs e)
    {
        try
        {
            AdmissionBLL AdmissionBLL = new AdmissionBLL();
            CandidateInfoDO CandidateInfoDO = new CandidateInfoDO();

            CandidateInfoDO.AcademicYear = Convert.ToInt32(ddlAcedamic.SelectedValue);

            DataTable DtAdmission = new DataTable();
            DtAdmission = AdmissionBLL.GetAdmissionAcademicDetails(CandidateInfoDO);


            GvAdmission.DataSource = CreateTable("Status IS null", DtAdmission);
            GvAdmission.DataBind();


            if (CreateTable("Status IS null", DtAdmission).Rows.Count > 0)
                btnSave.Visible = true;
            else
                btnSave.Visible = false;
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            AdmissionBLL AdmissionBLL = new AdmissionBLL();
            List<CandidateInfoDO> CandidateInfoDoList = new List<CandidateInfoDO>();
            foreach (GridViewRow gvrow in GvAdmission.Rows)
            {
                CheckBox CheckBox = (CheckBox)gvrow.FindControl("ChkFee");
                if (CheckBox.Checked)
                {
                    CandidateInfoDO CandidateInfoDO = new CandidateInfoDO();
                    CandidateInfoDO.AcademicYear = Convert.ToInt32(ddlAcedamic.SelectedValue);
                    if (chkIsActive.Checked)
                        CandidateInfoDO.Status = 1;
                    else
                        CandidateInfoDO.Status = 0;
                    CandidateInfoDO.RegistrationId = Convert.ToInt32(GvAdmission.Rows[gvrow.RowIndex].Cells[1].Text);
                    CandidateInfoDoList.Add(CandidateInfoDO);
                }
            }
            int Result = 0;
            Result = AdmissionBLL.UpdateNewRegistrationNumber(CandidateInfoDoList);
            btnGetDetails_Click(null, null);

            if (Result > 0)
            {
                ErrMsg.Visible = true;
                ErrMsg.ForeColor = System.Drawing.Color.Green;
                ErrMsg.Text = "All selected students admission number re-generated succssfully for the academic year " + ddlAcedamic.SelectedItem.Text;
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex); 
        }
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
