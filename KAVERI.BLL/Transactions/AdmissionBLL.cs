using System;
using System.Collections.Generic;
using System.Text;
using KAVERI.DO.Transactions;
using KAVERI.DO;
using KAVERI.DAL.Masters;
using KAVERI.DAL;
using KAVERI.DAL.Transactions;
using System.Data;

namespace KAVERI.BLL.Transactions
{
  public class AdmissionBLL
  {
    public AdmissionDAL _AdmissionDAL = new AdmissionDAL();

    public int InsertCandidateDetails(CandidateInfoDO CandidateInfoDO)
    {
      try
      {
        int num = this._AdmissionDAL.InsertCandidateDetails(CandidateInfoDO);
        this._AdmissionDAL.InsertStandardAllocationDetails(new StandardAllocationDO()
        {
          RegistrationId = num,
          StandardId = CandidateInfoDO.StandardSought,
          CreatedBy = CandidateInfoDO.CreatedBy,
          ModifiedBy = CandidateInfoDO.ModifiedBy,
          AcademicYear = CandidateInfoDO.AcademicYear,
          FeeTemplateId = CandidateInfoDO.FeeTemplateId
        });
        if (num > 0)
        {
          CandidateInfoDO.ParentsInfoDO.RegistrationId = num;
          if (this._AdmissionDAL.InsertParentDetails(CandidateInfoDO.ParentsInfoDO) > 0)
          {
            CandidateInfoDO.OfficeUseDO.RegistrationId = num;
            if (this._AdmissionDAL.InsertOfficeDetails(CandidateInfoDO.OfficeUseDO) > 0)
              return num;
          }
        }
        return num;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int UpdateCandidateDetails(CandidateInfoDO CandidateInfoDO)
    {
      try
      {
        int num = this._AdmissionDAL.UpdateCandidateDetails(CandidateInfoDO);
        if (num > 0)
        {
          CandidateInfoDO.ParentsInfoDO.RegistrationId = num;
          if (this._AdmissionDAL.UpdateParentDetails(CandidateInfoDO.ParentsInfoDO) > 0)
          {
            CandidateInfoDO.OfficeUseDO.RegistrationId = num;
            if (this._AdmissionDAL.UpdateOfficeDetails(CandidateInfoDO.OfficeUseDO) > 0)
              return num;
          }
        }
        return num;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetAdmissionDetails(CandidateInfoDO CandidateInfoDO)
    {
      return this._AdmissionDAL.GetAdmissionDetails(CandidateInfoDO);
    }

    public DataTable GetAdmissionAcademicDetails(CandidateInfoDO CandidateInfoDO)
    {
      return this._AdmissionDAL.GetAdmissionAcademicDetails(CandidateInfoDO);
    }

    public DataTable GetAdmissionAcademicDetailsForPromotion(CandidateInfoDO CandidateInfoDO)
    {
      return this._AdmissionDAL.GetAdmissionAcademicDetailsForPromotion(CandidateInfoDO);
    }

    public int ResetRegistrationNumberToZero(CandidateInfoDO CandidateInfoDO)
    {
      return this._AdmissionDAL.ResetRegistrationNumberToZero(CandidateInfoDO);
    }

    public int UpdateNewRegistrationNumber(List<CandidateInfoDO> CandidateInfoDO)
    {
      int num = 0;
      foreach (CandidateInfoDO CandidateInfoDO1 in CandidateInfoDO)
        num = this._AdmissionDAL.UpdateNewRegistrationNumber(CandidateInfoDO1);
      return num;
    }

    public int UpdatePromotion(DataTable DtFee, int CreatedBy)
    {
      try
      {
        FeeCollectionDO FeeCollectionDO = new FeeCollectionDO();
        FeeCollectionDO.FeeCollectionDetailsList = new List<FeeCollectionDetailsDO>();
        foreach (DataRow dataRow in (InternalDataCollectionBase) DtFee.Rows)
          FeeCollectionDO.FeeCollectionDetailsList.Add(new FeeCollectionDetailsDO()
          {
            FeeId = Convert.ToInt32(dataRow["FeeId"].ToString()),
            FeeCollectionId = 0,
            FeeAmount = Convert.ToDouble(dataRow["Amount"].ToString()),
            PaidAmount = Convert.ToDouble("0"),
            PendingAmount = Convert.ToDouble(dataRow["Amount"].ToString()),
            CreatedBy = CreatedBy,
            ModifiedBy = CreatedBy,
            ReceiptNo = "0"
          });
        return new FeeCollectionBLL().InsertFeeCollection(FeeCollectionDO);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int UpdateAllocation(List<CandidateInfoDO> CandidateInfoDO, DataTable DtFee)
    {
      int num = 0;
      foreach (CandidateInfoDO candidateInfoDo in CandidateInfoDO)
        this._AdmissionDAL.InsertStandardAllocationDetails(new StandardAllocationDO()
        {
          RegistrationId = candidateInfoDo.RegistrationId,
          StandardId = candidateInfoDo.StandardSought,
          CreatedBy = candidateInfoDo.CreatedBy,
          ModifiedBy = candidateInfoDo.ModifiedBy,
          AcademicYear = candidateInfoDo.CurrentAcademicYear,
          FeeTemplateId = candidateInfoDo.FeeTemplateId
        });
      foreach (CandidateInfoDO candidateInfoDo in CandidateInfoDO)
      {
        FeeCollectionDO FeeCollectionDO = new FeeCollectionDO();
        FeeCollectionDO.AcademicYearId = candidateInfoDo.CurrentAcademicYear;
        FeeCollectionDO.CreatedBy = candidateInfoDo.CreatedBy;
        FeeCollectionDO.FeeCollectionId = 0;
        FeeCollectionDO.ModifiedBy = candidateInfoDo.CreatedBy;
        FeeCollectionDO.PaymentMode = 1;
        FeeCollectionDO.PayType = "D";
        FeeCollectionDO.ReceiptNo = "0";
        FeeCollectionDO.RegistrationId = candidateInfoDo.RegistrationId;
        FeeCollectionDO.StandardId = candidateInfoDo.StandardSought;
        FeeCollectionDO.TemplateId = candidateInfoDo.FeeTemplateId;
        FeeCollectionDO.StudentName = candidateInfoDo.StudentName;
        FeeCollectionDO.FatherName = candidateInfoDo.FatherName;
        FeeCollectionDO.ChequeDate = "";
        FeeCollectionDO.ChequeNo = "";
        FeeCollectionDO.ChequeBank = "";
        FeeCollectionDO.FeeCollectionDetailsList = new List<FeeCollectionDetailsDO>();
        foreach (DataRow dataRow in (InternalDataCollectionBase) DtFee.Rows)
          FeeCollectionDO.FeeCollectionDetailsList.Add(new FeeCollectionDetailsDO()
          {
            FeeId = Convert.ToInt32(dataRow["FeeId"].ToString()),
            FeeCollectionId = 0,
            FeeAmount = Convert.ToDouble(dataRow["Amount"].ToString()),
            PaidAmount = Convert.ToDouble("0"),
            PendingAmount = Convert.ToDouble(dataRow["Amount"].ToString()),
            CreatedBy = candidateInfoDo.CreatedBy,
            ModifiedBy = candidateInfoDo.CreatedBy,
            ReceiptNo = "0"
          });
        new FeeCollectionBLL().InsertFeeCollection(FeeCollectionDO);
      }
      foreach (CandidateInfoDO CandidateInfoDO1 in CandidateInfoDO)
        num = this._AdmissionDAL.UpdateAllocation(CandidateInfoDO1);
      return num;
    }
  }
}
