using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.District.BusinessObject
{
    public class District
    {
        private int _DistrictID;
        public int DistrictID
        {
            get
            {
                try { return _DistrictID; }
                catch (System.Exception err) { throw new Exception("Error getting DistrictID", err); }
            }
            set
            {
                try { _DistrictID = value; }
                catch (System.Exception err) { throw new Exception("Error setting DistrictID",err); }
            }
        }
        private string _DistrictName;
        public string DistrictName
        {
            get
            {
                try { return _DistrictName; }
                catch (System.Exception err) { throw new Exception("Error getting DistrictName", err); }
            }
            set
            {
                try { _DistrictName = value; }
                catch (System.Exception err) { throw new Exception("Error setting DistrictName", err); }
            }
        }

        private int _StateID;
        public int StateID
        {
            get
            {
                try { return _StateID; }
                catch (System.Exception err) { throw new Exception("Error getting StateID", err); }
            }
            set
            {
                try { _StateID = value; }
                catch (System.Exception err) { throw new Exception("Error setting StateID", err); }
            }
        }
        private string _StateName;
        public string StateName
        {
            get
            {
                try { return _StateName; }
                catch (System.Exception err) { throw new Exception("Error getting StateName", err); }
            }
            set
            {
                try { _StateName = value; }
                catch (System.Exception err) { throw new Exception("Error setting StateName", err); }
            }
        }
        private int _CountryID;
        public int CountryID
        {
            get
            {
                try { return _CountryID; }
                catch (System.Exception err) { throw new Exception("Error getting CountryID", err); }
            }
            set
            {
                try { _CountryID = value; }
                catch (System.Exception err) { throw new Exception("Error setting CountryID", err); }
            }
        }
        private string _CountryName;
        public string CountryName
        {
            get
            {
                try { return _CountryName; }
                catch (System.Exception err) { throw new Exception("Error getting CountryName", err); }
            }
            set
            {
                try { _CountryName = value; }
                catch (System.Exception err) { throw new Exception("Error setting CountryName", err); }
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
    public class DistrictList : List<District>
    { 
    }
}