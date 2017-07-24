using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.PurchaseOrder.DataAccessLayer
{
    public class PurchaseOrder
    {
        public Store.PurchaseOrder.BusinessObject.PurchaseOrder GetAllPurchaseOrder(int PurchaseOrderID, int Flag, string FlagValue)
        {
            Store.PurchaseOrder.BusinessObject.PurchaseOrder objPOrder = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_PurchaseOrder";
                paramList.Add(new SQLParameter("@PurchaseOrderID", PurchaseOrderID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objPOrder = new BusinessObject.PurchaseOrder();
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseOrderID")) == false)
                    {
                        objPOrder.PurchaseOrderID = dr.GetInt32(dr.GetOrdinal("PurchaseOrderID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("VendorID")) == false)
                    {
                        objPOrder.VendorID = dr.GetInt32(dr.GetOrdinal("VendorID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseDate")) == false)
                    {
                        objPOrder.PurchaseDate = dr.GetDateTime(dr.GetOrdinal("PurchaseDate"));

                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseAmount")) == false)
                    {
                        objPOrder.PurchaseAmount = dr.GetDecimal(dr.GetOrdinal("PurchaseAmount"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TaxValue")) == false)
                    {
                        objPOrder.TaxValue = dr.GetDecimal(dr.GetOrdinal("TaxValue"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ShipingAndHandlingCost")) == false)
                    {
                        objPOrder.ShipingAndHandlingCost = dr.GetDecimal(dr.GetOrdinal("ShipingAndHandlingCost"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("MiscCost")) == false)
                    {
                        objPOrder.MiscCost = dr.GetDecimal(dr.GetOrdinal("MiscCost"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objPOrder.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objPOrder.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objPOrder.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objPOrder.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objPOrder.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objPOrder.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objPOrder.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    
                }
                dr.Close();
                return objPOrder;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.PurchaseOrder.BusinessObject.PurchaseOrderList GetAllPurchaseOrderList(int PurchaseOrderID, int Flag, string FlagValue)
        {
            Store.PurchaseOrder.BusinessObject.PurchaseOrder objPOrder = null;
            Store.PurchaseOrder.BusinessObject.PurchaseOrderList objPOrderList = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_PurchaseOrder";
                objPOrderList = new BusinessObject.PurchaseOrderList();
                paramList.Add(new SQLParameter("@PurchaseOrderID", PurchaseOrderID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objPOrder = new BusinessObject.PurchaseOrder();
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseOrderID")) == false)
                    {
                        objPOrder.PurchaseOrderID = dr.GetInt32(dr.GetOrdinal("PurchaseOrderID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("VendorID")) == false)
                    {
                        objPOrder.VendorID = dr.GetInt32(dr.GetOrdinal("VendorID"));
                    }
                    //if (dr.IsDBNull(dr.GetOrdinal("VendorName")) == false)
                    //{
                    //    objPOrder.VendorName = dr.GetString(dr.GetOrdinal("VendorName"));
                    //}
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseDate")) == false)
                    {
                        objPOrder.PurchaseDate = dr.GetDateTime(dr.GetOrdinal("PurchaseDate"));

                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseAmount")) == false)
                    {
                        objPOrder.PurchaseAmount = dr.GetDecimal(dr.GetOrdinal("PurchaseAmount"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TaxValue")) == false)
                    {
                        objPOrder.TaxValue = dr.GetDecimal(dr.GetOrdinal("TaxValue"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ShipingAndHandlingCost")) == false)
                    {
                        objPOrder.ShipingAndHandlingCost = dr.GetDecimal(dr.GetOrdinal("ShipingAndHandlingCost"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("MiscCost")) == false)
                    {
                        objPOrder.MiscCost = dr.GetDecimal(dr.GetOrdinal("MiscCost"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objPOrder.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objPOrder.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objPOrder.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objPOrder.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objPOrder.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objPOrder.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objPOrder.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    objPOrderList.Add(objPOrder);

                }
                dr.Close();
                return objPOrderList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable runQuery(string query)
        {
            try
            {
                return ExecuteQuery.ExecuteDataTable(query);
            }
            catch
            {
                throw;
            }
       }

        

        public Store.Common.MessageInfo ManagePurchase(Store.PurchaseOrder.BusinessObject.PurchaseOrder objPOrder, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;

            try
            {
                SQL = "USP_ManagePurchaseOrder";
                param.Add(new SQLParameter("@PurchaseOrderID", objPOrder.PurchaseOrderID));
                param.Add(new SQLParameter("@VendorID", objPOrder.VendorID));
                param.Add(new SQLParameter("@PurchaseAmount", objPOrder.PurchaseAmount));
                param.Add(new SQLParameter("@TaxValue", objPOrder.TaxValue));
                param.Add(new SQLParameter("@ShipingAndHandlingCost", objPOrder.ShipingAndHandlingCost));
                param.Add(new SQLParameter("@MiscCost", objPOrder.MiscCost));
                param.Add(new SQLParameter("@PDiscount", objPOrder.PDiscount));
                param.Add(new SQLParameter("@PDiscountPre", objPOrder.PDiscountPre));
                param.Add(new SQLParameter("@UserId", objPOrder.CreatedBy));
                param.Add(new SQLParameter("@ReferenceID", objPOrder.ReferenceID));
                param.Add(new SQLParameter("@IsActive", objPOrder.IsActive));
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