using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.SalesOrder.BusinessObject
{
    public class SalesOrder
    {
        public int SalesOrderID{ get; set; }
        public int VendorID{ get; set; }
        public string VendorName { get; set; }
        public DateTime SaleDate{ get; set; }
        public decimal TotalCostAmount{ get; set; }
        public decimal TotalSaleAmount{ get; set; }
        public decimal TotalDiscountAmount{ get; set; }
        public decimal TotalTaxValue{ get; set; }
        public decimal ShipingAndHandlingCost{ get; set; }
        public decimal MiscSaleAmount { get; set; }
        public int ClientID{ get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public int ReferenceID { get; set; }
        public int IsActive{ get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPer { get; set; }

    }
    public class SalesOrderList : List<SalesOrder>
    { 
    
    }
}