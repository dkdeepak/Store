using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;
namespace Store.PurchaseReceived.BusinessLogic
{
    public class PurchaseReceived
    { 
        Store.PurchaseReceived.DataAccessLayer.PurchaseReceived odlPurchaseReceived = new DataAccessLayer.PurchaseReceived();
        public Store.PurchaseReceived.BusinessObject.PurchaseReceived GetAllPurchaseReceived(int PurchaseReceivedID, int Flag, string FlagValue)
        {
            try
            {
                return odlPurchaseReceived.GetAllPurchaseReceived(PurchaseReceivedID, Flag, FlagValue); 
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.PurchaseReceived.BusinessObject.PurchaseReceivedList GetAllPurchaseReceivedList(int PurchaseReceivedID, int Flag, string FlagValue)
        {
            try 
            {
                return odlPurchaseReceived.GetAllPurchaseReceivedList(PurchaseReceivedID, Flag, FlagValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManagePurchaseReceivedItem(Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem objPurchaseReceivedItem, int cmdMode)
        {
            try
            {
                return odlPurchaseReceived.ManagePurchaseReceivedItem(objPurchaseReceivedItem,cmdMode);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Store.Common.MessageInfo ManagePurchaseReceived(Store.PurchaseReceived.BusinessObject.PurchaseReceived objPurchaseROrder, int cmdMode)
        {
            try
            {
                return odlPurchaseReceived.ManagePurchaseReceived(objPurchaseROrder, cmdMode);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}