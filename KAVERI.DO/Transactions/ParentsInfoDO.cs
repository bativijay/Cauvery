// Decompiled with JetBrains decompiler
// Type: KAVERI.DO.Transactions.ParentsInfoDO
// Assembly: KAVERI.DO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0126CF26-90EB-4002-B060-3AD325F4345D
// Assembly location: C:\inetpub\wwwroot\Cauvery\Cauvery\bin\KAVERI.DO.dll

using System;

namespace KAVERI.DO.Transactions
{
  public class ParentsInfoDO
  {
    public int ParentId { get; set; }

    public int RegistrationId { get; set; }

    public string FatherName { get; set; }

    public string FatherOccupation { get; set; }

    public string FatherQualification { get; set; }

    public string MotherName { get; set; }

    public string MotherOccupation { get; set; }

    public string MotherQualification { get; set; }

    public string PermanantAddress { get; set; }

    public string TemporaryAddress { get; set; }

    public string EmergencyAddress { get; set; }

    public string PermanantTelNo { get; set; }

    public string TemporaryTelNo { get; set; }

    public string EmergencyTelNo { get; set; }

    public string Relationship { get; set; }

    public string OtherInformation { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public int ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public string PermanantTelNoOff { get; set; }

    public string EmergencyTelNoOff { get; set; }

    public string TemporaryTelNoOff { get; set; }

    public string TemporaryMobNo { get; set; }

    public string PermanantMobNo { get; set; }
  }
}
