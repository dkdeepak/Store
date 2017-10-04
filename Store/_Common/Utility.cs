using System;
using System.Data;
using System.Configuration;
using System.Web;
using Store.DatabaseHelper.Database.Common;
using Store.DatabaseHelper.Database.DatabaseHelper;

namespace Store
{
    namespace Common
    {
        namespace Utility
        {
            /// <summary>
            /// Class with static functions to create a JavaScript block
            /// using System.Text.StringBuilder. As StringBuilder is 
            /// incapsulated in the class, the client is not required
            /// import/refernce it.
            /// 
            /// The class also performs basic formatting of the string.
            /// </summary>
            public class ScriptBuilder
            {
                private static System.Text.StringBuilder _sbScript = new System.Text.StringBuilder();

                public static string Script
                {
                    get { return _sbScript.ToString(); }
                }

                public static void AppendScript(string script)
                {
                    _sbScript.Append(script + " " + "\n");
                }

                public static void Clear()
                {
                    _sbScript.Length = 0;
                }
            }
            public static class ExceptionLog
            {
              public static void Exceptionlogs(string msg, string loc, string page, int userId)
                {
                    string SQL = "";
                    ParameterList param = new ParameterList();
                    SQL = "proc_ExceptionLog";
                    param.Add(new SQLParameter("@msg", msg));
                    param.Add(new SQLParameter("@loc", loc));
                    param.Add(new SQLParameter("@page", page));
                    param.Add(new SQLParameter("@UserId", userId));
                    ExecuteQuery.ExecuteNonQuery(SQL, param);
                }
                public static string LineNumber(this Exception e)
                {
                    string linenum = "";
                    try
                    {
                        linenum = Convert.ToString(e.StackTrace.Substring(e.StackTrace.LastIndexOf(' ')));
                    }
                    catch
                    {
                    }
                    return linenum;
                }
            }
        }
    }
}

