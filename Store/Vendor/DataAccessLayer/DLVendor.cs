using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.Vendor.DataAccessLayer
{
    public class Vendor
    {
        public Store.Vendor.BusinessObject.VendorList GetAllVendorList(int VendorID, int Flag, string FlagValue)
        {
            Store.Vendor.BusinessObject.VendorList objVendorList = new BusinessObject.VendorList();
            Store.Vendor.BusinessObject.Vendor objVendor = new BusinessObject.Vendor();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_Vendor";
                paramList.Add(new SQLParameter("@VendorID", VendorID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", Flag));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objVendor = new BusinessObject.Vendor();
                    if (dr.IsDBNull(dr.GetOrdinal("VendorID")) == false)
                    {
                        objVendor.VendorID = dr.GetInt32(dr.GetOrdinal("VendorID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("VendorName")) == false))
                    {
                        objVendor.VendorName = dr.GetString(dr.GetOrdinal("VendorName"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objVendor.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objVendor.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objVendor.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objVendor.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objVendor.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID")); ;
                    }
                    objVendorList.Add(objVendor);
                }
                dr.Close();
                return objVendorList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.Vendor.BusinessObject.Vendor GetAllVendor(int VendorID, int Flag, string FlagValue)
        {
            Store.Vendor.BusinessObject.Vendor objVendor = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_Vendor";
                paramList.Add(new SQLParameter("@VendorID", VendorID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", Flag));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objVendor = new BusinessObject.Vendor();
                    if (dr.IsDBNull(dr.GetOrdinal("VendorID")) == false)
                    {
                        objVendor.VendorID = dr.GetInt32(dr.GetOrdinal("VendorID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("VendorName")) == false))
                    {
                        objVendor.VendorName = dr.GetString(dr.GetOrdinal("VendorName"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objVendor.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objVendor.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objVendor.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objVendor.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objVendor.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID")); ;
                    }
                    dr.Close();
                }
                return objVendor;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public Store.Common.MessageInfo ManageVendor(Store.Vendor.BusinessObject.Vendor objVendor, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageVendor";
                param.Add(new SQLParameter("@VendorID", objVendor.VendorID));
                param.Add(new SQLParameter("@VendorName", objVendor.VendorName));
                param.Add(new SQLParameter("@UserId", objVendor.CreatedBy));
                param.Add(new SQLParameter("@ReferenceID", objVendor.ReferenceID));
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