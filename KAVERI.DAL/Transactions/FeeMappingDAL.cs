// Decompiled with JetBrains decompiler
// Type: KAVERI.DAL.Transactions.FeeMappingDAL
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
  public class FeeMappingDAL
  {
    public int InsertFeeMappingHeaderDetails(FeeMappingHeaderDO FeeMappingHeaderDO)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["KAVERI"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "usp_InsertFeeMappingHeader";
        SqlParameter sqlParameter1 = new SqlParameter("@FeeMappingId", SqlDbType.Int, 50);
        sqlParameter1.Value = (object) FeeMappingHeaderDO.FeeMappingId;
        sqlCommand.Parameters.Add(sqlParameter1);
        SqlParameter sqlParameter2 = new SqlParameter("@MappingTemplateName", SqlDbType.VarChar, 50);
        sqlParameter2.Value = (object) FeeMappingHeaderDO.MappingTemplateName;
        sqlCommand.Parameters.Add(sqlParameter2);
        SqlParameter sqlParameter3 = new SqlParameter("@StandardId", SqlDbType.Int, 50);
        sqlParameter3.Value = (object) FeeMappingHeaderDO.StandardId;
        sqlCommand.Parameters.Add(sqlParameter3);
        SqlParameter sqlParameter4 = new SqlParameter("@IsActive", SqlDbType.VarChar, 50);
        sqlParameter4.Value = (object) (bool) (FeeMappingHeaderDO.IsActive ? true : false);
        sqlCommand.Parameters.Add(sqlParameter4);
        SqlParameter sqlParameter5 = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
        sqlParameter5.Value = (object) FeeMappingHeaderDO.CreatedBy;
        sqlCommand.Parameters.Add(sqlParameter5);
        SqlParameter sqlParameter6 = new SqlParameter("@ModifiedBy", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) FeeMappingHeaderDO.ModifiedBy;
        sqlCommand.Parameters.Add(sqlParameter6);
        SqlParameter sqlParameter7 = new SqlParameter("@FeeMode", SqlDbType.VarChar, 50);
        sqlParameter7.Value = (object) FeeMappingHeaderDO.FeeMode;
        sqlCommand.Parameters.Add(sqlParameter7);
        SqlParameter sqlParameter8 = new SqlParameter("@ReportFormatId", SqlDbType.VarChar, 50);
        sqlParameter8.Value = (object) FeeMappingHeaderDO.ReportFormatId;
        sqlCommand.Parameters.Add(sqlParameter8);
        SqlParameter sqlParameter9 = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
        sqlParameter9.Direction = ParameterDirection.ReturnValue;
        sqlCommand.Parameters.Add(sqlParameter9);
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
        int num = (int) sqlCommand.Parameters["@RETURN_VALUE"].Value;
        sqlConnection.Close();
        return num;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int InsertFeeMappingDetails(FeeMappingDetailsDO FeeMappingDetailsDO)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["KAVERI"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "usp_InsertFeeMappingDetails";
        SqlParameter sqlParameter1 = new SqlParameter("@FeeMappingDetailId", SqlDbType.Int, 50);
        sqlParameter1.Value = (object) FeeMappingDetailsDO.FeeMappingDetailId;
        sqlCommand.Parameters.Add(sqlParameter1);
        SqlParameter sqlParameter2 = new SqlParameter("@FeeMappingHeaderId", SqlDbType.Int, 50);
        sqlParameter2.Value = (object) FeeMappingDetailsDO.FeeMappingHeaderId;
        sqlCommand.Parameters.Add(sqlParameter2);
        SqlParameter sqlParameter3 = new SqlParameter("@FeeId", SqlDbType.Int, 50);
        sqlParameter3.Value = (object) FeeMappingDetailsDO.FeeId;
        sqlCommand.Parameters.Add(sqlParameter3);
        SqlParameter sqlParameter4 = new SqlParameter("@FeeAmount", SqlDbType.Int, 50);
        sqlParameter4.Value = (object) FeeMappingDetailsDO.FeeAmount;
        sqlCommand.Parameters.Add(sqlParameter4);
        SqlParameter sqlParameter5 = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
        sqlParameter5.Value = (object) FeeMappingDetailsDO.CreatedBy;
        sqlCommand.Parameters.Add(sqlParameter5);
        SqlParameter sqlParameter6 = new SqlParameter("@ModifiedBy", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) FeeMappingDetailsDO.ModifiedBy;
        sqlCommand.Parameters.Add(sqlParameter6);
        SqlParameter sqlParameter7 = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
        sqlParameter7.Direction = ParameterDirection.ReturnValue;
        sqlCommand.Parameters.Add(sqlParameter7);
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
        int num = (int) sqlCommand.Parameters["@RETURN_VALUE"].Value;
        sqlConnection.Close();
        return num;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int UpdateFeeMappingHeaderDetails(FeeMappingHeaderDO FeeMappingHeaderDO)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["KAVERI"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "usp_UpdateFeeMappingHeader";
        SqlParameter sqlParameter1 = new SqlParameter("@FeeMappingId", SqlDbType.Int, 50);
        sqlParameter1.Value = (object) FeeMappingHeaderDO.FeeMappingId;
        sqlCommand.Parameters.Add(sqlParameter1);
        SqlParameter sqlParameter2 = new SqlParameter("@MappingTemplateName", SqlDbType.VarChar, 50);
        sqlParameter2.Value = (object) FeeMappingHeaderDO.MappingTemplateName;
        sqlCommand.Parameters.Add(sqlParameter2);
        SqlParameter sqlParameter3 = new SqlParameter("@StandardId", SqlDbType.Int, 50);
        sqlParameter3.Value = (object) FeeMappingHeaderDO.StandardId;
        sqlCommand.Parameters.Add(sqlParameter3);
        SqlParameter sqlParameter4 = new SqlParameter("@IsActive", SqlDbType.VarChar, 50);
        sqlParameter4.Value = (object) (bool) (FeeMappingHeaderDO.IsActive ? true : false);
        sqlCommand.Parameters.Add(sqlParameter4);
        SqlParameter sqlParameter5 = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
        sqlParameter5.Value = (object) FeeMappingHeaderDO.CreatedBy;
        sqlCommand.Parameters.Add(sqlParameter5);
        SqlParameter sqlParameter6 = new SqlParameter("@ModifiedBy", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) FeeMappingHeaderDO.ModifiedBy;
        sqlCommand.Parameters.Add(sqlParameter6);
        SqlParameter sqlParameter7 = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
        sqlParameter7.Direction = ParameterDirection.ReturnValue;
        sqlCommand.Parameters.Add(sqlParameter7);
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
        int num = (int) sqlCommand.Parameters["@RETURN_VALUE"].Value;
        sqlConnection.Close();
        return num;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int DeleteFeeMappingDetailsByHeaderId(FeeMappingHeaderDO FeeMappingHeaderDO)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["KAVERI"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "usp_DeleteFeeMappingDetailsByHeaderId";
        SqlParameter sqlParameter1 = new SqlParameter("@FeeMappingHeaderId", SqlDbType.Int, 50);
        sqlParameter1.Value = (object) FeeMappingHeaderDO.FeeMappingId;
        sqlCommand.Parameters.Add(sqlParameter1);
        SqlParameter sqlParameter2 = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
        sqlParameter2.Direction = ParameterDirection.ReturnValue;
        sqlCommand.Parameters.Add(sqlParameter2);
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
        int num = (int) sqlCommand.Parameters["@RETURN_VALUE"].Value;
        sqlConnection.Close();
        return num;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetFeeMappingHeaderDetails(FeeMappingHeaderDO FeeMappingHeaderDO)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetFeeMappingHeaderDetails", CommandType.StoredProcedure, new SqlParameter[1]
        {
          new SqlParameter("@FeeMappingTemplate", (object) FeeMappingHeaderDO.MappingTemplateName.Trim().ToString())
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetFeeMappingHeaderDetailsByStandardId(FeeMappingHeaderDO FeeMappingHeaderDO)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetFeeMappingHeaderDetailsByStandard", CommandType.StoredProcedure, new SqlParameter[2]
        {
          new SqlParameter("@StandardId", (object) FeeMappingHeaderDO.StandardId),
          new SqlParameter("@FeeMode", (object) FeeMappingHeaderDO.FeeMode)
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetFeeMasterDetails(int HeaderId, int FeeMode)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetFeeMasterDetailsForMapping", CommandType.StoredProcedure, new SqlParameter[2]
        {
          new SqlParameter("@HeaderId", (object) HeaderId),
          new SqlParameter("@FeeMode", (object) FeeMode)
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetFeeMappingHeaderDetailsByTempNameAndStd(FeeMappingHeaderDO FeeMappingHeaderDO)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetFeeMappingHeaderByTempNameAndStd", CommandType.StoredProcedure, new SqlParameter[3]
        {
          new SqlParameter("@MappingTemplateName", (object) FeeMappingHeaderDO.MappingTemplateName.Trim().ToString()),
          new SqlParameter("@StandardId", (object) FeeMappingHeaderDO.StandardId.ToString()),
          new SqlParameter("@FeeMode", (object) FeeMappingHeaderDO.FeeMode.ToString())
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetFeeMappingDetailsByTempId(FeeMappingHeaderDO FeeMappingHeaderDO)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetFeeMappingDetails", CommandType.StoredProcedure, new SqlParameter[1]
        {
          new SqlParameter("@FeeMappingTemplateId", (object) FeeMappingHeaderDO.FeeMappingId.ToString())
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
