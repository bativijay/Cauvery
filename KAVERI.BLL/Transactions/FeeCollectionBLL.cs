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
  public class FeeCollectionBLL
  {
    public FeeCollectionDAL _FeeCollectionDAL = new FeeCollectionDAL();

    public int InsertFeeCollection(FeeCollectionDO FeeCollectionDO)
    {
      try
      {
        int num1 = 0;
        int num2 = 0;
        if (FeeCollectionDO.FeeCollectionDetailsList[0].FeeCollectionId == 0)
        {
          num1 = this._FeeCollectionDAL.InsertCollectionHeader(FeeCollectionDO);
          if (FeeCollectionDO.PayType == "D" && num1 > 0)
          {
            foreach (FeeCollectionDetailsDO collectionDetailsDo in FeeCollectionDO.FeeCollectionDetailsList)
            {
              collectionDetailsDo.FeeCollectionId = num1;
              FeeCollectionDO.FeeCollectionDetailsDO = collectionDetailsDo;
              num2 = this._FeeCollectionDAL.InsertCollectionDetails(FeeCollectionDO);
            }
          }
        }
        else
        {
          FeeCollectionDO.FeeCollectionId = FeeCollectionDO.FeeCollectionDetailsList[0].FeeCollectionId;
          this._FeeCollectionDAL.UpdateCollectionHeader(FeeCollectionDO);
          foreach (FeeCollectionDetailsDO collectionDetailsDo in FeeCollectionDO.FeeCollectionDetailsList)
          {
            FeeCollectionDO.FeeCollectionDetailsDO = collectionDetailsDo;
            num2 = this._FeeCollectionDAL.InsertCollectionDetails(FeeCollectionDO);
            num1 = collectionDetailsDo.FeeCollectionId;
          }
        }
        return num1;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable CheckFeeCollectionDetails(FeeCollectionDO FeeCollectionDO)
    {
      return this._FeeCollectionDAL.CheckFeeCollectionDetails(FeeCollectionDO);
    }

    public DataTable GetFeeCollectionDetails(FeeCollectionDO FeeCollectionDO)
    {
      return this._FeeCollectionDAL.GetFeeCollectionDetails(FeeCollectionDO);
    }

    public DataTable GetCollectionDetails(FeeCollectionDO FeeCollectionDO)
    {
      return this._FeeCollectionDAL.GetCollectionDetails(FeeCollectionDO);
    }

    public DataTable GetRptFeeCollectionDetails(FeeCollectionDO FeeCollectionDO)
    {
      return this._FeeCollectionDAL.GetRptFeeCollectionDetails(FeeCollectionDO);
    }

    public DataTable GetRptPendingCollectionDetails(FeeCollectionDO FeeCollectionDO)
    {
      return this._FeeCollectionDAL.GetRptPendingCollectionDetails(FeeCollectionDO);
    }

    public DataTable GetRptRegistrationDetails(AdmissionReportDO AdmissionReport)
    {
      return this._FeeCollectionDAL.GetRptRegistrationDetails(AdmissionReport);
    }

    public DataTable GetReceiptDetails(int Type)
    {
      return this._FeeCollectionDAL.GetReceiptDetails(Type);
    }

    public int UpdateReceiptDetails(int Type)
    {
      return this._FeeCollectionDAL.UpdateReceiptDetails(Type);
    }

    public DataTable GetReportReceiptDetails(int RegistrationNo, string StudentName, string FatherName, int AcademicYear)
    {
      return this._FeeCollectionDAL.GetReportReceiptDetails(RegistrationNo,StudentName,FatherName,  AcademicYear);
    }

    public DataTable GetReportReceiptDetails(int RegistrationNo, string ReceiptNo)
    {
      return this._FeeCollectionDAL.GetReportReceiptDetails(RegistrationNo, ReceiptNo);
    }
  }
}
