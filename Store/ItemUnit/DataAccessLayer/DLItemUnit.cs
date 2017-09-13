using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.ItemUnit.DataAccessLayer
{
    public class ItemUnit
    {
        public Store.ItemUnit.BusinessObject.ItemUnitList GetAllItemUnitList(int UnitID, int Flag, string FlagValue)
        {
            Store.ItemUnit.BusinessObject.ItemUnit objItemUnit = new BusinessObject.ItemUnit();
            Store.ItemUnit.BusinessObject.ItemUnitList objItemUnitList = new BusinessObject.ItemUnitList();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_ItemMeasurmentUnit";
                paramList.Add(new SQLParameter("@UnitID",UnitID));
                paramList.Add(new SQLParameter("@Flag",Flag));
                paramList.Add(new SQLParameter("@FlagValue",FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objItemUnit = new BusinessObject.ItemUnit();
                    if (dr.IsDBNull(dr.GetOrdinal("UnitID")) == false)
                    {
                        objItemUnit.UnitID = dr.GetInt32(dr.GetOrdinal("UnitID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("UnitName")) == false)
                    {
                        objItemUnit.UnitName = dr.GetString(dr.GetOrdinal("UnitName"));
                    }
                    //if (dr.IsDBNull(dr.GetOrdinal("CategoryID")) == false)
                    //{
                    //    objItemUnit.CategoryID = dr.GetInt32(dr.GetOrdinal("CategoryID"));
                    //}
                    //if (dr.IsDBNull(dr.GetOrdinal("CategoryName")) == false)
                    //{
                    //    objItemUnit.CategoryName = dr.GetString(dr.GetOrdinal("CategoryName"));
                    //}

                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objItemUnit.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objItemUnit.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objItemUnit.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    { 
                        objItemUnit.ModifiedOn=dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objItemUnit.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    objItemUnitList.Add(objItemUnit);
                }
                dr.Close();
                return objItemUnitList;
            }
            catch
            {
                throw;
            }
        }
        public Store.ItemUnit.BusinessObject.ItemUnit GetAllItemUnit(int UnitID, int Flag, string FlagValue)
        {
            Store.ItemUnit.BusinessObject.ItemUnit objItemUnit =null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_UnitName";
                paramList.Add(new SQLParameter("@UnitID",UnitID));
                paramList.Add(new SQLParameter("@Flag",Flag));
                paramList.Add(new SQLParameter("@FlagValue",FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objItemUnit = new BusinessObject.ItemUnit();
                    if (dr.IsDBNull(dr.GetOrdinal("UnitID")) == false)
                    {
                        objItemUnit.UnitID = dr.GetInt32(dr.GetOrdinal("UnitID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("UnitName")) == false)
                    {
                        objItemUnit.UnitName = dr.GetString(dr.GetOrdinal("UnitName"));
                    }
                    //if (dr.IsDBNull(dr.GetOrdinal("CategoryID")) == false)
                    //{
                    //    objItemUnit.CategoryID = dr.GetInt32(dr.GetOrdinal("CategoryID"));
                    //}
                    //if (dr.IsDBNull(dr.GetOrdinal("CategoryName")) == false)
                    //{
                    //    objItemUnit.CategoryName = dr.GetString(dr.GetOrdinal("CategoryName"));
                    //}

                    if (dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false)
                    {
                        objItemUnit.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false)
                    {
                        objItemUnit.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false)
                    {
                        objItemUnit.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false)
                    {
                        objItemUnit.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false)
                    {
                        objItemUnit.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    dr.Close();
                }
                
                return objItemUnit;

            }
            catch
            {
                throw;
            }

        }
        public Store.Common.MessageInfo ManageItemUnit(Store.ItemUnit.BusinessObject.ItemUnit objItemUnit, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageItemMeasurementUnit";
                param.Add(new SQLParameter("@UnitID",objItemUnit.UnitID));
                param.Add(new SQLParameter("@UnitName", objItemUnit.UnitName));
                //param.Add(new SQLParameter("@CategoryID", objItemUnit.CategoryID)); 
                if(cmdMode==CommandMode.N)              
                    param.Add(new SQLParameter("@UserId", objItemUnit.CreatedBy));
                else
                    param.Add(new SQLParameter("@UserId", objItemUnit.ModifiedBy));
                param.Add(new SQLParameter("@ReferenceID", objItemUnit.ReferenceID));
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