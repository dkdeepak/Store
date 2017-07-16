using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Tax.BusinessObject
{
    public class Tax
    {

        private int _TaxID;
        public int TaxID
        {
            get
            {
                try { return _TaxID; }
                catch (System.Exception err) { throw new Exception("Error getting TaxID", err); }
            }
            set
            {
                try { _TaxID = value; }
                catch (System.Exception err) { throw new Exception("Error gettting TaxID", err); }
            }
        }
        private string _TaxName;
        public string TaxName
        {
            get
            {
                try { return _TaxName; }
                catch (System.Exception err) { throw new Exception("Error getting TaxName", err); }
            }
            set
            {
                try { _TaxName = value; }
                catch (System.Exception err) { throw new Exception("Error gettting TaxName", err); }
            }
        }
        private string _TaxDisplayName;
        public string TaxDisplayName
        {
            get
            {
                try { return _TaxDisplayName; }
                catch (System.Exception err) { throw new Exception("Error getting TaxDisplayName", err); }
            }
            set
            {
                try { _TaxDisplayName = value; }
                catch (System.Exception err) { throw new Exception("Error gettting TaxDisplayName", err); }
            }
        }
        private decimal _TaxValue;
        public decimal TaxValue
        {
            get
            {
                try { return _TaxValue; }
                catch (System.Exception err) { throw new Exception("Error getting TaxValue", err); }
            }
            set
            {
                try { _TaxValue = value; }
                catch (System.Exception err) { throw new Exception("Error gettting TaxValue", err); }
            }
        }
        private int _ClientID;
        public int ClientID
        {
            get
            {
                try { return _ClientID; }
                catch (System.Exception err) { throw new Exception("Error getting ClientID", err); }
            }
            set
            {
                try { _ClientID = value; }
                catch (System.Exception err) { throw new Exception("Error gettting ClientID", err); }
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
    public class TaxList : List<Tax>
    { 
    
    }
}