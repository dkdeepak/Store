using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.District.DataAccessLayer
{
    public class District
    {
        public Store.District.BusinessObject.DistrictList GetAllDistrictList(int DistrictID, int Flag, string FlagValue)
        {
            Store.District.BusinessObject.District objDistrict = new BusinessObject.District();
            Store.District.BusinessObject.DistrictList objDistrictList = new BusinessObject.DistrictList();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_District";
                paramList.Add(new SQLParameter("@DistrictID", DistrictID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objDistrict = new BusinessObject.District();
                    if (dr.IsDBNull(dr.GetOrdinal("DistrictID")) == false)
                    {
                        objDistrict.DistrictID = dr.GetInt32(dr.GetOrdinal("DistrictID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("DistrictName")) == false))
                    {
                        objDistrict.DistrictName = dr.GetString(dr.GetOrdinal("DistrictName"));

                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StateID")) == false)
                    {
                        objDistrict.StateID = dr.GetInt32(dr.GetOrdinal("StateID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("StateName")) == false))
                    {
                        objDistrict.StateName = dr.GetString(dr.GetOrdinal("StateName"));

                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryID")) == false)
                    {
                        objDistrict.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CountryName")) == false))
                    {
                        objDistrict.CountryName = dr.GetString(dr.GetOrdinal("CountryName"));

                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objDistrict.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objDistrict.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objDistrict.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objDistrict.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objDistrict.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    objDistrictList.Add(objDistrict);
                }
                dr.Close();
                return objDistrictList;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public Store.District.BusinessObject.District GetAllDistrict(int DistrictID, int Flag, string FlagValue)
        {
            Store.District.BusinessObject.District objDistrict = new BusinessObject.District();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_District";
                paramList.Add(new SQLParameter("@DistrictID", DistrictID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objDistrict = new BusinessObject.District();
                    if (dr.IsDBNull(dr.GetOrdinal("DistrictID")) == false)
                    {
                        objDistrict.DistrictID = dr.GetInt32(dr.GetOrdinal("DistrictID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("DistrictName")) == false))
                    {
                        objDistrict.DistrictName = dr.GetString(dr.GetOrdinal("DistrictName"));

                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StateID")) == false)
                    {
                        objDistrict.StateID = dr.GetInt32(dr.GetOrdinal("StateID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("StateName")) == false))
                    {
                        objDistrict.StateName = dr.GetString(dr.GetOrdinal("StateName"));

                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryID")) == false)
                    {
                        objDistrict.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CountryName")) == false))
                    {
                        objDistrict.CountryName = dr.GetString(dr.GetOrdinal("CountryName"));

                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objDistrict.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objDistrict.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objDistrict.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objDistrict.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objDistrict.ReferenceID = dr.GetInt32(dr.GetOrdinal("RefCode"));
                    }
                    
                }
                dr.Close();
                return objDistrict;
            }
            catch (Exception ex)
            {
                throw;
            }        
        }
        public Store.Common.MessageInfo ManageDistrict(Store.District.BusinessObject.District objDistrict, CommandMode cmdMode)
        {
            string SQL = "USP_ManageDistrict";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageDistrict";
                param.Add(new SQLParameter("@DistrictID", objDistrict.DistrictID));
                param.Add(new SQLParameter("@DistrictName", objDistrict.DistrictName));
                param.Add(new SQLParameter("@StateID",objDistrict.StateID));
                param.Add(new SQLParameter("@CountryID", objDistrict.CountryID));
                if(cmdMode==CommandMode.N)
                    param.Add(new SQLParameter("@UserId", objDistrict.CreatedBy));
                else
                    param.Add(new SQLParameter("@UserId", objDistrict.ModifiedBy));
                param.Add(new SQLParameter("@ReferenceID", objDistrict.ReferenceID));
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
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}