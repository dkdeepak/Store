﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;
using Store.PurchaseReceived.BusinessObject;

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
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(PurchaseReceived).FullName, 1);
                return null;
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
        public Store.Common.MessageInfo ManagePurchaseReceivedItem(Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem objPurchaseReceivedItem, CommandMode cmdMode)
        {
            try
            {
                return odlPurchaseReceived.ManagePurchaseReceivedItem(objPurchaseReceivedItem,cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(PurchaseReceived).FullName, 1);
                return null;
            }
        }

        //public Store.Common.MessageInfo ManagePurchaseReceived(Store.PurchaseReceived.BusinessObject.PurchaseReceived objPurchaseROrder, int cmdMode)
        public Store.Common.MessageInfo ManagePurchaseReceived(Store.PurchaseReceived.BusinessObject.PurchaseReceived objPurchaseROrder, CommandMode cmdMode)
        {
            try
            {
                return odlPurchaseReceived.ManagePurchaseReceived(objPurchaseROrder,cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(PurchaseReceived).FullName, 1);
                return null;
            }
        }


        //public MessageInfo ManagePurchaseReceived(BusinessObject.PurchaseReceived objPurchaseReceived, CommandMode cmdMode)
        //{
        //    throw new NotImplementedException();
        //}
    }
}