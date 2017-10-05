﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.SalesReturned.BusinessLogic
{
    public class SalesReturned
    {
        Store.SalesReturned.DataAccessLayer.SalesReturned odlSalesReturned = new DataAccessLayer.SalesReturned();
        public Store.SalesReturned.BusinessObject.SalesReturned GetAllSalesReturned(int SalesReturnedID, int Flag, string FlagValue)
        {
            try
            {
                return odlSalesReturned.GetAllSalesReturned(SalesReturnedID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesReturned).FullName, 1);
                return null;
            }
        }
        public Store.SalesReturned.BusinessObject.SalesReturnedList GetAllSalesReturnedList(int SalesReturnedID, int Flag, string FlagValue)
        {
            try
            {
                return odlSalesReturned.GetAllSalesReturnedList(SalesReturnedID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesReturned).FullName, 1);
                return null;
            }
        }
        public Store.Common.MessageInfo ManageSalesRetunedItem(Store.SaleReturnItem.BusinessObject.SaleReturnItem objSaleReturnItem, int cmdMode)
        {
            try
            {
                return odlSalesReturned.ManageSaleRetunedItem(objSaleReturnItem, cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesReturned).FullName, 1);
                return null;
            }
        }
        public Store.Common.MessageInfo ManageSalesRetuned(Store.SalesReturned.BusinessObject.SalesReturned objSalesReturned, CommandMode cmdMode)
        {
            try
            {
                return odlSalesReturned.ManageSaleRetuned(objSalesReturned, cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesReturned).FullName, 1);
                return null;
            }
        }
    }
}