using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.TypeOfUser.BusinessLogic
{
    public class TypeOfUser
    {
        Store.TypeOfUser.DataAccessLayer.TypeOfUser odlTypeOfUser = new DataAccessLayer.TypeOfUser();
        public Store.TypeOfUser.BusinessObject.TypeOfUserList GetAllTypeOfUserList(int TypeofUserId, int Flag, string FlagValue)
        {
            try
            {
                return odlTypeOfUser.GetAllTypeOfUserList(TypeofUserId, Flag, FlagValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.TypeOfUser.BusinessObject.TypeOfUser GetAllTypeOfUser(int TypeofUserID, int Flag, string FlagValue)
        {
            try
            {
                return odlTypeOfUser.GetAllTypeOfUser(TypeofUserID, Flag, FlagValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.TypeOfUser.BusinessObject.TypeOfUser objTypeOfUser, CommandMode cmdMode)
        {
            try
            {
                return odlTypeOfUser.ManageTypeOfUser(objTypeOfUser, cmdMode);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}