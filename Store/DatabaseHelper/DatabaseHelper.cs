using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Store.DatabaseHelper
{
  namespace Database
    {
        #region Namespace - Common
        namespace Common
        {
            public class SQLParameter
            {
                string _parameterName = "";
                object _parameterValue = null;
                ParameterDirection _direction = ParameterDirection.Input;
                SqlDbType? _dbType = null;
                int _size = -1;
               
                public SQLParameter()
                {

                }

                public SQLParameter(string parameterName, object parameterValue)
                {
                    _parameterName = parameterName;
                    _parameterValue = parameterValue;
                }

                public SQLParameter(string parameterName, object parameterValue, SqlDbType dbType)
                {
                    _parameterName = parameterName;
                    _parameterValue = parameterValue;
                    _dbType = dbType;
                }

                public SQLParameter(string parameterName, object parameterValue, SqlDbType dbType, int size)
                {
                    _parameterName = parameterName;
                    _parameterValue = parameterValue;
                    _dbType = dbType;
                    _size = size;
                }

                public SQLParameter(string parameterName, object parameterValue, ParameterDirection paramDirection)
                {
                    _parameterName = parameterName;
                    _parameterValue = parameterValue;
                    _direction = paramDirection;
                }

                public SQLParameter(string parameterName, object parameterValue, SqlDbType dbType, ParameterDirection paramDirection)
                {
                    _parameterName = parameterName;
                    _parameterValue = parameterValue;
                    _dbType = dbType;
                    _direction = paramDirection;
                }

                public string ParameterName
                {
                    get { return _parameterName; }
                    set { _parameterName = value; }
                }

                public object ParameterValue
                {
                    get { return _parameterValue; }
                    set { _parameterValue = value; }
                }

                public SqlDbType? DBType
                {
                    get { return _dbType; }
                    set { _dbType = value; }
                }

                public int Size
                {
                    get { return _size; }
                    set { _size = value; }
                }

                public ParameterDirection ParameterDirection
                {
                    get { return _direction; }
                    set { _direction = value; }
                }
            }

            public class ParameterList : List<SQLParameter>
            {
                public ParameterList()
                {

                }

                public SQLParameter GetParameterByName(string parameterName)
                {
                    return this.Find(delegate(Common.SQLParameter p) { return p.ParameterName.ToUpper() == parameterName.ToUpper(); });
                }

                public int GetParameterIndexByName(string parameterName)
                {
                    return this.FindIndex(delegate(Common.SQLParameter p) { return p.ParameterName.ToUpper() == parameterName.ToUpper(); });
                }
            }

            /// <summary>
            /// Encapsulates System.Data.SqlClient.SqlParameter
            /// to create a generic list. Use this to pass a
            /// list of SqlParameters to various static functions 
            /// of ExecuteQuery class.
            /// Now it is obsolete.
            /// </summary>
            //public class SQLParameterList : List<SqlParameter>
            //{
            //    public SQLParameterList()
            //    {

            //    }
            //}

            public class Key
            {
                string _key;

                public Key()
                {

                }

                public Key(string keyName)
                {
                    _key = keyName;
                }

                public string KeyName
                {
                    get { return _key; }
                    set { _key = value; }
                }
            }

            public class ForeignKey
            {
                Key _sourceKey = new Key();
                Key _targetKey = new Key();
                int _primaryKeyQueryIndex = -1;

                public ForeignKey()
                {

                }

                public ForeignKey(string sourceKey, string targetKey)
                {
                    _sourceKey.KeyName = sourceKey;
                    _targetKey.KeyName = targetKey;
                }

                public ForeignKey(string sourceKey, string targetKey, int primaryKeyQueryIndex)
                {
                    _sourceKey.KeyName = sourceKey;
                    _targetKey.KeyName = targetKey;
                    _primaryKeyQueryIndex = primaryKeyQueryIndex;
                }

                public string SourceKey
                {
                    get { return _sourceKey.KeyName; }
                    set { _sourceKey.KeyName = value; }
                }

                public string TargetKey
                {
                    get { return _targetKey.KeyName; }
                    set { _targetKey.KeyName = value; }
                }

                public int PrimaryKeyQueryIndex
                {
                    get { return _primaryKeyQueryIndex; }
                    set { _primaryKeyQueryIndex = value; }
                }
            }

            public class ForeignKeyList : List<ForeignKey>
            {
                public ForeignKeyList()
                {

                }
            }

            public class PrimaryKeyList : List<Key>
            {
                public PrimaryKeyList()
                {

                }
            }

            public class TransactionQuery
            {
                string _procedureName;
                ParameterList _parameterList = new ParameterList();
                PrimaryKeyList _primaryKeyList = new PrimaryKeyList();
                ForeignKeyList _foreignKeyList = new ForeignKeyList();
                int _primaryKeyQueryIndex = -1;

                public TransactionQuery()
                {

                }

                public string ProcedureName
                {
                    get { return _procedureName; }
                    set { _procedureName = value; }
                }

                public ParameterList SQLParameters
                {
                    get { return _parameterList; }
                    set { _parameterList = value; }
                }

                public PrimaryKeyList PrimaryKeyList
                {
                    get { return _primaryKeyList; }
                    set { _primaryKeyList = value; }
                }

                public ForeignKeyList ForeignKeyList
                {
                    get { return _foreignKeyList; }
                    set { _foreignKeyList = value; }
                }

                public int PrimaryKeyQueryIndex
                {
                    get { return _primaryKeyQueryIndex; }
                    set { _primaryKeyQueryIndex = value; }
                }
            }

            public class TransactionQueryList : List<TransactionQuery>
            {
                public TransactionQueryList()
                {

                }
            }
        }
        #endregion

        #region Namespace - DatabaseHelper
        namespace DatabaseHelper
        {
            /// <summary>
            /// Summary description for ExecuteQuery
            /// </summary>
            public class ExecuteQuery
            {
                private static string _connectionString = "";

                public ExecuteQuery()
                {
                    //
                    // TODO: Add constructor logic here
                    //
                }

                #region Public Properties

                public static string ConnectionString
                {
                    get { return _connectionString; }
                    set { _connectionString = value; }
                }

                #endregion

                #region Private Methods
                //private static SqlCommand BuildSqlCommand(SqlConnection conn, SqlTransaction transaction, CommandType cmdType, string procedureName, Common.SQLParameterList SQLParam)
                //{
                //    SqlCommand cmd = new SqlCommand();
                //    cmd.CommandType = cmdType;
                //    cmd.Connection = conn;
                //    cmd.Transaction = transaction;
                //    cmd.CommandText = procedureName;
                //    foreach (SqlParameter param in SQLParam)
                //    {
                //        cmd.Parameters.Add(param);
                //    }
                //    return cmd;
                //}

                private static SqlCommand BuildBaseSqlCommand(SqlConnection conn, SqlTransaction transaction, CommandType cmdType, string procedureName, Common.ParameterList SQLParam)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = cmdType;
                    cmd.Connection = conn;
                    cmd.Transaction = transaction;
                    cmd.CommandText = procedureName;
                    foreach (Common.SQLParameter param in SQLParam)
                    {
                        cmd.Parameters.Add(new SqlParameter(param.ParameterName, param.ParameterValue));

                        if (param.DBType != null)
                            cmd.Parameters[cmd.Parameters.Count - 1].SqlDbType = (SqlDbType)param.DBType;

                        if (param.Size != -1)
                            cmd.Parameters[cmd.Parameters.Count - 1].Size = param.Size;

                        cmd.Parameters[cmd.Parameters.Count - 1].Direction = param.ParameterDirection;
                    }
                    return cmd;
                }

                private static SqlCommand BuildSqlCommand(SqlConnection conn, SqlTransaction transaction, CommandType cmdType, string procedureName, Common.ParameterList SQLParam)
                {
                    SqlCommand cmd = BuildBaseSqlCommand(conn, transaction, cmdType, procedureName, SQLParam);
                    return cmd;
                }

                private static SqlCommand BuildSqlCommand(SqlConnection conn, SqlTransaction transaction, CommandType cmdType, string procedureName, Common.ParameterList SQLParam, int timeOutDuration)
                {
                    SqlCommand cmd = BuildBaseSqlCommand(conn, transaction, cmdType, procedureName, SQLParam);
                    cmd.CommandTimeout = timeOutDuration;

                    return cmd;
                }

                private static void StoreParameterOutputValues(SqlCommand cmd, Common.ParameterList SQLParam)
                {
                    foreach (SqlParameter param in cmd.Parameters)
                    {
                        if (param.Direction != ParameterDirection.Input)
                            SQLParam.GetParameterByName(param.ParameterName).ParameterValue = param.Value;
                    }
                }
                #endregion

                #region Public Methods
                //public static SqlDataReader ExecuteReader(string SQL)
                //{
                //    SqlConnection conn;
                //    SqlDataReader reader;

                //    try
                //    {
                //        conn = new SqlConnection(AppConfiguration.ConnectionString((ModuleType)HttpContext.Current.Session["ModuleType"]));
                //        conn.Open();
                //        using (SqlCommand cmd = BuildSqlCommand(conn, null, CommandType.Text, SQL, new Gurukul.Database.Common.SQLParameterList()))
                //        {
                //            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //        }
                //        return reader;
                //    }
                //    catch (Exception)
                //    {
                //        throw;
                //    }
                //}

                public static SqlDataAdapter ExecuteDataAdapter(string SQL)
                {
                    SqlConnection conn = null;
                    SqlDataAdapter ad;

                    try
                    {
                        conn = new SqlConnection(ConnectionString);
                        conn.Open();
                        ad = new SqlDataAdapter(SQL, conn);
                        conn.Close();
                        return ad;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();

                    }
                }
                public static SqlDataAdapter ExecuteDataAdapter(string procedureName, Common.ParameterList SQLParam)
                {
                    SqlConnection conn = null;
                    SqlDataAdapter ad;

                    try
                    {
                        conn = new SqlConnection(ConnectionString);
                        conn.Open();
                        ad = new SqlDataAdapter();
                        ad.SelectCommand = BuildSqlCommand(conn, null, CommandType.StoredProcedure, procedureName, SQLParam);
                        conn.Close();
                        return ad;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
                        
                    }
                }
                public static DataTableReader ExecuteReader(string SQL)
                {
                    DataTableReader reader;
                    DataSet ds;

                    try
                    {
                        ds = ExecuteDataSet(SQL);
                        reader = ds.CreateDataReader();
                        return reader;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                public static DataTableReader ExecuteReader(string SQL, int timeOut)
                {
                    DataTableReader reader;
                    DataSet ds;

                    try
                    {
                        ds = ExecuteDataSet(SQL, timeOut);
                        reader = ds.CreateDataReader();
                        return reader;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                public static DataTableReader ExecuteReader(string procedureName, Common.ParameterList SQLParam)
                {
                    DataTableReader reader;
                    DataSet ds;

                    try
                    {
                        ds = ExecuteDataSet(procedureName, SQLParam);
                        reader = ds.CreateDataReader();
                        return reader;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                public static DataTableReader ExecuteReader(string procedureName, Common.ParameterList SQLParam, int timeOut)
                {
                    DataTableReader reader;
                    DataSet ds;

                    try
                    {
                        ds = ExecuteDataSet(procedureName, SQLParam, timeOut);
                        reader = ds.CreateDataReader();
                        return reader;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                public static DataSet ExecuteDataSet(string SQL)
                {
                    SqlConnection conn = null;
                    SqlDataAdapter ad;
                    DataSet ds = new DataSet();

                    try
                    {
                        conn = new SqlConnection(ConnectionString);
                        conn.Open();
                        ad = new SqlDataAdapter(SQL, conn);
                        ad.SelectCommand.CommandTimeout = 120;
                        ad.Fill(ds);
                        conn.Close();                       
                        return ds;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
                        
                    }
                }
                public static DataSet ExecuteDataSet(string SQL, int timeOut)
                {
                    SqlConnection conn = null;
                    SqlDataAdapter ad;
                    DataSet ds = new DataSet();

                    try
                    {
                        conn = new SqlConnection(ConnectionString);
                        conn.Open();
                        ad = new SqlDataAdapter(SQL, conn);
                        ad.SelectCommand.CommandTimeout = timeOut;
                        ad.Fill(ds);
                        conn.Close();
                        return ds;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
                    }
                }
                public static DataSet ExecuteDataSet(string procedureName, Common.ParameterList SQLParam)
                {
                    SqlDataAdapter ad;
                    DataSet ds = new DataSet();

                    try
                    {
                        ad = ExecuteDataAdapter(procedureName, SQLParam);
                        ad.Fill(ds);
                        return ds;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                public static DataSet ExecuteDataSet(string procedureName, Common.ParameterList SQLParam, int timeOut)
                {
                    SqlDataAdapter ad;
                    DataSet ds = new DataSet();

                    try
                    {
                        ad = ExecuteDataAdapter(procedureName, SQLParam);
                        ad.SelectCommand.CommandTimeout = timeOut;

                        ad.Fill(ds);
                        return ds;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                public static DataTable ExecuteDataTable(string SQL)
                {
                    SqlDataAdapter ad;
                    DataTable dt = new DataTable();

                    try
                    {
                        ad = ExecuteDataAdapter(SQL);
                        ad.Fill(dt);
                        return dt;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                public static DataTable ExecuteDataTable(string SQL, Common.ParameterList SQLParam)
                {
                    SqlDataAdapter ad;
                    DataTable dt = new DataTable();

                    try
                    {
                        ad = ExecuteDataAdapter(SQL, SQLParam);
                        ad.Fill(dt);
                        return dt;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                public static void ExecuteNonQuery(string procedureName, Common.ParameterList SQLParam)
                {
                    SqlConnection conn = new SqlConnection();

                    try
                    {
                        using (conn = new SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            using (SqlCommand cmd = BuildSqlCommand(conn, null, CommandType.StoredProcedure, procedureName, SQLParam))
                            {
                                cmd.ExecuteNonQuery();
                                StoreParameterOutputValues(cmd, SQLParam);
                            }
                            conn.Close();
                            //Gurukul.Database.Common.SQLParameter.ConType = ConnectionType.WebConn;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
                        //Gurukul.Database.Common.SQLParameter.ConType = ConnectionType.WebConn;
                    }
                }
                public static void ExecuteNonQuery(string procedureName, Common.ParameterList SQLParam, int timeOutDuration)
                {
                    SqlConnection conn = new SqlConnection();

                    try
                    {
                        using (conn = new SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            using (SqlCommand cmd = BuildSqlCommand(conn, null, CommandType.StoredProcedure, procedureName, SQLParam))
                            {
                                cmd.CommandTimeout = timeOutDuration;
                                cmd.ExecuteNonQuery();
                                StoreParameterOutputValues(cmd, SQLParam);
                            }
                            conn.Close();
                            // Gurukul.Database.Common.SQLParameter.ConType = ConnectionType.WebConn;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
                        //Gurukul.Database.Common.SQLParameter.ConType = ConnectionType.WebConn;
                    }
                }
                public static void ExecuteNonQuery(Common.TransactionQueryList transactionQueryList)
                {
                    SqlConnection conn = new SqlConnection(ConnectionString);
                    SqlCommand cmd;
                    SqlTransaction transaction;
                    Common.TransactionQuery transactionQuery;
                    Common.ForeignKeyList fkList;

                    try
                    {
                        conn.Open();
                        transaction = conn.BeginTransaction();

                        try
                        {
                            for (int i = 0; i < transactionQueryList.Count; i++)
                            {
                                transactionQuery = transactionQueryList[i];

                                // Set the direction of all primary keys in current transaction
                                // query
                                // Assumption: No two parameter/PK names are same
                                if (transactionQuery.PrimaryKeyList.Count > 0)
                                {
                                    // for each primary keys of current query
                                    for (int j = 0; j < transactionQuery.PrimaryKeyList.Count; j++)
                                    {
                                        // loop through all the parameters of current query
                                        for (int k = 0; k < transactionQuery.SQLParameters.Count; k++)
                                        {
                                            // to find the the index of primary key in the list
                                            // parameters of current query by comparing their names
                                            if (transactionQuery.PrimaryKeyList[j].KeyName.ToUpper() == transactionQuery.SQLParameters[k].ParameterName.ToUpper())
                                            {
                                                // Set the direction of selected parameter
                                                transactionQuery.SQLParameters[k].ParameterDirection = ParameterDirection.InputOutput;
                                                // Work done for selected primary key. 
                                                // Break out of the loop.
                                                break;
                                            }
                                        }
                                    }
                                }

                                // Set the value of foreign keys with the values of
                                // primary keys (returned by output parameter) of previous
                                // parent table
                                if (transactionQuery.PrimaryKeyQueryIndex != -1 && transactionQuery.ForeignKeyList.Count > 0)
                                {
                                    // Find the list of foreign keys of current query
                                    fkList = transactionQuery.ForeignKeyList;

                                    // loop for all items of foreign key
                                    for (int j = 0; j < fkList.Count; j++)
                                    {
                                        // loop through all the parameters of current query
                                        for (int k = 0; k < transactionQuery.SQLParameters.Count; k++)
                                        {
                                            // to find the the index of "Source" key in the list
                                            // parameters of current query by comparing their names
                                            if (fkList[j].SourceKey.ToUpper() == transactionQuery.SQLParameters[k].ParameterName.ToUpper())
                                            {
                                                // if "Source" key index is found
                                                // then loop through all the parameters of previous
                                                // parent table 
                                                for (int l = 0; l < transactionQueryList[transactionQuery.PrimaryKeyQueryIndex].SQLParameters.Count; l++)
                                                {
                                                    // to find the index of "Target" key in the
                                                    // list of parameters by comparing their names
                                                    if (fkList[j].TargetKey.ToUpper() == transactionQueryList[transactionQuery.PrimaryKeyQueryIndex].SQLParameters[l].ParameterName.ToUpper())
                                                    {
                                                        // if "Target" key is found, then assign
                                                        // the value of selected key of previous parent
                                                        // table (returned by output parameter) to the
                                                        // selected key of parameters of current
                                                        // query
                                                        transactionQuery.SQLParameters[k].ParameterValue = transactionQueryList[transactionQuery.PrimaryKeyQueryIndex].SQLParameters[l].ParameterValue;
                                                        // Work done for selected foreign key.
                                                        // Break out of the loop
                                                        break;
                                                    }
                                                }
                                                // Work done for selected foreign key.
                                                // Break out of the loop
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (transactionQuery.ForeignKeyList.Count > 0)
                                {
                                    // Find the list of foreign keys of current query
                                    fkList = transactionQuery.ForeignKeyList;

                                    // loop for all items of foreign key
                                    for (int j = 0; j < fkList.Count; j++)
                                    {
                                        if (fkList[j].PrimaryKeyQueryIndex == -1)
                                            throw new System.Exception("Primary key query index is missing a value in foreign key definition.");

                                        // Find the the index of "Source" key in the list of
                                        // parameters of current query by comparing their names
                                        int k = -1;
                                        int l = -1;
                                        k = transactionQuery.SQLParameters.GetParameterIndexByName(fkList[j].SourceKey.ToUpper());
                                        // if "Source" key index is found
                                        if (k != -1)
                                        {
                                            // then find the index of "Target" key in the
                                            // list of parameters of previous parent table 
                                            // by comparing their names
                                            l = transactionQueryList[fkList[j].PrimaryKeyQueryIndex].SQLParameters.GetParameterIndexByName(fkList[j].TargetKey.ToUpper());
                                            // if "Target" key is found, then assign
                                            // the value of selected key of previous parent
                                            // table (returned by output parameter) to the
                                            // selected key of parameters of current
                                            // query
                                            if (l != -1)
                                                transactionQuery.SQLParameters[k].ParameterValue = transactionQueryList[fkList[j].PrimaryKeyQueryIndex].SQLParameters[l].ParameterValue;
                                        }
                                    }
                                }

                                // Build command and execute query
                                cmd = BuildSqlCommand(conn, transaction, CommandType.StoredProcedure, transactionQuery.ProcedureName, transactionQuery.SQLParameters);
                                cmd.ExecuteNonQuery();
                                StoreParameterOutputValues(cmd, transactionQuery.SQLParameters);
                            }

                            // All went well. Now commit the transaction and
                            // close the database connection
                            transaction.Commit();
                            conn.Close();
                            // Gurukul.Database.Common.SQLParameter.ConType = ConnectionType.WebConn;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
                        //Gurukul.Database.Common.SQLParameter.ConType = ConnectionType.WebConn;
                    }
                }
                public static void ExecuteNonQuery(Common.TransactionQueryList transactionQueryList, int timeOutDuration)
                {
                    SqlConnection conn = new SqlConnection(ConnectionString);
                    SqlCommand cmd;
                    SqlTransaction transaction;
                    Common.TransactionQuery transactionQuery;
                    Common.ForeignKeyList fkList;

                    try
                    {
                        conn.Open();
                        transaction = conn.BeginTransaction();

                        try
                        {
                            for (int i = 0; i < transactionQueryList.Count; i++)
                            {
                                transactionQuery = transactionQueryList[i];

                                // Set the direction of all primary keys in current transaction
                                // query
                                // Assumption: No two parameter/PK names are same
                                if (transactionQuery.PrimaryKeyList.Count > 0)
                                {
                                    // for each primary keys of current query
                                    for (int j = 0; j < transactionQuery.PrimaryKeyList.Count; j++)
                                    {
                                        // loop through all the parameters of current query
                                        for (int k = 0; k < transactionQuery.SQLParameters.Count; k++)
                                        {
                                            // to find the the index of primary key in the list
                                            // parameters of current query by comparing their names
                                            if (transactionQuery.PrimaryKeyList[j].KeyName.ToUpper() == transactionQuery.SQLParameters[k].ParameterName.ToUpper())
                                            {
                                                // Set the direction of selected parameter
                                                transactionQuery.SQLParameters[k].ParameterDirection = ParameterDirection.InputOutput;
                                                // Work done for selected primary key. 
                                                // Break out of the loop.
                                                break;
                                            }
                                        }
                                    }
                                }

                                // Set the value of foreign keys with the values of
                                // primary keys (returned by output parameter) of previous
                                // parent table
                                if (transactionQuery.PrimaryKeyQueryIndex != -1 && transactionQuery.ForeignKeyList.Count > 0)
                                {
                                    // Find the list of foreign keys of current query
                                    fkList = transactionQuery.ForeignKeyList;

                                    // loop for all items of foreign key
                                    for (int j = 0; j < fkList.Count; j++)
                                    {
                                        // loop through all the parameters of current query
                                        for (int k = 0; k < transactionQuery.SQLParameters.Count; k++)
                                        {
                                            // to find the the index of "Source" key in the list
                                            // parameters of current query by comparing their names
                                            if (fkList[j].SourceKey.ToUpper() == transactionQuery.SQLParameters[k].ParameterName.ToUpper())
                                            {
                                                // if "Source" key index is found
                                                // then loop through all the parameters of previous
                                                // parent table 
                                                for (int l = 0; l < transactionQueryList[transactionQuery.PrimaryKeyQueryIndex].SQLParameters.Count; l++)
                                                {
                                                    // to find the index of "Target" key in the
                                                    // list of parameters by comparing their names
                                                    if (fkList[j].TargetKey.ToUpper() == transactionQueryList[transactionQuery.PrimaryKeyQueryIndex].SQLParameters[l].ParameterName.ToUpper())
                                                    {
                                                        // if "Target" key is found, then assign
                                                        // the value of selected key of previous parent
                                                        // table (returned by output parameter) to the
                                                        // selected key of parameters of current
                                                        // query
                                                        transactionQuery.SQLParameters[k].ParameterValue = transactionQueryList[transactionQuery.PrimaryKeyQueryIndex].SQLParameters[l].ParameterValue;
                                                        // Work done for selected foreign key.
                                                        // Break out of the loop
                                                        break;
                                                    }
                                                }
                                                // Work done for selected foreign key.
                                                // Break out of the loop
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (transactionQuery.ForeignKeyList.Count > 0)
                                {
                                    // Find the list of foreign keys of current query
                                    fkList = transactionQuery.ForeignKeyList;

                                    // loop for all items of foreign key
                                    for (int j = 0; j < fkList.Count; j++)
                                    {
                                        if (fkList[j].PrimaryKeyQueryIndex == -1)
                                            throw new System.Exception("Primary key query index is missing a value in foreign key definition.");

                                        // Find the the index of "Source" key in the list of
                                        // parameters of current query by comparing their names
                                        int k = -1;
                                        int l = -1;
                                        k = transactionQuery.SQLParameters.GetParameterIndexByName(fkList[j].SourceKey.ToUpper());
                                        // if "Source" key index is found
                                        if (k != -1)
                                        {
                                            // then find the index of "Target" key in the
                                            // list of parameters of previous parent table 
                                            // by comparing their names
                                            l = transactionQueryList[fkList[j].PrimaryKeyQueryIndex].SQLParameters.GetParameterIndexByName(fkList[j].TargetKey.ToUpper());
                                            // if "Target" key is found, then assign
                                            // the value of selected key of previous parent
                                            // table (returned by output parameter) to the
                                            // selected key of parameters of current
                                            // query
                                            if (l != -1)
                                                transactionQuery.SQLParameters[k].ParameterValue = transactionQueryList[fkList[j].PrimaryKeyQueryIndex].SQLParameters[l].ParameterValue;
                                        }
                                    }
                                }

                                // Build command and execute query
                                cmd = BuildSqlCommand(conn, transaction, CommandType.StoredProcedure, transactionQuery.ProcedureName, transactionQuery.SQLParameters, timeOutDuration);
                                cmd.ExecuteNonQuery();
                                StoreParameterOutputValues(cmd, transactionQuery.SQLParameters);
                            }

                            // All went well. Now commit the transaction and
                            // close the database connection
                            transaction.Commit();
                            conn.Close();
                            //Gurukul.Database.Common.SQLParameter.ConType = ConnectionType.WebConn;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (conn.State != ConnectionState.Closed)
                            conn.Close();
                        //Gurukul.Database.Common.SQLParameter.ConType = ConnectionType.WebConn;
                    }
                }
                public static void SqlBulkCopyImport(DataTable dtExcel, string destabname, string[] destcol)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        // Open the connection.
                        conn.Open();
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                        {
                            // Specify the destination table name.
                            bulkCopy.DestinationTableName = destabname;
                            string[] desttablecol = destcol;
                            int i = 0;
                            int j = desttablecol.Length;
                            foreach (DataColumn dc in dtExcel.Columns)
                            {
                                // Because the number of the test Excel columns is not 
                                // equal to the number of table columns, we need to map 
                                // columns.
                                if (i < j)
                                {
                                    bulkCopy.ColumnMappings.Add(dc.ColumnName, desttablecol[i].ToString());
                                    i++;
                                }
                                //break;

                            }

                            // Write from the source to the destination.
                            bulkCopy.WriteToServer(dtExcel);
                        }
                    }
                }
                #endregion
            }
        }
        #endregion
    }
}
