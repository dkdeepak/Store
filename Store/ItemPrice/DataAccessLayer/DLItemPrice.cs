using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.ItemPrice.DataAccessLayer
{
    public class ItemPrice
    {
        public Store.ItemPrice.BusinessObject.ItemPriceList GetAllItemPriceList(int ItemPriceID, int Flag, string FlagValue)
        {
            Store.ItemPrice.BusinessObject.ItemPriceList objItemPriceList = new BusinessObject.ItemPriceList();
            Store.ItemPrice.BusinessObject.ItemPrice objItemPrice = new BusinessObject.ItemPrice();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_ItemPrice";
                objItemPriceList = new BusinessObject.ItemPriceList();
                paramList.Add(new SQLParameter("@ItemPriceID", ItemPriceID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objItemPrice = new BusinessObject.ItemPrice();
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPriceID")) == false)
                    {
                        objItemPrice.ItemPriceID = dr.GetInt32(dr.GetOrdinal("ItemPriceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemID")) == false)
                    {
                        objItemPrice.ItemID = dr.GetInt32(dr.GetOrdinal("ItemID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPrefix")) == false)
                    {
                        objItemPrice.ItemPrefix = dr.GetString(dr.GetOrdinal("ItemPrefix"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemCostPricePerUnit")) == false)
                    {
                        objItemPrice.ItemCostPricePerUnit = dr.GetDecimal(dr.GetOrdinal("ItemCostPricePerUnit"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemSalePricePerUnit")) == false)
                    {
                        objItemPrice.ItemSalePricePerUnit = dr.GetDecimal(dr.GetOrdinal("ItemSalePricePerUnit"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemDiscountPercentagePerUnit")) == false)
                    {
                        objItemPrice.ItemDiscountPercentagePerUnit = dr.GetDecimal(dr.GetOrdinal("ItemDiscountPercentagePerUnit"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("WindowFrom")) == false)
                    {
                        objItemPrice.WindowFrom = dr.GetDateTime(dr.GetOrdinal("WindowFrom"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("WindowTo")) == false)
                    {
                        objItemPrice.WindowTo = dr.GetDateTime(dr.GetOrdinal("WindowTo"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CategoryID")) == false)
                    {
                        objItemPrice.CategoryID = dr.GetInt32(dr.GetOrdinal("CategoryID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CategoryName")) == false)
                    {
                        objItemPrice.CategoryName = dr.GetString(dr.GetOrdinal("CategoryName"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objItemPrice.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objItemPrice.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objItemPrice.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objItemPrice.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objItemPrice.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("BatchNo")) == false)
                    {
                        objItemPrice.BatchNo = dr.GetString(dr.GetOrdinal("BatchNo"));
                    }
                    objItemPriceList.Add(objItemPrice);
                }
                dr.Close();
                return objItemPriceList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.ItemPrice.BusinessObject.ItemPrice GetAllItemPrice(int ItemPriceID, int Flag, string FlagValue)
        {
            Store.ItemPrice.BusinessObject.ItemPrice objItemPrice = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_ItemPrice";
                paramList.Add(new SQLParameter("@ItemPriceID", ItemPriceID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objItemPrice = new BusinessObject.ItemPrice();
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPriceID")) == false)
                    {
                        objItemPrice.ItemPriceID = dr.GetInt32(dr.GetOrdinal("ItemPriceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemID")) == false)
                    {
                        objItemPrice.ItemID = dr.GetInt32(dr.GetOrdinal("ItemID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPrefix")) == false)
                    {
                        objItemPrice.ItemPrefix = dr.GetString(dr.GetOrdinal("ItemPrefix"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemCostPricePerUnit")) == false)
                    {
                        objItemPrice.ItemCostPricePerUnit = dr.GetDecimal(dr.GetOrdinal("ItemCostPricePerUnit"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemSalePricePerUnit")) == false)
                    {
                        objItemPrice.ItemSalePricePerUnit = dr.GetDecimal(dr.GetOrdinal("ItemSalePricePerUnit"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemDiscountPercentagePerUnit")) == false)
                    {
                        objItemPrice.ItemDiscountPercentagePerUnit = dr.GetDecimal(dr.GetOrdinal("ItemDiscountPercentagePerUnit"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("WindowFrom")) == false)
                    {
                        objItemPrice.WindowFrom = dr.GetDateTime(dr.GetOrdinal("WindowFrom"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("WindowTo")) == false)
                    {
                        objItemPrice.WindowTo = dr.GetDateTime(dr.GetOrdinal("WindowTo"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CategoryID")) == false)
                    {
                        objItemPrice.CategoryID = dr.GetInt32(dr.GetOrdinal("CategoryID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CategoryName")) == false)
                    {
                        objItemPrice.CategoryName = dr.GetString(dr.GetOrdinal("CategoryName"));
                    }

                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objItemPrice.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));                        
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objItemPrice.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));                        
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objItemPrice.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));                       
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objItemPrice.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objItemPrice.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID")); 
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("BatchNo")) == false)
                    {
                        objItemPrice.BatchNo = dr.GetString(dr.GetOrdinal("BatchNo"));
                    }
                    
                }
                dr.Close();
                return objItemPrice;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManageItemPrice(Store.ItemPrice.BusinessObject.ItemPrice objItemPrice, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_Manage_ItemPrice";
                param.Add(new SQLParameter("@ItemPriceID",objItemPrice.ItemPriceID));
                param.Add(new SQLParameter("@ItemID",objItemPrice.ItemID));                
                param.Add(new SQLParameter("@ItemCostPricePerUnit",objItemPrice.ItemCostPricePerUnit));
                param.Add(new SQLParameter("@ItemSalePricePerUnit",objItemPrice.ItemSalePricePerUnit));
                param.Add(new SQLParameter("@ItemDiscountPercentagePerUnit",objItemPrice.ItemDiscountPercentagePerUnit));
                param.Add(new SQLParameter("@WindowFrom",objItemPrice.WindowFrom));
                param.Add(new SQLParameter("@WindowTo",objItemPrice.WindowTo));
                param.Add(new SQLParameter("@CategoryID",objItemPrice.CategoryID));               
                param.Add(new SQLParameter("@BatchNo",objItemPrice.BatchNo));
                param.Add(new SQLParameter("@UserId", objItemPrice.CreatedBy));
                param.Add(new SQLParameter("@ReferenceID", objItemPrice.ReferenceID));
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
