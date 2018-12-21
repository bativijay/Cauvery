// Decompiled with JetBrains decompiler
// Type: KAVERI.DAL.Transactions.RefundDAL
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
  public class RefundDAL
  {
    public int InsertRefund(RefundDO RefundDO)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQueryReturnInt("usp_InsertRefund", CommandType.StoredProcedure, new SqlParameter[7]
        {
          new SqlParameter("@StandardId", (object) RefundDO.Standard.ToString()),
          new SqlParameter("@TemplateId", (object) RefundDO.TemplateId.ToString()),
          new SqlParameter("@RegistrationId", (object) RefundDO.RegistrationId.ToString()),
          new SqlParameter("@AcademicYearId", (object) RefundDO.AcademicYear.ToString()),
          new SqlParameter("@RefundAmount", (object) RefundDO.RefundAmount.ToString()),
          new SqlParameter("@CreatedBy", (object) RefundDO.CreatedBy.ToString()),
          new SqlParameter("@ModifiedBy", (object) RefundDO.ModifiedBy.ToString())
        }, true);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
