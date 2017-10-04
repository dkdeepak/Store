using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.Country.BusinessLogic
{
    public class Country
    {
        Store.Country.DataAccessLayer.Country odlCountry = new DataAccessLayer.Country();
        public Store.Country.BusinessObject.CountryList GetAllCountryList(int CountryID, int Flag, string FlagValue)
        {
            try
            {
                return odlCountry.GetAllCountryList(CountryID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
               Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Category).FullName, 1);
                return null;
            }
        }public Store.Country.BusinessObject.Country GetAllCountry(int CountryID, int Flag, string FlagValue)
        {
            try
            {
                return odlCountry.GetAllCountry(CountryID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Category).FullName, 1);
                return null;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.Country.BusinessObject.Country objCountry, CommandMode cmdMode)
        {
            try
            {
                return odlCountry.ManageCountry(objCountry, cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Category).FullName, 1);
                return null;
            }

        }
    }
}
