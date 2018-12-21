// Decompiled with JetBrains decompiler
// Type: KAVERI.DAL.Transactions.FeeCollectionDAL
// Assembly: KAVERI.DAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F8FBF119-0E31-4DCD-929B-D288DECA59B6
// Assembly location: C:\inetpub\wwwroot\Cauvery\Cauvery\bin\KAVERI.DAL.dll

using KAVERI.DAL;
using KAVERI.DO.Transactions;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KAVERI.DAL.Transactions
{
  public class FeeCollectionDAL
  {
    public int InsertCollectionHeader(FeeCollectionDO FeeCollectionDO)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQueryReturnInt("usp_InsertFeeCollectionHeader", CommandType.StoredProcedure, new SqlParameter[18]
        {
          new SqlParameter("@FeeCollectionId", (object) FeeCollectionDO.FeeCollectionId.ToString()),
          new SqlParameter("@StandardId", (object) FeeCollectionDO.StandardId.ToString()),
          new SqlParameter("@TemplateId", (object) FeeCollectionDO.TemplateId.ToString()),
          new SqlParameter("@RegistrationId", (object) FeeCollectionDO.RegistrationId.ToString()),
          new SqlParameter("@AcademicYearId", (object) FeeCollectionDO.AcademicYearId.ToString()),
          new SqlParameter("@TotalFeeAmount", (object) FeeCollectionDO.TotalFeeAmount.ToString()),
          new SqlParameter("@TotalPendingAmount", (object) FeeCollectionDO.TotalPendingAmount.ToString()),
          new SqlParameter("@TotalAmountPaid", (object) FeeCollectionDO.TotalAmountPaid.ToString()),
          new SqlParameter("@PaymentMode", (object) FeeCollectionDO.PaymentMode.ToString()),
          new SqlParameter("@PayType", (object) FeeCollectionDO.PayType.ToString()),
          new SqlParameter("@CreatedBy", (object) FeeCollectionDO.CreatedBy.ToString()),
          new SqlParameter("@ModifiedBy", (object) FeeCollectionDO.ModifiedBy.ToString()),
          new SqlParameter("@ReceiptNo", (object) FeeCollectionDO.ReceiptNo.ToString()),
          new SqlParameter("@ChequeNo", (object) FeeCollectionDO.ChequeNo.ToString()),
          new SqlParameter("@ChequeDate", (object) FeeCollectionDO.ChequeDate.ToString()),
          new SqlParameter("@ChequeBank", (object) FeeCollectionDO.ChequeBank.ToString()),
          new SqlParameter("@StudentName", (object) FeeCollectionDO.StudentName.ToString()),
          new SqlParameter("@FatherName", (object) FeeCollectionDO.FatherName.ToString())
        }, true);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int InsertCollectionDetails(FeeCollectionDO FeeCollectionDO)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQueryReturnInt("usp_InsertFeeCollectionDetails", CommandType.StoredProcedure, new SqlParameter[17]
        {
          new SqlParameter("@FeeCollectionDetailId", (object) FeeCollectionDO.FeeCollectionDetailsDO.FeeCollectionDetailId.ToString()),
          new SqlParameter("@FeeCollectionId", (object) FeeCollectionDO.FeeCollectionDetailsDO.FeeCollectionId.ToString()),
          new SqlParameter("@FeeId", (object) FeeCollectionDO.FeeCollectionDetailsDO.FeeId.ToString()),
          new SqlParameter("@FeeAmount", (object) FeeCollectionDO.FeeCollectionDetailsDO.FeeAmount.ToString()),
          new SqlParameter("@PendingAmount", (object) FeeCollectionDO.FeeCollectionDetailsDO.PendingAmount.ToString()),
          new SqlParameter("@PaidAmount", (object) FeeCollectionDO.FeeCollectionDetailsDO.PaidAmount.ToString()),
          new SqlParameter("@PaymentMode", (object) FeeCollectionDO.PaymentMode.ToString()),
          new SqlParameter("@CreatedBy", (object) FeeCollectionDO.FeeCollectionDetailsDO.CreatedBy.ToString()),
          new SqlParameter("@ModifiedBy", (object) FeeCollectionDO.FeeCollectionDetailsDO.ModifiedBy.ToString()),
          new SqlParameter("@ReceiptNo", (object) FeeCollectionDO.FeeCollectionDetailsDO.ReceiptNo.ToString()),
          new SqlParameter("@RegistrationId", (object) FeeCollectionDO.RegistrationId.ToString()),
          new SqlParameter("@TemplateId", (object) FeeCollectionDO.TemplateId.ToString()),
          new SqlParameter("@AcademicYearId", (object) FeeCollectionDO.AcademicYearId.ToString()),
          new SqlParameter("@StandardId", (object) FeeCollectionDO.StandardId.ToString()),
          new SqlParameter("@ChequeNo", (object) FeeCollectionDO.ChequeNo.ToString()),
          new SqlParameter("@ChequeDate", (object) FeeCollectionDO.ChequeDate.ToString()),
          new SqlParameter("@ChequeBank", (object) FeeCollectionDO.ChequeBank.ToString())
        }, true);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int UpdateCollectionHeader(FeeCollectionDO FeeCollectionDO)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQueryReturnInt("usp_UpdateFeeCollectionHeader", CommandType.StoredProcedure, new SqlParameter[4]
        {
          new SqlParameter("@FeeCollectionId", (object) FeeCollectionDO.FeeCollectionId.ToString()),
          new SqlParameter("@TotalPendingAmount", (object) FeeCollectionDO.TotalPendingAmount.ToString()),
          new SqlParameter("@TotalAmountPaid", (object) FeeCollectionDO.TotalAmountPaid.ToString()),
          new SqlParameter("@ModifiedBy", (object) FeeCollectionDO.ModifiedBy.ToString())
        }, true);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable CheckFeeCollectionDetails(FeeCollectionDO FeeCollectionDO)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_CheckFeeCollectionDetails", CommandType.StoredProcedure, new SqlParameter[4]
        {
          new SqlParameter("@StandardId", (object) FeeCollectionDO.StandardId),
          new SqlParameter("@TemplateId", (object) FeeCollectionDO.TemplateId),
          new SqlParameter("@RegistrationId", (object) FeeCollectionDO.RegistrationId),
          new SqlParameter("@AcademicYearId", (object) FeeCollectionDO.AcademicYearId)
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetFeeCollectionDetails(FeeCollectionDO FeeCollectionDO)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetFeeCollectionDetails", CommandType.StoredProcedure, new SqlParameter[4]
        {
          new SqlParameter("@StandardId", (object) FeeCollectionDO.StandardId),
          new SqlParameter("@TemplateId", (object) FeeCollectionDO.TemplateId),
          new SqlParameter("@RegistrationId", (object) FeeCollectionDO.RegistrationId),
          new SqlParameter("@AcademicYearId", (object) FeeCollectionDO.AcademicYearId)
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetCollectionDetails(FeeCollectionDO FeeCollectionDO)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetCollectionDetails", CommandType.StoredProcedure, new SqlParameter[4]
        {
          new SqlParameter("@StandardId", (object) FeeCollectionDO.StandardId),
          new SqlParameter("@TemplateId", (object) FeeCollectionDO.TemplateId),
          new SqlParameter("@RegistrationId", (object) FeeCollectionDO.RegistrationId),
          new SqlParameter("@AcademicYearId", (object) FeeCollectionDO.AcademicYearId)
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetRptFeeCollectionDetails(FeeCollectionDO FeeCollectionDO)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetRptFeeCollectionDetails", CommandType.StoredProcedure, new SqlParameter[3]
        {
          new SqlParameter("@FromDate", (object) FeeCollectionDO.FromDate),
          new SqlParameter("@EndDate", (object) FeeCollectionDO.ToDate),
          new SqlParameter("@AcademicYear", (object) FeeCollectionDO.AcademicYearId)
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetRptRegistrationDetails(AdmissionReportDO AdmissionReport)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetRptAdmissionRegister", CommandType.StoredProcedure, new SqlParameter[6]
        {
          new SqlParameter("@Sex", (object) AdmissionReport.Sex),
          new SqlParameter("@Age", (object) AdmissionReport.Age),
          new SqlParameter("@StandardId", (object) AdmissionReport.StandardId),
          new SqlParameter("@Caste", (object) AdmissionReport.Caste),
          new SqlParameter("@BelongsTo", (object) AdmissionReport.BelongsTo),
          new SqlParameter("@AcademicYear", (object) AdmissionReport.AcademicYear)
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetReceiptDetails(int Type)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetReceiptDetails", CommandType.StoredProcedure, new SqlParameter[1]
        {
          new SqlParameter("@Type", (object) Type)
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int UpdateReceiptDetails(int Type)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["KAVERI"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "usp_UpdateReceipt";
        SqlParameter sqlParameter = new SqlParameter("@Type", SqlDbType.Int, 50);
        sqlParameter.Value = (object) Type;
        sqlCommand.Parameters.Add(sqlParameter);
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
        return 1;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetReportReceiptDetails(int RegistrationNo, string StudentName, string FatherName, int AcademicYear)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetRptReceiptDetails", CommandType.StoredProcedure, new SqlParameter[4]
        {
          new SqlParameter("@RegistrationNo", (object) RegistrationNo),
          new SqlParameter("@StudentName", (object) StudentName),
          new SqlParameter("@FatherName", (object) FatherName),
          new SqlParameter("@AcademicYearId", (object) AcademicYear)
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetReportReceiptDetails(int RegistrationNo, string ReceiptNo)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetRptReceipt", CommandType.StoredProcedure, new SqlParameter[2]
        {
          new SqlParameter("@RegistrationNo", (object) RegistrationNo),
          new SqlParameter("@ReceiptNo", (object) ReceiptNo)
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetRptPendingCollectionDetails(FeeCollectionDO FeeCollectionDO)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetRptPendingCollectionDetails", CommandType.StoredProcedure, new SqlParameter[2]
        {
          new SqlParameter("@StandardId", (object) FeeCollectionDO.StandardId),
          new SqlParameter("@AcademicYearId", (object) FeeCollectionDO.AcademicYearId)
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
