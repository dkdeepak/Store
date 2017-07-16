using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.SalesReturned.BusinessObject
{
    public class SalesReturned
    {
        public int SalesReturnedID { get; set; }
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public DateTime SalesReturnDate { get; set; }
        public decimal TotalSalesReturnAmount{get;set;}
        public decimal TaxValue { get; set; }
        public decimal ShippingAndHandlingCost { get; set; }
        public decimal MiscCost { get; set; }
        public int SalesOrderID{get; set;}
        public int ClientID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ReferenceID { get; set; }
        public int IsActive { get; set; }
        
    }
    public class SalesReturnedList : List<SalesReturned>
    { }
}