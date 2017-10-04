using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;
using System.Data;

namespace Store.PurchaseOrder.BusinessLogic
{
    public class PurchaseOrder
    {
        Store.PurchaseOrder.DataAccessLayer.PurchaseOrder odlPurchaseOrder = new DataAccessLayer.PurchaseOrder();
        public Store.PurchaseOrder.BusinessObject.PurchaseOrder GetAllPurchaseOrder(int PurchaseOrderID, int Flag, string FlagValue)
        {
            try
            {
                return odlPurchaseOrder.GetAllPurchaseOrder(PurchaseOrderID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(PurchaseOrder).FullName, 1);
                return null;
            }
        }
        public Store.PurchaseOrder.BusinessObject.PurchaseOrderList GetAllPurchaseOrderList(int PurchaseOrderID, int Flag, string FlagValue)
        {
            try
            {
                return odlPurchaseOrder.GetAllPurchaseOrderList(PurchaseOrderID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(PurchaseOrder).FullName, 1);
                return null;
            }
        }
        
        public Store.Common.MessageInfo ManagePurchaseOrder(Store.PurchaseOrder.BusinessObject.PurchaseOrder objPOrder, CommandMode cmdMode)
        {
            try
            {
                return odlPurchaseOrder.ManagePurchase(objPOrder, cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(PurchaseOrder).FullName, 1);
                return null;
            }
        }
        public DataTable RunQuery(string query)
        {
            try
            {
                return odlPurchaseOrder.runQuery(query);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(PurchaseOrder).FullName, 1);
                return null;
            }
        }

    }
}