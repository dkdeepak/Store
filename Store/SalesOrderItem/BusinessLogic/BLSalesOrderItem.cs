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
            catch 
            {
                throw;
            }
        }
        public Store.SalesOrderItem.BusinessObject.SalesOrderItem GetAllSalesOrderItem(int SalesOrderItemId, int Flag, string FlagValue)
        {
            try
            {
                return odlSalesOrderItem.GetAllSalesOrderItem(SalesOrderItemId, Flag, FlagValue);
            }
            catch
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.SalesOrderItem.BusinessObject.SalesOrderItem objSalesOrderItem, CommandMode cmdMode)
        {
            try
            {
                return odlSalesOrderItem.ManageSalesOrderItem(objSalesOrderItem, cmdMode);
            }
            catch
            {
                throw;            
            }
        }


    }
}