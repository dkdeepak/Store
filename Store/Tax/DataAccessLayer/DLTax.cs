using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;
using Store.Common;

namespace Store.Tax.DataAccessLayer
{
    public class Tax
    {
        public Store.Tax.BusinessObject.TaxList GetAllTaxList(int TaxID, int Flag, string FlagValue)
        {
            Store.Tax.BusinessObject.TaxList objTaxList = new BusinessObject.TaxList();
            Store.Tax.BusinessObject.Tax objTax = new BusinessObject.Tax();
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_Tax";
                paramList.Add(new SQLParameter("@TaxID", TaxID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", Flag));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objTax = new BusinessObject.Tax();
                    if (dr.IsDBNull(dr.GetOrdinal("TaxID")) == false)
                    {
                        objTax.TaxID = dr.GetInt32(dr.GetOrdinal("TaxID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("TaxName")) == false))
                    {
                        objTax.TaxName = dr.GetString(dr.GetOrdinal("TaxName"));
                    }

                    if ((dr.IsDBNull(dr.GetOrdinal("TaxDisplayName")) == false))
                    {
                        objTax.TaxDisplayName = dr.GetString(dr.GetOrdinal("TaxDisplayName"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("TaxValue")) == false))
                    {
                        objTax.TaxValue = dr.GetDecimal(dr.GetOrdinal("TaxValue"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ClientID")) == false))
                    {
                        objTax.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objTax.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objTax.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objTax.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objTax.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objTax.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID")); ;
                    }
                    objTaxList.Add(objTax);
                }
                dr.Close();
               
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Tax).FullName, 1);
                
            }
            return objTaxList;
        }
        public Store.Tax.BusinessObject.Tax GetAllTax(int TaxID, int Flag, string FlagValue)
        {
            Store.Tax.BusinessObject.Tax objTax = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_Tax";
                paramList.Add(new SQLParameter("@TaxID", TaxID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", Flag));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objTax = new BusinessObject.Tax();
                    if (dr.IsDBNull(dr.GetOrdinal("TaxID")) == false)
                    {
                        objTax.TaxID = dr.GetInt32(dr.GetOrdinal("TaxID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("objTax")) == false))
                    {
                        objTax.TaxName = dr.GetString(dr.GetOrdinal("TaxName"));
                    }

                    if ((dr.IsDBNull(dr.GetOrdinal("TaxDisplayName")) == false))
                    {
                        objTax.TaxDisplayName = dr.GetString(dr.GetOrdinal("TaxDispalayName"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("TaxValue")) == false))
                    {
                        objTax.TaxValue = dr.GetDecimal(dr.GetOrdinal("TaxValue"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ClientID")) == false))
                    {
                        objTax.ClientID = dr.GetInt32(dr.GetOrdinal("ClientID"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedOn")) == false))
                    {
                        objTax.CreatedOn = dr.GetDateTime(dr.GetOrdinal("CreatedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("CreatedBy")) == false))
                    {
                        objTax.CreatedBy = dr.GetInt32(dr.GetOrdinal("CreatedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedBy")) == false))
                    {
                        objTax.ModifiedBy = dr.GetInt32(dr.GetOrdinal("ModifiedBy"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ModifiedOn")) == false))
                    {
                        objTax.ModifiedOn = dr.GetDateTime(dr.GetOrdinal("ModifiedOn"));
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("ReferenceID")) == false))
                    {
                        objTax.ReferenceID = dr.GetInt32(dr.GetOrdinal("ReferenceID")); ;
                    }
                    dr.Close();

                }
                
           }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Tax).FullName, 1);
                
            }
            return objTax;
        }
        public Store.Common.MessageInfo ManageTax(Store.Tax.BusinessObject.Tax objTax, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList param = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageTax";
                param.Add(new SQLParameter("@TaxID", objTax.TaxID));
                param.Add(new SQLParameter("@TaxName", objTax.TaxName));
                param.Add(new SQLParameter("@TaxDisplayName", objTax.TaxDisplayName));
                param.Add(new SQLParameter("@TaxValue", objTax.TaxValue));
                if (cmdMode == CommandMode.N)
                    param.Add(new SQLParameter("@UserId", objTax.CreatedBy));
                else
                    param.Add(new SQLParameter("@UserId", objTax.ModifiedBy));
                param.Add(new SQLParameter("@ReferenceID", objTax.ReferenceID));
                param.Add(new SQLParameter("@CMDMode", cmdMode));
                dr = ExecuteQuery.ExecuteReader(SQL, param);
                if (dr.Read())
                {
                    objMessageInfo = new Store.Common.MessageInfo();
                    //objMessageInfo = new Pareeksha.Common.MessageInfo();
                    objMessageInfo.ErrorCode = Convert.ToInt32(dr["ErrorCode"]);
                    objMessageInfo.ErrorMessage = Convert.ToString(dr["ErrorMessage"]);
                    objMessageInfo.TranID = Convert.ToInt32(dr["TranID"]);
                    objMessageInfo.TranCode = Convert.ToString(dr["TranCode"]);
                    objMessageInfo.TranMessage = Convert.ToString(dr["TranMessage"]);
                }
                
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Tax).FullName, 1);
                
            }
            return objMessageInfo;

        }
    }
}