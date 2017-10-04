using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;

namespace Store.Country.DataAccessLayer
{
    public class Country
    {
        public Store.Country.BusinessObject.CountryList GetAllCountryList(int CountryID, int Flag, string FlagValue)
        {
            Store.Country.BusinessObject.CountryList objCountryList = new BusinessObject.CountryList();
            Store.Country.BusinessObject.Country objCountry = new BusinessObject.Country();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_Country";
                paramList.Add(new SQLParameter("@CountryID", CountryID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objCountry = new BusinessObject.Country();
                    if (dr.IsDBNull(dr.GetOrdinal("CountryID")) == false)
                    {
                        objCountry.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CountryName")) == false))
                    {
                        objCountry.CountryName = dr.GetString(dr.GetOrdinal("CountryName"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objCountry.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objCountry.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objCountry.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objCountry.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objCountry.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID")); ;
                    }
                    objCountryList.Add(objCountry);
      
                }
                dr.Close();
                
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Country).FullName, 1);
                
            }
            return objCountryList;
        }
        public Store.Country.BusinessObject.Country GetAllCountry(int CountryID, int Flag, string FlagValue)
        {
            Store.Country.BusinessObject.Country objCountry = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_Country";
                paramList.Add(new SQLParameter("@CountryID", CountryID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", Flag));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objCountry = new BusinessObject.Country();
                    if (dr.IsDBNull(dr.GetOrdinal("CountryID")) == false)
                    {
                        objCountry.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CountryName")) == false))
                    {
                        objCountry.CountryName = dr.GetString(dr.GetOrdinal("CountryName"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objCountry.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objCountry.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objCountry.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objCountry.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objCountry.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID"));
                    }
                }
                dr.Close();

               
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Country).FullName, 1);
            }
             return objCountry;
        }
        public Store.Common.MessageInfo ManageCountry(Store.Country.BusinessObject.Country objCountry, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageCountry";
                param.Add(new SQLParameter("@CountryID", objCountry.CountryID));
                param.Add(new SQLParameter("@CountryName", objCountry.CountryName));
                if(cmdMode==CommandMode.N)
                    param.Add(new SQLParameter("@UserId",     objCountry.CreatedBy));
                else
                    param.Add(new SQLParameter("@UserId" ,   objCountry.ModifiedBy));
                param.Add(new SQLParameter("@ReferenceID", objCountry.ReferenceID));
                param.Add(new SQLParameter("@CMDMode",   cmdMode));
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
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Country).FullName, 1);
            }
            return objMessageInfo;
        }
    }
}
