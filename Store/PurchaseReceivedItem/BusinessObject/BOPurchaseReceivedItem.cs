using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.PurchaseReceivedItem.BusinessObject
{
    public class PurchaseReceivedItem
    {
        public Int32 PurchaseItemReceivedID { get; set; }
        public Int32 PurchaseReceivedID { get; set; }
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
    public class PurchaseReceivedItemList : List<PurchaseReceivedItem>
    { 
    }
}