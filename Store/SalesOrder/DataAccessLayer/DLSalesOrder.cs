using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.SalesOrder.DataAccessLayer
{
    public class SalesOrder
    {
        public Store.SalesOrder.BusinessObject.SalesOrderList GetAllSalesOrderList(int SalesOrderID, int Flag, string FlagValue)
        {
            Store.SalesOrder.BusinessObject.SalesOrder objSalesOrder = new BusinessObject.SalesOrder();
            Store.SalesOrder.BusinessObject.SalesOrderList objSalesOrderList = new BusinessObject.SalesOrderList();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_SalesOrder";
                paramList.Add(new SQLParameter("@SalesOrderID",SalesOrderID));
                paramList.Add(new SQLParameter("@Flag",Flag));
                paramList.Add(new SQLParameter("@FlagValue",FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objSalesOrder = new BusinessObject.SalesOrder();
                    
                    if (dr.IsDBNull(dr.GetOrdinal("SalesOrderID")) == false)
                    {
                        objSalesOrder.SalesOrderID = dr.GetInt32(dr.GetOrdinal("SalesOrderID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("VendorID")) == false)
                    {
                        objSalesOrder.VendorID = dr.GetInt32(dr.GetOrdinal("VendorID"));
                    }
                    //if (dr.IsDBNull(dr.GetOrdinal("VendorName")) == false)
                    //{
                    //    objSalesOrder.VendorName = dr.GetString(dr.GetOrdinal("VendorName"));
                    //}
                    if (dr.IsDBNull(dr.GetOrdinal("SaleDate")) == false)
                    {
                        objSalesOrder.SaleDate = dr.GetDateTime(dr.GetOrdinal("SaleDate"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TotalCostAmount")) == false)
                    {
                        objSalesOrder.TotalCostAmount = dr.GetDecimal(dr.GetOrdinal("TotalCostAmount"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TotalSaleAmount")) == false)
                    {
                        objSalesOrder.TotalSaleAmount = dr.GetDecimal(dr.GetOrdinal("TotalSaleAmount"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TotalDiscountAmount")) == false)
                    {
                        objSalesOrder.TotalDiscountAmount = dr.GetDecimal(dr.GetOrdinal("TotalDiscountAmount"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TotalTaxValue")) == false)
                    {
                        objSalesOrder.TotalTaxValue = dr.GetDecimal(dr.GetOrdinal("TotalTaxValue"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ShipingAndHandlingCost")) == false)
                    {
                        objSalesOrder.ShipingAndHandlingCost = dr.GetDecimal(dr.GetOrdinal("ShipingAndHandlingCost"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("MiscSaleAmount")) == false)
                    {
                        objSalesOrder.MiscSaleAmount = dr.GetDecimal(dr.GetOrdinal("MiscSaleAmount"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objSalesOrder.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objSalesOrder.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objSalesOrder.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objSalesOrder.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objSalesOrder.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    { 
                        objSalesOrder.ModifiedOn=dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objSalesOrder.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objSalesOrder.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    objSalesOrderList.Add(objSalesOrder);
                }
                dr.Close();
               
            }
            catch(Exception ex )
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesOrder).FullName, 1);
                
            }
            return objSalesOrderList;
        }
        public Store.SalesOrder.BusinessObject.SalesOrder GetAllSalesOrder(int SalesOrderID, int Flag, string FlagValue)
        {
            Store.SalesOrder.BusinessObject.SalesOrder objSalesOrder =null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_SalesOrder";
                paramList.Add(new SQLParameter("@SalesOrderID", SalesOrderID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objSalesOrder = new BusinessObject.SalesOrder();

                    if (dr.IsDBNull(dr.GetOrdinal("SalesOrderID")) == false)
                    {
                        objSalesOrder.SalesOrderID = dr.GetInt32(dr.GetOrdinal("SalesOrderID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("VendorID")) == false)
                    {
                        objSalesOrder.VendorID = dr.GetInt32(dr.GetOrdinal("VendorID"));
                    }
                    //if (dr.IsDBNull(dr.GetOrdinal("VendorName")) == false)
                    //{
                    //    objSalesOrder.VendorName = dr.GetString(dr.GetOrdinal("VendorName"));
                    //}
                    if (dr.IsDBNull(dr.GetOrdinal("SaleDate")) == false)
                    {
                        objSalesOrder.SaleDate = dr.GetDateTime(dr.GetOrdinal("SaleDate"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TotalCostAmount")) == false)
                    {
                        objSalesOrder.TotalCostAmount = dr.GetDecimal(dr.GetOrdinal("TotalCostAmount"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TotalSaleAmount")) == false)
                    {
                        objSalesOrder.TotalSaleAmount = dr.GetDecimal(dr.GetOrdinal("TotalSaleAmount"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TotalDiscountAmount")) == false)
                    {
                        objSalesOrder.TotalDiscountAmount = dr.GetDecimal(dr.GetOrdinal("TotalDiscountAmount"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TotalTaxValue")) == false)
                    {
                        objSalesOrder.TotalTaxValue = dr.GetDecimal(dr.GetOrdinal("TotalTaxValue"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ShipingAndHandlingCost")) == false)
                    {
                        objSalesOrder.ShipingAndHandlingCost = dr.GetDecimal(dr.GetOrdinal("ShipingAndHandlingCost"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("MiscSaleAmount")) == false)
                    {
                        objSalesOrder.MiscSaleAmount = dr.GetDecimal(dr.GetOrdinal("MiscSaleAmount"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objSalesOrder.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objSalesOrder.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objSalesOrder.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objSalesOrder.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objSalesOrder.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objSalesOrder.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objSalesOrder.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objSalesOrder.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    
                }
                dr.Close();
               
            }

            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesOrder).FullName, 1);
                
            }
            return objSalesOrder;

        }
        public Store.Common.MessageInfo ManageSalesOrder(Store.SalesOrder.BusinessObject.SalesOrder objSalesOrder, CommandMode cmdMode)
        {
            string SQL = "USP_ManageSales";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageSales";
                param.Add(new SQLParameter("@SalesOrderID", objSalesOrder.SalesOrderID));
                param.Add(new SQLParameter("@VendorID", objSalesOrder.VendorID));
                //param.Add(new SQLParameter("@SaleDate", objSalesOrder.SaleDate));
                param.Add(new SQLParameter("@TotalCostAmount", objSalesOrder.TotalCostAmount));
                param.Add(new SQLParameter("@TotalSaleAmount", objSalesOrder.TotalSaleAmount));
                param.Add(new SQLParameter("@TotalDiscountAmount", objSalesOrder.TotalDiscountAmount));
                param.Add(new SQLParameter("@TotalTaxValue", objSalesOrder.TotalTaxValue));
                param.Add(new SQLParameter("@ShipingAndHandlingCost", objSalesOrder.ShipingAndHandlingCost));
                param.Add(new SQLParameter("@MiscSaleAmount", objSalesOrder.MiscSaleAmount));
                param.Add(new SQLParameter("@IsActive", objSalesOrder.IsActive));
                param.Add(new SQLParameter("@ReferenceID", objSalesOrder.ReferenceID));
                param.Add(new SQLParameter("@UserId", objSalesOrder.CreatedBy));
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
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesOrder).FullName, 1);
                
            }
            return objMessageInfo;
        }
        //public Store.Common.MessageInfo ManageSalesOrderItem(Store.SalesOrderItem.BusinessObject.SalesOrderItem objSalesOrderItem, int cmdMode)
        //{
        //        string SQL = "";
        //    //string SQL = "USP_ManageSalesOrder";
        //    ParameterList param = new ParameterList();
        //    DataTableReader dr;
        //    Store.Common.MessageInfo objMessageInfo = null;
        //    try
        //    {
        //        SQL = "USP_ManageSalesItem";
        //        param.Add(new SQLParameter("@SaleOrderItemID", objSalesOrderItem.SaleOrderItemID));
        //        param.Add(new SQLParameter("@SalesOrderID", objSalesOrderItem.SalesOrderID));
        //        param.Add(new SQLParameter("@ItemPrefix", objSalesOrderItem.ItemPrefix));
        //        param.Add(new SQLParameter("@ItemUnit", objSalesOrderItem.ItemUnit));
        //        param.Add(new SQLParameter("@Description", objSalesOrderItem.Description));
        //        param.Add(new SQLParameter("@ItemCostPrice", objSalesOrderItem.ItemCostPrice));
        //        param.Add(new SQLParameter("@ItemSalePrice", objSalesOrderItem.ItemSalePrice));
        //        param.Add(new SQLParameter("@ItemDiscountPercentage", objSalesOrderItem.ItemDiscountPercentage));
        //        param.Add(new SQLParameter("@ItemDiscount", objSalesOrderItem.ItemDiscount));
        //        param.Add(new SQLParameter("@IsActive", objSalesOrderItem.IsActive));
        //        param.Add(new SQLParameter("@ReferenceID", objSalesOrderItem.ReferenceID));
        //        param.Add(new SQLParameter("@UserId", objSalesOrderItem.CreatedBy));
        //        param.Add(new SQLParameter("@CMDMode", cmdMode));
        //        dr = ExecuteQuery.ExecuteReader(SQL, param);
        //        if (dr.Read())
        //        {
        //            objMessageInfo = new Store.Common.MessageInfo();
        //            objMessageInfo.ErrorCode = Convert.ToInt32(dr["ErrorCode"]);
        //            objMessageInfo.ErrorMessage = Convert.ToString(dr["ErrorMessage"]);
        //            objMessageInfo.TranID = Convert.ToInt32(dr["TranID"]);
        //            objMessageInfo.TranCode = Convert.ToString(dr["TranCode"]);
        //            objMessageInfo.TranMessage = Convert.ToString(dr["TranMessage"]);
        //        }
        //        return objMessageInfo;

        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}