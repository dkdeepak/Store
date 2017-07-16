using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.ItemPrice.BusinessObject
{
    public class ItemPrice
    {
        public int ItemPriceID { get; set; }
        public int ItemID { get; set; }
        public string ItemPrefix { get; set; }
        public decimal ItemCostPricePerUnit { get; set; }
        public decimal ItemSalePricePerUnit { get; set; }
        public decimal ItemDiscountPercentagePerUnit { get; set; }
        public DateTime WindowFrom { get; set; }
        public DateTime WindowTo { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public int ReferenceID { get; set; }
        public string BatchNo { get; set; }

    }
    public class ItemPriceList : List<ItemPrice>
    { 
    }
}