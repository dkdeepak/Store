using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Currency.BusinessObject
{
    public class Currency
    {
        private int _CurrencyID;
        public int CurrencyID
        {
            get
            {
                try { return _CurrencyID; }
                catch(Exception err) { throw new Exception("Error getting CurrencyID", err); }
            }
            set
            {
                try { _CurrencyID = value; }
                catch(Exception err) { throw new Exception("Error setting CurrencyID",err); }
            }
        }
        private string _CurrencyName;
        public string CurrencyName
        {
            get
            {
                try { return _CurrencyName; }
                catch (Exception err) { throw new Exception("Error getting CurrencyName", err); }
            }
            set
            {
                try { _CurrencyName = value; }
                catch (Exception err) { throw new Exception("Error setting CurrencyName", err); }
            }
        }
        
        private string _Sign;
        public string Sign
        {
            get
            {
                try { return _Sign; }
                catch (Exception err) { throw new Exception("Error getting Sign", err); }
            }
            set
            {
                try { _Sign = value; }
                catch (Exception err) { throw new Exception("Error setting Sign", err); }
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
    public class CurrencyList : List<Currency>
    { 
    }
}