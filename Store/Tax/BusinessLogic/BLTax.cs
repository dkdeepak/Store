using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.Tax.BusinessLogic
{
    public class Tax
    {
        Store.Tax.DataAccessLayer.Tax odlTax = new DataAccessLayer.Tax();
        public Store.Tax.BusinessObject.TaxList GetAllTaxList(int TaxId, int Flag, string FlagValue)
        {
            try
            {
                return odlTax.GetAllTaxList(TaxId, Flag, FlagValue);
             }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Tax).FullName, 1);
                return null;
            }
        }
        public Store.Tax.BusinessObject.Tax GetAllTax(int TaxID, int Flag, string FlagValue)
        {
            try
            {
                return odlTax.GetAllTax(TaxID, Flag, FlagValue);
             }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Tax).FullName, 1);
                return null;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.Tax.BusinessObject.Tax objTax, CommandMode cmdMode)
        {
            try
            {
                return odlTax.ManageTax(objTax, cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Tax).FullName, 1);
                return null;
            }

        }
    }
}