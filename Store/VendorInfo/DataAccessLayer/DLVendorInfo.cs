using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.VendorInfo.DataAccessLayer
{
    public class VendorInfo
    {
        public Store.VendorInfo.BusinessObject.VendorInfoList GetAllVendorInfoList(int VendorInfoID, int Flag, string FlagValue)
        {
            Store.VendorInfo.BusinessObject.VendorInfo objVendorInfo = new BusinessObject.VendorInfo();
            Store.VendorInfo.BusinessObject.VendorInfoList objVendorInfoList = new BusinessObject.VendorInfoList();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_VendorInfo";
                paramList.Add(new SQLParameter("@VendorID",VendorInfoID));
                paramList.Add(new SQLParameter("@Flag",Flag));
                paramList.Add(new SQLParameter("@FlagValue",FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objVendorInfo = new BusinessObject.VendorInfo();
                    if (dr.IsDBNull(dr.GetOrdinal("VendorID")) == false)
                    {
                        objVendorInfo.VendorID = dr.GetInt32(dr.GetOrdinal("VendorID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("VendorName")) == false)
                    {
                        objVendorInfo.VendorName = dr.GetString(dr.GetOrdinal("VendorName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("VendorDisplayName")) == false)
                    {
                        objVendorInfo.VendorDisplayName = dr.GetString(dr.GetOrdinal("VendorDisplayName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TypeofVendorID")) == false)
                    {
                        objVendorInfo.TypeofVendorID = dr.GetInt32(dr.GetOrdinal("TypeofVendorID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TypeofVendorName")) == false)
                    {
                        objVendorInfo.TypeofVendorName = dr.GetString(dr.GetOrdinal("TypeofVendorName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Address")) == false)
                    {
                        objVendorInfo.Address = dr.GetString(dr.GetOrdinal("Address"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CityID")) == false)
                    {
                        objVendorInfo.CityID = dr.GetInt32(dr.GetOrdinal("CityID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CityName")) == false)
                    {
                        objVendorInfo.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StateID")) == false)
                    {
                        objVendorInfo.StateID = dr.GetInt32(dr.GetOrdinal("StateID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StateName")) == false)
                    {
                        objVendorInfo.StateName = dr.GetString(dr.GetOrdinal("StateName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryID")) == false)
                    {
                        objVendorInfo.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryName")) == false)
                    {
                        objVendorInfo.CountryName = dr.GetString(dr.GetOrdinal("CountryName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PinID")) == false)
                    {
                        objVendorInfo.PinID = dr.GetInt32(dr.GetOrdinal("PinID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ConcernPerson")) == false)
                    {
                        objVendorInfo.ConcernPerson = dr.GetInt32(dr.GetOrdinal("ConcernPerson"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PhoneNo")) == false)
                    {
                        objVendorInfo.PhoneNo = dr.GetInt32(dr.GetOrdinal("PhoneNo"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("MobileNo")) == false)
                    {
                        objVendorInfo.MobileNo = dr.GetInt32(dr.GetOrdinal("MobileNo"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Address")) == false)
                    {
                        objVendorInfo.Address = dr.GetString(dr.GetOrdinal("Address"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("EmailID")) == false)
                    {
                        objVendorInfo.EmailID = dr.GetString(dr.GetOrdinal("EmailID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("WebsiteAddress")) == false)
                    {
                        objVendorInfo.WebsiteAddress = dr.GetString(dr.GetOrdinal("WebsiteAddress"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PanNo")) == false)
                    {
                        objVendorInfo.PanNo = dr.GetString(dr.GetOrdinal("PanNo"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("GstNo")) == false)
                    {
                        objVendorInfo.GstNo = dr.GetString(dr.GetOrdinal("GstNo"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ServiceTaxNo")) == false)
                    {
                        objVendorInfo.ServiceTaxNo = dr.GetString(dr.GetOrdinal("ServiceTaxNo"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objVendorInfo.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objVendorInfo.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objVendorInfo.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objVendorInfo.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objVendorInfo.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    { 
                        objVendorInfo.ModifiedOn=dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objVendorInfo.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objVendorInfo.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    objVendorInfoList.Add(objVendorInfo);
                }
                dr.Close();
                return objVendorInfoList;
            }
            catch
            {
                throw;
            }
        }
        public Store.VendorInfo.BusinessObject.VendorInfo GetAllVendorInfo(int VendorInfoID, int Flag, string FlagValue)
        {
            Store.VendorInfo.BusinessObject.VendorInfo objVendorInfo =null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_VendorInfo";
                paramList.Add(new SQLParameter("@VendorInfoID", VendorInfoID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objVendorInfo = new BusinessObject.VendorInfo();
                    if (dr.IsDBNull(dr.GetOrdinal("VendorID")) == false)
                    {
                        objVendorInfo.VendorID = dr.GetInt32(dr.GetOrdinal("VendorID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("VendorName")) == false)
                    {
                        objVendorInfo.VendorName = dr.GetString(dr.GetOrdinal("VendorName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("VendorDisplayName")) == false)
                    {
                        objVendorInfo.VendorDisplayName = dr.GetString(dr.GetOrdinal("VendorDisplayName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TypeofVendorID")) == false)
                    {
                        objVendorInfo.TypeofVendorID = dr.GetInt32(dr.GetOrdinal("TypeofVendorID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Address")) == false)
                    {
                        objVendorInfo.Address = dr.GetString(dr.GetOrdinal("Address"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CityID")) == false)
                    {
                        objVendorInfo.CityID = dr.GetInt32(dr.GetOrdinal("CityID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StateID")) == false)
                    {
                        objVendorInfo.StateID = dr.GetInt32(dr.GetOrdinal("StateID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryID")) == false)
                    {
                        objVendorInfo.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PinID")) == false)
                    {
                        objVendorInfo.PinID = dr.GetInt32(dr.GetOrdinal("PinID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ConcernPerson")) == false)
                    {
                        objVendorInfo.ConcernPerson = dr.GetInt32(dr.GetOrdinal("ConcernPerson"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PhoneNo")) == false)
                    {
                        objVendorInfo.PhoneNo = dr.GetInt32(dr.GetOrdinal("PhoneNo"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("MobileNo")) == false)
                    {
                        objVendorInfo.MobileNo = dr.GetInt32(dr.GetOrdinal("MobileNo"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Address")) == false)
                    {
                        objVendorInfo.Address = dr.GetString(dr.GetOrdinal("Address"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("EmailID")) == false)
                    {
                        objVendorInfo.EmailID = dr.GetString(dr.GetOrdinal("EmailID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("WebsiteAddress")) == false)
                    {
                        objVendorInfo.WebsiteAddress = dr.GetString(dr.GetOrdinal("WebsiteAddress"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PanNo")) == false)
                    {
                        objVendorInfo.PanNo = dr.GetString(dr.GetOrdinal("PanNo"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("GstNo")) == false)
                    {
                        objVendorInfo.GstNo = dr.GetString(dr.GetOrdinal("GstNo"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ServiceTaxNo")) == false)
                    {
                        objVendorInfo.ServiceTaxNo = dr.GetString(dr.GetOrdinal("ServiceTaxNo"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objVendorInfo.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objVendorInfo.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objVendorInfo.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objVendorInfo.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objVendorInfo.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    { 
                        objVendorInfo.ModifiedOn=dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objVendorInfo.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objVendorInfo.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                   
                }
                dr.Close();
                return objVendorInfo;
            }

            catch
            {
                throw;
            }

        }
        public Store.Common.MessageInfo ManageVendorInfo(Store.VendorInfo.BusinessObject.VendorInfo objVendorInfo, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageVendorInfo";
                param.Add(new SQLParameter("@VendorID", objVendorInfo.VendorID));
                param.Add(new SQLParameter("@VendorName", objVendorInfo.VendorName));
                param.Add(new SQLParameter("@VendorDisplayName", objVendorInfo.VendorDisplayName));
                param.Add(new SQLParameter("@TypeofVendorID", objVendorInfo.TypeofVendorID));
                param.Add(new SQLParameter("@Address", objVendorInfo.Address));
                param.Add(new SQLParameter("@CityID", objVendorInfo.CityID));
                param.Add(new SQLParameter("@StateID", objVendorInfo.StateID));
                param.Add(new SQLParameter("@CountryID", objVendorInfo.CountryID));
                param.Add(new SQLParameter("@PinID", objVendorInfo.PinID));
                param.Add(new SQLParameter("@ConcernPerson", objVendorInfo.ConcernPerson));
                param.Add(new SQLParameter("@PhoneNo", objVendorInfo.PhoneNo));
                param.Add(new SQLParameter("@MobileNo", objVendorInfo.MobileNo));
                param.Add(new SQLParameter("@EmailID", objVendorInfo.EmailID));
                param.Add(new SQLParameter("@WebsiteAddress", objVendorInfo.WebsiteAddress));
                param.Add(new SQLParameter("@PanNo", objVendorInfo.PanNo));
                param.Add(new SQLParameter("@GstNo", objVendorInfo.GstNo));
                param.Add(new SQLParameter("@ServiceTaxNo", objVendorInfo.ServiceTaxNo));                
                param.Add(new SQLParameter("@IsActive", objVendorInfo.IsActive));
                param.Add(new SQLParameter("@ReferenceID", objVendorInfo.ReferenceID));
                param.Add(new SQLParameter("@CMDMode", cmdMode));
                dr = ExecuteQuery.ExecuteReader(SQL, param);
                if (dr.Read())
                {
                    objMessageInfo = new Store.Common.MessageInfo();
                    objMessageInfo.ErrorCode = Convert.ToInt32(dr["ErrorCode"]);
                    objMessageInfo.ErrorMessage = Convert.ToString(dr["ErrorMessage"]);
                    objMessageInfo.TranID = Convert.ToInt32(dr["TranID"]);
                    objMessageInfo.TranCode = Convert.ToString(dr["TranCode"]);
                    objMessageInfo.TranMessage = Convert.ToString(dr["TranMessage"]);
                }
                return objMessageInfo;
               
            }
            catch
            {
                throw;
            }
        }
    }
}