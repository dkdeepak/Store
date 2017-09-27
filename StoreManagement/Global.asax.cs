﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace StoreManagement
{
    public class Global : System.Web.HttpApplication
    {
        private static MetaModel s_defaultModel = new MetaModel();
        public static MetaModel DefaultModel
        {
            get
            {
                return s_defaultModel;
            }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            //                    IMPORTANT: DATA MODEL REGISTRATION 
            // Uncomment this line to register a LINQ to SQL model for ASP.NET Dynamic Data.
            // Set ScaffoldAllTables = true only if you are sure that you want all tables in the
            // data model to support a scaffold (i.e. templates) view. To control scaffolding for
            // individual tables, create a partial class for the table and apply the
            // [ScaffoldTable(true)] attribute to the partial class.
            // Note: Make sure that you change "YourDataContextType" to the name of the data context
            // class in your application.
            //DefaultModel.RegisterContext(typeof(YourDataContextType), new ContextConfiguration() { ScaffoldAllTables = false });

            // The following statement supports separate-page mode, where the List, Detail, Insert, and 
            // Update tasks are performed by using separate pages. To enable this mode, uncomment the following 
            // route definition, and comment out the route definitions in the combined-page mode section that follows.
            routes.Add(new DynamicDataRoute("{table}/{action}.aspx")
            {
                Constraints = new RouteValueDictionary(new { action = "List|Details|Edit|Insert" }),
                Model = DefaultModel
            });

            // The following statements support combined-page mode, where the List, Detail, Insert, and
            // Update tasks are performed by using the same page. To enable this mode, uncomment the
            // following routes and comment out the route definition in the separate-page mode section above.
            //routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx") {
            //    Action = PageAction.List,
            //    ViewName = "ListDetails",
            //    Model = DefaultModel
            //});

            //routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx") {
            //    Action = PageAction.Details,
            //    ViewName = "ListDetails",
            //    Model = DefaultModel
            //});
        }

        void Application_Start(object sender, EventArgs e)
        {
            Store.DatabaseHelper.Database.DatabaseHelper.ExecuteQuery.ConnectionString = ConfigurationManager.ConnectionStrings["ShopDB"].ToString();
            //Pareeksha.Database.DatabaseHelper.ExecuteQuery.ConnectionString = ConfigurationManager.ConnectionStrings["MyDbCon"].ToString();
        }
        //public static void WriteErrorLog(string strError)
        //{
        //    try
        //    {
        //        string strLogPath = HttpContext.Current.Server.MapPath("~/Log/");
        //        using (SqlConnection con = new SqlConnection())
        //        {
        //            con.ConnectionString = ConfigurationManager.ConnectionStrings["ShopDB"].ConnectionString;
        //            SqlCommand cmd = new SqlCommand("Sp_LogException", con);
        //            cmd.CommandType = CommandType.StoredProcedure;


        //            string strFileNameSuffix = DateTime.Today.Date.Day.ToString() + "_" + DateTime.Today.Date.Month.ToString() + "_" + DateTime.Today.Date.Year.ToString() + ".log";
        //            string strLine;

        //            string strFileName = strLogPath + strFileNameSuffix;

        //            strLine = DateTime.Now.ToString() + "|" + strError;
        //            StreamWriter sw;

        //            sw = new StreamWriter(strFileName, true);
        //            using (sw)
        //            {
        //                sw.WriteLine(strLine);
        //                sw.Close();
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        //string ErrMsg = ex.Message ;
        //    }


        //}
    }
}
