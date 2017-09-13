using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.Currency.BusinessLogic
{
    public class Currency
    {
        Store.Currency.DataAccessLayer.Currency odlCurrency = new DataAccessLayer.Currency();
        public Store.Currency.BusinessObject.CurrencyList GetAllCurrencyList(int CurrencyId, int Flag, string FlagValue)
        {
            try
            {
                return odlCurrency.GetAllCurrencyList(CurrencyId, Flag, FlagValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.Currency.BusinessObject.Currency GetAllCurrency(int CurrencyID, int Flag, string FlagValue)
        {
            try
            {
                return odlCurrency.GetAllCurrency(CurrencyID, Flag, FlagValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.Currency.BusinessObject.Currency objCurrency, CommandMode cmdMode)
        {
            try
            {
                return odlCurrency.ManageCurrency(objCurrency, cmdMode);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}