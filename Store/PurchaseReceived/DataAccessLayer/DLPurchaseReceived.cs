using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.PurchaseReceived.DataAccessLayer
{
    public class PurchaseReceived
    {
        public Store.PurchaseReceived.BusinessObject.PurchaseReceived GetAllPurchaseReceived(int PurchaseReceivedID, int Flag, string FlagValue)
        {
            Store.PurchaseReceived.BusinessObject.PurchaseReceived objPurchaseReceived = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_PurchaseReceived";
                paramList.Add(new SQLParameter("@PurchaseReceivedID", PurchaseReceivedID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL,paramList);
                while (dr.Read())
                {
                    objPurchaseReceived = new BusinessObject.PurchaseReceived();
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseReceivedID")) == false)
                    {
                        objPurchaseReceived.PurchaseReceivedID = dr.GetInt32(dr.GetOrdinal("PurchaseReceivedID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseOrderID")) == false)
                    {
                        objPurchaseReceived.PurchaseOrderID = dr.GetInt32(dr.GetOrdinal("PurchaseOrderID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("VendorID")) == false)
                    {
                        objPurchaseReceived.VendorID = dr.GetInt32(dr.GetOrdinal("VendorID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseRecivedDate")) == false)
                    {
                        objPurchaseReceived.PurchaseRecivedDate = dr.GetDateTime(dr.GetOrdinal("PurchaseRecivedDate"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseAmount")) == false)
                    {
                        objPurchaseReceived.PurchaseAmount = dr.GetDecimal(dr.GetOrdinal("PurchaseAmount"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TaxValue")) == false)
                    {
                        objPurchaseReceived.TaxValue = dr.GetDecimal(dr.GetOrdinal("TaxValue"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ShippingHandlingCost")) == false)
                    {
                        objPurchaseReceived.ShipingAndHandlingCost = dr.GetDecimal(dr.GetOrdinal("ShipingAndHandlingCost"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("MiscCost")) == false)
                    {
                        objPurchaseReceived.MiscCost = dr.GetDecimal(dr.GetOrdinal("MiscCost"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objPurchaseReceived.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objPurchaseReceived.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objPurchaseReceived.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objPurchaseReceived.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objPurchaseReceived.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objPurchaseReceived.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objPurchaseReceived.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    }
                    dr.Close();  
                }
                return objPurchaseReceived;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.PurchaseReceived.BusinessObject.PurchaseReceivedList GetAllPurchaseReceivedList(int PurchaseReceivedID, int Flag, string FlagValue)
        {
            Store.PurchaseReceived.BusinessObject.PurchaseReceived objPurchaseReceived = null;
            Store.PurchaseReceived.BusinessObject.PurchaseReceivedList objPurchaseReceivedList = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_PurchaseReceived";
                objPurchaseReceivedList = new BusinessObject.PurchaseReceivedList();
                paramList.Add(new SQLParameter("@PurchaseReceivedID", PurchaseReceivedID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objPurchaseReceived = new BusinessObject.PurchaseReceived();
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseReceivedID")) == false)
                    {
                        objPurchaseReceived.PurchaseReceivedID = dr.GetInt32(dr.GetOrdinal("PurchaseReceivedID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseOrderID")) == false)
                    {
                        objPurchaseReceived.PurchaseOrderID = dr.GetInt32(dr.GetOrdinal("PurchaseOrderID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("VendorID")) == false)
                    {
                        objPurchaseReceived.VendorID = dr.GetInt32(dr.GetOrdinal("VendorID"));
                    }
                    //if (dr.IsDBNull(dr.GetOrdinal("VendorName")) == false)
                    //{
                    //    objPurchaseReceived.VendorName = dr.GetString(dr.GetOrdinal("VendorName"));
                    //}
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseRecivedDate")) == false)
                    {
                        objPurchaseReceived.PurchaseRecivedDate = dr.GetDateTime(dr.GetOrdinal("PurchaseRecivedDate"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("PurchaseAmount")) == false)
                    {
                        objPurchaseReceived.PurchaseAmount = dr.GetDecimal(dr.GetOrdinal("PurchaseAmount"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("TaxValue")) == false)
                    {
                        objPurchaseReceived.TaxValue = dr.GetDecimal(dr.GetOrdinal("TaxValue"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ShipingAndHandlingCost")) == false)
                    {
                        objPurchaseReceived.ShipingAndHandlingCost = dr.GetDecimal(dr.GetOrdinal("ShipingAndHandlingCost"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("MiscCost")) == false)
                    {
                        objPurchaseReceived.MiscCost = dr.GetDecimal(dr.GetOrdinal("MiscCost"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ClientID")) == false)
                    {
                        objPurchaseReceived.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objPurchaseReceived.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objPurchaseReceived.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objPurchaseReceived.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objPurchaseReceived.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objPurchaseReceived.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("IsActive")) == false)
                    {
                        objPurchaseReceived.IsActive = dr.GetInt32(dr.GetOrdinal("IsActive"));
                    } 
                    objPurchaseReceivedList.Add(objPurchaseReceived);
                    
                }
                dr.Close();
                return objPurchaseReceivedList;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManagePurchaseReceived(Store.PurchaseReceived.BusinessObject.PurchaseReceived objPurchaseReceived, int cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManagePurchaseReceived";
                param.Add(new SQLParameter("@PurchaseReceivedID", objPurchaseReceived.PurchaseReceivedID));
                param.Add(new SQLParameter("@PurchaseOrderID", objPurchaseReceived.PurchaseOrderID));
                param.Add(new SQLParameter("@VendorID", objPurchaseReceived.VendorID));
                param.Add(new SQLParameter("@PurchaseAmount", objPurchaseReceived.PurchaseAmount));
                param.Add(new SQLParameter("@TaxValue", objPurchaseReceived.TaxValue));
                param.Add(new SQLParameter("@ShipingAndHandlingCost", objPurchaseReceived.ShipingAndHandlingCost));
                param.Add(new SQLParameter("@MiscCost", objPurchaseReceived.MiscCost));
                param.Add(new SQLParameter("@IsActive", objPurchaseReceived.IsActive));
                param.Add(new SQLParameter("@ReferenceID", objPurchaseReceived.ReferenceID));
                param.Add(new SQLParameter("@UserId", objPurchaseReceived.CreatedBy));
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
        public Store.Common.MessageInfo ManagePurchaseReceivedItem(Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem objPurchaseReceivedItem, int cmdMode)
        {

            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManagePurchaseReceivedItem";
                param.Add(new SQLParameter("@PurchaseItemReceivedID", objPurchaseReceivedItem.PurchaseReceivedID));
                param.Add(new SQLParameter("@PurchaseReceivedID", objPurchaseReceivedItem.PurchaseReceivedID));
                param.Add(new SQLParameter("@PurchaseOrderID", objPurchaseReceivedItem.PurchaseOrderID));
                param.Add(new SQLParameter("@ItemPrefix", objPurchaseReceivedItem.ItemPrefix));
                param.Add(new SQLParameter("@ItemUnit", objPurchaseReceivedItem.ItemUnit));
                param.Add(new SQLParameter("@Description", objPurchaseReceivedItem.Description));
                param.Add(new SQLParameter("@ItemPrice", objPurchaseReceivedItem.ItemPrice));
                param.Add(new SQLParameter("@IsActive", objPurchaseReceivedItem.IsActive));
                param.Add(new SQLParameter("@ReferenceID", objPurchaseReceivedItem.ReferenceID));
                param.Add(new SQLParameter("@UserId", objPurchaseReceivedItem.CreatedBy));
                param.Add(new SQLParameter("@ClientID", objPurchaseReceivedItem.ClientID));
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