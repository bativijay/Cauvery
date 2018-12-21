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
public partial class Transactions_Admission : System.Web.UI.Page
{
    DataTable DtFee = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrMsg.Visible = false;
        ErrorFeelabel.Visible = false;
        try
        {
            //txtDOB.Text = hf1.Value;
            Page.ClientScript.GetPostBackEventReference(this, String.Empty);

            if (!IsPostBack)
            {
                Session["StandardId"] = null;
                //txtDOB.Attributes.Add("readonly", "readonly");
                HtmlAnchor htmlAnchor = positionLnk;
                htmlAnchor.HRef = "javascript:OpenPopup('StudentSearch.aspx');";

                CommonBLL CommonBLL = new CommonBLL();
                ReligionMasterBLL ReligionMasterBLL = new ReligionMasterBLL();
                ReligionMasterDO ReligionMasterDO = new ReligionMasterDO();
                ReligionMasterDO.ReligionCode = "";

                CastMasterBLL CastMasterBLL = new CastMasterBLL();
                CastMasterDO CastMasterDO = new CastMasterDO();
                CastMasterDO.CastCode = "";

                StandardMasterBLL StandardMasterBLL = new StandardMasterBLL();
                StandardMasterDO StandardMasterDO = new StandardMasterDO();
                StandardMasterDO.StandardCode = "";

                CommonClass.LoadDropdownList(ddlReligion, ReligionMasterBLL.GetActiveReligionMasterDetails(ReligionMasterDO), "ReligionName", "ReligionId");
                CommonClass.LoadDropdownList(ddlCaste, CastMasterBLL.GetActiveCastMasterDetails(CastMasterDO), "CastName", "CastId");
                CommonClass.LoadDropdownList(ddlStandardSought, StandardMasterBLL.GetActiveStandardMasterDetails(StandardMasterDO), "StandardName", "StandardId");
                CommonClass.LoadDropdownList(ddlStandardStudying, StandardMasterBLL.GetActiveStandardMasterDetails(StandardMasterDO), "StandardName", "StandardId");

                CommonClass.LoadDropdownListWithoutSelect(ddlAcedamic, CommonBLL.GetParameterDetails("Acedemic"), "ParameterName", "ParameterValue");
                CommonClass.LoadDropdownList(ddlBelongsTo, CommonBLL.GetParameterDetails("BelongsTo"), "ParameterName", "ParameterValue");
                CommonClass.LoadDropdownListWithoutSelect(ddlFL, CommonBLL.GetParameterDetails("Language"), "ParameterName", "ParameterValue");
                CommonClass.LoadDropdownList(ddlSL, CommonBLL.GetParameterDetails("Language"), "ParameterName", "ParameterValue");
                CommonClass.LoadDropdownList(ddlTL, CommonBLL.GetParameterDetails("Language"), "ParameterName", "ParameterValue");
                CommonClass.LoadDropdownList(ddlSex, CommonBLL.GetParameterDetails("Gender"), "ParameterName", "ParameterValue");
                CommonClass.LoadDropdownList(ddlMotherToungue, CommonBLL.GetParameterDetails("MotherTongue"), "ParameterName", "ParameterValue");
                CommonClass.LoadDropdownListWithoutSelect(ddlNationality, CommonBLL.GetParameterDetails("Nationality"), "ParameterName", "ParameterValue");
            }
            if (Session["Selected_Student"] != null)
            {
                AdmissionBLL AdmissionBLL = new AdmissionBLL();
                CandidateInfoDO CandidateInfoDO = new CandidateInfoDO();
                DataTable DtCandidateDetails = new DataTable();
                RegistrationNo.Text = Session["Selected_Student"].ToString();
                CandidateInfoDO.RegistrationId = Convert.ToInt32(Session["Selected_Student"].ToString().Split('/')[0]);
                CandidateInfoDO.StudentName = "";

                ParentsInfoDO ParentsInfoDO = new ParentsInfoDO();
                ParentsInfoDO.FatherName = "";

                CandidateInfoDO.ParentsInfoDO = ParentsInfoDO;
                DtCandidateDetails = AdmissionBLL.GetAdmissionDetails(CandidateInfoDO);
                if ((DtCandidateDetails != null) && (DtCandidateDetails.Rows.Count > 0))
                    LoadCandidateDetails(DtCandidateDetails);
                else
                {
                    string ErrMessage = string.Empty;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Visible = true;
                    ErrMessage = "Registration No. " + RegistrationNo.Text + " not exists. ";
                    ErrMsg.Text = ErrMessage;
                    BtnClear_Click(null, null);
                }

                Session["Selected_Student"] = null;
                Session["StudentName"] = null;
                Session["FatherName"] = null;
                Session["StandardId"] = null;
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }

    #region CONTROL EVENTS
    protected void valDateRange_ServerValidate(object source, ServerValidateEventArgs args)
    {
        DateTime minDate = DateTime.Parse("1000/12/28");
        DateTime maxDate = DateTime.Parse("9999/12/28");
        DateTime dt;

        args.IsValid = (DateTime.TryParse(args.Value, out dt)
                        && dt <= maxDate
                        && dt >= minDate);
    }
    protected void lnkPhoto_Click(object sender, EventArgs e)
    {
        if (PhotoUploader.HasFile)
        {
            try
            {
                if (PhotoUploader.PostedFile.ContentType == "image/jpeg")
                {
                    if (PhotoUploader.PostedFile.ContentLength < 102400)
                    {
                        //save the file to the server
                        String savePath = Server.MapPath("~/StudentPhotos/") + PhotoUploader.PostedFile.FileName;// +file;
                        PhotoUploader.PostedFile.SaveAs(savePath);
                        StudentPhoto.ImageUrl = "~/StudentPhotos/" + PhotoUploader.PostedFile.FileName;
                        Session["Photo"] = StudentPhoto.ImageUrl;
                    }
                    //else
                    //StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
                }
                //else
                //    StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
            }
            catch (Exception ex)
            {
                WriteLogFile.LogError(ex);//StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    }
    protected void ImgBtnReCalculate_OnClick(object sender, ImageClickEventArgs e)
    {
        try
        {
            CalculateGridSum();
            ModalPopupExtender1.Show();
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
            foreach (GridViewRow dr in GvFeeMaster.Rows)
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
            GridViewRow row = GvFeeMaster.FooterRow;
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

    protected void BtnOkay_Click(object sender, EventArgs e)
    {
        try
        {
            AdmissionBLL AdmissionBLL = new AdmissionBLL();

            CandidateInfoDO CandidateInfoDO = new CandidateInfoDO();
            #region Candidate Info
            if (RegistrationNo.Text != string.Empty)
                CandidateInfoDO.RegistrationId = Convert.ToInt32(RegistrationNo.Text.Split('/')[0].ToString());

            CandidateInfoDO.AcademicYear = Convert.ToInt32(ddlAcedamic.SelectedValue);
            CandidateInfoDO.Caste = Convert.ToInt32(ddlCaste.SelectedValue);
            CandidateInfoDO.Catagory = Convert.ToInt32(ddlBelongsTo.SelectedValue);
            CandidateInfoDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
            CandidateInfoDO.DOB = Convert.ToDateTime(txtDOB.Text, new CultureInfo("en-GB", true)); //(txtDOB.Text);
            CandidateInfoDO.FirstLanguage = Convert.ToInt32(ddlFL.SelectedValue);
            CandidateInfoDO.MotherTongue = Convert.ToInt32(ddlMotherToungue.SelectedValue);
            CandidateInfoDO.Nationality = Convert.ToInt32(ddlNationality.SelectedValue);
            CandidateInfoDO.FeeTemplateId = Convert.ToInt32(ddlFeeTemplate.SelectedValue);
            if (Session["Photo"] != null)
                CandidateInfoDO.Photo = Session["Photo"].ToString();
            else
                CandidateInfoDO.Photo = StudentPhoto.ImageUrl.ToString();
            CandidateInfoDO.Religion = Convert.ToInt32(ddlReligion.SelectedValue);
            CandidateInfoDO.SchoolAddress = txtPresentAdd.Text;
            CandidateInfoDO.SecondLanguage = Convert.ToInt32(ddlSL.SelectedValue);
            CandidateInfoDO.Sex = Convert.ToInt32(ddlSex.SelectedValue);
            CandidateInfoDO.StandardSought = Convert.ToInt32(ddlStandardSought.SelectedValue);
            CandidateInfoDO.StandardStudying = Convert.ToInt32(ddlStandardStudying.SelectedValue);
            CandidateInfoDO.StudentName = PupilTextBox.Text.ToUpper();
            CandidateInfoDO.ThirdLanguage = Convert.ToInt32(ddlTL.SelectedValue);
            CandidateInfoDO.PreviousTCIssuedDate = PreviousTCTextBox.Text;
            CandidateInfoDO.JoiningAcademicYear = JoiningAcademicYearTextBox.Text;
            #endregion

            ParentsInfoDO ParentsInfoDO = new ParentsInfoDO();
            #region Parents Info
            ParentsInfoDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
            ParentsInfoDO.EmergencyAddress = txtEmerAdd.Text;

            ParentsInfoDO.FatherName = txtFatherName.Text.ToUpper();
            ParentsInfoDO.FatherOccupation = txtFatherOccupation.Text.ToUpper();
            ParentsInfoDO.FatherQualification = txtFatherQualification.Text.ToUpper();
            ParentsInfoDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString()); ;
            ParentsInfoDO.MotherName = txtMotherName.Text.ToUpper();
            ParentsInfoDO.MotherOccupation = txtMotherOccupation.Text.ToUpper();
            ParentsInfoDO.MotherQualification = txtMotherQualification.Text.ToUpper();
            ParentsInfoDO.OtherInformation = txtOtherInfo.Text;
            ParentsInfoDO.PermanantAddress = txtPermanantAdd.Text;
            ParentsInfoDO.Relationship = txtRelation.Text;
            ParentsInfoDO.TemporaryAddress = txtTemAdd.Text;

            ParentsInfoDO.TemporaryTelNo = txtTempTelNo.Text;
            ParentsInfoDO.PermanantTelNo = txtPerTelNo.Text;
            ParentsInfoDO.EmergencyTelNo = txtEmerTelNo.Text;

            ParentsInfoDO.PermanantTelNoOff = txtPerOffTelNo.Text;
            ParentsInfoDO.EmergencyTelNoOff = txtEmerOffTelNo.Text;
            ParentsInfoDO.TemporaryTelNoOff = txtTemOffTelNo.Text;
            ParentsInfoDO.TemporaryMobNo = txtTemMobNo.Text;
            ParentsInfoDO.PermanantMobNo = txtPerMobNo.Text;

            #endregion
            CandidateInfoDO.ParentsInfoDO = ParentsInfoDO;

            OfficeUseDO OfficeUseDO = new OfficeUseDO();
            #region Office Use
            if (txtAppRcvdOn.Text.Trim() != string.Empty)
                OfficeUseDO.ApplicationReceivedOn = Convert.ToDateTime(txtAppRcvdOn.Text, new CultureInfo("en-GB", true));
            else
                OfficeUseDO.ApplicationReceivedOn = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
            OfficeUseDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
            OfficeUseDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString());
            OfficeUseDO.ReceiptNoAndDate = txtAppnNoAndDate.Text;
            OfficeUseDO.Remarks = Remarks.Text;
            OfficeUseDO.TCNoIssuedDate = txtAppnNoAndDate0.Text;
            #endregion
            CandidateInfoDO.OfficeUseDO = OfficeUseDO;
            int RegistartionNo = 0;
            if (CandidateInfoDO.RegistrationId == 0)
            {
                //Validate Fee
                int count = 0;
                int ncount = 0;
                double PaidAmount = 0;
                if (RegistrationNo.Text == string.Empty)
                {

                    foreach (GridViewRow gvrow in GvFeeMaster.Rows)
                    {
                        if (Convert.ToDouble(((TextBox)gvrow.FindControl("txtFeeamount")).Text) <
                        Convert.ToDouble(((TextBox)gvrow.FindControl("txtamount")).Text))
                        {
                            count += 1;
                            PaidAmount += Convert.ToDouble(((TextBox)gvrow.FindControl("txtamount")).Text);
                        }

                        if (Convert.ToDouble(((TextBox)gvrow.FindControl("txtamount")).Text) < 0)
                        {
                            count += 1;
                        }
                    }
                }

                int counterror = 0;
                string ErrMessage = "";
                if (ddlPayMode.SelectedValue != "-1")
                {
                    if (ddlPayMode.SelectedItem.Text != "Cash")
                    {
                        if (txtChequeDate.Text == string.Empty)
                        {
                            counterror += 1;
                            ErrMessage = ErrMessage + "Please enter the proper cheque date.</br>";
                        }
                        if (txtChequeNo.Text == string.Empty)
                        {
                            counterror += 1;
                            ErrMessage = ErrMessage + "Please enter the proper cheque No.</br>";
                        }
                        if (txtChequeBank.Text == string.Empty)
                        {

                            ErrMessage = ErrMessage + "Please enter the bank name.</br>";
                        }
                    }
                }
                else
                {

                    counterror += 1;
                    ErrMessage = ErrMessage + "Please select payment mode.</br>";

                }


                if (count > 0)
                {
                    ErrorFeelabel.Visible = true;
                    ErrorFeelabel.Text = "Amount paid is either negative nor more than the fee amount";
                    ModalPopupExtender1.Show();
                }
                else if (counterror > 0)
                {
                    ErrorFeelabel.Visible = true;
                    ErrorFeelabel.Text = ErrMessage;
                    ModalPopupExtender1.Show();

                }
                else
                {
                    RegistartionNo = AdmissionBLL.InsertCandidateDetails(CandidateInfoDO);
                }

                if (RegistartionNo > 0)
                {
                    #region FEE COLLECTION
                    FeeCollectionBLL FeeCollectionBLL = new FeeCollectionBLL();
                    FeeCollectionDO FeeCollectionDO = new FeeCollectionDO();
                    #region COLLECTION HEADER

                    FeeCollectionDO.AcademicYearId = Convert.ToInt32(ddlAcedamic.SelectedValue);
                    FeeCollectionDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
                    FeeCollectionDO.FeeCollectionId = 0;
                    FeeCollectionDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString());
                    FeeCollectionDO.PaymentMode = Convert.ToInt32(ddlPayMode.SelectedValue);

                    FeeCollectionDO.PayType = "D";
                    FeeCollectionDO.ReceiptNo = "";
                    FeeCollectionDO.FatherName = txtFatherName.Text;
                    FeeCollectionDO.StudentName = PupilTextBox.Text;

                    if (ddlPayMode.SelectedItem.Text != "Cash")
                    {
                        FeeCollectionDO.ChequeDate = txtChequeDate.Text;
                        FeeCollectionDO.ChequeNo = txtChequeNo.Text;
                        FeeCollectionDO.ChequeBank = txtChequeBank.Text;
                    }
                    else
                    {
                        FeeCollectionDO.ChequeDate = txtChequeDate.Text;
                        FeeCollectionDO.ChequeNo = txtChequeNo.Text;
                        FeeCollectionDO.ChequeBank = txtChequeBank.Text;
                    }

                    FeeCollectionDO.RegistrationId = Convert.ToInt32(RegistartionNo);
                    FeeCollectionDO.StandardId = Convert.ToInt32(ddlStandardSought.SelectedValue);
                    FeeCollectionDO.TemplateId = Convert.ToInt32(ddlFeeTemplate.SelectedValue);

                    CalculateGridSum();

                    GridViewRow row = GvFeeMaster.FooterRow;
                    FeeCollectionDO.TotalAmountPaid = Convert.ToDouble(((TextBox)row.FindControl("txtSumamount")).Text);
                    FeeCollectionDO.TotalFeeAmount = Convert.ToDouble(((TextBox)row.FindControl("txtSumFeeamount")).Text);
                    FeeCollectionDO.TotalPendingAmount = Convert.ToDouble(((TextBox)row.FindControl("txtSumPendingamount")).Text);
                    FeeCollectionDO.TotalPendingAmount = FeeCollectionDO.TotalPendingAmount - FeeCollectionDO.TotalAmountPaid;

                    #endregion

                    #region CREATE DATATABLE FOR PRINT
                    DataTable DtPrint = new DataTable();
                    DtPrint.Columns.Add("FeeName", typeof(string));
                    DtPrint.Columns.Add("Amount", typeof(decimal));
                    DtPrint.Columns.Add("PendingAmount", typeof(decimal));
                    DtPrint.Columns.Add("TotalFeeAmount", typeof(decimal));
                    DtPrint.Columns.Add("Standard", typeof(string));
                    DtPrint.Columns.Add("StudentName", typeof(string));
                    DtPrint.Columns.Add("FatherName", typeof(string));
                    DtPrint.Columns.Add("AdmissionNo", typeof(string));
                    DtPrint.Columns.Add("PayMode", typeof(string));
                    DtPrint.Columns.Add("AcademicYear", typeof(string));
                    DtPrint.Columns.Add("AmountInWords", typeof(string));
                    DtPrint.Columns.Add("ReceiptNo", typeof(string));
                    DtPrint.Columns.Add("ChequeNo", typeof(string));
                    DtPrint.Columns.Add("ChequeDate", typeof(string));
                    DtPrint.Columns.Add("ChequeBank", typeof(string));
                    DtPrint.Columns.Add("ReceiptDate", typeof(string));
                    #endregion

                    #region DETAIL SECTION

                    //l1.Visible = true;
                    //l1.Text = "";

                    FeeCollectionDetailsDO FeeCollectionDetailsDO;
                    FeeCollectionDO.FeeCollectionDetailsList = new List<FeeCollectionDetailsDO>();

                    double TotalFeeAmount = 0;
                    foreach (GridViewRow gvrow in GvFeeMaster.Rows)
                    {
                        TotalFeeAmount += Convert.ToDouble(((TextBox)gvrow.FindControl("txtamount")).Text);
                    }
                    foreach (GridViewRow gvrow in GvFeeMaster.Rows)
                    {
                        FeeCollectionDetailsDO = new FeeCollectionDetailsDO();
                        FeeCollectionDetailsDO.FeeId = Convert.ToInt32(GvFeeMaster.DataKeys[gvrow.RowIndex].Values["FeeId"].ToString());
                        FeeCollectionDetailsDO.FeeCollectionId = Convert.ToInt32(GvFeeMaster.DataKeys[gvrow.RowIndex].Values["FeeCollectionId"].ToString());
                        FeeCollectionDetailsDO.FeeAmount = Convert.ToDouble(((TextBox)gvrow.FindControl("txtFeeamount")).Text);
                        FeeCollectionDetailsDO.PaidAmount = Convert.ToDouble(((TextBox)gvrow.FindControl("txtamount")).Text);
                        FeeCollectionDetailsDO.PendingAmount = FeeCollectionDetailsDO.FeeAmount - (FeeCollectionDetailsDO.PaidAmount + Convert.ToDouble(((TextBox)gvrow.FindControl("txtpaidamount")).Text));
                        FeeCollectionDetailsDO.CreatedBy = Convert.ToInt32(Session["LoginId"].ToString());
                        FeeCollectionDetailsDO.ModifiedBy = Convert.ToInt32(Session["LoginId"].ToString());
                        FeeCollectionDetailsDO.ReceiptNo = FeeCollectionBLL.GetReceiptDetails(1).Rows[0]["Prefix"].ToString() + (Convert.ToInt32(FeeCollectionBLL.GetReceiptDetails(1).Rows[0]["RcptNo"].ToString()) + 1).ToString();
                        if (FeeCollectionDetailsDO.PaidAmount > 0)
                        {
                            FeeCollectionDetailsDO.ReceiptNo = FeeCollectionBLL.GetReceiptDetails(1).Rows[0]["Prefix"].ToString() + (Convert.ToInt32(FeeCollectionBLL.GetReceiptDetails(1).Rows[0]["RcptNo"].ToString()) + 1).ToString();

                            Converter converter = new Converter(Convert.ToInt64(TotalFeeAmount), KAVERI.UTILITY.Converter.ConvertStyle.Asian);
                            DtPrint.Rows.Add(((Label)gvrow.FindControl("lblFeeName")).Text,
                                             FeeCollectionDetailsDO.PaidAmount,
                                             FeeCollectionDetailsDO.PendingAmount,
                                             FeeCollectionDetailsDO.FeeAmount,
                                             ddlStandardSought.SelectedItem.Text,
                                             PupilTextBox.Text.ToUpper(),
                                             txtFatherName.Text.ToUpper(),
                                             RegistrationNo,
                                             ddlPayMode.SelectedItem.Text,
                                             ddlAcedamic.SelectedItem.Text,
                                             converter.ConvertTo(),
                                             FeeCollectionDetailsDO.ReceiptNo,
                                             FeeCollectionDO.ChequeNo,
                                             FeeCollectionDO.ChequeDate,
                                             FeeCollectionDO.ChequeBank,
                                             DateTime.Now.Date.ToShortDateString());
                        }
                        else
                        {
                            FeeCollectionDetailsDO.ReceiptNo = "0";
                        }
                        FeeCollectionDO.FeeCollectionDetailsList.Add(FeeCollectionDetailsDO);
                    }
                    if (TotalFeeAmount > 0)
                    {
                        DtPrint.TableName = "DtFeeCollection";
                        DtPrint.AcceptChanges();
                        FeeCollectionBLL.UpdateReceiptDetails(1);
                    }
                    FeeCollectionBLL.InsertFeeCollection(FeeCollectionDO);

                    #endregion

                    #region PRINT
                    if (TotalFeeAmount > 0)
                    {
                        DataSet DsReport = new DataSet();
                        DsReport.Tables.Add(DtPrint);
                        Session["dspendingcollection"] = DsReport;

                        string navigateURL = string.Empty;
                        navigateURL = "~/ReportMaster/DisplayReportPopUp.aspx?print=1";
                        navigateURL = Page.ResolveClientUrl(navigateURL);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:OpenPopup('" + navigateURL + "')", true);
                    }
                    #endregion
                    #endregion
                }
            }
            else
            {
                RegistartionNo = AdmissionBLL.UpdateCandidateDetails(CandidateInfoDO);
            }

            if (RegistartionNo > 0)
            {
                if (CandidateInfoDO.RegistrationId > 0)
                {
                    string ErrMessage = string.Empty;
                    ErrMsg.Visible = true;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMessage = "Registration No. " + CandidateInfoDO.RegistrationId + " with Student name " + CandidateInfoDO.StudentName + " Updated succesfully.";
                    ErrMsg.Text = ErrMessage;
                }
                else
                {
                    string ErrMessage = string.Empty;
                    ErrMsg.ForeColor = System.Drawing.Color.Green;
                    ErrMsg.Visible = true;
                    ErrMessage = "Registration No. " + RegistartionNo + " with Student name " + CandidateInfoDO.StudentName + " saved succesfully.";
                    ErrMsg.Text = ErrMessage;
                }
                BtnClear_Click(null, null);
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {

            if (IsAdmissionValid())
            {
                DtFee = (DataTable)Session["FeeCollectionDataTable"];
                //if ((DtFee != null) && (DtFee.Rows.Count > 0))
                if (RegistrationNo.Text == string.Empty)
                {

                    GvFeeMaster.DataSource = DtFee;
                    GvFeeMaster.DataBind();
                    txtChequeBank.Visible = false;
                    txtChequeDate.Visible = false;
                    txtChequeNo.Visible = false;
                    ChequeDateLabel.Visible = false;
                    ChequeNoLabel.Visible = false;
                    ChequeBankLabel.Visible = false;
                    CommonBLL CommonBLL = new CommonBLL();
                    CommonClass.LoadDropdownList(ddlPayMode, CommonBLL.GetParameterDetails("PaymentMode"), "ParameterName", "ParameterValue");
                    CalculateGridSum();
                    ModalPopupExtender1.Show();
                }
                else
                {
                    BtnOkay_Click(null, null);
                }
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        try
        {

            #region Candidate Info
            StudentPhoto.ImageUrl = "~/Images/User.png";
            txtDOB.Text = string.Empty;
            RegistrationNo.Text = string.Empty;
            ddlCaste.SelectedValue = "-1";
            ddlBelongsTo.SelectedValue = "-1";
            //ddlFL.SelectedValue = "-1";
            ddlMotherToungue.SelectedValue = "-1";
            //ddlNationality.SelectedValue = "-1";
            ddlReligion.SelectedValue = "-1";
            txtPresentAdd.Text = string.Empty;
            ddlSL.SelectedValue = "-1";
            ddlSex.SelectedValue = "-1";
            ddlStandardSought.SelectedValue = "-1";
            ddlStandardStudying.SelectedValue = "-1";
            PupilTextBox.Text = string.Empty;
            ddlTL.SelectedValue = "-1";
            Session["Photo"] = null;
            PreviousTCTextBox.Text = string.Empty;
            JoiningAcademicYearTextBox.Text = string.Empty;
            ddlFeeTemplate.Items.Clear();
            ddlFeeTemplate.Enabled = true;
            ddlStandardSought.Enabled = true;
            #endregion

            #region Parent Info
            txtEmerAdd.Text = string.Empty;
            txtEmerTelNo.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtFatherOccupation.Text = string.Empty;
            txtFatherQualification.Text = string.Empty;

            txtMotherName.Text = string.Empty;
            txtMotherOccupation.Text = string.Empty;
            txtMotherQualification.Text = string.Empty;
            txtOtherInfo.Text = string.Empty;
            txtPermanantAdd.Text = string.Empty;
            txtPerTelNo.Text = string.Empty;
            txtRelation.Text = string.Empty;
            txtTemAdd.Text = string.Empty;
            txtTempTelNo.Text = string.Empty;
            txtPerMobNo.Text = string.Empty;

            txtPerOffTelNo.Text = string.Empty;
            txtTemOffTelNo.Text = string.Empty;
            txtPerMobNo.Text = string.Empty;
            txtTemMobNo.Text = string.Empty;
            txtEmerOffTelNo.Text = string.Empty;

            #endregion

            #region Office Use
            txtAppnNoAndDate.Text = string.Empty;
            Remarks.Text = string.Empty;
            txtAppnNoAndDate0.Text = string.Empty;
            txtAppRcvdOn.Text = string.Empty;
            #endregion

            #region CHEQUE DETAILS CLEAR
            ddlPayMode.SelectedValue = "-1";
            txtChequeBank.Text = string.Empty;
            txtChequeDate.Text = string.Empty;
            txtChequeNo.Text = string.Empty;
            #endregion
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }

    protected void RegistrationNo_OnTextChanged(object sender, EventArgs e)
    {
        try
        {
            AdmissionBLL AdmissionBLL = new AdmissionBLL();
            CandidateInfoDO CandidateInfoDO = new CandidateInfoDO();
            DataTable DtCandidateDetails = new DataTable();

            CandidateInfoDO.RegistrationId = Convert.ToInt32(RegistrationNo.Text);
            CandidateInfoDO.StudentName = "";

            ParentsInfoDO ParentsInfoDO = new ParentsInfoDO();
            ParentsInfoDO.FatherName = "";

            CandidateInfoDO.ParentsInfoDO = ParentsInfoDO;
            DtCandidateDetails = AdmissionBLL.GetAdmissionDetails(CandidateInfoDO);
            if ((DtCandidateDetails != null) && (DtCandidateDetails.Rows.Count > 0))
                LoadCandidateDetails(DtCandidateDetails);
            else
            {
                string ErrMessage = string.Empty;
                ErrMsg.ForeColor = System.Drawing.Color.Green;
                ErrMsg.Visible = true;
                ErrMessage = "Registration No. " + RegistrationNo.Text + " not exists. ";
                ErrMsg.Text = ErrMessage;
                BtnClear_Click(null, null);
            }
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    #endregion

    #region PRIVATE METHODS
    private void LoadCandidateDetails(DataTable DtCandidateDetails)
    {
        try
        {

            #region Candidate Info
            ddlAcedamic.SelectedValue = DtCandidateDetails.Rows[0]["CurrentAcademic"].ToString();
            ddlCaste.SelectedValue = DtCandidateDetails.Rows[0]["Caste"].ToString();
            ddlBelongsTo.SelectedValue = DtCandidateDetails.Rows[0]["Catagory"].ToString();
            txtDOB.Text = DtCandidateDetails.Rows[0]["DOB"].ToString();// String.Format("{0:d/M/yyyy}", DtCandidateDetails.Rows[0]["DOB"].ToString());
            ddlFL.SelectedValue = DtCandidateDetails.Rows[0]["FirstLanguage"].ToString();
            ddlMotherToungue.SelectedValue = DtCandidateDetails.Rows[0]["MotherTongue"].ToString();
            ddlNationality.SelectedValue = DtCandidateDetails.Rows[0]["Nationality"].ToString();
            StudentPhoto.ImageUrl = DtCandidateDetails.Rows[0]["Photo"].ToString();
            ddlReligion.SelectedValue = DtCandidateDetails.Rows[0]["Religion"].ToString();
            txtPresentAdd.Text = DtCandidateDetails.Rows[0]["SchoolAddress"].ToString();
            ddlSL.SelectedValue = DtCandidateDetails.Rows[0]["SecondLanguage"].ToString();
            ddlSex.SelectedValue = DtCandidateDetails.Rows[0]["Sex"].ToString();
            ddlStandardSought.SelectedValue = DtCandidateDetails.Rows[0]["StandardSought"].ToString();
            ddlStandardStudying.SelectedValue = DtCandidateDetails.Rows[0]["StandardStudying"].ToString();
            PupilTextBox.Text = DtCandidateDetails.Rows[0]["StudentName"].ToString();
            ddlTL.SelectedValue = DtCandidateDetails.Rows[0]["ThirdLanguage"].ToString();

            PreviousTCTextBox.Text = DtCandidateDetails.Rows[0]["PreviousTCIssuedDate"].ToString();
            JoiningAcademicYearTextBox.Text = DtCandidateDetails.Rows[0]["JoiningAcademicYear"].ToString();

            #region FILL TEMPLATE DROPDOWN
            try
            {
                FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
                FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();
                FeeMappingHeaderDO.StandardId = Convert.ToInt32(ddlStandardSought.SelectedValue);
                FeeMappingHeaderDO.FeeMode = 1;
                CommonClass.LoadDropdownList(ddlFeeTemplate, FeeMappingBLL.GetFeeMappingHeaderDetailsByStandardId(FeeMappingHeaderDO), "MappingTemplateName", "FeeMappingId");
            }
            catch (Exception ex)
            {
                WriteLogFile.LogError(ex);
            }
            #endregion
            ddlFeeTemplate.Enabled = false;
            ddlFeeTemplate.SelectedValue = DtCandidateDetails.Rows[0]["FeeTemplateId"].ToString();
            ddlStandardSought.Enabled = false;
            #endregion

            #region Parents Info
            txtEmerAdd.Text = DtCandidateDetails.Rows[0]["EmergencyAddress"].ToString();
            txtEmerTelNo.Text = DtCandidateDetails.Rows[0]["EmergencyTelNo"].ToString();
            txtFatherName.Text = DtCandidateDetails.Rows[0]["FatherName"].ToString();
            txtFatherOccupation.Text = DtCandidateDetails.Rows[0]["FatherOccupation"].ToString();
            txtFatherQualification.Text = DtCandidateDetails.Rows[0]["FatherQualification"].ToString();

            txtMotherName.Text = DtCandidateDetails.Rows[0]["MotherName"].ToString();
            txtMotherOccupation.Text = DtCandidateDetails.Rows[0]["MotherOccupation"].ToString();
            txtMotherQualification.Text = DtCandidateDetails.Rows[0]["MotherQualification"].ToString();
            txtOtherInfo.Text = DtCandidateDetails.Rows[0]["OtherInformation"].ToString();
            txtPermanantAdd.Text = DtCandidateDetails.Rows[0]["PermanantAddress"].ToString();
            txtPerTelNo.Text = DtCandidateDetails.Rows[0]["PermanantTelNo"].ToString();
            txtRelation.Text = DtCandidateDetails.Rows[0]["Relationship"].ToString();
            txtTemAdd.Text = DtCandidateDetails.Rows[0]["TemporaryAddress"].ToString();
            txtTempTelNo.Text = DtCandidateDetails.Rows[0]["TemporaryTelNo"].ToString();

            txtPerOffTelNo.Text = DtCandidateDetails.Rows[0]["PermanantTelNoOff"].ToString();
            txtTemOffTelNo.Text = DtCandidateDetails.Rows[0]["TemporaryTelNoOff"].ToString();
            txtPerMobNo.Text = DtCandidateDetails.Rows[0]["PermanantMobNo"].ToString();
            txtTemMobNo.Text = DtCandidateDetails.Rows[0]["TemporaryMobNo"].ToString();
            txtEmerOffTelNo.Text = DtCandidateDetails.Rows[0]["EmergencyTelNoOff"].ToString();
            #endregion

            #region Office Use
            if (DtCandidateDetails.Rows[0]["ReceiptNoAndDate"] != "")
            {
                txtAppnNoAndDate.Text = DtCandidateDetails.Rows[0]["ReceiptNoAndDate"].ToString();
            }
            else
                txtAppnNoAndDate.Text = "";
            Remarks.Text = DtCandidateDetails.Rows[0]["Remarks"].ToString();
            if (DtCandidateDetails.Rows[0]["ApplicationReceivedOn"].ToString() != "01/01/1753")
                txtAppRcvdOn.Text = DtCandidateDetails.Rows[0]["ApplicationReceivedOn"].ToString();
            txtAppnNoAndDate0.Text = DtCandidateDetails.Rows[0]["TCNoIssuedDate"].ToString();
            #endregion
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    private Boolean IsAdmissionValid()
    {
        string ErrMessage = string.Empty;
        bool Result = true;
        try
        {
            #region Candidate Info
            if (txtDOB.Text.Trim() == string.Empty)
            {
                Result = false;
                ErrMessage = "Date cannot be blank.</br>";
            }
            if (txtDOB.Text.Trim() != string.Empty)
            {
                if (Convert.ToDateTime(txtDOB.Text) >= DateTime.Now.Date)
                {
                    Result = false;
                    ErrMessage = ErrMessage + "Date of birth cannot be greater than today.</br>";
                }
            }
            if (PupilTextBox.Text.Trim() == string.Empty)
            {
                Result = false;
                ErrMessage = ErrMessage + "Student Name cannot be blank.</br>";
            }

            if (ddlMotherToungue.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Select mother tongue.</br>";
            }

            if (ddlStandardSought.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Select standard sought.</br>";
            }

            if (ddlReligion.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Select religion.</br>";
            }

            if (ddlCaste.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Select caste.</br>";
            }

            if (ddlSex.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Select gender.</br>";
            }

            if (ddlSL.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Select second language.</br>";
            }

            if (ddlTL.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Select third language.</br>";
            }
            #endregion

            #region Parent Information
            if (txtFatherName.Text.Trim() == string.Empty)
            {
                Result = false;
                ErrMessage = ErrMessage + "Father name cannot be empty.</br>";
            }

            if (txtMotherName.Text.Trim() == string.Empty)
            {
                Result = false;
                ErrMessage = ErrMessage + "Mother name cannot be empty.</br>";
            }

            if (txtEmerAdd.Text.Trim() == string.Empty)
            {
                Result = false;
                ErrMessage = ErrMessage + "Please enter emergency contact address.</br>";
            }

            /*if (txtPerTelNo.Text.Trim() == string.Empty)
            {
                Result = false;
                ErrMessage = ErrMessage + "Please enter personal telephone number.</br>";
            }*/

            /*if (txtRelation.Text.Trim() == string.Empty)
            {
                Result = false;
                ErrMessage = ErrMessage + "Please enter relation.</br>";
            }*/

            if (txtPerMobNo.Text.Trim() == string.Empty)
            {
                Result = false;
                ErrMessage = ErrMessage + "Please enter personal mobile number.</br>";
            }

            /*if (txtEmerTelNo.Text.Trim() == string.Empty)
            {
                Result = false;
                ErrMessage = ErrMessage + "Please enter emergency contact number.</br>";
            }*/

            /* if (txtOtherInfo.Text.Trim() == string.Empty)
             {
                 Result = false;
                 ErrMessage = ErrMessage + "Please enter other information.</br>";
             }*/
            #endregion

            if (ddlFeeTemplate.SelectedValue == "")
            {
                Result = false;
                ErrMessage = ErrMessage + "There are no template set for the standard selected.</br>";
            }
            if (ddlFeeTemplate.SelectedValue == "-1")
            {
                Result = false;
                ErrMessage = ErrMessage + "Select template for fee collection.</br>";
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
    protected void ddlStandardSought_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
            FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();
            FeeMappingHeaderDO.StandardId = Convert.ToInt32(ddlStandardSought.SelectedValue);
            FeeMappingHeaderDO.FeeMode = 1;
            ddlFeeTemplate.Items.Clear();
            CommonClass.LoadDropdownList(ddlFeeTemplate, FeeMappingBLL.GetFeeMappingHeaderDetailsByStandardId(FeeMappingHeaderDO), "MappingTemplateName", "FeeMappingId");
            ddlFL.Focus();
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    protected void ddlFeeTemplate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // Load Fee Details
            FeeMappingBLL FeeMappingBLL = new FeeMappingBLL();
            FeeMappingHeaderDO FeeMappingHeaderDO = new FeeMappingHeaderDO();

            FeeCollectionBLL FeeCollectionBLL = new FeeCollectionBLL();
            FeeCollectionDO FeeCollectionDO = new FeeCollectionDO();
            DataTable DtCheck = new DataTable();

            FeeCollectionDO.StandardId = Convert.ToInt32(ddlStandardSought.SelectedValue);
            FeeCollectionDO.TemplateId = Convert.ToInt32(ddlFeeTemplate.SelectedValue);
            FeeCollectionDO.RegistrationId = 0;
            FeeCollectionDO.AcademicYearId = Convert.ToInt32(ddlAcedamic.SelectedValue);
            DtCheck = FeeCollectionBLL.CheckFeeCollectionDetails(FeeCollectionDO);

            if (DtCheck.Rows.Count == 0)
            {
                DtFee = FeeMappingBLL.GetFeeMasterDetails(Convert.ToInt32(ddlFeeTemplate.SelectedValue), 1);
                Session["FeeCollectionDataTable"] = DtFee;
            }

            txtFatherName.Focus();
        }
        catch (Exception ex)
        {
            WriteLogFile.LogError(ex);
        }
    }
    protected void IM_Click(object sender, ImageClickEventArgs e)
    {
        ModalPopupExtender1.Hide();
    }
    protected void ddlPayMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPayMode.SelectedValue != "-1")
        {
            if (ddlPayMode.SelectedItem.Text != "Cash")
            {
                txtChequeDate.Visible = true;
                txtChequeNo.Visible = true;
                txtChequeBank.Visible = true;
                ChequeDateLabel.Visible = true;
                ChequeNoLabel.Visible = true;
                ChequeBankLabel.Visible = true;
            }
            else
            {
                txtChequeBank.Visible = false;
                txtChequeDate.Visible = false;
                txtChequeNo.Visible = false;
                ChequeDateLabel.Visible = false;
                ChequeNoLabel.Visible = false;
                ChequeBankLabel.Visible = false;
            }
        }
        else
        {
            txtChequeBank.Visible = false;
            txtChequeDate.Visible = false;
            txtChequeNo.Visible = false;
            ChequeDateLabel.Visible = false;
            ChequeNoLabel.Visible = false;
            ChequeBankLabel.Visible = false;
        }
        ModalPopupExtender1.Show();
    }
}
