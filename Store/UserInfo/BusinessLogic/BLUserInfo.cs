using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.UserInfo.BusinessLogic
{
    public class UserInfo
    {
        Store.UserInfo.DataAccessLayer.UserInfo odlUserInfo = new DataAccessLayer.UserInfo();
        public Store.UserInfo.BusinessObject.UserInfoList GetAllUserInfoList(int UserInfoId, int Flag, string FlagValue)
        {
            try
            {
                return odlUserInfo.GetAllUserInfoList(UserInfoId, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(UserInfo).FullName, 1);
                return null;
            }
        }
        public Store.UserInfo.BusinessObject.UserInfo GetAllUserInfo(int UserInfoId, int Flag, string FlagValue)
        {
            try
            {
                return odlUserInfo.GetAllUserInfo(UserInfoId, Flag, FlagValue);
            }
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(UserInfo).FullName, 1);
                return null;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.UserInfo.BusinessObject.UserInfo objUserInfo, CommandMode cmdMode)
        {
            try
            {
                return odlUserInfo.ManageUserInfo(objUserInfo, cmdMode);
            }
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(UserInfo).FullName, 1);
                return null;
            }
        }


    }
}