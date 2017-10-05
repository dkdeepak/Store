using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.TypeOfUser.DataAccessLayer
{
    public class TypeOfUser
    {
        public Store.TypeOfUser.BusinessObject.TypeOfUserList GetAllTypeOfUserList(int TypeofUserID, int Flag, string FlagValue)
        {
            Store.TypeOfUser.BusinessObject.TypeOfUserList objTypeOfUserList = new BusinessObject.TypeOfUserList();
            Store.TypeOfUser.BusinessObject.TypeOfUser objTypeOfUser = new BusinessObject.TypeOfUser();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_TypeOfUser";
                paramList.Add(new SQLParameter("@TypeofUserID", TypeofUserID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", Flag));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objTypeOfUser = new BusinessObject.TypeOfUser();
                    if (dr.IsDBNull(dr.GetOrdinal("TypeofUserID")) == false)
                    {
                        objTypeOfUser.TypeofUserID = dr.GetInt32(dr.GetOrdinal("TypeofUserID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("TypeofUserName")) == false))
                    {
                        objTypeOfUser.TypeofUserName = dr.GetString(dr.GetOrdinal("TypeofUserName"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ClientID")) == false))
                    {
                        objTypeOfUser.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objTypeOfUser.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objTypeOfUser.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objTypeOfUser.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objTypeOfUser.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objTypeOfUser.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID")); ;
                    }
                    objTypeOfUserList.Add(objTypeOfUser);
                }
                dr.Close();
                
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(TypeOfUser).FullName, 1);
                
            }
            return objTypeOfUserList;
        }
        public Store.TypeOfUser.BusinessObject.TypeOfUser GetAllTypeOfUser(int TypeofUserID, int Flag, string FlagValue)
        {
            Store.TypeOfUser.BusinessObject.TypeOfUser objTypeOfUser = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_TypeOfUser";
                paramList.Add(new SQLParameter("@TypeofUserID", TypeofUserID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", Flag));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objTypeOfUser = new BusinessObject.TypeOfUser();
                    if (dr.IsDBNull(dr.GetOrdinal("TypeofUserID")) == false)
                    {
                        objTypeOfUser.TypeofUserID = dr.GetInt32(dr.GetOrdinal("TypeofUserID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("TypeofUserName")) == false))
                    {
                        objTypeOfUser.TypeofUserName = dr.GetString(dr.GetOrdinal("TypeofUserName"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ClientID")) == false))
                    {
                        objTypeOfUser.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objTypeOfUser.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objTypeOfUser.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objTypeOfUser.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objTypeOfUser.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objTypeOfUser.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID")); ;
                    }
                    
                }
                dr.Close();
              
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(TypeOfUser).FullName, 1);
                
            }
            return objTypeOfUser;

        }
        public Store.Common.MessageInfo ManageTypeOfUser(Store.TypeOfUser.BusinessObject.TypeOfUser objTypeOfUser, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageTypeOfUser";
                param.Add(new SQLParameter("@TypeofUserID", objTypeOfUser.TypeofUserID));
                param.Add(new SQLParameter("@TypeofUserName", objTypeOfUser.TypeofUserName));
                if(cmdMode==CommandMode.N)
                    param.Add(new SQLParameter("@UserId", objTypeOfUser.CreatedBy));
                else
                    param.Add(new SQLParameter("@UserId", objTypeOfUser.ModifiedBy));
                param.Add(new SQLParameter("@ReferenceID", objTypeOfUser.ReferenceID));
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
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(TypeOfUser).FullName, 1);
                
            }
            return objMessageInfo;

        }
    }
}