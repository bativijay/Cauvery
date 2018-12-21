using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace KAVERI.DAL
{
  public class SqlDBHelper
  {
    private static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["KAVERI"].ConnectionString;

    internal static DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
    {
      DataTable dataTable = (DataTable) null;
      using (SqlConnection sqlConnection = new SqlConnection(SqlDBHelper.CONNECTION_STRING))
      {
        using (SqlCommand command = sqlConnection.CreateCommand())
        {
          command.CommandType = cmdType;
          command.CommandText = CommandName;
          try
          {
            if (sqlConnection.State != ConnectionState.Open)
              sqlConnection.Open();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command))
            {
              dataTable = new DataTable();
              sqlDataAdapter.Fill(dataTable);
            }
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }
      }
      return dataTable;
    }

    internal static DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, SqlParameter[] param)
    {
      DataTable dataTable = new DataTable();
      using (SqlConnection sqlConnection = new SqlConnection(SqlDBHelper.CONNECTION_STRING))
      {
        using (SqlCommand command = sqlConnection.CreateCommand())
        {
          command.CommandType = cmdType;
          command.CommandText = CommandName;
          command.Parameters.AddRange(param);
          try
          {
            if (sqlConnection.State != ConnectionState.Open)
              sqlConnection.Open();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command))
              sqlDataAdapter.Fill(dataTable);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }
      }
      return dataTable;
    }

    internal static bool ExecuteNonQuery(string CommandName, CommandType cmdType, SqlParameter[] pars)
    {
      int num = 0;
      using (SqlConnection sqlConnection = new SqlConnection(SqlDBHelper.CONNECTION_STRING))
      {
        using (SqlCommand command = sqlConnection.CreateCommand())
        {
          command.CommandType = cmdType;
          command.CommandText = CommandName;
          command.Parameters.AddRange(pars);
          try
          {
            if (sqlConnection.State != ConnectionState.Open)
              sqlConnection.Open();
            num = command.ExecuteNonQuery();
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }
      }
      return num > 0;
    }

    internal static int ExecuteNonQueryReturnInt(string CommandName, CommandType cmdType, SqlParameter[] pars, bool ReturnValueRequired)
    {
      int num = 0;
      using (SqlConnection sqlConnection = new SqlConnection(SqlDBHelper.CONNECTION_STRING))
      {
        using (SqlCommand command = sqlConnection.CreateCommand())
        {
          command.CommandType = cmdType;
          command.CommandText = CommandName;
          command.Parameters.AddRange(pars);
          if (ReturnValueRequired)
          {
            SqlParameter sqlParameter = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(sqlParameter);
          }
          try
          {
            if (sqlConnection.State != ConnectionState.Open)
              sqlConnection.Open();
            command.ExecuteNonQuery();
            num = (int) command.Parameters["@RETURN_VALUE"].Value;
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }
      }
      return num;
    }
  }
}
