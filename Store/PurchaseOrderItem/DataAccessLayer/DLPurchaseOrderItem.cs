using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.PurchaseOrderItem.DataAccessLayer
{
    public class PurchaseOrderItem
    {
        public Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem GetAllPurchaseOrderItem(int PurchaseOrderItemID, int Flag, string FlagValue)
        {
            Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem objPurchaseOrderItem = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_PurchaseOrderItem";
                paramList.Add(new SQLParameter("@PurchaseOrderItemID", PurchaseOrderItemID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objPurchaseOrderItem = new BusinessObject.PurchaseOrderItem();
                    if (dr.IsDBNull(dr.GetOrdinal("ItemID")) == false)
                    {
                        objPurchaseOrderItem.ItemID = dr.GetInt32(dr.GetOrdinal("ItemID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemUnit")) == false)
                    {
                        objPurchaseOrderItem.ItemUnit = dr.GetString(dr.GetOrdinal("ItemUnit"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Description")) == false)
                    {
                        objPurchaseOrderItem.Description = dr.GetString(dr.GetOrdinal("Description"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPrice")) == false)
                    {
                        objPurchaseOrderItem.ItemPrice = dr.GetDecimal(dr.GetOrdinal("ItemPrice"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TotalPrice")) == false)
                    {
                        objPurchaseOrderItem.TotalPrice = dr.GetDecimal(dr.GetOrdinal("TotalPrice"));
                    }
                    dr.Close();
                }
                return objPurchaseOrderItem;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList GetAllPurchaseOrderItemList(int PurchaseOrderItemID, int Flag, string FlagValue)
        {
            Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem objPurchaseOrderItem = null;
            Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList objPurchaseOrderItemList = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                objPurchaseOrderItemList = new BusinessObject.PurchaseOrderItemList();
                SQL = "proc_PurchaseOrderItem";
                paramList.Add(new SQLParameter("@PurchaseOrderItemID", PurchaseOrderItemID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objPurchaseOrderItem = new BusinessObject.PurchaseOrderItem();

                    if (dr.IsDBNull(dr.GetOrdinal("ItemID")) == false)
                    {
                        objPurchaseOrderItem.ItemID = dr.GetInt32(dr.GetOrdinal("ItemID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPrefix")) == false)
                    {
                        objPurchaseOrderItem.ItemPrefix = dr.GetString(dr.GetOrdinal("ItemPrefix"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemUnit")) == false)
                    {
                        objPurchaseOrderItem.ItemUnit = dr.GetString(dr.GetOrdinal("ItemUnit"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Description")) == false)
                    {
                        objPurchaseOrderItem.Description = dr.GetString(dr.GetOrdinal("Description"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPrice")) == false)
                    {
                        objPurchaseOrderItem.ItemPrice = dr.GetDecimal(dr.GetOrdinal("ItemPrice"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TotalPrice")) == false)
                    {
                        objPurchaseOrderItem.TotalPrice = dr.GetDecimal(dr.GetOrdinal("TotalPrice"));
                    }
                    objPurchaseOrderItemList.Add(objPurchaseOrderItem);
                }
                return objPurchaseOrderItemList;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManagePurchaseOrder(Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem objPurchaseOrderItem, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;

            try
            {
                SQL = "USP_ManagePurchaseOrderItem";

                param.Add(new SQLParameter("@PurchaseOrderID", objPurchaseOrderItem.PurchaseOrderID));
                param.Add(new SQLParameter("@PurchaseOrderItemID", objPurchaseOrderItem.PurchaseOrderItemID));
                param.Add(new SQLParameter("@ItemID", objPurchaseOrderItem.ItemID));
                param.Add(new SQLParameter("@ItemPrefix", objPurchaseOrderItem.ItemPrefix));
                param.Add(new SQLParameter("@Description", objPurchaseOrderItem.Description));
                param.Add(new SQLParameter("@ItemUnit", objPurchaseOrderItem.ItemUnit));
                param.Add(new SQLParameter("@ItemPrice", objPurchaseOrderItem.ItemPrice));
                param.Add(new SQLParameter("@TotalPrice", objPurchaseOrderItem.TotalPrice));
                param.Add(new SQLParameter("@Discount", objPurchaseOrderItem.Discount));
                param.Add(new SQLParameter("@DiscountPre", objPurchaseOrderItem.DiscountPre));
                param.Add(new SQLParameter("@UserId", objPurchaseOrderItem.CreatedBy));
                param.Add(new SQLParameter("@ReferenceID", objPurchaseOrderItem.ReferenceID));
                param.Add(new SQLParameter("@IsActive", objPurchaseOrderItem.IsActive));
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