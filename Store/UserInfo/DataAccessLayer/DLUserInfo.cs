using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.UserInfo.DataAccessLayer
{
    public class UserInfo
    {
        public Store.UserInfo.BusinessObject.UserInfoList GetAllUserInfoList(int UserInfoID, int Flag, string FlagValue)
        {
            Store.UserInfo.BusinessObject.UserInfo objUserInfo = new BusinessObject.UserInfo();
            Store.UserInfo.BusinessObject.UserInfoList objUserInfoList = new BusinessObject.UserInfoList();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_UserInfo";
                paramList.Add(new SQLParameter("@UserID",UserInfoID));
                paramList.Add(new SQLParameter("@Flag",Flag));
                paramList.Add(new SQLParameter("@FlagValue",FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objUserInfo = new BusinessObject.UserInfo();
                    if (dr.IsDBNull(dr.GetOrdinal("UserID")) == false)
                    {
                        objUserInfo.UserID = dr.GetInt32(dr.GetOrdinal("UserID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("UserName")) == false)
                    {
                        objUserInfo.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("UserDisplayName")) == false)
                    {
                        objUserInfo.UserDisplayName = dr.GetString(dr.GetOrdinal("UserDisplayName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TypeofUserID")) == false)
                    {
                        objUserInfo.TypeofUserID = dr.GetInt32(dr.GetOrdinal("TypeofUserID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TypeofUserName")) == false)
                    {
                        objUserInfo.TypeofUserName = dr.GetString(dr.GetOrdinal("TypeofUserName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Address")) == false)
                    {
                        objUserInfo.Address = dr.GetString(dr.GetOrdinal("Address"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CityID")) == false)
                    {
                        objUserInfo.CityID = dr.GetInt32(dr.GetOrdinal("CityID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CityName")) == false)
                    {
                        objUserInfo.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StateID")) == false)
                    {
                        objUserInfo.StateID = dr.GetInt32(dr.GetOrdinal("StateID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StateName")) == false)
                    {
                        objUserInfo.StateName = dr.GetString(dr.GetOrdinal("StateName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryID")) == false)
                    {
                        objUserInfo.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryName")) == false)
                    {
                        objUserInfo.CountryName = dr.GetString(dr.GetOrdinal("CountryName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PinID")) == false)
                    {
                        objUserInfo.PinID = dr.GetInt32(dr.GetOrdinal("PinID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ConcernPerson")) == false)
                    {
                        objUserInfo.ConcernPerson = dr.GetInt32(dr.GetOrdinal("ConcernPerson"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PhoneNo")) == false)
                    {
                        objUserInfo.PhoneNo = dr.GetInt32(dr.GetOrdinal("PhoneNo"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("MobileNo")) == false)
                    {
                        objUserInfo.MobileNo = dr.GetInt32(dr.GetOrdinal("MobileNo"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Address")) == false)
                    {
                        objUserInfo.Address = dr.GetString(dr.GetOrdinal("Address"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("EmailID")) == false)
                    {
                        objUserInfo.EmailID = dr.GetString(dr.GetOrdinal("EmailID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("WebsiteAddress")) == false)
                    {
                        objUserInfo.WebsiteAddress = dr.GetString(dr.GetOrdinal("WebsiteAddress"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objUserInfo.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objUserInfo.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objUserInfo.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objUserInfo.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objUserInfo.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    { 
                        objUserInfo.ModifiedOn=dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objUserInfo.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objUserInfo.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    objUserInfoList.Add(objUserInfo);
                }
                dr.Close();
                
            }
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(UserInfo).FullName, 1);
                
            }
            return objUserInfoList;
        }
        public Store.UserInfo.BusinessObject.UserInfo GetAllUserInfo(int UserInfoID, int Flag, string FlagValue)
        {
            Store.UserInfo.BusinessObject.UserInfo objUserInfo =null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_UserInfo";
                paramList.Add(new SQLParameter("@UserInfoID", UserInfoID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objUserInfo = new BusinessObject.UserInfo();
                    if (dr.IsDBNull(dr.GetOrdinal("UserID")) == false)
                    {
                        objUserInfo.UserID = dr.GetInt32(dr.GetOrdinal("UserID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("UserName")) == false)
                    {
                        objUserInfo.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("UserDisplayName")) == false)
                    {
                        objUserInfo.UserDisplayName = dr.GetString(dr.GetOrdinal("UserDisplayName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TypeofUserID")) == false)
                    {
                        objUserInfo.TypeofUserID = dr.GetInt32(dr.GetOrdinal("TypeofUserID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Address")) == false)
                    {
                        objUserInfo.Address = dr.GetString(dr.GetOrdinal("Address"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CityID")) == false)
                    {
                        objUserInfo.CityID = dr.GetInt32(dr.GetOrdinal("CityID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StateID")) == false)
                    {
                        objUserInfo.StateID = dr.GetInt32(dr.GetOrdinal("StateID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryID")) == false)
                    {
                        objUserInfo.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PinID")) == false)
                    {
                        objUserInfo.PinID = dr.GetInt32(dr.GetOrdinal("PinID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ConcernPerson")) == false)
                    {
                        objUserInfo.ConcernPerson = dr.GetInt32(dr.GetOrdinal("ConcernPerson"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PhoneNo")) == false)
                    {
                        objUserInfo.PhoneNo = dr.GetInt32(dr.GetOrdinal("PhoneNo"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("MobileNo")) == false)
                    {
                        objUserInfo.MobileNo = dr.GetInt32(dr.GetOrdinal("MobileNo"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Address")) == false)
                    {
                        objUserInfo.Address = dr.GetString(dr.GetOrdinal("Address"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("EmailID")) == false)
                    {
                        objUserInfo.EmailID = dr.GetString(dr.GetOrdinal("EmailID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("WebsiteAddress")) == false)
                    {
                        objUserInfo.WebsiteAddress = dr.GetString(dr.GetOrdinal("WebsiteAddress"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objUserInfo.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objUserInfo.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objUserInfo.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objUserInfo.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objUserInfo.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    { 
                        objUserInfo.ModifiedOn=dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objUserInfo.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objUserInfo.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                   
                }
                dr.Close();
               
            }

            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(UserInfo).FullName, 1);
                
            }
            return objUserInfo;
        }
        public Store.Common.MessageInfo ManageUserInfo(Store.UserInfo.BusinessObject.UserInfo objUserInfo, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageUserInfo";
                param.Add(new SQLParameter("@UserID", objUserInfo.UserID));
                param.Add(new SQLParameter("@UserName", objUserInfo.UserName));
                param.Add(new SQLParameter("@UserDisplayName", objUserInfo.UserDisplayName));
                param.Add(new SQLParameter("@TypeofUserID", objUserInfo.TypeofUserID));
                param.Add(new SQLParameter("@Address", objUserInfo.Address));
                param.Add(new SQLParameter("@CityID", objUserInfo.CityID));
                param.Add(new SQLParameter("@StateID", objUserInfo.StateID));
                param.Add(new SQLParameter("@CountryID", objUserInfo.CountryID));
                param.Add(new SQLParameter("@PinID", objUserInfo.PinID));
                param.Add(new SQLParameter("@ConcernPerson", objUserInfo.ConcernPerson));
                param.Add(new SQLParameter("@PhoneNo", objUserInfo.PhoneNo));
                param.Add(new SQLParameter("@MobileNo", objUserInfo.MobileNo));
                param.Add(new SQLParameter("@EmailID", objUserInfo.EmailID));
                param.Add(new SQLParameter("@WebsiteAddress", objUserInfo.WebsiteAddress));
                param.Add(new SQLParameter("@IsActive", objUserInfo.IsActive));
                param.Add(new SQLParameter("@ReferenceID", objUserInfo.ReferenceID));
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
                
               
            }
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(UserInfo).FullName, 1);
                
            }
            return objMessageInfo;
        }
    }
}