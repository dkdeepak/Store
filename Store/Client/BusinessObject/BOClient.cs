using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Client.BusinessObject
{
    public class Client
    {
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
                catch(System.Exception err) { throw new Exception("Error setting ClientID", err); }
            }
        }
        private string _ClientName;
        public string ClientName
        {
            get
            {
                try { return _ClientName; }
                catch (System.Exception err) { throw new Exception("Error getting ClientName", err); }
            }
            set
            {
                try { _ClientName = value; }
                catch (System.Exception err) { throw new Exception("Error setting ClientName", err); }
            }
        }
        private string _ClientDisplayName;
        public string ClientDisplayName
        {
            get
            {
                try { return _ClientDisplayName; }
                catch (System.Exception err) { throw new Exception("Error getting ClientDisplayName", err); }
            }
            set
            {
                try { _ClientDisplayName = value; }
                catch (System.Exception err) { throw new Exception("Error setting ClientDisplayName", err); }
            }
        }
        private string _Address;
        public string Address
        {
            get
            {
                try { return _Address; }
                catch (System.Exception err) { throw new Exception("Error getting Address", err); }
            }
            set
            {
                try { _Address = value; }
                catch (System.Exception err) { throw new Exception("Error setting Address", err); }
            }
        }
        private int _CityID;
        public int CityID
        {
            get
            {
                try { return _CityID; }
                catch (System.Exception err) { throw new Exception("Error getting CityID", err); }
            }
            set
            {
                try { _CityID = value; }
                catch (System.Exception err) { throw new Exception("Error setting CityID", err); }
            }
        }
        private string _CityName;
        public string CityName
        {
            get
            {
                try { return _CityName; }
                catch (System.Exception err) { throw new Exception("Error getting CityName", err); }
            }
            set
            {
                try { _CityName = value; }
                catch (System.Exception err) { throw new Exception("Error setting CityName", err); }
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
        private int _PinID;
        public int PinID
        {
            get
            {
                try { return _PinID; }
                catch (System.Exception err) { throw new Exception("Error getting PinID", err); }
            }
            set
            {
                try { _PinID = value; }
                catch (System.Exception err) { throw new Exception("Error setting PinID", err); }
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
        private int _IsActive;
        public Int32 IsActive
        {
            get
            {
                try { return _IsActive; }
                catch (System.Exception err) { throw new Exception("Error getting IsActive", err); }
                }
            set
            {
                try { _IsActive = value; }
                catch(System.Exception err) { throw new Exception("Error setting IsActive", err); }
            }
        }
    }
    public class ClientList : List<Client>
    { }
}