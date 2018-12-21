// Decompiled with JetBrains decompiler
// Type: KAVERI.DO.FeeMasterDO
// Assembly: KAVERI.DO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0126CF26-90EB-4002-B060-3AD325F4345D
// Assembly location: C:\inetpub\wwwroot\Cauvery\Cauvery\bin\KAVERI.DO.dll

using System;

namespace KAVERI.DO
{
  public class FeeMasterDO
  {
    public int FeeId { get; set; }

    public string FeeCode { get; set; }

    public string FeeName { get; set; }

    public int FeeType { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public int ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public int FeeMode { get; set; }
  }
}
