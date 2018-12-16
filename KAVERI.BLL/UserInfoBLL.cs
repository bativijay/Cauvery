using System;
using System.Collections.Generic;
using System.Text;
using KAVERI.DO;
using KAVERI.DAL;
using System.Data;
namespace KAVERI.BLL
{
  public class UserInfoBLL
  {
    public UserInfoDAL _UserInfoDAL = new UserInfoDAL();

    public int AuthenticateUser(UserInfoDO User)
    {
      return this._UserInfoDAL.AuthenticateUser(User);
    }

    public DataTable GetLoginDetails(UserInfoDO User)
    {
      return this._UserInfoDAL.GetLoginDetails(User);
    }

    public DataTable GetMenu(string MenuType, string MenuCatagory)
    {
      return this._UserInfoDAL.GetMenu(MenuType, MenuCatagory);
    }

    public int InsertUserDetails(UserInfoDO UserInfoDO)
    {
      return this._UserInfoDAL.InsertUserDetails(UserInfoDO);
    }

    public int ChangeUserPassword(UserInfoDO UserInfoDO)
    {
      return this._UserInfoDAL.ChangeUserPassword(UserInfoDO);
    }
  }
}
