using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.PurchaseOrderItem.BusinessObject
{
    public class PurchaseOrderItem
    {
        public Int32 PurchaseOrderItemID { get; set; }
        public Int32 PurchaseOrderID { get; set; }
        public Int32 ItemID { get; set; }
        public string ItemPrefix { get; set; }
        public string ItemUnit { get; set; }
        public string Description { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public Int32 ClientID { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Int32 ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Int32 ReferenceID { get; set; }
        public Int32 IsActive { get; set; }
        public Decimal Discount { get; set; }
        public Decimal DiscountPre { get; set; }
    }
    public class PurchaseOrderItemList : List<PurchaseOrderItem>
    {
    }
}