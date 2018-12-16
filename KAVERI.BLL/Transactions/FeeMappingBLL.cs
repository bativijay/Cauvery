using System;
using System.Collections.Generic;
using System.Text;
using KAVERI.DO.Transactions;
using KAVERI.DO;
using KAVERI.DAL.Masters;
using KAVERI.DAL;
using KAVERI.DAL.Transactions;
using System.Data;

namespace KAVERI.BLL.Transactions
{
  public class FeeMappingBLL
  {
    public FeeMappingDAL _FeeMappingDAL = new FeeMappingDAL();

    public int InsertFeeMappingHeaderDetails(FeeMappingHeaderDO FeeMappingHeaderDO)
    {
      try
      {
        int num1 = 0;
        int num2;
        if (FeeMappingHeaderDO.FeeMappingId > 0)
        {
          this._FeeMappingDAL.DeleteFeeMappingDetailsByHeaderId(FeeMappingHeaderDO);
          num2 = this._FeeMappingDAL.UpdateFeeMappingHeaderDetails(FeeMappingHeaderDO);
        }
        else
          num2 = this._FeeMappingDAL.InsertFeeMappingHeaderDetails(FeeMappingHeaderDO);
        if (num2 > 0)
        {
          foreach (FeeMappingDetailsDO FeeMappingDetailsDO in FeeMappingHeaderDO.FeeMappingDetailsList)
          {
            FeeMappingDetailsDO.FeeMappingHeaderId = num2;
            num1 = this._FeeMappingDAL.InsertFeeMappingDetails(FeeMappingDetailsDO);
          }
        }
        return num1;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable GetFeeMappingHeaderDetails(FeeMappingHeaderDO FeeMappingHeaderDO)
    {
      return this._FeeMappingDAL.GetFeeMappingHeaderDetails(FeeMappingHeaderDO);
    }

    public DataTable GetFeeMappingHeaderDetailsByStandardId(FeeMappingHeaderDO FeeMappingHeaderDO)
    {
      return this._FeeMappingDAL.GetFeeMappingHeaderDetailsByStandardId(FeeMappingHeaderDO);
    }

    public DataTable GetFeeMappingHeaderDetailsByTempNameAndStd(FeeMappingHeaderDO FeeMappingHeaderDO)
    {
      return this._FeeMappingDAL.GetFeeMappingHeaderDetailsByTempNameAndStd(FeeMappingHeaderDO);
    }

    public DataTable GetFeeMasterDetails(int HeaderId, int FeeMode)
    {
      return this._FeeMappingDAL.GetFeeMasterDetails(HeaderId, FeeMode);
    }

    public DataTable GetFeeMappingDetailsByTempId(FeeMappingHeaderDO FeeMappingHeaderDO)
    {
      return this._FeeMappingDAL.GetFeeMappingDetailsByTempId(FeeMappingHeaderDO);
    }
  }
}
