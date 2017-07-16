using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.PurchaseOrder.BusinessObject
{
    public class PurchaseOrder
    {
        public Int32 PurchaseOrderID { get; set; }
        public Int32 VendorID { get; set; }
        public string VendorName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal TaxValue { get; set; }
        public decimal ShipingAndHandlingCost { get; set; }
        public decimal MiscCost { get; set; }
        public Int32 ClientID { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Int32 ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Int32 ReferenceID { get; set; }
        public Int32 IsActive { get; set; }
        public Decimal PDiscount { get; set; }
        public Decimal PDiscountPre { get; set; }
        static PurchaseOrder()
        { }
    }

    public class PurchaseOrderList : List<PurchaseOrder>
    { }
}