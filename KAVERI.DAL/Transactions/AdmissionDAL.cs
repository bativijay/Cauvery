// Decompiled with JetBrains decompiler
// Type: KAVERI.DAL.Transactions.AdmissionDAL
// Assembly: KAVERI.DAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F8FBF119-0E31-4DCD-929B-D288DECA59B6
// Assembly location: C:\inetpub\wwwroot\Cauvery\Cauvery\bin\KAVERI.DAL.dll

using KAVERI.DAL;
using KAVERI.DO.Transactions;
using System;
using System.Data;
using System.Data.SqlClient;

namespace KAVERI.DAL.Transactions
{
  public class AdmissionDAL
  {
    public int InsertCandidateDetails(CandidateInfoDO CandidateInfoDO)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQueryReturnInt("usp_InsertCandidateInfo", CommandType.StoredProcedure, new SqlParameter[22]
        {
          new SqlParameter("@RegistrationId", (object) CandidateInfoDO.RegistrationId.ToString()),
          new SqlParameter("@AcademicYear", (object) CandidateInfoDO.AcademicYear.ToString()),
          new SqlParameter("@StudentName", (object) CandidateInfoDO.StudentName.ToString()),
          new SqlParameter("@Nationality", (object) CandidateInfoDO.Nationality.ToString()),
          new SqlParameter("@Sex", (object) CandidateInfoDO.Sex.ToString()),
          new SqlParameter("@DOB", (object) CandidateInfoDO.DOB),
          new SqlParameter("@MotherTongue", (object) CandidateInfoDO.MotherTongue.ToString()),
          new SqlParameter("@Religion", (object) CandidateInfoDO.Religion.ToString()),
          new SqlParameter("@Caste", (object) CandidateInfoDO.Caste.ToString()),
          new SqlParameter("@Catagory", (object) CandidateInfoDO.Catagory.ToString()),
          new SqlParameter("@SchoolAddress", (object) CandidateInfoDO.SchoolAddress.ToString()),
          new SqlParameter("@Photo", (object) CandidateInfoDO.Photo.ToString()),
          new SqlParameter("@StandardStudying", (object) CandidateInfoDO.StandardStudying.ToString()),
          new SqlParameter("@StandardSought", (object) CandidateInfoDO.StandardSought.ToString()),
          new SqlParameter("@FirstLanguage", (object) CandidateInfoDO.FirstLanguage.ToString()),
          new SqlParameter("@SecondLanguage", (object) CandidateInfoDO.SecondLanguage.ToString()),
          new SqlParameter("@ThirdLanguage", (object) CandidateInfoDO.ThirdLanguage.ToString()),
          new SqlParameter("@CreatedBy", (object) CandidateInfoDO.CreatedBy.ToString()),
          new SqlParameter("@ModifiedBy", (object) CandidateInfoDO.ModifiedBy.ToString()),
          new SqlParameter("@PreviousTCIssuedDate", (object) CandidateInfoDO.PreviousTCIssuedDate.ToString()),
          new SqlParameter("@JoiningAcademicYear", (object) CandidateInfoDO.JoiningAcademicYear.ToString()),
          new SqlParameter("@FeeTemplateId", (object) CandidateInfoDO.FeeTemplateId.ToString())
        }, true);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int InsertParentDetails(ParentsInfoDO ParentsInfoDO)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQueryReturnInt("usp_InsertParentInfo", CommandType.StoredProcedure, new SqlParameter[23]
        {
          new SqlParameter("@ParentId", (object) ParentsInfoDO.ParentId.ToString()),
          new SqlParameter("@RegistrationId", (object) ParentsInfoDO.RegistrationId.ToString()),
          new SqlParameter("@FatherName", (object) ParentsInfoDO.FatherName.ToString()),
          new SqlParameter("@FatherOccupation", (object) ParentsInfoDO.FatherOccupation.ToString()),
          new SqlParameter("@FatherQualification", (object) ParentsInfoDO.FatherQualification.ToString()),
          new SqlParameter("@MotherName", (object) ParentsInfoDO.MotherName.ToString()),
          new SqlParameter("@MotherOccupation", (object) ParentsInfoDO.MotherOccupation.ToString()),
          new SqlParameter("@MotherQualification", (object) ParentsInfoDO.MotherQualification.ToString()),
          new SqlParameter("@PermanantAddress", (object) ParentsInfoDO.PermanantAddress.ToString()),
          new SqlParameter("@TemporaryAddress", (object) ParentsInfoDO.TemporaryAddress.ToString()),
          new SqlParameter("@EmergencyAddress", (object) ParentsInfoDO.EmergencyAddress.ToString()),
          new SqlParameter("@PermanantTelNo", (object) ParentsInfoDO.PermanantTelNo.ToString()),
          new SqlParameter("@TemporaryTelNo", (object) ParentsInfoDO.TemporaryTelNo.ToString()),
          new SqlParameter("@EmergencyTelNo", (object) ParentsInfoDO.EmergencyTelNo.ToString()),
          new SqlParameter("@Relationship", (object) ParentsInfoDO.Relationship.ToString()),
          new SqlParameter("@OtherInformation", (object) ParentsInfoDO.OtherInformation.ToString()),
          new SqlParameter("@CreatedBy", (object) ParentsInfoDO.CreatedBy.ToString()),
          new SqlParameter("@ModifiedBy", (object) ParentsInfoDO.ModifiedBy.ToString()),
          new SqlParameter("@PermanantTelNoOff", (object) ParentsInfoDO.PermanantTelNoOff.ToString()),
          new SqlParameter("@EmergencyTelNoOff", (object) ParentsInfoDO.EmergencyTelNoOff.ToString()),
          new SqlParameter("@TemporaryTelNoOff", (object) ParentsInfoDO.TemporaryTelNoOff.ToString()),
          new SqlParameter("@TemporaryMobNo", (object) ParentsInfoDO.TemporaryMobNo.ToString()),
          new SqlParameter("@PermanantMobNo", (object) ParentsInfoDO.PermanantMobNo.ToString())
        }, true);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int InsertOfficeDetails(OfficeUseDO OfficeUseDO)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQueryReturnInt("usp_InsertOfficeUse", CommandType.StoredProcedure, new SqlParameter[8]
        {
          new SqlParameter("@OfficeUseId", (object) OfficeUseDO.OfficeUseId.ToString()),
          new SqlParameter("@RegistrationId", (object) OfficeUseDO.RegistrationId.ToString()),
          new SqlParameter("@ApplicationReceivedOn", (object) OfficeUseDO.ApplicationReceivedOn),
          new SqlParameter("@ReceiptNoAndDate", (object) OfficeUseDO.ReceiptNoAndDate.ToString()),
          new SqlParameter("@TCNoIssuedDate", (object) OfficeUseDO.TCNoIssuedDate.ToString()),
          new SqlParameter("@Remarks", (object) OfficeUseDO.Remarks.ToString()),
          new SqlParameter("@CreatedBy", (object) OfficeUseDO.CreatedBy.ToString()),
          new SqlParameter("@ModifiedBy", (object) OfficeUseDO.ModifiedBy.ToString())
        }, true);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int InsertStandardAllocationDetails(StandardAllocationDO StandardAllocationDO)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQueryReturnInt("usp_InsertStandardAllocation", CommandType.StoredProcedure, new SqlParameter[7]
        {
          new SqlParameter("@StandardId", (object) StandardAllocationDO.StandardId.ToString()),
          new SqlParameter("@DivisionId", (object) StandardAllocationDO.DivisionId.ToString()),
          new SqlParameter("@RegistrationId", (object) StandardAllocationDO.RegistrationId.ToString()),
          new SqlParameter("@CreatedBy", (object) StandardAllocationDO.CreatedBy.ToString()),
          new SqlParameter("@ModifiedBy", (object) StandardAllocationDO.ModifiedBy.ToString()),
          new SqlParameter("@AcademicYear", (object) StandardAllocationDO.AcademicYear.ToString()),
          new SqlParameter("@FeeTemplateId", (object) StandardAllocationDO.FeeTemplateId.ToString())
        }, true);
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
        return SqlDBHelper.ExecuteNonQueryReturnInt("usp_UpdateCandidateInfo", CommandType.StoredProcedure, new SqlParameter[20]
        {
          new SqlParameter("@RegistrationId", (object) CandidateInfoDO.RegistrationId.ToString()),
          new SqlParameter("@AcademicYear", (object) CandidateInfoDO.AcademicYear.ToString()),
          new SqlParameter("@StudentName", (object) CandidateInfoDO.StudentName.ToString()),
          new SqlParameter("@Nationality", (object) CandidateInfoDO.Nationality.ToString()),
          new SqlParameter("@Sex", (object) CandidateInfoDO.Sex.ToString()),
          new SqlParameter("@DOB", (object) CandidateInfoDO.DOB),
          new SqlParameter("@MotherTongue", (object) CandidateInfoDO.MotherTongue.ToString()),
          new SqlParameter("@Religion", (object) CandidateInfoDO.Religion.ToString()),
          new SqlParameter("@Caste", (object) CandidateInfoDO.Caste.ToString()),
          new SqlParameter("@Catagory", (object) CandidateInfoDO.Catagory.ToString()),
          new SqlParameter("@SchoolAddress", (object) CandidateInfoDO.SchoolAddress.ToString()),
          new SqlParameter("@Photo", (object) CandidateInfoDO.Photo.ToString()),
          new SqlParameter("@StandardStudying", (object) CandidateInfoDO.StandardStudying.ToString()),
          new SqlParameter("@StandardSought", (object) CandidateInfoDO.StandardSought.ToString()),
          new SqlParameter("@FirstLanguage", (object) CandidateInfoDO.FirstLanguage.ToString()),
          new SqlParameter("@SecondLanguage", (object) CandidateInfoDO.SecondLanguage.ToString()),
          new SqlParameter("@ThirdLanguage", (object) CandidateInfoDO.ThirdLanguage.ToString()),
          new SqlParameter("@ModifiedBy", (object) CandidateInfoDO.ModifiedBy.ToString()),
          new SqlParameter("@PreviousTCIssuedDate", (object) CandidateInfoDO.PreviousTCIssuedDate.ToString()),
          new SqlParameter("@JoiningAcademicYear", (object) CandidateInfoDO.JoiningAcademicYear.ToString())
        }, true);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int UpdateParentDetails(ParentsInfoDO ParentsInfoDO)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQueryReturnInt("usp_UpdateParentInfo", CommandType.StoredProcedure, new SqlParameter[22]
        {
          new SqlParameter("@ParentId", (object) ParentsInfoDO.ParentId.ToString()),
          new SqlParameter("@RegistrationId", (object) ParentsInfoDO.RegistrationId.ToString()),
          new SqlParameter("@FatherName", (object) ParentsInfoDO.FatherName.ToString()),
          new SqlParameter("@FatherOccupation", (object) ParentsInfoDO.FatherOccupation.ToString()),
          new SqlParameter("@FatherQualification", (object) ParentsInfoDO.FatherQualification.ToString()),
          new SqlParameter("@MotherName", (object) ParentsInfoDO.MotherName.ToString()),
          new SqlParameter("@MotherOccupation", (object) ParentsInfoDO.MotherOccupation.ToString()),
          new SqlParameter("@MotherQualification", (object) ParentsInfoDO.MotherQualification.ToString()),
          new SqlParameter("@PermanantAddress", (object) ParentsInfoDO.PermanantAddress.ToString()),
          new SqlParameter("@TemporaryAddress", (object) ParentsInfoDO.TemporaryAddress.ToString()),
          new SqlParameter("@EmergencyAddress", (object) ParentsInfoDO.EmergencyAddress.ToString()),
          new SqlParameter("@PermanantTelNo", (object) ParentsInfoDO.PermanantTelNo.ToString()),
          new SqlParameter("@TemporaryTelNo", (object) ParentsInfoDO.TemporaryTelNo.ToString()),
          new SqlParameter("@EmergencyTelNo", (object) ParentsInfoDO.EmergencyTelNo.ToString()),
          new SqlParameter("@Relationship", (object) ParentsInfoDO.Relationship.ToString()),
          new SqlParameter("@OtherInformation", (object) ParentsInfoDO.OtherInformation.ToString()),
          new SqlParameter("@ModifiedBy", (object) ParentsInfoDO.ModifiedBy.ToString()),
          new SqlParameter("@PermanantTelNoOff", (object) ParentsInfoDO.PermanantTelNoOff.ToString()),
          new SqlParameter("@EmergencyTelNoOff", (object) ParentsInfoDO.EmergencyTelNoOff.ToString()),
          new SqlParameter("@TemporaryTelNoOff", (object) ParentsInfoDO.TemporaryTelNoOff.ToString()),
          new SqlParameter("@TemporaryMobNo", (object) ParentsInfoDO.TemporaryMobNo.ToString()),
          new SqlParameter("@PermanantMobNo", (object) ParentsInfoDO.PermanantMobNo.ToString())
        }, true);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int UpdateNewRegistrationNumber(CandidateInfoDO CandidateInfoDO)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQueryReturnInt("usp_UpdateNewRegistrationNumber", CommandType.StoredProcedure, new SqlParameter[3]
        {
          new SqlParameter("@RegistrationId", (object) CandidateInfoDO.RegistrationId.ToString()),
          new SqlParameter("@AcademicYear", (object) CandidateInfoDO.AcademicYear.ToString()),
          new SqlParameter("@Status", (object) CandidateInfoDO.Status.ToString())
        }, true);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int ResetRegistrationNumberToZero(CandidateInfoDO CandidateInfoDO)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQueryReturnInt("usp_ResetRegistrationNumberToZero", CommandType.StoredProcedure, new SqlParameter[2]
        {
          new SqlParameter("@RegistrationId", (object) CandidateInfoDO.RegistrationId.ToString()),
          new SqlParameter("@AcademicYear", (object) CandidateInfoDO.AcademicYear.ToString())
        }, true);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int UpdateOfficeDetails(OfficeUseDO OfficeUseDO)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQueryReturnInt("usp_UpdateOfficeUse", CommandType.StoredProcedure, new SqlParameter[7]
        {
          new SqlParameter("@OfficeUseId", (object) OfficeUseDO.OfficeUseId.ToString()),
          new SqlParameter("@RegistrationId", (object) OfficeUseDO.RegistrationId.ToString()),
          new SqlParameter("@ApplicationReceivedOn", (object) OfficeUseDO.ApplicationReceivedOn.ToString()),
          new SqlParameter("@ReceiptNoAndDate", (object) OfficeUseDO.ReceiptNoAndDate.ToString()),
          new SqlParameter("@TCNoIssuedDate", (object) OfficeUseDO.TCNoIssuedDate.ToString()),
          new SqlParameter("@Remarks", (object) OfficeUseDO.Remarks.ToString()),
          new SqlParameter("@ModifiedBy", (object) OfficeUseDO.ModifiedBy.ToString())
        }, true);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetAdmissionDetails(CandidateInfoDO CandidateInfoDO)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetAdmissionDetails", CommandType.StoredProcedure, new SqlParameter[3]
        {
          new SqlParameter("@AdmissionNo", (object) CandidateInfoDO.RegistrationId),
          new SqlParameter("@StudentName", (object) CandidateInfoDO.StudentName),
          new SqlParameter("@FatherName", (object) CandidateInfoDO.ParentsInfoDO.FatherName)
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetAdmissionAcademicDetailsForPromotion(CandidateInfoDO CandidateInfoDO)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetAcademicDetailsForPromotion", CommandType.StoredProcedure, new SqlParameter[1]
        {
          new SqlParameter("@AcademicYear", (object) CandidateInfoDO.AcademicYear)
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetAdmissionAcademicDetails(CandidateInfoDO CandidateInfoDO)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetAcademicDetails", CommandType.StoredProcedure, new SqlParameter[1]
        {
          new SqlParameter("@AcademicYear", (object) CandidateInfoDO.AcademicYear)
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int UpdateAllocation(CandidateInfoDO CandidateInfoDO)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQueryReturnInt("usp_UpdateAllocation", CommandType.StoredProcedure, new SqlParameter[2]
        {
          new SqlParameter("@RegistrationId", (object) CandidateInfoDO.RegistrationId.ToString()),
          new SqlParameter("@AcademicYear", (object) CandidateInfoDO.AcademicYear.ToString())
        }, true);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
