// Decompiled with JetBrains decompiler
// Type: KAVERI.DAL.UserInfoDAL
// Assembly: KAVERI.DAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F8FBF119-0E31-4DCD-929B-D288DECA59B6
// Assembly location: C:\inetpub\wwwroot\Cauvery\Cauvery\bin\KAVERI.DAL.dll

using KAVERI.DO;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KAVERI.DAL
{
  public class UserInfoDAL
  {
    public int AuthenticateUser(UserInfoDO User)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["KAVERI"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "usp_ValidateLogin";
        SqlParameter sqlParameter1 = new SqlParameter("@Username", SqlDbType.VarChar, 50);
        sqlParameter1.Value = (object) User.UserName.Trim().ToString();
        sqlCommand.Parameters.Add(sqlParameter1);
        SqlParameter sqlParameter2 = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        sqlParameter2.Value = (object) User.Password.Trim().ToString();
        sqlCommand.Parameters.Add(sqlParameter2);
        sqlConnection.Open();
        int num = (int) sqlCommand.ExecuteScalar();
        sqlConnection.Close();
        return num;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetLoginDetails(UserInfoDO User)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetLoginDetails", CommandType.StoredProcedure, new SqlParameter[1]
        {
          new SqlParameter("@Username", (object) User.UserName.Trim().ToString())
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetMenu(string MenuType, string MenuCatagory)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetMenuDetails", CommandType.StoredProcedure, new SqlParameter[2]
        {
          new SqlParameter("@MenuType", (object) MenuType.Trim().ToString()),
          new SqlParameter("@MenuCatagory", (object) MenuCatagory.Trim().ToString())
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int InsertUserDetails(UserInfoDO UserInfoDO)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQuery("usp_InsertUser", CommandType.StoredProcedure, new SqlParameter[12]
        {
          new SqlParameter("@Id", (object) UserInfoDO.UserInfoId),
          new SqlParameter("@LastName", (object) UserInfoDO.LastName),
          new SqlParameter("@FirstName", (object) UserInfoDO.FirstName),
          new SqlParameter("@UserName", (object) UserInfoDO.UserName),
          new SqlParameter("@Password", (object) UserInfoDO.Password),
          new SqlParameter("@Email", (object) UserInfoDO.Email),
          new SqlParameter("@Address", (object) UserInfoDO.Address),
          new SqlParameter("@Gender", (object) UserInfoDO.Gender),
          new SqlParameter("@RoleName", (object) UserInfoDO.RoleName),
          new SqlParameter("@IsActive", (object) (bool) (UserInfoDO.IsActive ? true : false)),
          new SqlParameter("@CreatedBy", (object) UserInfoDO.CreatedBy),
          new SqlParameter("@ModifiedBy", (object) UserInfoDO.ModifiedBy)
        }) ? 1 : 0;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int ChangeUserPassword(UserInfoDO UserInfoDO)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQuery("usp_ChangeUserPassword", CommandType.StoredProcedure, new SqlParameter[3]
        {
          new SqlParameter("@UserName", (object) UserInfoDO.UserName),
          new SqlParameter("@Password", (object) UserInfoDO.Password),
          new SqlParameter("@ModifiedBy", (object) UserInfoDO.ModifiedBy)
        }) ? 1 : 0;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
