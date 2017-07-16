using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.SaleReturnItem.BusinessObject
{
    public class SaleReturnItem
    {
        public int SaleReturnItemID { get; set; }
        public int SalesReturnID{ get; set; }
        public int SalesOrderID{ get; set; }
        public int ItemId{ get; set; }
        public string ItemPrefix { get; set; }
        public string ItemUnit{ get; set; }
        public string Description{ get; set; }
        public decimal ItemPrice{ get; set; }
        public int ClientID{ get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public int ReferenceID { get; set; }
        public int IsActive{ get; set; }
    }
    public class SaleReturnItemList : List<SaleReturnItem>
    { 
    
    }
}