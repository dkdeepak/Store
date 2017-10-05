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
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(PurchaseReceivedItem).FullName, 1);
                return null;
            }
        }
        public Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItemList GetAllPurchaseReceivedItemList(int PurchaseReceivedItemID, int Flag, string FlagValue)
        {
            try
            {
                return odlPurchaseReceivedItem.GetAllPurchaseReceivedItemList(PurchaseReceivedItemID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(PurchaseReceivedItem).FullName, 1);
                return null;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItemList objPurchaseReceivedItemList, CommandMode cmdMode)
        {
            try
            {
                return odlPurchaseReceivedItem.ManagePurchaseReceived(objPurchaseReceivedItemList, cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(PurchaseReceivedItem).FullName, 1);
                return null;
            }
        }
        
    }
}