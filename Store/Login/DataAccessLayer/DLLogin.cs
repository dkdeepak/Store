using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.Login.DataAccessLayer
{
    public class Login
    {
        public Store.Login.BusinessObject.LoginList GetAllLoginList(int LoginID, int Flag, string FlagValue)
        {
            Store.Login.BusinessObject.Login objLogin = new BusinessObject.Login();
            Store.Login.BusinessObject.LoginList objLoginList = new BusinessObject.LoginList();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_Login";
                paramList.Add(new SQLParameter("@LoginID",LoginID));
                paramList.Add(new SQLParameter("@Flag",Flag));
                paramList.Add(new SQLParameter("@FlagValue",FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objLogin = new BusinessObject.Login();
                    if (dr.IsDBNull(dr.GetOrdinal("LoginID")) == false)
                    {
                        objLogin.LoginID = dr.GetInt32(dr.GetOrdinal("LoginID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("UserID")) == false)
                    {
                        objLogin.UserID = dr.GetInt32(dr.GetOrdinal("UserID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Password")) == false)
                    {
                        objLogin.Password = dr.GetString(dr.GetOrdinal("Password"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("OldPassword")) == false)
                    {
                        objLogin.OldPassword = dr.GetString(dr.GetOrdinal("OldPassword"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objLogin.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("UserTypeID")) == false)
                    {
                        objLogin.UserTypeID = dr.GetInt32(dr.GetOrdinal("UserTypeID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objLogin.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("LastLoginDate")) == false)
                    {
                        objLogin.LastLoginDate = dr.GetDateTime(dr.GetOrdinal("LastLoginDate"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objLogin.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objLogin.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objLogin.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    { 
                        objLogin.ModifiedOn=dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objLogin.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    objLoginList.Add(objLogin);
                }
                dr.Close();
                return objLoginList;
            }
            catch
            {
                throw;
            }
        }
        public Store.Login.BusinessObject.Login GetAllLogin(int LoginID, int Flag, string FlagValue)
        {
            Store.Login.BusinessObject.Login objLogin =null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_Login";
                paramList.Add(new SQLParameter("@LoginID", LoginID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objLogin = new BusinessObject.Login();
                    if (dr.IsDBNull(dr.GetOrdinal("LoginID")) == false)
                    {
                        objLogin.LoginID = dr.GetInt32(dr.GetOrdinal("LoginID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("UserID")) == false)
                    {
                        objLogin.UserID = dr.GetInt32(dr.GetOrdinal("UserID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Password")) == false)
                    {
                        objLogin.Password = dr.GetString(dr.GetOrdinal("Password"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("OldPassword")) == false)
                    {
                        objLogin.OldPassword = dr.GetString(dr.GetOrdinal("OldPassword"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objLogin.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("UserTypeID")) == false)
                    {
                        objLogin.UserTypeID = dr.GetInt32(dr.GetOrdinal("UserTypeID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objLogin.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("LastLoginDate")) == false)
                    {
                        objLogin.LastLoginDate = dr.GetDateTime(dr.GetOrdinal("LastLoginDate"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objLogin.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objLogin.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objLogin.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objLogin.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objLogin.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    dr.Close();
                }
                return objLogin;
            }

            catch
            {
                throw;
            }

        }
        public Store.Common.MessageInfo ManageLogin(Store.Login.BusinessObject.Login objLogin, CommandMode cmdMode)
        {
            string SQL = "USP_ManageLogin";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageItemMeasurementLogin";
                param.Add(new SQLParameter("@LoginID",objLogin.LoginID));
                param.Add(new SQLParameter("@UserID", objLogin.UserID));
                param.Add(new SQLParameter("@Password", objLogin.Password));
                param.Add(new SQLParameter("@OldPassword", objLogin.OldPassword));
                param.Add(new SQLParameter("@IsActive", objLogin.IsActive));
                param.Add(new SQLParameter("@LastLoginDate", objLogin.LastLoginDate));
                param.Add(new SQLParameter("@UserTypeID", objLogin.UserTypeID));
                param.Add(new SQLParameter("@UserId", objLogin.CreatedBy));
                param.Add(new SQLParameter("@ReferenceID", objLogin.ReferenceID));
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