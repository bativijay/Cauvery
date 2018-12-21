// Decompiled with JetBrains decompiler
// Type: KAVERI.DO.Transactions.FeeMappingHeaderDO
// Assembly: KAVERI.DO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0126CF26-90EB-4002-B060-3AD325F4345D
// Assembly location: C:\inetpub\wwwroot\Cauvery\Cauvery\bin\KAVERI.DO.dll

using System;
using System.Collections.Generic;

namespace KAVERI.DO.Transactions
{
  public class FeeMappingHeaderDO
  {
    public int FeeMappingId { get; set; }

    public string MappingTemplateName { get; set; }

    public int StandardId { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public int ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public FeeMappingDetailsDO FeeMappingDetailsDO { get; set; }

    public List<FeeMappingDetailsDO> FeeMappingDetailsList { get; set; }

    public int FeeMode { get; set; }

    public int ReportFormatId { get; set; }
  }
}
