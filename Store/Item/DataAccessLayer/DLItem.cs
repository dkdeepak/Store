using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Store.Common;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;

namespace Store.Item.DataAccessLayer
{
    public class Item
    {
        public Store.Item.BusinessObject.ItemList GetAllItemList(int ItemID, int Flag, string FlagValue)
        {
            Store.Item.BusinessObject.ItemList objItemList = new BusinessObject.ItemList();
            Store.Item.BusinessObject.Item objItem = new BusinessObject.Item();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try 
            {
                SQL = "proc_Item";               
                paramList.Add(new SQLParameter("@ItemID",ItemID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objItem =new BusinessObject.Item();
                   
                    if (dr.IsDBNull(dr.GetOrdinal("ItemId")) == false)
                    {
                        objItem.ItemID = dr.GetInt32(dr.GetOrdinal("ItemID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPrefix")) == false)
                    {
                        objItem.ItemPrefix = dr.GetString(dr.GetOrdinal("ItemPrefix"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Barcode")) == false)
                    {
                        objItem.Barcode = dr.GetString(dr.GetOrdinal("Barcode"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemCode")) == false)
                    {
                        objItem.ItemCode = dr.GetString(dr.GetOrdinal("ItemCode"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemDescription")) == false)
                    {
                        objItem.ItemDescription = dr.GetString(dr.GetOrdinal("ItemDescription"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemUnitId")) == false)
                    {
                        objItem.ItemUnitId = dr.GetInt32(dr.GetOrdinal("ItemUnitId"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("UnitName")) == false)
                    {
                        objItem.UnitName = dr.GetString(dr.GetOrdinal("UnitName"));
                    }

                    //if (dr.IsDBNull(dr.GetOrdinal("ItemCostPricePerUnit")) == false)
                    //{
                    //    objItem.ItemCostPricePerUnit = dr.GetDecimal(dr.GetOrdinal("ItemCostPricePerUnit"));
                    //}
                    //if (dr.IsDBNull(dr.GetOrdinal("ItemSalePricePerUnit")) == false)
                    //{
                    //    objItem.ItemSalePricePerUnit = dr.GetDecimal(dr.GetOrdinal("ItemSalePricePerUnit"));
                    //}
                    //if (dr.IsDBNull(dr.GetOrdinal("ItemDiscountPercentagePerUnit")) == false)
                    //{
                    //    objItem.ItemDiscountPercentagePerUnit = dr.GetDecimal(dr.GetOrdinal("ItemDiscountPercentagePerUnit"));
                    //}
                    //if (dr.IsDBNull(dr.GetOrdinal("WindowFrom")) == false)
                    //{
                    //    objItem.WindowFrom = dr.GetDateTime(dr.GetOrdinal("WindowFrom"));
                    //}
                    //if (dr.IsDBNull(dr.GetOrdinal("WindowTo")) == false)
                    //{
                    //    objItem.WindowTo = dr.GetDateTime(dr.GetOrdinal("WindowTo"));
                    //}
                    //if (dr.IsDBNull(dr.GetOrdinal("BatchNo")) == false)
                    //{
                    //    objItem.BatchNo = dr.GetString(dr.GetOrdinal("BatchNo"));
                    //}
                    if (dr.IsDBNull(dr.GetOrdinal("CategoryID")) == false)
                    {
                        objItem.CategoryID = dr.GetInt32(dr.GetOrdinal("CategoryID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CategoryName")) == false)
                    {
                        objItem.CategoryName = dr.GetString(dr.GetOrdinal("CategoryName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objItem.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objItem.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objItem.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objItem.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objItem.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    //if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    //{
                    //    objItem.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    //}
                    objItemList.Add(objItem);

                }
                dr.Close();
                return objItemList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.Item.BusinessObject.Item GetAllItem(string Item, int Flag, string FlagValue)
        {

            Store.Item.BusinessObject.Item objItem = new BusinessObject.Item();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                // SQL = "proc_Item";
                SQL = "proc_ItemDetial";
                paramList.Add(new SQLParameter("@Item", Item));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objItem = new BusinessObject.Item();

                    if (dr.IsDBNull(dr.GetOrdinal("ItemDescription")) == false)
                    {
                        objItem.ItemDescription = dr.GetString(dr.GetOrdinal("ItemDescription"));
                    }

                    //if (dr.IsDBNull(dr.GetOrdinal("ItemCostPricePerUnit")) == false)
                    //{
                    //    objItem.ItemCostPricePerUnit = dr.GetDecimal(dr.GetOrdinal("ItemCostPricePerUnit"));
                    //}
                    //if (dr.IsDBNull(dr.GetOrdinal("ItemSalePricePerUnit")) == false)
                    //{
                    //    objItem.ItemSalePricePerUnit = dr.GetDecimal(dr.GetOrdinal("ItemSalePricePerUnit"));
                    //}
                    //if (dr.IsDBNull(dr.GetOrdinal("ItemDiscountPercentagePerUnit")) == false)
                    //{
                    //    objItem.ItemDiscountPercentagePerUnit = dr.GetDecimal(dr.GetOrdinal("ItemDiscountPercentagePerUnit"));
                    //}

                }
                dr.Close();
                return objItem;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public Store.Common.MessageInfo ManageItem(Store.Item.BusinessObject.Item objItem, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try 
            {
                SQL = "USP_ManageItem";
                param.Add(new SQLParameter("@ItemID", objItem.ItemID));
                //param.Add(new SQLParameter("@ItemPriceID", objItem.ItemPriceID));
                param.Add(new SQLParameter("@ItemPrefix", objItem.ItemPrefix)); 
                param.Add(new SQLParameter("@ItemCode",objItem.ItemCode));
                param.Add(new SQLParameter("@Barcode", objItem.Barcode));
                param.Add(new SQLParameter("@ItemDescription", objItem.ItemDescription));
                param.Add(new SQLParameter("@ItemUnitId",objItem.ItemUnitId));
                //param.Add(new SQLParameter("@ItemCostPricePerUnit", objItem.ItemCostPricePerUnit));
                //param.Add(new SQLParameter("@ItemSalePricePerUnit", objItem.ItemSalePricePerUnit));
                //param.Add(new SQLParameter("@ItemDiscountPercentagePerUnit", objItem.ItemDiscountPercentagePerUnit));
                //param.Add(new SQLParameter("@WindowFrom", objItem.WindowFrom));
                //param.Add(new SQLParameter("@WindowTo", objItem.WindowTo));
                //param.Add(new SQLParameter("@BatchNo", objItem.BatchNo));
                param.Add(new SQLParameter("@CategoryID",objItem.CategoryID));
                param.Add(new SQLParameter("@IsActive", objItem.IsActive));
                param.Add(new SQLParameter("@ReferenceID", objItem.ReferenceID));
                if(cmdMode==CommandMode.N)
                    param.Add(new SQLParameter("@UserId", objItem.CreatedBy));
                else
                    param.Add(new SQLParameter("@UserId", objItem.ModifiedBy));
                param.Add(new SQLParameter("@CMDMode", cmdMode));
                dr = ExecuteQuery.ExecuteReader(SQL,param);
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