using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;

namespace Store.State.DataAcessLayer
{
    public class State
    {
        public Store.State.BusinessObject.State GetAllState(int StateID, int Flag, string FlagValue)
        {
            Store.State.BusinessObject.State objState = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "";
                paramList.Add(new SQLParameter("@StateID", StateID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    if (dr.IsDBNull(dr.GetOrdinal("StateID")) == false)
                    {
                        objState.StateID = dr.GetInt32(dr.GetOrdinal("StateID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StateName")) == false)
                    {
                        objState.StateName = dr.GetString(dr.GetOrdinal("StateName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryID")) == false)
                    {
                        objState.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objState.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objState.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objState.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));

                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objState.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objState.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    
                }
                dr.Close();
                return objState;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Store.State.BusinessObject.StateList GetAllStateList(int StateID, int Flag, string FlagValue)
        {
            Store.State.BusinessObject.State objState = null;
            Store.State.BusinessObject.StateList objStateList = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_State";
                objStateList = new BusinessObject.StateList();
                paramList.Add(new SQLParameter("@StateID", StateID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objState = new BusinessObject.State();
                    if (dr.IsDBNull(dr.GetOrdinal("StateID")) == false)
                    {
                        objState.StateID = dr.GetInt32(dr.GetOrdinal("StateID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StateName")) == false)
                    {
                        objState.StateName = dr.GetString(dr.GetOrdinal("StateName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryID")) == false)
                    {
                        objState.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryName")) == false)
                    {
                        objState.CountryName = dr.GetString(dr.GetOrdinal("CountryName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objState.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objState.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objState.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objState.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objState.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    objStateList.Add(objState);
                    
                }
                dr.Close();
                return objStateList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManageState(Store.State.BusinessObject.State objState, CommandMode cmdMode)
        {
            string SQL = "USP_ManageState";
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                paramList.Add(new SQLParameter("@StateID", objState.StateID));
                paramList.Add(new SQLParameter("@StateName", objState.StateName));
                paramList.Add(new SQLParameter("@CountryID", objState.CountryID));
                if(cmdMode==CommandMode.N)
                    paramList.Add(new SQLParameter("@UserId", objState.CreatedBy));
                else
                    paramList.Add(new SQLParameter("@UserId", objState.ModifiedBy));
                paramList.Add(new SQLParameter("@ReferenceID", objState.ReferenceID));
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
                return objMessageInfo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}