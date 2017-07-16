using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.SalesOrderItem.DataAccessLayer
{
    public class SalesOrderItem
    {
        public Store.SalesOrderItem.BusinessObject.SalesOrderItemList GetAllSalesOrderItemList(int SalesOrderItemId, int Flag, string FlagValue)
        {
            Store.SalesOrderItem.BusinessObject.SalesOrderItem objSalesOrderItem = new BusinessObject.SalesOrderItem();
            Store.SalesOrderItem.BusinessObject.SalesOrderItemList objSalesOrderItemList = new BusinessObject.SalesOrderItemList();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_SalesOrderItem";
                paramList.Add(new SQLParameter("@SaleOrderItemID", SalesOrderItemId));
                paramList.Add(new SQLParameter("@Flag",Flag));
                paramList.Add(new SQLParameter("@FlagValue",FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objSalesOrderItem = new BusinessObject.SalesOrderItem();
                    if (dr.IsDBNull(dr.GetOrdinal("SaleOrderItemID")) == false)
                    {
                        objSalesOrderItem.SaleOrderItemID = dr.GetInt32(dr.GetOrdinal("SaleOrderItemID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("SalesOrderID")) == false)
                    {
                        objSalesOrderItem.SalesOrderID = dr.GetInt32(dr.GetOrdinal("SalesOrderID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemId")) == false)
                    {
                        objSalesOrderItem.ItemId = dr.GetInt32(dr.GetOrdinal("ItemId"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPrefix")) == false)
                    {
                        objSalesOrderItem.ItemPrefix = dr.GetString(dr.GetOrdinal("ItemPrefix"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemUnit")) == false)
                    {
                        objSalesOrderItem.ItemUnit = dr.GetString(dr.GetOrdinal("ItemUnit"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Description")) == false)
                    {
                        objSalesOrderItem.Description = dr.GetString(dr.GetOrdinal("Description"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemCostPrice")) == false)
                    {
                        objSalesOrderItem.ItemCostPrice = dr.GetDecimal(dr.GetOrdinal("ItemCostPrice"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemSalePrice")) == false)
                    {
                        objSalesOrderItem.ItemSalePrice = dr.GetDecimal(dr.GetOrdinal("ItemSalePrice"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemDiscountPercentage")) == false)
                    {
                        objSalesOrderItem.ItemDiscountPercentage = dr.GetDecimal(dr.GetOrdinal("ItemDiscountPercentage"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemDiscount")) == false)
                    {
                        objSalesOrderItem.ItemDiscount = dr.GetDecimal(dr.GetOrdinal("ItemDiscount"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objSalesOrderItem.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objSalesOrderItem.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objSalesOrderItem.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objSalesOrderItem.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objSalesOrderItem.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    { 
                        objSalesOrderItem.ModifiedOn=dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objSalesOrderItem.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objSalesOrderItem.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    objSalesOrderItemList.Add(objSalesOrderItem);
                }
                dr.Close();
                return objSalesOrderItemList;
            }
            catch
            {
                throw;
            }
        }
        public Store.SalesOrderItem.BusinessObject.SalesOrderItem GetAllSalesOrderItem(int SalesOrderItemID, int Flag, string FlagValue)
        {
            Store.SalesOrderItem.BusinessObject.SalesOrderItem objSalesOrderItem =null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_SalesOrderItem";
                paramList.Add(new SQLParameter("@SalesOrderItemID", SalesOrderItemID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objSalesOrderItem = new BusinessObject.SalesOrderItem();
                    if (dr.IsDBNull(dr.GetOrdinal("SaleOrderItemID")) == false)
                    {
                        objSalesOrderItem.SaleOrderItemID = dr.GetInt32(dr.GetOrdinal("SaleOrderItemID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("SalesOrderID")) == false)
                    {
                        objSalesOrderItem.SalesOrderID = dr.GetInt32(dr.GetOrdinal("SalesOrderID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("SalesOrderID")) == false)
                    {
                        objSalesOrderItem.SalesOrderID = dr.GetInt32(dr.GetOrdinal("SalesOrderID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemId")) == false)
                    {
                        objSalesOrderItem.ItemId = dr.GetInt32(dr.GetOrdinal("ItemId"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPrefix")) == false)
                    {
                        objSalesOrderItem.ItemPrefix = dr.GetString(dr.GetOrdinal("ItemPrefix"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemUnit")) == false)
                    {
                        objSalesOrderItem.ItemUnit = dr.GetString(dr.GetOrdinal("ItemUnit"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Description")) == false)
                    {
                        objSalesOrderItem.Description = dr.GetString(dr.GetOrdinal("Description"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemCostPrice")) == false)
                    {
                        objSalesOrderItem.ItemCostPrice = dr.GetDecimal(dr.GetOrdinal("ItemCostPrice"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemSalePrice")) == false)
                    {
                        objSalesOrderItem.ItemSalePrice = dr.GetDecimal(dr.GetOrdinal("ItemSalePrice"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemDiscountPercentage")) == false)
                    {
                        objSalesOrderItem.ItemDiscountPercentage = dr.GetDecimal(dr.GetOrdinal("ItemDiscountPercentage"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objSalesOrderItem.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objSalesOrderItem.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objSalesOrderItem.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objSalesOrderItem.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objSalesOrderItem.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objSalesOrderItem.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objSalesOrderItem.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objSalesOrderItem.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    dr.Close();
                }
                return objSalesOrderItem;
            }

            catch
            {
                throw;
            }

        }
        public Store.Common.MessageInfo ManageSalesOrderItem(Store.SalesOrderItem.BusinessObject.SalesOrderItem objSalesOrderItem, CommandMode cmdMode)
        {
            string SQL = "USP_ManageSalesOrderItem";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageSalesOrderItem";
                param.Add(new SQLParameter("@SaleOrderItemID", objSalesOrderItem.SaleOrderItemID));
                param.Add(new SQLParameter("@SalesOrderID", objSalesOrderItem.SalesOrderID));
                param.Add(new SQLParameter("@ItemId", objSalesOrderItem.ItemId));
                param.Add(new SQLParameter("@ItemUnit", objSalesOrderItem.ItemUnit));
                param.Add(new SQLParameter("@Description", objSalesOrderItem.Description));
                param.Add(new SQLParameter("@ItemCostPrice", objSalesOrderItem.ItemCostPrice));
                param.Add(new SQLParameter("@ItemSalePrice", objSalesOrderItem.ItemSalePrice));
                param.Add(new SQLParameter("@ItemDiscountPercentage", objSalesOrderItem.ItemDiscountPercentage));
                param.Add(new SQLParameter("@ItemDiscount", objSalesOrderItem.ItemDiscount));
                param.Add(new SQLParameter("@IsActive", objSalesOrderItem.IsActive));
                param.Add(new SQLParameter("@ReferenceID", objSalesOrderItem.ReferenceID));
                param.Add(new SQLParameter("@UserId", objSalesOrderItem.CreatedBy));
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