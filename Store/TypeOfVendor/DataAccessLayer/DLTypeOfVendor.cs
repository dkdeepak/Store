using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.TypeOfVendor.DataAccessLayer
{
    public class TypeOfVendor
    {
        public Store.TypeOfVendor.BusinessObject.TypeOfVendorList GetAllTypeOfVendorList(int TypeofVendorID, int Flag, string FlagValue)
        {
            Store.TypeOfVendor.BusinessObject.TypeOfVendorList objTypeOfVendorList = new BusinessObject.TypeOfVendorList();
            Store.TypeOfVendor.BusinessObject.TypeOfVendor objTypeOfVendor = new BusinessObject.TypeOfVendor();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_TypeOfVendor";
                paramList.Add(new SQLParameter("@TypeofVendorID", TypeofVendorID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", Flag));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objTypeOfVendor = new BusinessObject.TypeOfVendor();
                    if (dr.IsDBNull(dr.GetOrdinal("TypeofVendorID")) == false)
                    {
                        objTypeOfVendor.TypeofVendorID = dr.GetInt32(dr.GetOrdinal("TypeofVendorID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("TypeofVendorName")) == false))
                    {
                        objTypeOfVendor.TypeofVendorName = dr.GetString(dr.GetOrdinal("TypeofVendorName"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ClientID")) == false))
                    {
                        objTypeOfVendor.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objTypeOfVendor.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objTypeOfVendor.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objTypeOfVendor.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objTypeOfVendor.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objTypeOfVendor.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID")); ;
                    }
                    objTypeOfVendorList.Add(objTypeOfVendor);
                }
                dr.Close();
                return objTypeOfVendorList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.TypeOfVendor.BusinessObject.TypeOfVendor GetAllTypeOfVendor(int TypeofVendorID, int Flag, string FlagValue)
        {
            Store.TypeOfVendor.BusinessObject.TypeOfVendor objTypeOfVendor = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_TypeOfVendor";
                paramList.Add(new SQLParameter("@TypeofVendorID", TypeofVendorID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", Flag));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objTypeOfVendor = new BusinessObject.TypeOfVendor();
                    if (dr.IsDBNull(dr.GetOrdinal("TypeofVendorID")) == false)
                    {
                        objTypeOfVendor.TypeofVendorID = dr.GetInt32(dr.GetOrdinal("TypeofVendorID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("TypeofVendorName")) == false))
                    {
                        objTypeOfVendor.TypeofVendorName = dr.GetString(dr.GetOrdinal("TypeofVendorName"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ClientID")) == false))
                    {
                        objTypeOfVendor.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objTypeOfVendor.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objTypeOfVendor.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objTypeOfVendor.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objTypeOfVendor.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objTypeOfVendor.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID")); ;
                    }
                    
                }
                dr.Close();
                return objTypeOfVendor;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public Store.Common.MessageInfo ManageTypeOfVendor(Store.TypeOfVendor.BusinessObject.TypeOfVendor objTypeOfVendor, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageTypeOfVendor";
                param.Add(new SQLParameter("@TypeofVendorID", objTypeOfVendor.TypeofVendorID));
                param.Add(new SQLParameter("@TypeofVendorName", objTypeOfVendor.TypeofVendorName));
                if(cmdMode==CommandMode.N)
                    param.Add(new SQLParameter("@UserId", objTypeOfVendor.CreatedBy));
                else
                    param.Add(new SQLParameter("@UserId", objTypeOfVendor.ModifiedBy));
                param.Add(new SQLParameter("@ReferenceID", objTypeOfVendor.ReferenceID));
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
            catch (Exception)
            {
                throw;
            }

        }
    }
}