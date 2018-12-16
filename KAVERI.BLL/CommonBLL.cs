using System;
using System.Collections.Generic;
using System.Text;
using KAVERI.DO;
using KAVERI.DAL.Masters;
using KAVERI.DAL;
using System.Data;

namespace KAVERI.BLL
{
  public class CommonBLL
  {
    public CommonDAL _CommonDAL = new CommonDAL();

    public DataTable GetParameterDetails(string Catagory)
    {
      return this._CommonDAL.GetParameterDetails(Catagory);
    }

    public DataTable GetStandardDetails()
    {
      return this._CommonDAL.GetStandardDetails();
    }

    public int InsertNewYear(string ParameterName, int AcademicYearId)
    {
      this._CommonDAL.InsertAcademicYear(ParameterName, AcademicYearId);
      return this._CommonDAL.InsertNewYear(ParameterName, AcademicYearId);
    }

    public DataTable GetAcademicYear(string AcademicYear)
    {
      return this._CommonDAL.GetAcademicYear(AcademicYear);
    }

    public DataTable IsAcademicYear(string AcademicYear)
    {
      return this._CommonDAL.IsAcademicYear(AcademicYear);
    }
  }
}
