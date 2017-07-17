using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using AjaxControlToolkit;


namespace StoreManagement
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataSource dbSrc = new SqlDataSource();
                dbSrc.ConnectionString = ConfigurationManager.ConnectionStrings["ShopDB"].ConnectionString;
                dbSrc.SelectCommand = "SELECT PurchaseOrderID, PurchaseAmount, TaxValue FROM tbl_tPurchaseOrder";
                GridView1.DataSource = dbSrc;
                GridView1.DataBind();
            }
        }
        //The code to populate the nested GridView that is called on the main GridView's OnRowDataBound event
        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                GridView gv = (GridView)e.Row.FindControl("GridView2");
                SqlDataSource dbSrc = new SqlDataSource();
                dbSrc.ConnectionString = ConfigurationManager.ConnectionStrings["ShopDB"].ConnectionString;
                dbSrc.SelectCommand = "SELECT PurchaseOrderItemID,ItemID, ItemUnit FROM tbl_tPurchaseOrderItem where PurchaseOrderID='" + ((DataRowView)e.Row.DataItem)["PurchaseOrderID"].ToString() + "'";
                gv.DataSource = dbSrc;
                gv.DataBind();
            }
        }

    }
    }
