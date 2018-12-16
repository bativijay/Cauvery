using System;
using System.Collections.Generic;
using System.Text;
using KAVERI.DO;
using KAVERI.DO.Masters;
using KAVERI.DAL.Masters;
using KAVERI.DAL;
using System.Data;

namespace KAVERI.BLL
{
  public class CastMasterBLL
  {
    public CastMasterDAL _CastMasterDAL = new CastMasterDAL();

    public int InsertCastMasterDetails(CastMasterDO CastMasterDO)
    {
      return this._CastMasterDAL.InsertCastMasterDetails(CastMasterDO);
    }

    public DataTable GetCastType()
    {
      return this._CastMasterDAL.GetCastType();
    }

    public DataTable GetCastMasterDetails(CastMasterDO CastMasterDO)
    {
      return this._CastMasterDAL.GetCastMasterDetails(CastMasterDO);
    }

    public DataTable GetActiveCastMasterDetails(CastMasterDO CastMasterDO)
    {
      try
      {
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = new DataTable();
        DataTable castMasterDetails = this._CastMasterDAL.GetCastMasterDetails(CastMasterDO);
        DataTable dataTable3 = castMasterDetails.Clone();
        foreach (DataRow row in castMasterDetails.Select("IsActive = 1"))
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
