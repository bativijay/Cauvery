// Decompiled with JetBrains decompiler
// Type: KAVERI.DO.Transactions.CandidateInfoDO
// Assembly: KAVERI.DO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0126CF26-90EB-4002-B060-3AD325F4345D
// Assembly location: C:\inetpub\wwwroot\Cauvery\Cauvery\bin\KAVERI.DO.dll

using System;

namespace KAVERI.DO.Transactions
{
  public class CandidateInfoDO
  {
    public int RegistrationId { get; set; }

    public int AcademicYear { get; set; }

    public int CurrentAcademicYear { get; set; }

    public string StudentName { get; set; }

    public int Nationality { get; set; }

    public int Sex { get; set; }

    public DateTime DOB { get; set; }

    public int MotherTongue { get; set; }

    public int Religion { get; set; }

    public int Caste { get; set; }

    public int Catagory { get; set; }

    public string SchoolAddress { get; set; }

    public string Photo { get; set; }

    public int StandardStudying { get; set; }

    public int StandardSought { get; set; }

    public int FirstLanguage { get; set; }

    public int SecondLanguage { get; set; }

    public int ThirdLanguage { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public int ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public ParentsInfoDO ParentsInfoDO { get; set; }

    public OfficeUseDO OfficeUseDO { get; set; }

    public int Status { get; set; }

    public int AdmissionNo { get; set; }

    public string PreviousTCIssuedDate { get; set; }

    public string JoiningAcademicYear { get; set; }

    public StandardAllocationDO StandardAllocationDO { get; set; }

    public int FeeTemplateId { get; set; }

    public string FatherName { get; set; }
  }
}
