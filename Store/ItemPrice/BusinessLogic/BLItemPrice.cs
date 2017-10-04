using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;
using System.Data;

namespace Store.ItemPrice.BusinessLogic
{
    public class ItemPrice
    {
        Store.ItemPrice.DataAccessLayer.ItemPrice odlItemPrice = new DataAccessLayer.ItemPrice();
        public Store.ItemPrice.BusinessObject.ItemPriceList GetAllItemPriceList(int ItemPriceID, int Flag, string FlagValue)
        {
            try
            {
                return odlItemPrice.GetAllItemPriceList(ItemPriceID, Flag, FlagValue);
            }
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(ItemPrice).FullName, 1);
                return null;
            }
        }
        public Store.ItemPrice.BusinessObject.ItemPrice GetAllItemPrice(int ItemPriceID, int Flag, string FlagValue)
        {
            try
            {
                return odlItemPrice.GetAllItemPrice(ItemPriceID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(ItemPrice).FullName, 1);
                return null;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.ItemPrice.BusinessObject.ItemPrice objItemPrice, CommandMode cmdMode)
        {
            try
            {
                return odlItemPrice.ManageItemPrice(objItemPrice, cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(ItemPrice).FullName, 1);
                return null;
            }
        }

        
        public DataTable runQuery(string query)
        {
            return odlItemPrice.runQuery(query);
        }
        public DataSet getBatch(int itemId)
        {
            return odlItemPrice.getBatch(itemId);
        }
       
    }
}