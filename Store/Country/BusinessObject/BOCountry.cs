using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Country.BusinessObject
{
    public class Country
    {
        private int _CountryId;
        public int CountryID
        {
            get
            {
                try
                {
                    return _CountryId;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting CountryId", err);
                }

            }
            set
            {
                try
                {
                    _CountryId = value;
                }
                catch(System.Exception err)
                {
                    throw new Exception("Error setting CountryId", err);
                }
            }
        }
        private string _CountryName;
        public string CountryName
        {
            get
            {
                try
                {
                    return _CountryName;
                }
                catch (System.Exception err) 
                {
                    throw new Exception("Error getting CountryName", err);
                }
            }
            set
            {
                try
                {
                    _CountryName = value;
                }
                catch(System.Exception err)
                {
                    throw new Exception("Error setting CountryName", err);
                }
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
    public class CountryList : List<Country>
    {
    }
}