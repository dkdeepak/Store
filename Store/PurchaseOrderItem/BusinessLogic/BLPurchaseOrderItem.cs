﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.PurchaseOrderItem.BusinessLogic
{
    public class PurchaseOrderItem
    {
        Store.PurchaseOrderItem.DataAccessLayer.PurchaseOrderItem odlPurchaseOrderItem = new DataAccessLayer.PurchaseOrderItem();
        public Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem GetAllPurchaseOrderItemItem(int PurchaseOrderItemID, int Flag, string FlagValue)
        {
            try
            {
                return odlPurchaseOrderItem.GetAllPurchaseOrderItem(PurchaseOrderItemID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList GetAllPurchaseOrderItemList(int PurchaseOrderItemID, int Flag, string FlagValue)
        {
            try
            {
                return odlPurchaseOrderItem.GetAllPurchaseOrderItemList(PurchaseOrderItemID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList objPurchaseOrderItemList, CommandMode cmdMode)
        {
            try
            {
                return odlPurchaseOrderItem.ManagePurchaseOrder(objPurchaseOrderItemList, cmdMode);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}