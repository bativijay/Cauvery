// Decompiled with JetBrains decompiler
// Type: KAVERI.BLL.Transactions.RefundBLL
// Assembly: KAVERI.BLL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E27F0570-FB29-4C6D-B871-0053DF6E809F
// Assembly location: C:\inetpub\wwwroot\Cauvery\Cauvery\bin\KAVERI.BLL.dll

using KAVERI.DAL.Transactions;
using KAVERI.DO.Transactions;
using System;

namespace KAVERI.BLL.Transactions
{
  public class RefundBLL
  {
    public RefundDAL _RefundDAL = new RefundDAL();

    public int InsertRefund(RefundDO RefundDO)
    {
      try
      {
        return this._RefundDAL.InsertRefund(RefundDO);
      }
      catch (Exception ex)
      {
          throw ex;
      }
    }
  }
}
