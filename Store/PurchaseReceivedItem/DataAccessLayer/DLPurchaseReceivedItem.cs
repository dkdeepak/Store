using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.PurchaseReceivedItem.DataAccessLayer
{
    public class PurchaseReceivedItem
    {
        public Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem GetAllPurchaseReceivedItem(int PurchaseReceivedItemID, int Flag, string FlagValue)
        {
            Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem objPurchaseReceivedItem = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_PurchaseReceivedItem";
                paramList.Add(new SQLParameter("@PurchaseReceivedItemID", PurchaseReceivedItemID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objPurchaseReceivedItem = new BusinessObject.PurchaseReceivedItem();
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseItemReceivedID")) == false)
                    {
                        objPurchaseReceivedItem.PurchaseItemReceivedID = dr.GetInt32(dr.GetOrdinal("PurchaseItemReceivedID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseOrderID")) == false)
                    {
                        objPurchaseReceivedItem.PurchaseOrderID = dr.GetInt32(dr.GetOrdinal("PurchaseOrderID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseReceivedID")) == false)
                    {
                        objPurchaseReceivedItem.PurchaseReceivedID = dr.GetInt32(dr.GetOrdinal("PurchaseReceivedID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemID")) == false)
                    {
                        objPurchaseReceivedItem.ItemID = dr.GetInt32(dr.GetOrdinal("ItemID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemUnit")) == false)
                    {
                        objPurchaseReceivedItem.ItemUnit = dr.GetString(dr.GetOrdinal("ItemUnit"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Description")) == false)
                    {
                        objPurchaseReceivedItem.Description = dr.GetString(dr.GetOrdinal("Description"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPrice")) == false)
                    {
                        objPurchaseReceivedItem.ItemPrice = dr.GetDecimal(dr.GetOrdinal("ItemPrice"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objPurchaseReceivedItem.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objPurchaseReceivedItem.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objPurchaseReceivedItem.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objPurchaseReceivedItem.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objPurchaseReceivedItem.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objPurchaseReceivedItem.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objPurchaseReceivedItem.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    dr.Close();
                }
                return objPurchaseReceivedItem;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItemList GetAllPurchaseReceivedItemList(int PurchaseItemReceivedID, int Flag, string FlagValue)
        {
            Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem objPurchaseReceivedItem = null;
            Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItemList objPurchaseReceivedItemList = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_PurchaseReceivedItem";
                objPurchaseReceivedItemList = new BusinessObject.PurchaseReceivedItemList();
                paramList.Add(new SQLParameter("@PurchaseItemReceivedID", PurchaseItemReceivedID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objPurchaseReceivedItem = new BusinessObject.PurchaseReceivedItem();
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseItemReceivedID")) == false)
                    {
                        objPurchaseReceivedItem.PurchaseItemReceivedID = dr.GetInt32(dr.GetOrdinal("PurchaseItemReceivedID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseOrderID")) == false)
                    {
                        objPurchaseReceivedItem.PurchaseOrderID = dr.GetInt32(dr.GetOrdinal("PurchaseOrderID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseReceivedID")) == false)
                    {
                        objPurchaseReceivedItem.PurchaseReceivedID = dr.GetInt32(dr.GetOrdinal("PurchaseReceivedID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemID")) == false)
                    {
                        objPurchaseReceivedItem.ItemID = dr.GetInt32(dr.GetOrdinal("ItemID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPrefix")) == false)
                    {
                        objPurchaseReceivedItem.ItemPrefix = dr.GetString(dr.GetOrdinal("ItemPrefix"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemUnit")) == false)
                    {
                        objPurchaseReceivedItem.ItemUnit = dr.GetString(dr.GetOrdinal("ItemUnit"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Description")) == false)
                    {
                        objPurchaseReceivedItem.Description = dr.GetString(dr.GetOrdinal("Description"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPrice")) == false)
                    {
                        objPurchaseReceivedItem.ItemPrice = dr.GetDecimal(dr.GetOrdinal("ItemPrice"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objPurchaseReceivedItem.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objPurchaseReceivedItem.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objPurchaseReceivedItem.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objPurchaseReceivedItem.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objPurchaseReceivedItem.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objPurchaseReceivedItem.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objPurchaseReceivedItem.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    objPurchaseReceivedItemList.Add(objPurchaseReceivedItem);
                }
                dr.Close();
                return objPurchaseReceivedItemList;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Store.Common.MessageInfo ManagePurchaseReceived(Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem objPurchaseReceivedItem, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;

            try
            {
                SQL = "USP_PurchaseReceivedItem";
                param.Add(new SQLParameter("@PurchaseItemReceivedID", objPurchaseReceivedItem.PurchaseItemReceivedID));
                param.Add(new SQLParameter("@PurchaseReceivedID", objPurchaseReceivedItem.PurchaseReceivedID));
                param.Add(new SQLParameter("@PurchaseOrderID", objPurchaseReceivedItem.PurchaseOrderID));
                param.Add(new SQLParameter("@ItemID", objPurchaseReceivedItem.ItemID));
                param.Add(new SQLParameter("@ItemUnit", objPurchaseReceivedItem.ItemUnit));
                param.Add(new SQLParameter("@Description", objPurchaseReceivedItem.Description));
                param.Add(new SQLParameter("@ItemPrice", objPurchaseReceivedItem.ItemPrice));
                param.Add(new SQLParameter("@TotalPrice", objPurchaseReceivedItem.TotalPrice));

                param.Add(new SQLParameter("@UserId", objPurchaseReceivedItem.CreatedBy));
                param.Add(new SQLParameter("@ReferenceID", objPurchaseReceivedItem.ReferenceID));
                param.Add(new SQLParameter("@IsActive", objPurchaseReceivedItem.IsActive));

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