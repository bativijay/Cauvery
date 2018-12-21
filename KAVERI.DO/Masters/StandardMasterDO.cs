using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace KAVERI.DO.Masters
{
  public class StandardMasterDO
  {
    public int StandardId { get; set; }

    public string StandardCode { get; set; }

    public string StandardName { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public int ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }
  }
}
