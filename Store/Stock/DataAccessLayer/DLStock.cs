using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;
using System.Data.SqlClient;
using Store.DatabaseHelper.Database.Common;
using System.Data;
using Store.DatabaseHelper.Database.DatabaseHelper;

namespace Store.Stock.DataAccessLayer
{
    public class Stock
    {
        public Store.Stock.BusinessObject.Stock GetAllStock(int StockID, int Flag, string FlagValue)
        {
            Store.Stock.BusinessObject.Stock objstock = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_stocks";
                paramList.Add(new SQLParameter("@StockID", StockID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    if (dr.IsDBNull(dr.GetOrdinal("StockID")) == false)
                    {
                        objstock.StockID = dr.GetInt32(dr.GetOrdinal("StockID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemID")) == false)
                    {
                        objstock.ItemID = dr.GetInt32(dr.GetOrdinal("ItemID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StockQuantity")) == false)
                    {
                        objstock.StockQuantity = dr.GetInt32(dr.GetOrdinal("StockQuantity"));
                    }
                    dr.Close();

                }
               
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Stock).FullName, 1);
                
            }
            return objstock;



            //Store.Stock.BusinessLogic.Stock oblstock = null;
            //Store.Stock.BusinessObject.StockList objstocklist = null;


        }
        public Store.Stock.BusinessObject.StockList GetAllStockList(int StockID, int Flag, string FlagValue)
        {
            Store.Stock.BusinessObject.Stock objstock = null;
            Store.Stock.BusinessObject.StockList objstockList = null;
            string SQL = string.Empty;
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            try
            {
                SQL = "proc_stock";
                objstockList = new BusinessObject.StockList();
                paramList.Add(new SQLParameter("@StockID", StockID));
                paramList.Add(new SQLParameter("@Flag", Flag));
                paramList.Add(new SQLParameter("@FlagValue", FlagValue));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
                while (dr.Read())
                {
                    objstock = new BusinessObject.Stock();
                    if (dr.IsDBNull(dr.GetOrdinal("StockID")) == false)
                    {
                        objstock.StockID = dr.GetInt32(dr.GetOrdinal("StockID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemID")) == false)
                    {
                        objstock.ItemID = dr.GetInt32(dr.GetOrdinal("ItemID"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("ItemPrefix")) == false)
                    {
                        objstock.ItemPrefix = dr.GetString(dr.GetOrdinal("ItemPrefix"));
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("StockQuantity")) == false)
                    {
                        objstock.StockQuantity = dr.GetInt32(dr.GetOrdinal("StockQuantity"));
                    }
                    objstockList.Add(objstock);
                }
                dr.Close();

                
            }

            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Stock).FullName, 1);
                
            }
            return objstockList;
        }
        public Store.Common.MessageInfo ManageStock(Store.Stock.BusinessObject.Stock objstock, CommandMode cmdMode)
        {
            string SQL = "";
            ParameterList paramList = new ParameterList();
            DataTableReader dr;
            Store.Common.MessageInfo objMessageInfo = null;
            try
            {
                SQL = "USP_ManageStock";
                paramList.Add(new SQLParameter("@StockID", objstock.StockID));
                paramList.Add(new SQLParameter("@ItemID", objstock.ItemID));
                paramList.Add(new SQLParameter("@StockQuantity", objstock.StockQuantity));
                paramList.Add(new SQLParameter("@CMDMode", cmdMode));
                dr = ExecuteQuery.ExecuteReader(SQL, paramList);
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
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Stock).FullName, 1);
                
            }
            return objMessageInfo;
        
        }
    }
            
}