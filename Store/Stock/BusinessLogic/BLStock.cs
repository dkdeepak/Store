using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.Stock.BusinessLogic
{
    public class Stock
    {
        Store.Stock.DataAccessLayer.Stock odlStock = new DataAccessLayer.Stock();
     public Store.Stock.BusinessObject.Stock GetAllStock(int StockID, int Flag, string FlagValue)
        {
            try 
            {
                return odlStock.GetAllStock(StockID,Flag,FlagValue); 
            }
            catch (Exception)
            {
                throw;
            }
       }
     public Store.Stock.BusinessObject.StockList GetAllStockList(int StockID, int Flag, string FlagValue)
     {
         try
         {
             return odlStock.GetAllStockList(StockID, Flag, FlagValue); 
         }
         catch (Exception)
         {
             throw;
         }
     }
     public Store.Common.MessageInfo ManageStockMaster(Store.Stock.BusinessObject.Stock objStock, CommandMode cmdMode)
     {
         try
         {
             return odlStock.ManageStock(objStock, cmdMode);
         }
         catch (Exception)
         { 
             throw;
         }
     }


    }
}