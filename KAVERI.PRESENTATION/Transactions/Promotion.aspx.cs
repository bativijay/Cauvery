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

public partial class Transactions_Promotion : System.Web.UI.Page
{
    #region PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrMsg.Visible = false;
        if (!IsPostBack)
        {
            CommonBLL CommonBLL = new CommonBLL();
            CommonClass.LoadDropdownListWithoutSelect(ddlAcedamic, CommonBLL.GetParameterDetails("Acedemic"), "ParameterName", "ParameterValue");
            CommonClass.LoadDropdownListWithoutSelect(ddlCurrentAcedamic, CommonBLL.GetParameterDetails("Acedemic"), "ParameterName", "ParameterValue");

            AdmissionBLL AdmissionBLL = new AdmissionBLL();
            CandidateInfoDO CandidateInfoDO = new CandidateInfoDO();

            StandardMasterBLL StandardMasterBLL = new StandardMasterBLL();
            StandardMasterDO StandardMasterDO = new StandardMasterDO();
            StandardMasterDO.StandardCode = "";

            CommonClass.LoadDropdownList(ddlPromoteStandard, StandardMasterBLL.GetActiveStandardMasterDetails(StandardMasterDO), "StandardName", "StandardId");
            CommonClass.LoadDropdownList(ddlStandard, StandardMasterBLL.GetActiveStandardMasterDetails(StandardMasterDO), "StandardName", "StandardId");

            CandidateInfoDO.AcademicYear = Convert.ToInt32(ddlAcedamic.SelectedValue);

            ddlAcedamic.SelectedValue = (Convert.ToInt32(ddlCurrentAcedamic.SelectedValue) - 1).ToString();

            /*DataTable DtAdmission = new DataTable();
             DtAdmission = AdmissionBLL.GetAdmissionAcademicDetails(CandidateInfoDO);

             GvAdmission.DataSource = CreateTable("Status IS null", DtAdmission);
             GvAdmission.DataBind();

             if (CreateTable("Status IS null", DtAdmission).Rows.Count > 0)
                 btnSave.Visible = true;
             else
                 btnSave.Visible = false;
             btnSave.Visible = true;*/
        }
    }
    #endregion

    #region CONTROL EVENTS
    protected void btnGetDetails_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateCollection(false))
            {
                AdmissionBLL AdmissionBLL = new AdmissionBLL();
                CandidateInfoDO CandidateInfoDO = new CandidateInfoDO();

                CandidateInfoDO.AcademicYear = Convert.ToInt32(ddlAcedamic.SelectedValue);

                DataTable DtAdmission = new DataTable();
                DtAdmission = AdmissionBLL.GetAdmissionAcademicDetailsForPromotion(CandidateInfoDO);


                GvAdmission.DataSource = CreateTable("Status = 0    AND StandardName ='" + ddlStandard.SelectedItem.Text + "'", DtAdmission);
                GvAdmission.DataBind();


                if (CreateTable("Status = 0 ", DtAdmission).Rows.Count > 0)
                    btnSave.Visible = true;
                else
                    btnSave.Visible = false;
            }
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
            if (ValidateCollection(true))
            {
                DataTable DtFee = new DataTable();
                AdmissionBLL AdmissionBLL = new AdmissionBLL();
                List<CandidateInfoDO> CandidateInfoDoList = new List<CandidateInfoDO>();
                foreach (GridViewRow gvrow in GvAdmission.Rows)
                {
                    CheckBox CheckBox = (CheckBox)gvrow.FindControl("ChkFee");
                    if (CheckBox.Checked)
                    {
                        CandidateInfoDO CandidateInfoDO = new CandidateInfoDO();
                        CandidateInfoDO.AcademicYear = Convert.ToInt32(ddlAcedamic.SelectedValue);
                        CandidateInfoDO.CurrentAcademicYear = Convert.ToInt32(ddlCurrentAcedamic.SelectedValue);
                        CandidateInfoDO.StandardSought = Convert.ToInt32(ddlPromoteStandard.SelectedValue);
                        CandidateInfoDO.FeeTemplateId = Convert.ToInt32(ddlTemplate.SelectedValue);
                        CandidateInfoDO.RegistrationId = Convert.ToInt32(GvAdmission.Rows[gvrow.RowIndex].Cells[1].Text);
                        CandidateInfoDO.StudentName= GvAdmission.Rows[gvrow.RowIndex].Cells[2].Text;
                        CandidateInfoDO.FatherName = GvAdmission.Rows[gvrow.RowIndex].Cells[6].Text;
                        CandidateInfoDoList.Add(CandidateInfoDO);


                        #region Fee Collection
                        FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
                        FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();
                        FeeCollectionBLL FeeCollectionBLL = new FeeCollectionBLL();
                        FeeCollectionDO FeeCollectionDO = new FeeCollectionDO();
                        DataTable DtCheck = new DataTable();

                        FeeCollectionDO.StandardId = Convert.ToInt32(ddlStandard.SelectedValue);
                        FeeCollectionDO.TemplateId = Convert.ToInt32(ddlTemplate.SelectedValue);
                        FeeCollectionDO.RegistrationId = Convert.ToInt32(GvAdmission.Rows[gvrow.RowIndex].Cells[1].Text);
                        FeeCollectionDO.AcademicYearId = Convert.ToInt32(ddlCurrentAcedamic.SelectedValue);

                        DtCheck = FeeCollectionBLL.CheckFeeCollectionDetails(FeeCollectionDO);

                        if (DtCheck.Rows.Count == 0)
                        {
                            DtFee = FeeMappingBLL.GetFeeMasterDetails(Convert.ToInt32(ddlTemplate.SelectedValue), 1);
                        }
                        else
                        {
                            DtFee = FeeCollectionBLL.GetFeeCollectionDetails(FeeCollectionDO);
                        }

                        FeeCollectionDO.TotalAmountPaid = 0;
                        FeeCollectionDO.TotalFeeAmount = Convert.ToDouble(DtFee.Compute("Sum(Amount)", ""));
                        FeeCollectionDO.TotalPendingAmount = Convert.ToDouble(DtFee.Compute("Sum(Amount)", ""));
                        #endregion
                    }
                }
                int Result = 0;
                Result = AdmissionBLL.UpdateAllocation(CandidateInfoDoList, DtFee);
                btnGetDetails_Click(null, null);

                if (Result == 0)
                {
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Text = "All selected student promoted succssfully for the standard "+ddlPromoteStandard.SelectedItem.Text+" for the academic year " + ddlCurrentAcedamic.SelectedItem.Text;
                    btnGetDetails.Focus(); 
                }
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }

    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
            FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();
            FeeMappingHeaderDO.StandardId = Convert.ToInt32(ddlPromoteStandard.SelectedValue);

            FeeMappingHeaderDO.FeeMode = 1;
            CommonClass.LoadDropdownList(ddlTemplate, FeeMappingBLL.GetFeeMappingHeaderDetailsByStandardId(FeeMappingHeaderDO), "MappingTemplateName", "FeeMappingId");
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
    #endregion

    #region PRIVATE METHODS
    private Boolean ValidateCollection(bool IsPromote)
    {
        string ErrMessage = string.Empty;
        bool Result = true;
        try
        {
            if (ddlStandard.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Please select the standard from to promote</br>";
            }

            if (ddlPromoteStandard.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Please select the to promote standard</br>";
            }

            if (ddlPromoteStandard.SelectedValue == ddlStandard.SelectedValue)
            {
                Result = false;
                ErrMessage = ErrMessage + "Cannot promote student as the both selected standards are same.</br>";
            }
            
           
            if (ddlTemplate.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Please select the template</br>";
            }

            if (ddlAcedamic.SelectedValue == ddlCurrentAcedamic.SelectedValue)
            {
                Result = false;
                ErrMessage = ErrMessage + "Cannot promote student as the both academic years are same.</br>";
            }

            if (IsPromote)
            {
                int ChkCount = 0;
                if (GvAdmission.Rows.Count > 0)
                {
                    foreach (GridViewRow gvrow in GvAdmission.Rows)
                    {
                        CheckBox checkAll = (CheckBox)gvrow.FindControl("ChkFee");

                        if (checkAll.Checked)
                        {
                            ChkCount += 1;
                        }
                    }

                    if (ChkCount == 0)
                    {
                        Result = false;
                        ErrMessage = ErrMessage + "No students selected for the promotion</br>";
                    }
                }
            }
            if (!Result)
            {
                ErrMsg.Visible = true;
                ErrMsg.Text = ErrMessage;
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
