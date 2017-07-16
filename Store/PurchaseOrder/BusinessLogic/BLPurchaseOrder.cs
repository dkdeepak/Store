﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

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
        public Store.Common.MessageInfo ManagePurchaseOrderMaster(Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem objPurchaseOrderItem, int cmdMode)
        {
            try
            {
                return odlPurchaseOrder.ManagePurchaseOrder(objPurchaseOrderItem, cmdMode);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManagePurchaseOrder(Store.PurchaseOrder.BusinessObject.PurchaseOrder objPOrder, int cmdMode)
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

    }
}