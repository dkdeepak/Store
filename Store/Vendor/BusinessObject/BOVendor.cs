using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Vendor.BusinessObject
{
    public class Vendor
    {
        public int VendorID{get;set;}
        public string VendorName{get;set;}
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public int ReferenceID { get; set; }
    }
    public class VendorList : List<Vendor>
    { 
    }
}