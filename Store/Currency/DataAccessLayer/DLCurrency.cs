using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.Currency.DataAccessLayer
{
    public class Currency
    {
        public Store.Currency.BusinessObject.CurrencyList GetAllCurrencyList(int CurrencyID, int Flag, string FlagValue)
        {
            Store.Currency.BusinessObject.CurrencyList objCurrencyList = new BusinessObject.CurrencyList();
            Store.Currency.BusinessObject.Currency objCurrency = new BusinessObject.Currency();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_Currency";
                paramList.Add(new SQLParameter("@CurrencyID", CurrencyID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", Flag));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objCurrency = new BusinessObject.Currency();
                    if (dr.IsDBNull(dr.GetOrdinal("CurrencyID")) == false)
                    {
                        objCurrency.CurrencyID = dr.GetInt32(dr.GetOrdinal("CurrencyID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CurrencyName")) == false))
                    {
                        objCurrency.CurrencyName = dr.GetString(dr.GetOrdinal("CurrencyName"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("Sign")) == false))
                    {
                        objCurrency.Sign = dr.GetString(dr.GetOrdinal("Sign"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ClientID")) == false))
                    {
                        objCurrency.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objCurrency.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objCurrency.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objCurrency.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objCurrency.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objCurrency.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID")); 
                    }
                    objCurrencyList.Add(objCurrency);
                }
                dr.Close();
              
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Currency).FullName, 1);
                
            }
            return objCurrencyList;
        }
        public Store.Currency.BusinessObject.Currency GetAllCurrency(int CurrencyID, int Flag, string FlagValue)
        {
            Store.Currency.BusinessObject.Currency objCurrency = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_Currency";
                paramList.Add(new SQLParameter("@CurrencyID", CurrencyID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", Flag));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objCurrency = new BusinessObject.Currency();
                    if (dr.IsDBNull(dr.GetOrdinal("CurrencyID")) == false)
                    {
                        objCurrency.CurrencyID = dr.GetInt32(dr.GetOrdinal("CurrencyID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CurrencyName")) == false))
                    {
                        objCurrency.CurrencyName = dr.GetString(dr.GetOrdinal("CurrencyName"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("Sign")) == false))
                    {
                        objCurrency.Sign = dr.GetString(dr.GetOrdinal("Sign"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ClientID")) == false))
                    {
                        objCurrency.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objCurrency.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objCurrency.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objCurrency.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objCurrency.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objCurrency.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID")); ;
                    }
                    
                }
                dr.Close();
               
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Currency).FullName, 1);
            }
            return objCurrency;

        }
        public Store.Common.MessageInfo ManageCurrency(Store.Currency.BusinessObject.Currency objCurrency, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageCurrency";
                param.Add(new SQLParameter("@CurrencyID", objCurrency.CurrencyID));
                param.Add(new SQLParameter("@CurrencyName", objCurrency.CurrencyName));
                param.Add(new SQLParameter("@Sign", objCurrency.Sign));
                if (cmdMode==CommandMode.N)
                    param.Add(new SQLParameter("@UserId", objCurrency.CreatedBy));
                else
                    param.Add(new SQLParameter("@UserId", objCurrency.ModifiedBy));
                param.Add(new SQLParameter("@ReferenceID", objCurrency.ReferenceID));
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
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Currency).FullName, 1);
            }
            return objMessageInfo;

        }
    }
}