using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Stock.BusinessObject
{
    public class Stock
    {
        public int StockID { get; set; }
        public string ItemPrefix { get; set; }
        public int ItemID{ get; set; }
        public int StockQuantity{ get; set; }

    }
    public class StockList : List<Stock>
    { 
    }
}