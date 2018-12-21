using System;
using System.Collections.Generic;
using System.Text;
using KAVERI.DO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using KAVERI.DO.Masters;
namespace KAVERI.DAL
{
  public class CommonDAL
  {
    public DataTable GetParameterDetails(string Catagory)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetParameterDetails", CommandType.StoredProcedure, new SqlParameter[1]
        {
          new SqlParameter("@Catagory", (object) Catagory.Trim().ToString())
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetStandardDetails()
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteSelectCommand("usp_GetStandard", CommandType.StoredProcedure);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int InsertNewYear(string ParameterName, int AcademicYearId)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQueryReturnInt("usp_InsertNewYear", CommandType.StoredProcedure, new SqlParameter[2]
        {
          new SqlParameter("@ParameterName", (object) ParameterName),
          new SqlParameter("@AcademicYearId", (object) AcademicYearId)
        }, true);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int InsertAcademicYear(string ParameterName, int AcademicYearId)
    {
      try
      {
        return SqlDBHelper.ExecuteNonQueryReturnInt("usp_InsertAcademicYear", CommandType.StoredProcedure, new SqlParameter[2]
        {
          new SqlParameter("@ParameterName", (object) ParameterName),
          new SqlParameter("@AcademicYearId", (object) AcademicYearId)
        }, true);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetAcademicYear(string AcademicYear)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_GetAcademicDetailsForYearEnd", CommandType.StoredProcedure, new SqlParameter[1]
        {
          new SqlParameter("@AcademicYear", (object) AcademicYear.Trim().ToString())
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable IsAcademicYear(string AcademicYear)
    {
      DataTable dataTable = new DataTable();
      try
      {
        return SqlDBHelper.ExecuteParamerizedSelectCommand("usp_IsAcademicDetailsForYearEnd", CommandType.StoredProcedure, new SqlParameter[1]
        {
          new SqlParameter("@AcademicYear", (object) AcademicYear.Trim().ToString())
        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
