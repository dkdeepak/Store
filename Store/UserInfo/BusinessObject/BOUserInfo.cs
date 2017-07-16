using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.UserInfo.BusinessObject
{
    public class UserInfo
    {
        private int _UserID;
        public int UserID
        {
            get
            {
                try { return _UserID; }
                catch(Exception err) { throw new Exception("Error getting UserID`", err); }
            }
            set
            {
                try { _UserID = value; }
                catch (Exception err) { throw new Exception("Error setting UserID", err); }
            }
        }
        private string _UserName;
        public string UserName
        {
            get
            {
                try { return _UserName; }
                catch (Exception err) { throw new Exception("Error getting UserName`", err); }
            }
            set
            {
                try { _UserName = value; }
                catch (Exception err) { throw new Exception("Error setting UserName", err); }
            }
        }
        private string _UserDisplayName;
        public string UserDisplayName
        {
            get
            {
                try { return _UserDisplayName; }
                catch (Exception err) { throw new Exception("Error getting UserDisplayName`", err); }
            }
            set
            {
                try { _UserDisplayName = value; }
                catch (Exception err) { throw new Exception("Error setting UserDisplayName", err); }
            }
        }
        private int _TypeofUserID;
        public int TypeofUserID
        {
            get
            {
                try { return _TypeofUserID; }
                catch (System.Exception err) { throw new Exception("Error getting TypeofUserID", err); }
            }
            set
            {
                try { _TypeofUserID = value; }
                catch (System.Exception err) { throw new Exception("Error gettting TypeofUserID", err); }
            }
        }
        private string _TypeofUserName;
        public string TypeofUserName
        {
            get
            {
                try { return _TypeofUserName; }
                catch (System.Exception err) { throw new Exception("Error getting TypeofUserName", err); }
            }
            set
            {
                try { _TypeofUserName = value; }
                catch (System.Exception err) { throw new Exception("Error gettting TypeofUserName", err); }
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
        private int _ConcernPerson;
        public int ConcernPerson
        {
            get
            {
                try { return _ConcernPerson; }
                catch (System.Exception err) { throw new Exception("Error getting ConcernPerson", err); }
            }
            set
            {
                try { _ConcernPerson = value; }
                catch (System.Exception err) { throw new Exception("Error setting ConcernPerson", err); }
            }
        }
        private int _PhoneNo;
        public int PhoneNo
        {
            get
            {
                try { return _PhoneNo; }
                catch (System.Exception err) { throw new Exception("Error getting PhoneNo", err); }
            }
            set
            {
                try { _PhoneNo = value; }
                catch (System.Exception err) { throw new Exception("Error setting PhoneNo", err); }
            }
        }

        private int _MobileNo;
        public int MobileNo
        {
            get
            {
                try { return _MobileNo; }
                catch (System.Exception err) { throw new Exception("Error getting MobileNo", err); }
            }
            set
            {
                try { _MobileNo = value; }
                catch (System.Exception err) { throw new Exception("Error setting MobileNo", err); }
            }
        }
        private string _EmailID;
        public string EmailID
        {
            get
            {
                try { return _EmailID; }
                catch (System.Exception err) { throw new Exception("Error getting EmailID", err); }
            }
            set
            {
                try { _EmailID = value; }
                catch (System.Exception err) { throw new Exception("Error setting EmailID", err); }
            }
        }

        private string _WebsiteAddress;
        public string WebsiteAddress
        {
            get
            {
                try { return _WebsiteAddress; }
                catch (System.Exception err) { throw new Exception("Error getting WebsiteAddress", err); }
            }
            set
            {
                try { _WebsiteAddress = value; }
                catch (System.Exception err) { throw new Exception("Error setting WebsiteAddress", err); }
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
        private int _IsActive;
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
    public class UserInfoList : List<UserInfo>
    { 
    
    }
}