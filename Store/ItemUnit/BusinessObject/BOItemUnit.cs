using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.ItemUnit.BusinessObject
{
    public class ItemUnit
    {
        private int _UnitID;
        public int UnitID
        {
            get
            {
                try { return _UnitID; }
                catch(Exception err) { throw new Exception("Error getting UnitID",err); }
            }
            set
            {
                try { _UnitID = value; }
                catch(Exception err) { throw new Exception("Error setting UnitID", err); }
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
    }
    public class ItemUnitList : List<ItemUnit>
    { 
    
    }
}