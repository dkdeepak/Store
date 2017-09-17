using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.PurchaseReceivedItem.BusinessLogic
{
    public class PurchaseReceivedItem
    {
        Store.PurchaseReceivedItem.DataAccessLayer.PurchaseReceivedItem odlPurchaseReceivedItem = new DataAccessLayer.PurchaseReceivedItem();
        public Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem GetAllPurchaseReceivedItem(int PurchaseReceivedItemID, int Flag, string FlagValue)
        {
            try
            {
                return odlPurchaseReceivedItem.GetAllPurchaseReceivedItem(PurchaseReceivedItemID, Flag, FlagValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItemList GetAllPurchaseReceivedItemList(int PurchaseReceivedItemID, int Flag, string FlagValue)
        {
            try
            {
                return odlPurchaseReceivedItem.GetAllPurchaseReceivedItemList(PurchaseReceivedItemID, Flag, FlagValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItemList objPurchaseReceivedItemList, CommandMode cmdMode)
        {
            try
            {
                return odlPurchaseReceivedItem.ManagePurchaseReceived(objPurchaseReceivedItemList, cmdMode);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}