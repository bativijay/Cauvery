using System;
using System.Collections.Generic;
using System.Text;
using KAVERI.DO;
using KAVERI.DAL.Masters;
using KAVERI.DAL;
using System.Data;

namespace KAVERI.BLL
{
  public class FeeMasterBLL
  {
    public FeeMasterDAL _FeeMasterDAL = new FeeMasterDAL();

    public int InsertFeeMasterDetails(FeeMasterDO FeeMasterDO)
    {
      return this._FeeMasterDAL.InsertFeeMasterDetails(FeeMasterDO);
    }

    public DataTable GetFeeType()
    {
      return this._FeeMasterDAL.GetFeeType();
    }

    public DataTable GetFeeMasterDetails(FeeMasterDO FeeMasterDO)
    {
      return this._FeeMasterDAL.GetFeeMasterDetails(FeeMasterDO);
    }
  }
}
