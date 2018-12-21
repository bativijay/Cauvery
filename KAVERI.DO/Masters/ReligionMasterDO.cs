using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace KAVERI.DO.Masters
{
  public class ReligionMasterDO
  {
    public int ReligionId { get; set; }

    public string ReligionCode { get; set; }

    public string ReligionName { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public int ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }
  }
}
