// Decompiled with JetBrains decompiler
// Type: KAVERI.DO.Transactions.OfficeUseDO
// Assembly: KAVERI.DO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0126CF26-90EB-4002-B060-3AD325F4345D
// Assembly location: C:\inetpub\wwwroot\Cauvery\Cauvery\bin\KAVERI.DO.dll

using System;

namespace KAVERI.DO.Transactions
{
  public class OfficeUseDO
  {
    public int OfficeUseId { get; set; }

    public int RegistrationId { get; set; }

    public DateTime ApplicationReceivedOn { get; set; }

    public string ReceiptNoAndDate { get; set; }

    public string TCNoIssuedDate { get; set; }

    public string Remarks { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public int ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }
  }
}
