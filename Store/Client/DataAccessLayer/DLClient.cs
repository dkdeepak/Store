using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;

namespace Store.Client.DataAccessLayer
{
    public class Client
    {
        public Store.Client.BusinessObject.Client GetAllClient(int ClientID, int Flag, string FlagValue)
        {
            Store.Client.BusinessObject.Client objClient = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_Client";
                paramList.Add(new SQLParameter("@ClientID",ClientID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objClient = new BusinessObject.Client();
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false) 
                    {
                        objClient.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientName")) == false)
                    {
                        objClient.ClientName = dr.GetString(dr.GetOrdinal("ClientName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientDisplayName")) == false)
                    {
                        objClient.ClientDisplayName = dr.GetString(dr.GetOrdinal("ClientDisplayName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Address")) == false)
                    {
                        objClient.Address = dr.GetString(dr.GetOrdinal("Address"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CityID")) == false)
                    {
                        objClient.CityID = dr.GetInt32(dr.GetOrdinal("CityID"));
                    }

                    if (dr.IsDBNull(dr.GetOrdinal("CityName")) == false)
                    {
                        objClient.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StateID")) == false)
                    {
                        objClient.StateID = dr.GetInt32(dr.GetOrdinal("StateID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StateName")) == false)
                    {
                        objClient.StateName = dr.GetString(dr.GetOrdinal("StateName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryID")) == false)
                    {
                        objClient.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryName")) == false)
                    {
                        objClient.CountryName = dr.GetString(dr.GetOrdinal("CountryName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PinID")) == false)
                    {
                        objClient.PinID = dr.GetInt32(dr.GetOrdinal("PinID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objClient.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objClient.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objClient.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objClient.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objClient.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objClient.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Client).FullName, 1);
            }
              return objClient;
        }
        public Store.Client.BusinessObject.ClientList GetAllClientList(int ClientID, int Flag, string FlagValue)
        {
            Store.Client.BusinessObject.Client objClient = null;
            Store.Client.BusinessObject.ClientList objClientList = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_Client";
                objClientList = new BusinessObject.ClientList(); 
                paramList.Add(new SQLParameter("@ClientID",ClientID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objClient = new BusinessObject.Client();
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false) 
                    {
                        objClient.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientName")) == false)
                    {
                        objClient.ClientName = dr.GetString(dr.GetOrdinal("ClientName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientDisplayName")) == false)
                    {
                        objClient.ClientDisplayName = dr.GetString(dr.GetOrdinal("ClientDisplayName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Address")) == false)
                    {
                        objClient.Address = dr.GetString(dr.GetOrdinal("Address"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CityID")) == false)
                    {
                        objClient.CityID = dr.GetInt32(dr.GetOrdinal("CityID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CityName")) == false)
                    {
                        objClient.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StateID")) == false)
                    {
                        objClient.StateID = dr.GetInt32(dr.GetOrdinal("StateID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StateName")) == false)
                    {
                        objClient.StateName = dr.GetString(dr.GetOrdinal("StateName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryID")) == false)
                    {
                        objClient.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryName")) == false)
                    {
                        objClient.CountryName = dr.GetString(dr.GetOrdinal("CountryName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PinID")) == false)
                    {
                        objClient.PinID = dr.GetInt32(dr.GetOrdinal("PinID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objClient.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objClient.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objClient.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objClient.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objClient.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objClient.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    objClientList.Add(objClient);
                }
                dr.Close();
                
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Client).FullName, 1);
            }
            return objClientList;
        }
        public Store.Common.MessageInfo ManageClient(Store.Client.BusinessObject.Client objClient, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageClient";
                paramList.Add(new SQLParameter("@ClientID",objClient.ClientID));
                paramList.Add(new SQLParameter("@ClientName",objClient.ClientName));
                paramList.Add(new SQLParameter("@ClientDisplayName", objClient.ClientDisplayName));
                paramList.Add(new SQLParameter("@Address", objClient.Address));
                paramList.Add(new SQLParameter("@CityID", objClient.CityID));
                paramList.Add(new SQLParameter("@StateID", objClient.StateID));
                paramList.Add(new SQLParameter("@CountryID", objClient.CountryID));
                paramList.Add(new SQLParameter("@PinID", objClient.PinID));
                if(cmdMode==CommandMode.N)
                    paramList.Add(new SQLParameter("@UserId", objClient.CreatedBy));
                else
                    paramList.Add(new SQLParameter("@UserId", objClient.ModifiedBy));
                paramList.Add(new SQLParameter("@ReferenceID", objClient.ReferenceID));
                paramList.Add(new SQLParameter("@IsActive", objClient.IsActive));
                paramList.Add(new SQLParameter("@CMDMode", cmdMode));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                if (dr.Read())
                {
                    objMessageInfo = new Store.Common.MessageInfo();
                    //objMessageInfo = new Pareeksha.Common.MessageInfo();
                    objMessageInfo.ErrorCode = Convert.ToInt32(dr["ErrorCode"]);
                    objMessageInfo.ErrorMessage = Convert.ToString(dr["ErrorMessage"]);
                    objMessageInfo.TranID = Convert.ToInt32(dr["TranID"]);
                    objMessageInfo.TranCode = Convert.ToString(dr["TranCode"]);
                    objMessageInfo.TranMessage = Convert.ToString(dr["TranMessage"]);
                }
                
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Client).FullName, 1);
            }
            return objMessageInfo;
        }
    }
}
