using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KAVERI.DO.Transactions
{
  public class FeeCollectionDO
  {
    public int FeeCollectionId { get; set; }

    public int StandardId { get; set; }

    public int TemplateId { get; set; }

    public int RegistrationId { get; set; }

    public int AcademicYearId { get; set; }

    public double TotalFeeAmount { get; set; }

    public double TotalPendingAmount { get; set; }

    public double TotalAmountPaid { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public int ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public int PaymentMode { get; set; }

    public string PayType { get; set; }

    public string FromDate { get; set; }

    public string ToDate { get; set; }

    public string ReceiptNo { get; set; }

    public string ChequeNo { get; set; }

    public string ChequeDate { get; set; }

    public string ChequeBank { get; set; }

    public FeeCollectionDetailsDO FeeCollectionDetailsDO { get; set; }

    public List<FeeCollectionDetailsDO> FeeCollectionDetailsList { get; set; }
  }
}
