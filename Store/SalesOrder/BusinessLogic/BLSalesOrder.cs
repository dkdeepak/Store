using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.SalesOrder.BusinessLogic
{
    public class SalesOrder
    {
        Store.SalesOrder.DataAccessLayer.SalesOrder odlSalesOrder = new DataAccessLayer.SalesOrder();
        public Store.SalesOrder.BusinessObject.SalesOrderList GetAllSalesOrderList(int SalesOrderId, int Flag, string FlagValue)
        {
            try
            {
                return odlSalesOrder.GetAllSalesOrderList(SalesOrderId, Flag, FlagValue);
            }
            catch 
            {
                throw;
            }
        }
        public Store.SalesOrder.BusinessObject.SalesOrder GetAllSalesOrder(int SalesOrderId, int Flag, string FlagValue)
        {
            try
            {
                return odlSalesOrder.GetAllSalesOrder(SalesOrderId, Flag, FlagValue);
            }
            catch
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManageSaleOrder(Store.SalesOrder.BusinessObject.SalesOrder objSalesOrder, int cmdMode)
        {
            try
            {
                return odlSalesOrder.ManageSalesOrder(objSalesOrder, cmdMode);
            }
            catch
            {
                throw;            
            }
        }
        public Store.Common.MessageInfo ManageSaleOrderItem(Store.SalesOrderItem.BusinessObject.SalesOrderItem objSalesOrderItem, int cmdMode)
        {
            try
            {
                return odlSalesOrder.ManageSalesOrderITem(objSalesOrderItem, cmdMode);
            }
            catch
            {
                throw;
            }
        }


    }
}