// Decompiled with JetBrains decompiler
// Type: KAVERI.DAL.Masters.FeeMasterDAL
// Assembly: KAVERI.DAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F8FBF119-0E31-4DCD-929B-D288DECA59B6
// Assembly location: C:\inetpub\wwwroot\Cauvery\Cauvery\bin\KAVERI.DAL.dll

using KAVERI.DAL;
using KAVERI.DO;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KAVERI.DAL.Masters
{
  public class FeeMasterDAL
  {
    public int InsertFeeMasterDetails(FeeMasterDO FeeMasterDO)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["KAVERI"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "usp_InsertFeeMaster";
        SqlParameter sqlParameter1 = new SqlParameter("@FeeId", SqlDbType.Int, 50);
        sqlParameter1.Value = (object) FeeMasterDO.FeeId;
        sqlCommand.Parameters.Add(sqlParameter1);
        SqlParameter sqlParameter2 = new SqlParameter("@FeeCode", SqlDbType.VarChar, 50);
        sqlParameter2.Value = (object) FeeMasterDO.FeeCode;
        sqlCommand.Parameters.Add(sqlParameter2);
        SqlParameter sqlParameter3 = new SqlParameter("@FeeName", SqlDbType.VarChar, 50);
        sqlParameter3.Value = (object) FeeMasterDO.FeeName;
        sqlCommand.Parameters.Add(sqlParameter3);
        SqlParameter sqlParameter4 = new SqlParameter("@FeeType", SqlDbType.VarChar, 50);
        sqlParameter4.Value = (object) FeeMasterDO.FeeType;
        sqlCommand.Parameters.Add(sqlParameter4);
        SqlParameter sqlParameter5 = new SqlParameter("@IsActive", SqlDbType.VarChar, 50);
        sqlParameter5.Value = (object) (bool) (FeeMasterDO.IsActive ? true : false);
        sqlCommand.Parameters.Add(sqlParameter5);
        SqlParameter sqlParameter6 = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) FeeMasterDO.CreatedBy;
        sqlCommand.Parameters.Add(sqlParameter6);
        SqlParameter sqlParameter7 = new SqlParameter("@ModifiedBy", SqlDbType.VarChar, 50);
        sqlParameter7.Value = (object) FeeMasterDO.ModifiedBy;
        sqlCommand.Parameters.Add(sqlParameter7);
        SqlParameter sqlParameter8 = new SqlParameter("@FeeMode", SqlDbType.VarChar, 50);
        sqlParameter8.Value = (object) FeeMasterDO.FeeMode;
        sqlCommand.Parameters.Add(sqlParameter8);
        sqlConnection.Open();
        int num = sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
        return num;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetFeeType()
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteSelectCommand("usp_GetFeetype", CommandType.StoredProcedure);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetFeeMasterDetails(FeeMasterDO FeeMasterDO)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetFeeMasterDetails", CommandType.StoredProcedure, new SqlParameter[1]
        {
          new SqlParameter("@FeeCode", (object) FeeMasterDO.FeeCode.Trim().ToString())
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
