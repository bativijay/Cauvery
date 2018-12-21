// Decompiled with JetBrains decompiler
// Type: KAVERI.DAL.Masters.ReligionMasterDAL
// Assembly: KAVERI.DAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F8FBF119-0E31-4DCD-929B-D288DECA59B6
// Assembly location: C:\inetpub\wwwroot\Cauvery\Cauvery\bin\KAVERI.DAL.dll

using KAVERI.DAL;
using KAVERI.DO.Masters;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KAVERI.DAL.Masters
{
  public class ReligionMasterDAL
  {
    public int InsertReligionMasterDetails(ReligionMasterDO ReligionMasterDO)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["KAVERI"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "usp_InsertReligionMaster";
        SqlParameter sqlParameter1 = new SqlParameter("@ReligionId", SqlDbType.Int, 50);
        sqlParameter1.Value = (object) ReligionMasterDO.ReligionId;
        sqlCommand.Parameters.Add(sqlParameter1);
        SqlParameter sqlParameter2 = new SqlParameter("@ReligionCode", SqlDbType.VarChar, 50);
        sqlParameter2.Value = (object) ReligionMasterDO.ReligionCode;
        sqlCommand.Parameters.Add(sqlParameter2);
        SqlParameter sqlParameter3 = new SqlParameter("@ReligionName", SqlDbType.VarChar, 50);
        sqlParameter3.Value = (object) ReligionMasterDO.ReligionName;
        sqlCommand.Parameters.Add(sqlParameter3);
        SqlParameter sqlParameter4 = new SqlParameter("@IsActive", SqlDbType.VarChar, 50);
        sqlParameter4.Value = (object) (bool) (ReligionMasterDO.IsActive ? true : false);
        sqlCommand.Parameters.Add(sqlParameter4);
        SqlParameter sqlParameter5 = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
        sqlParameter5.Value = (object) ReligionMasterDO.CreatedBy;
        sqlCommand.Parameters.Add(sqlParameter5);
        SqlParameter sqlParameter6 = new SqlParameter("@ModifiedBy", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) ReligionMasterDO.ModifiedBy;
        sqlCommand.Parameters.Add(sqlParameter6);
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

    public DataTable GetReligionType()
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteSelectCommand("usp_GetReligiontype", CommandType.StoredProcedure);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetReligionMasterDetails(ReligionMasterDO ReligionMasterDO)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetReligionMasterDetails", CommandType.StoredProcedure, new SqlParameter[1]
        {
          new SqlParameter("@ReligionCode", (object) ReligionMasterDO.ReligionCode.Trim().ToString())
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
