using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Item.BusinessObject
{
    public class Item
    {
        private int _ItemID;
        public int    ItemID
        {
            get
            {
                try { return _ItemID; }
                catch(Exception err) { throw new Exception("Error getting ItemID",err); }
            }
            set
            {
                try { _ItemID = value; }
                catch (Exception err) { throw new Exception("Error setting ItemID",err); }
            }
        }
        private string _ItemPrefix;
        public string ItemPrefix
        {
            get
            {
                try { return _ItemPrefix; }
                catch (Exception err) { throw new Exception("Error getting ItemPrefix", err); }
            }
            set
            {
                try { _ItemPrefix = value; }
                catch (Exception err) { throw new Exception("Error setting ItemPrefix", err); }
            }
        }
        private string _ItemCode;
        public string ItemCode
        {
            get
            {
                try { return _ItemCode; }
                catch (Exception err) { throw new Exception("Error getting ItemCode", err); }
            }
            set
            {
                try { _ItemCode = value; }
                catch (Exception err) { throw new Exception("Error setting ItemCode", err); }
            }
        }
        private string _Barcode;
        public string Barcode
        {
            get
            {
                try { return _Barcode; }
                catch (Exception err) { throw new Exception("Error getting Barcode", err); }
            }
            set
            {
                try { _Barcode = value; }
                catch (Exception err) { throw new Exception("Error setting Barcode", err); }
            }
        }
        private string _ItemDescription;
        public string ItemDescription
        {
            get
            {
                try { return _ItemDescription; }
                catch (Exception err) { throw new Exception("Error getting ItemDescription", err); }
            }
            set
            {
                try { _ItemDescription = value; }
                catch (Exception err) { throw new Exception("Error setting ItemDescription", err); }
            }
        }
        private int _ItemUnitId;
        public int ItemUnitId
        {
            get
            {
                try { return _ItemUnitId; }
                catch (Exception err) { throw new Exception("Error getting ItemUnitId", err); }
            }
            set
            {
                try { _ItemUnitId = value; }
                catch (Exception err) { throw new Exception("Error setting ItemUnitId", err); }
            }
        }
        private string _UnitName;
        public string UnitName
        {
            get
            {
                try { return _UnitName; }
                catch (Exception err) { throw new Exception("Error getting UnitName", err); }
            }
            set
            {
                try { _UnitName = value; }
                catch (Exception err) { throw new Exception("Error setting UnitName", err); }
            }
        }
        private int _ItemPriceID;
        //public int ItemPriceID
        //{
        //    get
        //    {
        //        try { return _ItemPriceID; }
        //        catch (Exception err) { throw new Exception("Error getting ItemPriceID", err); }
        //    }
        //    set
        //    {
        //        try { _ItemPriceID = value; }
        //        catch (Exception err) { throw new Exception("Error setting ItemPriceID", err); }
        //    }
        //}
        //private decimal _ItemCostPricePerUnit;
        //public decimal ItemCostPricePerUnit
        //{
        //    get
        //    {
        //        try { return _ItemCostPricePerUnit; }
        //        catch (Exception err) { throw new Exception("Error getting ItemCostPricePerUnit", err); }
        //    }
        //    set
        //    {
        //        try { _ItemCostPricePerUnit = value; }
        //        catch (Exception err) { throw new Exception("Error setting ItemCostPricePerUnit", err); }
        //    }
        //}
        //private decimal _ItemSalePricePerUnit;
        //public decimal ItemSalePricePerUnit
        //{
        //    get
        //    {
        //        try { return _ItemSalePricePerUnit; }
        //        catch (Exception err) { throw new Exception("Error getting ItemSalePricePerUnit", err); }
        //    }
        //    set
        //    {
        //        try { _ItemSalePricePerUnit = value; }
        //        catch (Exception err) { throw new Exception("Error setting ItemSalePricePerUnit", err); }
        //    }
        //}
        //private decimal _ItemDiscountPercentagePerUnit;
        //public decimal ItemDiscountPercentagePerUnit
        //{
        //    get
        //    {
        //        try { return _ItemDiscountPercentagePerUnit; }
        //        catch (Exception err) { throw new Exception("Error getting ItemDiscountPercentagePerUnit", err); }
        //    }
        //    set
        //    {
        //        try { _ItemDiscountPercentagePerUnit = value; }
        //        catch (Exception err) { throw new Exception("Error setting ItemDiscountPercentagePerUnit", err); }
        //    }
        //}
        //private DateTime _WindowFrom;
        //public DateTime WindowFrom
        //{
        //    get
        //    {
        //        try { return _WindowFrom; }
        //        catch (Exception err) { throw new Exception("Error getting WindowFrom", err); }
        //    }
        //    set
        //    {
        //        try { _WindowFrom = value; }
        //        catch (Exception err) { throw new Exception("Error setting WindowFrom", err); }
        //    }
        //}
        //private DateTime _WindowTo;
        //public DateTime WindowTo
        //{
        //    get
        //    {
        //        try { return _WindowTo; }
        //        catch (Exception err) { throw new Exception("Error getting WindowTo", err); }
        //    }
        //    set
        //    {
        //        try { _WindowTo = value; }
        //        catch (Exception err) { throw new Exception("Error setting WindowTo", err); }
        //    }
        //}
        //private string _BatchNo;
        //public string BatchNo
        //{
        //    get
        //    {
        //        try { return _BatchNo; }
        //        catch (Exception err) { throw new Exception("Error getting BatchNo", err); }
        //    }
        //    set
        //    {
        //        try { _BatchNo = value; }
        //        catch (Exception err) { throw new Exception("Error setting BatchNo", err); }
        //    }
        //}
        private int _CategoryID;
        public int CategoryID
        {
            get
            {
                try { return _CategoryID; }
                catch (Exception err) { throw new Exception("Error getting CategoryID", err); }
            }
            set
            {
                try { _CategoryID = value; }
                catch (Exception err) { throw new Exception("Error setting CategoryID", err); }
            }
        }
        private string _CategoryName;
        public string CategoryName
        {
            get
            {
                try { return _CategoryName; }
                catch (Exception err) { throw new Exception("Error getting CategoryName", err); }
            }
            set
            {
                try { _CategoryName = value; }
                catch (Exception err) { throw new Exception("Error setting CategoryName", err); }
            }

        }
        private int _CreatedBy;
        public int CreatedBy
        {
            get
            {
                try
                {
                    return _CreatedBy;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting CreatedBy", err);
                }
            }
            set
            {
                try
                {
                    _CreatedBy = value;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting CreatedBy", err);
                }
            }
        }
        private DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get
            {
                try
                {
                    return _CreatedOn;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting CreatedOn", err);
                }
            }
            set
            {
                try
                {
                    _CreatedOn = value;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting CreatedOn", err);
                }
            }
        }
        private DateTime _ModifiedOn;
        public DateTime ModifiedOn
        {
            get
            {
                try
                {
                    return _ModifiedOn;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting ModifiedOn", err);
                }
            }
            set
            {
                try
                {
                    _ModifiedOn = value;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting ModifiedOn", err);
                }
            }
        }
        private int _ModifiedBy;
        public int ModifiedBy
        {
            get
            {
                try
                {
                    return _ModifiedBy;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting ModifiedBy", err);
                }
            }
            set
            {
                try
                {
                    _ModifiedBy = value;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting ModifiedBy", err);
                }
            }
        }
        private int _ReferenceID;
        public int ReferenceID
        {
            get
            {
                try
                {
                    return _ReferenceID;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting ReferenceID", err);
                }
            }
            set
            {
                try
                {
                    _ReferenceID = value;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting ReferenceID", err);
                }
            }
        }
        public int _IsActive;
        public int IsActive
        {
            get
            {
                try
                {
                    return _IsActive;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting IsActive", err);
                }
            }
            set
            {
                try
                {
                    _IsActive = value;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting IsActive", err);
                }
            }
        }

    }
    public class ItemList : List<Item>
    { 
    }
} 
 