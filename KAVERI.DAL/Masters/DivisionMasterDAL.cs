// Decompiled with JetBrains decompiler
// Type: KAVERI.DAL.Masters.DivisionMasterDAL
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
  public class DivisionMasterDAL
  {
    public int InsertDivisionMasterDetails(DivisionMasterDO DivisionMasterDO)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["KAVERI"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "usp_InsertDivisionMaster";
        SqlParameter sqlParameter1 = new SqlParameter("@DivisionId", SqlDbType.Int, 50);
        sqlParameter1.Value = (object) DivisionMasterDO.DivisionId;
        sqlCommand.Parameters.Add(sqlParameter1);
        SqlParameter sqlParameter2 = new SqlParameter("@DivisionCode", SqlDbType.VarChar, 50);
        sqlParameter2.Value = (object) DivisionMasterDO.DivisionCode;
        sqlCommand.Parameters.Add(sqlParameter2);
        SqlParameter sqlParameter3 = new SqlParameter("@DivisionName", SqlDbType.VarChar, 50);
        sqlParameter3.Value = (object) DivisionMasterDO.DivisionName;
        sqlCommand.Parameters.Add(sqlParameter3);
        SqlParameter sqlParameter4 = new SqlParameter("@IsActive", SqlDbType.VarChar, 50);
        sqlParameter4.Value = (object) (bool) (DivisionMasterDO.IsActive ? true : false);
        sqlCommand.Parameters.Add(sqlParameter4);
        SqlParameter sqlParameter5 = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
        sqlParameter5.Value = (object) DivisionMasterDO.CreatedBy;
        sqlCommand.Parameters.Add(sqlParameter5);
        SqlParameter sqlParameter6 = new SqlParameter("@ModifiedBy", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) DivisionMasterDO.ModifiedBy;
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

    public DataTable GetDivisionType()
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteSelectCommand("usp_GetDivisiontype", CommandType.StoredProcedure);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetDivisionMasterDetails(DivisionMasterDO DivisionMasterDO)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetDivisionMasterDetails", CommandType.StoredProcedure, new SqlParameter[1]
        {
          new SqlParameter("@DivisionCode", (object) DivisionMasterDO.DivisionCode.Trim().ToString())
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
