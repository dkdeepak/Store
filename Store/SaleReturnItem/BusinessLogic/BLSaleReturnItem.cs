using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.SaleReturnItem.BusinessLogic
{
    public class SaleReturnItem
    {
        Store.SaleReturnItem.DataAccessLayer.SaleReturnItem odlSaleReturnItem = new DataAccessLayer.SaleReturnItem();
        public Store.SaleReturnItem.BusinessObject.SaleReturnItemList GetAllSaleReturnItemList(int SaleReturnItemId, int Flag, string FlagValue)
        {
            try
            {
                return odlSaleReturnItem.GetAllSaleReturnItemList(SaleReturnItemId, Flag, FlagValue);
            }
            catch(Exception ex) 
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SaleReturnItem).FullName, 1);
                return null; 
            }
        }
        public Store.SaleReturnItem.BusinessObject.SaleReturnItem GetAllSaleReturnItem(int SaleReturnItemId, int Flag, string FlagValue)
        {
            try
            {
                return odlSaleReturnItem.GetAllSaleReturnItem(SaleReturnItemId, Flag, FlagValue);
            }
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SaleReturnItem).FullName, 1);
                return null;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.SaleReturnItem.BusinessObject.SaleReturnItem objSaleReturnItem, CommandMode cmdMode)
        {
            try
            {
                return odlSaleReturnItem.ManageSaleReturnItem(objSaleReturnItem, cmdMode);
            }
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SaleReturnItem).FullName, 1);
                return null;
            }
        }


    }
}