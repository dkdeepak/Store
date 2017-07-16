using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.SalesOrderItem.BusinessObject
{
    public class SalesOrderItem
    {
        public int SaleOrderItemID { get; set; }
        public int SalesOrderID{ get; set; }
        public int ItemId{ get; set; }
        public string ItemPrefix { get; set; }
        public string ItemUnit{ get; set; }
        public string Description{ get; set; }
        public decimal ItemCostPrice{ get; set; }
        public decimal ItemSalePrice{ get; set; }
        public decimal ItemDiscountPercentage{ get; set; }
        public decimal ItemDiscount{ get; set; }
        public int ClientID{ get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public int ReferenceID { get; set; }
        public int IsActive{ get; set; }
    }
    public class SalesOrderItemList : List<SalesOrderItem>
    { 
    
    }
}