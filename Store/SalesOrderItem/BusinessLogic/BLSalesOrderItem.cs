using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.SalesOrderItem.BusinessLogic
{
    public class SalesOrderItem
    {
        Store.SalesOrderItem.DataAccessLayer.SalesOrderItem odlSalesOrderItem = new DataAccessLayer.SalesOrderItem();
        public Store.SalesOrderItem.BusinessObject.SalesOrderItemList GetAllSalesOrderItemList(int SalesOrderItemId, int Flag, string FlagValue)
        {
            try
            {
                return odlSalesOrderItem.GetAllSalesOrderItemList(SalesOrderItemId, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesOrderItem).FullName, 1);
                return null;
            }
        }
        public Store.SalesOrderItem.BusinessObject.SalesOrderItem GetAllSalesOrderItem(int SalesOrderItemId, int Flag, string FlagValue)
        {
            try
            {
                return odlSalesOrderItem.GetAllSalesOrderItem(SalesOrderItemId, Flag, FlagValue);
            }
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesOrderItem).FullName, 1);
                return null;
            }
        }
      
        public Store.Common.MessageInfo ManageItemMaster(Store.SalesOrderItem.BusinessObject.SalesOrderItemList objSalesOrderItemList, CommandMode cmdMode)
        {
            try
            {
                return odlSalesOrderItem.ManageSalesOrderItem(objSalesOrderItemList, cmdMode);
            }
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesOrderItem).FullName, 1);
                return null;
            }
        }


    }
}