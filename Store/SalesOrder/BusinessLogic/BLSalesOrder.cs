﻿using System;
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
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesOrder).FullName, 1);
                return null;
            }
        }
        public Store.SalesOrder.BusinessObject.SalesOrder GetAllSalesOrder(int SalesOrderId, int Flag, string FlagValue)
        {
            try
            {
                return odlSalesOrder.GetAllSalesOrder(SalesOrderId, Flag, FlagValue);
            }
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesOrder).FullName, 1);
                return null;
            }
        }
        public Store.Common.MessageInfo ManageSaleOrder(Store.SalesOrder.BusinessObject.SalesOrder objSalesOrder, CommandMode cmdMode)
        {
            try
            {
                return odlSalesOrder.ManageSalesOrder(objSalesOrder,cmdMode);
            }
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesOrder).FullName, 1);
                return null;
            }
        }
        //public Store.Common.MessageInfo ManageSaleOrderItem(Store.SalesOrderItem.BusinessObject.SalesOrderItem objSalesOrderItem, int cmdMode)
        //{
        //    try
        //    {
        //        return odlSalesOrder.ManageSalesOrderItem(objSalesOrderItem, cmdMode);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


    }
}