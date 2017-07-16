using System;
using System.Data;
using System.Configuration;
using System.Web;

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
        }
    }
}
