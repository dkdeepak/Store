using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.SaleReturnItem.DataAccessLayer
{
    public class SaleReturnItem
    {
        public Store.SaleReturnItem.BusinessObject.SaleReturnItemList GetAllSaleReturnItemList(int SaleReturnItemID, int Flag, string FlagValue)
        {
            Store.SaleReturnItem.BusinessObject.SaleReturnItem objSaleReturnItem = new BusinessObject.SaleReturnItem();
            Store.SaleReturnItem.BusinessObject.SaleReturnItemList objSaleReturnItemList = new BusinessObject.SaleReturnItemList();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_SalesReturnItem";
                paramList.Add(new SQLParameter("@SaleReturnItemID",SaleReturnItemID));
                paramList.Add(new SQLParameter("@Flag",Flag));
                paramList.Add(new SQLParameter("@FlagValue",FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objSaleReturnItem = new BusinessObject.SaleReturnItem();
                    if (dr.IsDBNull(dr.GetOrdinal("SaleReturnItemID")) == false)
                    {
                        objSaleReturnItem.SaleReturnItemID = dr.GetInt32(dr.GetOrdinal("SaleReturnItemID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("SalesReturnID")) == false)
                    {
                        objSaleReturnItem.SalesReturnID = dr.GetInt32(dr.GetOrdinal("SalesReturnID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("SalesOrderID")) == false)
                    {
                        objSaleReturnItem.SalesOrderID = dr.GetInt32(dr.GetOrdinal("SalesOrderID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemId")) == false)
                    {
                        objSaleReturnItem.ItemId = dr.GetInt32(dr.GetOrdinal("ItemId"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPrefix")) == false)
                    {
                        objSaleReturnItem.ItemPrefix = dr.GetString(dr.GetOrdinal("ItemPrefix"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemUnit")) == false)
                    {
                        objSaleReturnItem.ItemUnit = dr.GetString(dr.GetOrdinal("ItemUnit"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Description")) == false)
                    {
                        objSaleReturnItem.Description = dr.GetString(dr.GetOrdinal("Description"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPrice")) == false)
                    {
                        objSaleReturnItem.ItemPrice = dr.GetDecimal(dr.GetOrdinal("ItemPrice"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objSaleReturnItem.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objSaleReturnItem.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objSaleReturnItem.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objSaleReturnItem.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objSaleReturnItem.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    { 
                        objSaleReturnItem.ModifiedOn=dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objSaleReturnItem.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objSaleReturnItem.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    objSaleReturnItemList.Add(objSaleReturnItem);
                }
                dr.Close();
                return objSaleReturnItemList;
            }
            catch
            {
                throw;
            }
        }
        public Store.SaleReturnItem.BusinessObject.SaleReturnItem GetAllSaleReturnItem(int SaleReturnItemID, int Flag, string FlagValue)
        {
            Store.SaleReturnItem.BusinessObject.SaleReturnItem objSaleReturnItem =null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_SaleReturnItem";
                paramList.Add(new SQLParameter("@SaleReturnItemID", SaleReturnItemID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objSaleReturnItem = new BusinessObject.SaleReturnItem();
                    if (dr.IsDBNull(dr.GetOrdinal("SaleReturnItemID")) == false)
                    {
                        objSaleReturnItem.SaleReturnItemID = dr.GetInt32(dr.GetOrdinal("SaleReturnItemID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("SalesRetrunID")) == false)
                    {
                        objSaleReturnItem.SalesReturnID = dr.GetInt32(dr.GetOrdinal("SalesRetrunID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("SalesOrderID")) == false)
                    {
                        objSaleReturnItem.SalesOrderID = dr.GetInt32(dr.GetOrdinal("SalesOrderID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemId")) == false)
                    {
                        objSaleReturnItem.ItemId = dr.GetInt32(dr.GetOrdinal("ItemId"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPrefix")) == false)
                    {
                        objSaleReturnItem.ItemPrefix = dr.GetString(dr.GetOrdinal("ItemPrefix"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemUnit")) == false)
                    {
                        objSaleReturnItem.ItemUnit = dr.GetString(dr.GetOrdinal("ItemUnit"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Description")) == false)
                    {
                        objSaleReturnItem.Description = dr.GetString(dr.GetOrdinal("Description"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPrice")) == false)
                    {
                        objSaleReturnItem.ItemPrice = dr.GetDecimal(dr.GetOrdinal("ItemPrice"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objSaleReturnItem.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objSaleReturnItem.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objSaleReturnItem.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objSaleReturnItem.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objSaleReturnItem.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objSaleReturnItem.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objSaleReturnItem.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objSaleReturnItem.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    dr.Close();
                }
                return objSaleReturnItem;
            }

            catch
            {
                throw;
            }

        }
        public Store.Common.MessageInfo ManageSaleReturnItem(Store.SaleReturnItem.BusinessObject.SaleReturnItem objSaleReturnItem, CommandMode cmdMode)
        {
            string SQL = "USP_ManageSaleReturnItem";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_SalesReturnItem";
                param.Add(new SQLParameter("@SaleReturnItemID", objSaleReturnItem.SaleReturnItemID));
                param.Add(new SQLParameter("@SalesReturnID", objSaleReturnItem.SalesReturnID));
                param.Add(new SQLParameter("@SalesOrderID", objSaleReturnItem.SalesOrderID));
                param.Add(new SQLParameter("@ItemID", objSaleReturnItem.ItemId));
                param.Add(new SQLParameter("@ItemUnit", objSaleReturnItem.ItemUnit));
                param.Add(new SQLParameter("@Description", objSaleReturnItem.Description));
                param.Add(new SQLParameter("@ItemPrice", objSaleReturnItem.ItemPrice));
                param.Add(new SQLParameter("@IsActive", objSaleReturnItem.IsActive));
                param.Add(new SQLParameter("@ReferenceID", objSaleReturnItem.ReferenceID));
                param.Add(new SQLParameter("@UserId", objSaleReturnItem.CreatedBy));
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