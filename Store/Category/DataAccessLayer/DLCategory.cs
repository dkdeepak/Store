using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.Category.DataAccessLayer
{
    public class Category
    {
        public Store.Category.BusinessObject.CategoryList GetAllCategoryList(int CategoryID, int Flag, string FlagValue)
        {
            Store.Category.BusinessObject.CategoryList objCategoryList = new BusinessObject.CategoryList();
            Store.Category.BusinessObject.Category objCategory = new BusinessObject.Category();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_Category";
                paramList.Add(new SQLParameter("@CategoryI", CategoryID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", Flag));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objCategory = new BusinessObject.Category();
                    if (dr.IsDBNull(dr.GetOrdinal("CategoryID")) == false)
                    {
                        objCategory.CategoryID = dr.GetInt32(dr.GetOrdinal("CategoryID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CategoryName")) == false))
                    {
                        objCategory.CategoryName = dr.GetString(dr.GetOrdinal("CategoryName"));
                    }

                    if ((dr.IsDBNull(dr.GetOrdinal("ParentCategoryID")) == false))
                    {
                        objCategory.ParentCategoryID = dr.GetInt32(dr.GetOrdinal("ParentCategoryID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ParentCategory")) == false))
                    {
                        objCategory.ParentCategory = dr.GetString(dr.GetOrdinal("ParentCategory"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ClientID")) == false))
                    {
                        objCategory.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objCategory.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objCategory.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objCategory.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objCategory.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objCategory.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID")); 
                    }
                    objCategoryList.Add(objCategory);
                }
                dr.Close();
                
            }

            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Category).FullName, 1);
            }
            return objCategoryList;
        }
        public Store.Category.BusinessObject.Category GetAllCategory(int CategoryID, int Flag, string FlagValue)
        {
            Store.Category.BusinessObject.Category objCategory = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_Category";
                paramList.Add(new SQLParameter("@CategoryID", CategoryID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", Flag));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objCategory = new BusinessObject.Category();
                    if (dr.IsDBNull(dr.GetOrdinal("CategoryID")) == false)
                    {
                        objCategory.CategoryID = dr.GetInt32(dr.GetOrdinal("CategoryID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CategoryName")) == false))
                    {
                        objCategory.CategoryName = dr.GetString(dr.GetOrdinal("CategoryName"));
                    }

                    if ((dr.IsDBNull(dr.GetOrdinal("ParentCategoryID")) == false))
                    {
                        objCategory.ParentCategoryID = dr.GetInt32(dr.GetOrdinal("ParentCategoryID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ParentCategory")) == false))
                    {
                        objCategory.ParentCategory = dr.GetString(dr.GetOrdinal("ParentCategory"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ClientID")) == false))
                    {
                        objCategory.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objCategory.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objCategory.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objCategory.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objCategory.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objCategory.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID")); ;
                    }
                    
                }
                dr.Close();
                
            }           
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Category).FullName, 1);
            }
            return objCategory;

        }
        public Store.Common.MessageInfo ManageCategory(Store.Category.BusinessObject.Category objCategory, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageCategory";
                param.Add(new SQLParameter("@CategoryI", objCategory.CategoryID));
                param.Add(new SQLParameter("@CategoryName", objCategory.CategoryName));
                param.Add(new SQLParameter("@ParentCategoryID", objCategory.ParentCategoryID));
                if (cmdMode==CommandMode.N)
                    param.Add(new SQLParameter("@UserId", objCategory.CreatedBy));
                else
                    param.Add(new SQLParameter("@UserId", objCategory.ModifiedBy));
                param.Add(new SQLParameter("@ReferenceID", objCategory.ReferenceID));
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
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Category).FullName, 1);
            }
            return objMessageInfo;
        }
    }
}