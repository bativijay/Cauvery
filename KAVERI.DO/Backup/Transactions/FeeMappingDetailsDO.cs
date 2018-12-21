// Decompiled with JetBrains decompiler
// Type: KAVERI.DO.Transactions.FeeMappingDetailsDO
// Assembly: KAVERI.DO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0126CF26-90EB-4002-B060-3AD325F4345D
// Assembly location: C:\inetpub\wwwroot\Cauvery\Cauvery\bin\KAVERI.DO.dll

using System;

namespace KAVERI.DO.Transactions
{
  public class FeeMappingDetailsDO
  {
    public int FeeMappingDetailId { get; set; }

    public int FeeMappingHeaderId { get; set; }

    public int FeeId { get; set; }

    public double FeeAmount { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public int ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }
  }
}
