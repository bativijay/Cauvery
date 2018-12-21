using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KAVERI.DO
{
  public class UserInfoDO
  {
    public int UserInfoId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }

    public int Gender { get; set; }

    public string RoleName { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public int ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }
  }
}
