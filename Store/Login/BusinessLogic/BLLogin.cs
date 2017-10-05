using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.Login.BusinessLogic
{
    public class Login
    {
        Store.Login.DataAccessLayer.Login odlLogin = new DataAccessLayer.Login();
        public Store.Login.BusinessObject.LoginList GetAllLoginList(int LoginId, int Flag, string FlagValue)
        {
            try
            {
                return odlLogin.GetAllLoginList(LoginId, Flag, FlagValue);
            }
            catch(Exception ex) 
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Login).FullName, 1);
                return null;
            }
        }
        public Store.Login.BusinessObject.Login GetAllLogin(int LoginId, int Flag, string FlagValue)
        {
            try
            {
                return odlLogin.GetAllLogin(LoginId, Flag, FlagValue);
            }
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Login).FullName, 1);
                return null;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.Login.BusinessObject.Login objLogin, CommandMode cmdMode)
        {
            try
            {
                return odlLogin.ManageLogin(objLogin, cmdMode);
            }
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Login).FullName, 1);
                return null;
            }
        }


    }
}