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
using System.Configuration;
public partial class Transactions_Refund : System.Web.UI.Page
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

            //CommonClass.LoadDropdownList(ddlPromoteStandard, StandardMasterBLL.GetActiveStandardMasterDetails(StandardMasterDO), "StandardName", "StandardId");
            CommonClass.LoadDropdownList(ddlStandard, StandardMasterBLL.GetActiveStandardMasterDetails(StandardMasterDO), "StandardName", "StandardId");

            CandidateInfoDO.AcademicYear = Convert.ToInt32(ddlAcedamic.SelectedValue);

            ddlAcedamic.SelectedValue = (Convert.ToInt32(ddlCurrentAcedamic.SelectedValue) - 1).ToString();

            /* DataTable DtAdmission = new DataTable();
             DtAdmission = AdmissionBLL.GetAdmissionAcademicDetails(CandidateInfoDO);

             GvAdmission.DataSource = CreateTable("Status IS null", DtAdmission);
             GvAdmission.DataBind();

             if (CreateTable("Status IS null", DtAdmission).Rows.Count > 0)
                 btnSave.Visible = true;
             else
                 btnSave.Visible = false;*/
        }
        #region Registration Number Load
        if (Session["Selected_Student"] != null)
        {
            txtRegistrationNo.Text = Session["Selected_Student"].ToString();
            txtStudentName.Text = Session["StudentName"].ToString();
            txtFatherName.Text = Session["FatherName"].ToString();
            ddlTemplate.SelectedValue = Session["TemplateId"].ToString();
            Session["Selected_Student"] = null;
            Session["TemplateId"] = null;
            Session["StudentName"] = null;
            Session["FatherName"] = null;
        }
        #endregion
    }
    #endregion

    protected void btnGetDetails_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateGet())
            {
                AdmissionBLL AdmissionBLL = new AdmissionBLL();
                CandidateInfoDO CandidateInfoDO = new CandidateInfoDO();

                CandidateInfoDO.AcademicYear = Convert.ToInt32(ddlCurrentAcedamic.SelectedValue);

                DataTable DtAdmission = new DataTable();
                DtAdmission = AdmissionBLL.GetAdmissionAcademicDetails(CandidateInfoDO);


                FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
                FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();
                FeeCollectionBLL FeeCollectionBLL = new FeeCollectionBLL();
                FeeCollectionDO FeeCollectionDO = new FeeCollectionDO();
                DataTable DtCheck = new DataTable();

                FeeCollectionDO.StandardId = Convert.ToInt32(ddlStandard.SelectedValue);
                FeeCollectionDO.TemplateId = Convert.ToInt32(ddlTemplate.SelectedValue);
                FeeCollectionDO.RegistrationId = Convert.ToInt32(txtRegistrationNo.Text.Split('/')[0]);
                FeeCollectionDO.AcademicYearId = Convert.ToInt32(ddlCurrentAcedamic.SelectedValue);
                DtCheck = FeeCollectionBLL.CheckFeeCollectionDetails(FeeCollectionDO);
                DataTable DtFee = new DataTable();
                if (DtCheck.Rows.Count == 0)
                {
                    DtFee = FeeMappingBLL.GetFeeMasterDetails(Convert.ToInt32(ddlTemplate.SelectedValue), 1);
                }
                else
                {
                    DtFee = FeeCollectionBLL.GetFeeCollectionDetails(FeeCollectionDO);
                }

                GvAdmission.DataSource = DtFee;
                GvAdmission.DataBind();
                btnSave.Visible = true;
                /*P1.Enabled = false;
            
                GvAdmission.DataSource = CreateTable("Status IS null AND StandardName ='" + ddlStandard.SelectedItem.Text + "'", DtAdmission);
                GvAdmission.DataBind();
                */
                LoadDefaultAmount();
                CalculateGridSum();

                if (DtFee.Rows.Count > 0)
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
            DataTable DtFee = new DataTable();
            AdmissionBLL AdmissionBLL = new AdmissionBLL();
            List<CandidateInfoDO> CandidateInfoDoList = new List<CandidateInfoDO>();

            if (ValidateSave())
            {
                #region Refund
                FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
                FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();
                RefundBLL RefundBLL = new RefundBLL();
                RefundDO RefundDO = new RefundDO();
                DataTable DtCheck = new DataTable();

                RefundDO.Standard = Convert.ToInt32(ddlStandard.SelectedValue);
                RefundDO.TemplateId = Convert.ToInt32(ddlTemplate.SelectedValue);
                RefundDO.RegistrationId = Convert.ToInt32(txtRegistrationNo.Text.Split('/')[0].ToString());
                RefundDO.AcademicYear = Convert.ToInt32(ddlCurrentAcedamic.SelectedValue);
                RefundDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
                RefundDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString());
                RefundDO.RefundAmount = Convert.ToDouble(txtRefundAmount.Text);

                if (RefundBLL.InsertRefund(RefundDO) > 0)
                {
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Text = "Refunded Rs." + RefundDO.RefundAmount + "to " + txtStudentName.Text + " successfully.";
                }
                else
                {
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Red;
                    ErrMsg.Text = "Refund was not successfull.";
                }
                #endregion
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
            FeeMappingHeaderDO.StandardId = Convert.ToInt32(ddlStandard.SelectedValue);

            FeeMappingHeaderDO.FeeMode = 1;
            CommonClass.LoadDropdownList(ddlTemplate, FeeMappingBLL.GetFeeMappingHeaderDetailsByStandardId(FeeMappingHeaderDO), "MappingTemplateName", "FeeMappingId");

        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }

    protected void lbtnRegionSearch_Click(object sender, EventArgs e)
    {
        if (ddlStandard.SelectedValue != "-1")
        {
            Session["StandardId"] = ddlStandard.SelectedValue;
            string navigateURL = string.Empty;
            navigateURL = @"." + "/" + "StudentSearch.aspx";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:OpenPopup('" + navigateURL + "')", true);
        }
        else
        {
            ErrMsg.Visible = true;
            ErrMsg.Text = "Select standard";
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

    protected void ImgBtnReCalculate_OnClick(object sender, ImageClickEventArgs e)
    {
        try
        {
            CalculateGridSum();
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }

    protected void txtRefundAmount_TextChanged(object sender, EventArgs e)
    {
        try
        {

            if ((txtRefundAmount.Text.Trim() == string.Empty) || (txtRefundAmount.Text.Trim() == "0.00"))
            {
                txtRefundAmount.Text = "0.00";
            }
            txtRefundAmount.Text = Convert.ToDouble(txtRefundAmount.Text).ToString("#0.00");

        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    #region PRIVATE METHODS
    private void LoadDefaultAmount()
    {
        try
        {
            foreach (GridViewRow dr in GvAdmission.Rows)
            {
                double price = Convert.ToDouble(((TextBox)dr.FindControl("txtFeeamount")).Text) - Convert.ToDouble(((TextBox)dr.FindControl("txtpaidamount")).Text);
                if (ConfigurationManager.AppSettings["AmountDisplay"] == "1")
                {
                    ((TextBox)dr.FindControl("txtamount")).Text = price.ToString("#.00");
                }
                else
                {
                    ((TextBox)dr.FindControl("txtamount")).Text = "0.00";
                }
                ((TextBox)dr.FindControl("txtPendingamount")).Text = price.ToString("#.00");
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    private void CalculateGridSum()
    {
        double FeeAmountgrandtotal = 0;
        double Amountgrandtotal = 0;
        double TotalPendingAmountgrandtotal = 0;
        double TotalPaidAmountgrandtotal = 0;
        try
        {
            foreach (GridViewRow dr in GvAdmission.Rows)
            {
                double price = Convert.ToDouble(((TextBox)dr.FindControl("txtFeeamount")).Text);
                FeeAmountgrandtotal = FeeAmountgrandtotal + price;
                if (((TextBox)dr.FindControl("txtamount")).Text.Trim() != string.Empty)
                {
                    double Amountprice = Convert.ToDouble(((TextBox)dr.FindControl("txtamount")).Text);
                    Amountgrandtotal = Amountgrandtotal + Amountprice;
                }
                else
                    ((TextBox)dr.FindControl("txtamount")).Text = "0.00";
                double Pendingprice = Convert.ToDouble(((TextBox)dr.FindControl("txtPendingamount")).Text);
                TotalPendingAmountgrandtotal = TotalPendingAmountgrandtotal + Pendingprice;

                double Paidgprice = Convert.ToDouble(((TextBox)dr.FindControl("txtpaidamount")).Text);
                TotalPaidAmountgrandtotal = TotalPaidAmountgrandtotal + Paidgprice;

            }
            GridViewRow row = GvAdmission.FooterRow;
            ((TextBox)row.FindControl("txtSumFeeamount")).Text = Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(Convert.ToString(FeeAmountgrandtotal)))).ToString();
            ((TextBox)row.FindControl("txtSumamount")).Text = Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(Convert.ToString(Amountgrandtotal)))).ToString();
            ((TextBox)row.FindControl("txtSumPendingamount")).Text = Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(Convert.ToString(TotalPendingAmountgrandtotal)))).ToString();
            ((TextBox)row.FindControl("txtpaidSumamount")).Text = Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(Convert.ToString(TotalPaidAmountgrandtotal)))).ToString();
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    private Boolean ValidateGet()
    {
        string ErrMessage = string.Empty;
        bool Result = true;
        try
        {
            if (ddlTemplate.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Please select the template</br>";
            }


            if (ddlStandard.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Please select the standard</br>";
            }

            if (ddlAcedamic.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Please select the academic year</br>";
            }

            if (txtRegistrationNo.Text.Trim() == string.Empty)
            {
                Result = false;
                ErrMessage = ErrMessage + "Please enter the student admission number.</br>";
            }


            if (!Result)
            {
                ErrMsg.Visible = true;
                ErrMsg.ForeColor = System.Drawing.Color.Red;
                ErrMsg.Text = ErrMessage;
            }

        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        } 
        return Result;
    }
    private Boolean ValidateSave()
    {
        string ErrMessage = string.Empty;
        bool Result = true;
        try
        {
            GridViewRow row = GvAdmission.FooterRow;
            Double TotalAmountPaid = Convert.ToDouble(((TextBox)row.FindControl("txtSumamount")).Text);
            Double TotalFeeAmount = Convert.ToDouble(((TextBox)row.FindControl("txtSumFeeamount")).Text);
            Double TotalPendingAmount = Convert.ToDouble(((TextBox)row.FindControl("txtSumPendingamount")).Text);
            Double TotalPaidAmount = Convert.ToDouble(((TextBox)row.FindControl("txtpaidSumamount")).Text);
            if (TotalFeeAmount - TotalPendingAmount == 0)
            {
                Result = false;
                ErrMessage = ErrMessage + "Student has not yet paid the fees.</br>";
            }

            if (TotalPaidAmount - Convert.ToDouble(txtRefundAmount.Text) < 0)
            {
                Result = false;
                ErrMessage = ErrMessage + "Refund cannot exceed paid amount.</br>";
            }
            if (!Result)
            {
                ErrMsg.Visible = true;
                ErrMsg.ForeColor = System.Drawing.Color.Red;
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
