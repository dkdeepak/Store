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
            catch (Exception)
            {
                throw;
            }
        }
        public Store.PurchaseOrder.BusinessObject.PurchaseOrderList GetAllPurchaseOrderList(int PurchaseOrderID, int Flag, string FlagValue)
        {
            try
            {
                return odlPurchaseOrder.GetAllPurchaseOrderList(PurchaseOrderID, Flag, FlagValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public Store.Common.MessageInfo ManagePurchaseOrder(Store.PurchaseOrder.BusinessObject.PurchaseOrder objPOrder, CommandMode cmdMode)
        {
            try
            {
                return odlPurchaseOrder.ManagePurchase(objPOrder, cmdMode);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable RunQuery(string query)
        {
            try
            {
                return odlPurchaseOrder.runQuery(query);
            }
            catch { throw; }
        }

    }
}