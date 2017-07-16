using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Data.SqlClient;

namespace StoreManagement.Report
{
    public partial class SalesOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument rptDoc = new ReportDocument();
            //SMS.Admin.Admission.Report.Admission.AdmissionDetails ds = new SMS.Admin.Admission.Report.Admission.AdmissionDetails(); // .xsd file name
            StoreManagement.Report.SalesOrderDetails sod = new StoreManagement.Report.SalesOrderDetails();
            DataTable dt = new DataTable();

            // Just set the name of data table
            dt.TableName = "DataTable1";
            rptDoc.Load(Server.MapPath("~/StoreManagement/Report/SalesOrder.rpt"));

            //set dataset to the report viewer.
            rptDoc.SetDataSource(sod);
            
            

            
        }
    }
}