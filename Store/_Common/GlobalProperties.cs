using System;
using System.Data;
using System.Configuration;
using System.Web;


namespace Store
{
    namespace Common
    {
        /// <summary>
        /// Summary description for GlobalProperties
        /// </summary>
        public static class GlobalProperties
        {
            static DateTime _fromDate;
            static DateTime _toDate;
            static int _systemCode;
            
            public static DateTime FromDate
            {
                get { return _fromDate; }
                set { _fromDate = value; }
            }
            public static int SystemCode
            {
                get { return _systemCode; }
                set { _systemCode = value; }
            }
            public static int RefCode {get;set;}           

            public static DateTime ToDate
            {
                get
                {
                    if (_toDate != DateTime.MinValue)
                        return Convert.ToDateTime(_toDate.Month + "/" + _toDate.Day + "/" + _toDate.Year + " 23:59:59.998");
                    else
                        return _toDate;
                }
                set { _toDate = value; }
            }
        }
    }
}
