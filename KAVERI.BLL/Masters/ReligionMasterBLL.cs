using System;
using System.Collections.Generic;
using System.Text;
using KAVERI.DO;
using KAVERI.DAL.Masters;
using KAVERI.DAL;
using System.Data;
using KAVERI.DO.Masters;

namespace KAVERI.BLL
{
  public class ReligionMasterBLL
  {
    public ReligionMasterDAL _ReligionMasterDAL = new ReligionMasterDAL();

    public int InsertReligionMasterDetails(ReligionMasterDO ReligionMasterDO)
    {
      return this._ReligionMasterDAL.InsertReligionMasterDetails(ReligionMasterDO);
    }

    public DataTable GetReligionType()
    {
      return this._ReligionMasterDAL.GetReligionType();
    }

    public DataTable GetReligionMasterDetails(ReligionMasterDO ReligionMasterDO)
    {
      return this._ReligionMasterDAL.GetReligionMasterDetails(ReligionMasterDO);
    }

    public DataTable GetActiveReligionMasterDetails(ReligionMasterDO ReligionMasterDO)
    {
      try
      {
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = new DataTable();
        DataTable religionMasterDetails = this._ReligionMasterDAL.GetReligionMasterDetails(ReligionMasterDO);
        DataTable dataTable3 = religionMasterDetails.Clone();
        foreach (DataRow row in religionMasterDetails.Select("IsActive = 1"))
          dataTable3.ImportRow(row);
        return dataTable3;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
