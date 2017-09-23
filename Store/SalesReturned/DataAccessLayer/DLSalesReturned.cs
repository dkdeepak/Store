using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.SalesReturned.DataAccessLayer
{
    public class SalesReturned
    {
        public Store.SalesReturned.BusinessObject.SalesReturned GetAllSalesReturned(int SalesReturnedID, int Flag, string FlagValue)
        {
            Store.SalesReturned.BusinessObject.SalesReturned objSalesReturned = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_SalesReturn";
                paramList.Add(new SQLParameter("@SalesReturnedID", SalesReturnedID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    if (dr.IsDBNull(dr.GetOrdinal("SalesReturnedID")) == false)
                    {
                        objSalesReturned.SalesReturnedID = dr.GetInt32(dr.GetOrdinal("SalesReturnedID"));
                    }

                    if (dr.IsDBNull(dr.GetOrdinal("VendorID")) == false)
                    {
                        objSalesReturned.VendorID = dr.GetInt32(dr.GetOrdinal("VendorID"));
                    }

                    if (dr.IsDBNull(dr.GetOrdinal("VendorName")) == false)
                    {
                        objSalesReturned.VendorName = dr.GetString(dr.GetOrdinal("VendorName"));
                    }

                    if (dr.IsDBNull(dr.GetOrdinal("SalesReturnDate")) == false)
                    {
                        objSalesReturned.SalesReturnDate = dr.GetDateTime(dr.GetOrdinal("SalesReturnDate"));
                    }

                    if (dr.IsDBNull(dr.GetOrdinal("TotalSalesReturnAmount")) == false)
                    {
                        objSalesReturned.TotalSalesReturnAmount = dr.GetDecimal(dr.GetOrdinal("TotalSalesReturnAmount"));
                    }

                    if (dr.IsDBNull(dr.GetOrdinal("TaxValue")) == false)
                    {
                        objSalesReturned.TaxValue = dr.GetDecimal(dr.GetOrdinal("TaxValue"));    
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ShippingAndHandlingCost")) == false)
                    {
                        objSalesReturned.ShippingAndHandlingCost = dr.GetDecimal(dr.GetOrdinal("ShippingAndHandlingCost"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("MiscCost")) == false)
                    {
                        objSalesReturned.MiscCost = dr.GetDecimal(dr.GetOrdinal("MiscCost"));
                    }

                    if (dr.IsDBNull(dr.GetOrdinal("SalesOrderID")) == false)
                    {
                        objSalesReturned.SalesOrderID = dr.GetInt32(dr.GetOrdinal("SalesOrderID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objSalesReturned.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objSalesReturned.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objSalesReturned.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objSalesReturned.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objSalesReturned.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objSalesReturned.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objSalesReturned.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    dr.Close();
                }
                return objSalesReturned;
                
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.SalesReturned.BusinessObject.SalesReturnedList GetAllSalesReturnedList(int SalesReturnedID, int Flag, string FlagValue)
        {
            Store.SalesReturned.BusinessObject.SalesReturned objSalesReturned = null;
            Store.SalesReturned.BusinessObject.SalesReturnedList objSalesReturnedList = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_SalesReturn";
                objSalesReturnedList = new BusinessObject.SalesReturnedList();
                paramList.Add(new SQLParameter("@SalesReturnedID", SalesReturnedID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objSalesReturned = new BusinessObject.SalesReturned();
                    if (dr.IsDBNull(dr.GetOrdinal("SalesReturnedID")) == false)
                    {
                        objSalesReturned.SalesReturnedID = dr.GetInt32(dr.GetOrdinal("SalesReturnedID"));
                    }

                    if (dr.IsDBNull(dr.GetOrdinal("VendorID")) == false)
                    {
                        objSalesReturned.VendorID = dr.GetInt32(dr.GetOrdinal("VendorID"));
                    }
                    //if (dr.IsDBNull(dr.GetOrdinal("VendorName")) == false)
                    //{
                    //    objSalesReturned.VendorName = dr.GetString(dr.GetOrdinal("VendorName"));
                    //}
                    if (dr.IsDBNull(dr.GetOrdinal("SalesReturnDate")) == false)
                    {
                        objSalesReturned.SalesReturnDate = dr.GetDateTime(dr.GetOrdinal("SalesReturnDate"));
                    }

                    if (dr.IsDBNull(dr.GetOrdinal("TotalSalesReturnAmount")) == false)
                    {
                        objSalesReturned.TotalSalesReturnAmount = dr.GetDecimal(dr.GetOrdinal("TotalSalesReturnAmount"));
                    }

                    if (dr.IsDBNull(dr.GetOrdinal("TaxValue")) == false)
                    {
                        objSalesReturned.TaxValue = dr.GetDecimal(dr.GetOrdinal("TaxValue"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ShippingAndHandlingCost")) == false)
                    {
                        objSalesReturned.ShippingAndHandlingCost = dr.GetDecimal(dr.GetOrdinal("ShippingAndHandlingCost"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("MiscCost")) == false)
                    {
                        objSalesReturned.MiscCost = dr.GetDecimal(dr.GetOrdinal("MiscCost"));
                    }

                    if (dr.IsDBNull(dr.GetOrdinal("SalesOrderID")) == false)
                    {
                        objSalesReturned.SalesOrderID = dr.GetInt32(dr.GetOrdinal("SalesOrderID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objSalesReturned.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objSalesReturned.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objSalesReturned.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objSalesReturned.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objSalesReturned.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objSalesReturned.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objSalesReturned.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    objSalesReturnedList.Add(objSalesReturned);
                }
                dr.Close();
                return objSalesReturnedList;

            }
            catch (Exception)
            {
                throw;
            }  
        }
        public Store.Common.MessageInfo ManageSaleRetuned(Store.SalesReturned.BusinessObject.SalesReturned objSalesReturned, CommandMode cmdMode)
        {
            string SQL = "USP_SalesReturned";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_SalesReturned";
                param.Add(new SQLParameter("@SalesReturnedID", objSalesReturned.SalesReturnedID));
                param.Add(new SQLParameter("@VendorID", objSalesReturned.VendorID));
                param.Add(new SQLParameter("@TotalSalesReturnAmount", objSalesReturned.TotalSalesReturnAmount));
                param.Add(new SQLParameter("@SalesOrderID", objSalesReturned.SalesOrderID));
                param.Add(new SQLParameter("@TaxValue", objSalesReturned.TaxValue));
                param.Add(new SQLParameter("@ShippingAndHandlingCost", objSalesReturned.ShippingAndHandlingCost));
                param.Add(new SQLParameter("@MiscCost", objSalesReturned.MiscCost));
                param.Add(new SQLParameter("@UserId", objSalesReturned.CreatedBy));
                param.Add(new SQLParameter("@ReferenceID", objSalesReturned.ReferenceID));
                param.Add(new SQLParameter("@CMDMode", cmdMode));
                param.Add(new SQLParameter("@IsActive", objSalesReturned.IsActive));
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
        public Store.Common.MessageInfo ManageSaleRetunedItem(Store.SaleReturnItem.BusinessObject.SaleReturnItem objSaleReturnItem, int cmdMode)
        {

            string SQL = "dbo.USP_SalesReturnItem";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_SalesReturnItem";
                param.Add(new SQLParameter("@SaleReturnItemID", objSaleReturnItem.SaleReturnItemID));
                param.Add(new SQLParameter("@SalesReturnID", objSaleReturnItem.SalesReturnID));
                param.Add(new SQLParameter("@SalesOrderID", objSaleReturnItem.SalesOrderID));
                param.Add(new SQLParameter("@ItemPrefix", objSaleReturnItem.ItemPrefix));
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