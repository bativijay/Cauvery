using System;
using System.Collections.Generic;
using System.Text;
using KAVERI.DO;
using KAVERI.DAL.Masters;
using KAVERI.DO.Masters;
using KAVERI.DAL;
using System.Data;

namespace KAVERI.BLL
{
  public class StandardMasterBLL
  {
    public StandardMasterDAL _StandardMasterDAL = new StandardMasterDAL();

    public int InsertStandardMasterDetails(StandardMasterDO StandardMasterDO)
    {
      return this._StandardMasterDAL.InsertStandardMasterDetails(StandardMasterDO);
    }

    public DataTable GetStandardType()
    {
      return this._StandardMasterDAL.GetStandardType();
    }

    public DataTable GetStandardMasterDetails(StandardMasterDO StandardMasterDO)
    {
      return this._StandardMasterDAL.GetStandardMasterDetails(StandardMasterDO);
    }

    public DataTable GetActiveStandardMasterDetails(StandardMasterDO StandardMasterDO)
    {
      try
      {
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = new DataTable();
        DataTable standardMasterDetails = this._StandardMasterDAL.GetStandardMasterDetails(StandardMasterDO);
        DataTable dataTable3 = standardMasterDetails.Clone();
        foreach (DataRow row in standardMasterDetails.Select("IsActive = 1"))
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
