// Decompiled with JetBrains decompiler
// Type: KAVERI.DAL.Masters.CastMasterDAL
// Assembly: KAVERI.DAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F8FBF119-0E31-4DCD-929B-D288DECA59B6
// Assembly location: C:\inetpub\wwwroot\Cauvery\Cauvery\bin\KAVERI.DAL.dll

using KAVERI.DAL;
using KAVERI.DO.Masters;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
namespace KAVERI.DAL.Masters
{
  public class CastMasterDAL
  {
    public int InsertCastMasterDetails(CastMasterDO CastMasterDO)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["KAVERI"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "usp_InsertCastMaster";
        SqlParameter sqlParameter1 = new SqlParameter("@CastId", SqlDbType.Int, 50);
        sqlParameter1.Value = (object) CastMasterDO.CastId;
        sqlCommand.Parameters.Add(sqlParameter1);
        SqlParameter sqlParameter2 = new SqlParameter("@CastCode", SqlDbType.VarChar, 50);
        sqlParameter2.Value = (object) CastMasterDO.CastCode;
        sqlCommand.Parameters.Add(sqlParameter2);
        SqlParameter sqlParameter3 = new SqlParameter("@CastName", SqlDbType.VarChar, 50);
        sqlParameter3.Value = (object) CastMasterDO.CastName;
        sqlCommand.Parameters.Add(sqlParameter3);
        SqlParameter sqlParameter4 = new SqlParameter("@IsActive", SqlDbType.VarChar, 50);
        sqlParameter4.Value = (object) (bool) (CastMasterDO.IsActive ? true : false);
        sqlCommand.Parameters.Add(sqlParameter4);
        SqlParameter sqlParameter5 = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
        sqlParameter5.Value = (object) CastMasterDO.CreatedBy;
        sqlCommand.Parameters.Add(sqlParameter5);
        SqlParameter sqlParameter6 = new SqlParameter("@ModifiedBy", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) CastMasterDO.ModifiedBy;
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

    public DataTable GetCastType()
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteSelectCommand("usp_GetCasttype", CommandType.StoredProcedure);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetCastMasterDetails(CastMasterDO CastMasterDO)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetCastMasterDetails", CommandType.StoredProcedure, new SqlParameter[1]
        {
          new SqlParameter("@CastCode", (object) CastMasterDO.CastCode.Trim().ToString())
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
