﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

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
            catch
            {
                throw;
            }
        }
        public Store.ItemPrice.BusinessObject.ItemPrice GetAllItemPrice(int ItemPriceID, int Flag, string FlagValue)
        {
            try
            {
                return odlItemPrice.GetAllItemPrice(ItemPriceID, Flag, FlagValue);
            }
            catch
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.ItemPrice.BusinessObject.ItemPrice objItemPrice, CommandMode cmdMode)
        {
            try
            {
                return odlItemPrice.ManageItemPrice(objItemPrice, cmdMode);
            }
            catch
            {
                throw;
            }
        }
    }
}