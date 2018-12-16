using System;
using System.Collections.Generic;
using System.Text;
using KAVERI.DO;
using KAVERI.DAL.Masters;
using KAVERI.DAL;
using System.Data;

namespace KAVERI.BLL
{
  public class DivisionMasterBLL
  {
    public DivisionMasterDAL _DivisionMasterDAL = new DivisionMasterDAL();

    public int InsertDivisionMasterDetails(DivisionMasterDO DivisionMasterDO)
    {
      return this._DivisionMasterDAL.InsertDivisionMasterDetails(DivisionMasterDO);
    }

    public DataTable GetDivisionType()
    {
      return this._DivisionMasterDAL.GetDivisionType();
    }

    public DataTable GetDivisionMasterDetails(DivisionMasterDO DivisionMasterDO)
    {
      return this._DivisionMasterDAL.GetDivisionMasterDetails(DivisionMasterDO);
    }
  }
}
