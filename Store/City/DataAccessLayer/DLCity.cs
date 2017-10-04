using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.City.DataAccessLayer
{
    public class City
    {
        public Store.City.BusinessObject.CityList GetAllCityList(int CityID, int Flag, string FlagValue)
        {
            Store.City.BusinessObject.City objCity = new BusinessObject.City();
            Store.City.BusinessObject.CityList objCityList = new BusinessObject.CityList();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_City";
                paramList.Add(new SQLParameter("@CityID", CityID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objCity = new BusinessObject.City();
                    if (dr.IsDBNull(dr.GetOrdinal("CityID")) == false)
                    {
                        objCity.CityID = dr.GetInt32(dr.GetOrdinal("CityID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CityName")) == false))
                    {
                        objCity.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StateID")) == false)
                    {
                        objCity.StateID = dr.GetInt32(dr.GetOrdinal("StateID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("StateName")) == false))
                    {
                        objCity.StateName = dr.GetString(dr.GetOrdinal("StateName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("DistrictID")) == false)
                    {
                        objCity.DistrictID = dr.GetInt32(dr.GetOrdinal("DistrictID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("DistrictName")) == false))
                    {
                        objCity.DistrictName = dr.GetString(dr.GetOrdinal("DistrictName"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryID")) == false)
                    {
                        objCity.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CountryName")) == false))
                    {
                        objCity.CountryName = dr.GetString(dr.GetOrdinal("CountryName"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objCity.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objCity.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objCity.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objCity.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objCity.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                    objCityList.Add(objCity);
                }
                dr.Close();
               
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(City).FullName, 1);
 +          }
             return objCityList;
        }
        public Store.City.BusinessObject.City GetAllCity(int CityID, int Flag, string FlagValue)
        {
            Store.City.BusinessObject.City objCity = new BusinessObject.City();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_City";
                paramList.Add(new SQLParameter("@CityID", CityID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objCity = new BusinessObject.City();
                    if (dr.IsDBNull(dr.GetOrdinal("CityID")) == false)
                    {
                        objCity.CityID = dr.GetInt32(dr.GetOrdinal("CityID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CityName")) == false))
                    {
                        objCity.CityName = dr.GetString(dr.GetOrdinal("CityName"));

                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StateID")) == false)
                    {
                        objCity.StateID = dr.GetInt32(dr.GetOrdinal("StateID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("DistrictID")) == false)
                    {
                        objCity.DistrictID = dr.GetInt32(dr.GetOrdinal("DistrictID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("CountryID")) == false)
                    {
                        objCity.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CountryName")) == false))
                    {
                        objCity.CountryName = dr.GetString(dr.GetOrdinal("CountryName"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objCity.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objCity.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objCity.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objCity.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objCity.ReferenceID = dr.GetInt32(dr.GetOrdinal("RefCode"));
                    }
                    
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(City).FullName, 1);
 +          }
            return objCity;
        }
        public Store.Common.MessageInfo ManageCity(Store.City.BusinessObject.City objCity, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageCity";
                param.Add(new SQLParameter("@CityID", objCity.CityID));
                param.Add(new SQLParameter("@CityName", objCity.CityName));
                param.Add(new SQLParameter("@StateID", objCity.StateID));
                param.Add(new SQLParameter("@DistrictID", objCity.DistrictID));
                param.Add(new SQLParameter("@CountryID", objCity.CountryID));
                if(cmdMode==CommandMode.N)
                    param.Add(new SQLParameter("@UserId", objCity.CreatedBy));
                else
                    param.Add(new SQLParameter("@UserId", objCity.ModifiedBy));
                param.Add(new SQLParameter("@ReferenceID", objCity.ReferenceID));
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
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(City).FullName, 1);
 +          }
            return objMessageInfo;
        }
    }
}
