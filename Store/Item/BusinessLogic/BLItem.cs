using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.Item.BusinessLogic
{
    public class Item
    {
       
         Store.Item.DataAccessLayer.Item odlItem = new DataAccessLayer.Item();
         public Store.Item.BusinessObject.ItemList GetAllItemList(int ItemID, int Flag, string FlagValue)
         {
             try 
             {
                 return odlItem.GetAllItemList(ItemID, Flag, FlagValue);
             }
             catch(Exception)
             {
                 throw;
             }

         }
         public Store.Item.BusinessObject.Item GetAllItem(string Item, int Flag, string FlagValue)
         {
             try
             {
                 return odlItem.GetAllItem(Item, Flag, FlagValue);
             }
             catch (Exception)
             {
                 throw;
             }
         }
         public Store.Common.MessageInfo ManageItemMaster(Store.Item.BusinessObject.Item objItem, CommandMode cmdMode)
         {
             try
             {
                 return odlItem.ManageItem(objItem,cmdMode);
             }
             catch (Exception)
             {
                 throw;
             }
         
         }
    }
}