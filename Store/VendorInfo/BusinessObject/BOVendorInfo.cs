using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.VendorInfo.BusinessObject
{
    public class VendorInfo
    {
        private int _VendorID;
        public int VendorID
        {
            get
            {
                try { return _VendorID; }
                catch(Exception err) { throw new Exception("Error getting VendorID`", err); }
            }
            set
            {
                try { _VendorID = value; }
                catch (Exception err) { throw new Exception("Error setting VendorID", err); }
            }
        }
        private string _VendorName;
        public string VendorName
        {
            get
            {
                try { return _VendorName; }
                catch (Exception err) { throw new Exception("Error getting VendorName`", err); }
            }
            set
            {
                try { _VendorName = value; }
                catch (Exception err) { throw new Exception("Error setting VendorName", err); }
            }
        }
        private string _VendorDisplayName;
        public string VendorDisplayName
        {
            get
            {
                try { return _VendorDisplayName; }
                catch (Exception err) { throw new Exception("Error getting VendorDisplayName`", err); }
            }
            set
            {
                try { _VendorDisplayName = value; }
                catch (Exception err) { throw new Exception("Error setting VendorDisplayName", err); }
            }
        }
        private int _TypeofVendorID;
        public int TypeofVendorID
        {
            get
            {
                try { return _TypeofVendorID; }
                catch (System.Exception err) { throw new Exception("Error getting TypeofVendorID", err); }
            }
            set
            {
                try { _TypeofVendorID = value; }
                catch (System.Exception err) { throw new Exception("Error gettting TypeofVendorID", err); }
            }
        }
        private string _TypeofVendorName;
        public string TypeofVendorName
        {
            get
            {
                try { return _TypeofVendorName; }
                catch (System.Exception err) { throw new Exception("Error getting TypeofVendorName", err); }
            }
            set
            {
                try { _TypeofVendorName = value; }
                catch (System.Exception err) { throw new Exception("Error gettting TypeofVendorName", err); }
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
        private string _PanNo;
        public string PanNo
        {
            get
            {
                try { return _PanNo; }
                catch (System.Exception err) { throw new Exception("Error getting PanNo", err); }
            }
            set
            {
                try { _PanNo = value; }
                catch (System.Exception err) { throw new Exception("Error setting PanNo", err); }
            }
        }
        private string _GstNo;
        public string GstNo
        {
            get
            {
                try { return _GstNo; }
                catch (System.Exception err) { throw new Exception("Error getting GstNo", err); }
            }
            set
            {
                try { _GstNo = value; }
                catch (System.Exception err) { throw new Exception("Error setting GstNo", err); }
            }
        }
        private string _ServieTaxNo;
        public string ServiceTaxNo
        {
            get
            {
                try { return _ServieTaxNo; }
                catch (System.Exception err) { throw new Exception("Error getting ServieTaxNo", err); }
            }
            set
            {
                try { _ServieTaxNo = value; }
                catch (System.Exception err) { throw new Exception("Error setting ServieTaxNo", err); }
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
    public class VendorInfoList : List<VendorInfo>
    { 
    
    }
}