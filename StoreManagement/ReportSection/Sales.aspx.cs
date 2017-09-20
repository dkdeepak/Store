using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using AjaxControlToolkit;
using Store;

namespace StoreManagement.ReportSection
{
    public partial class Sales : System.Web.UI.Page
    {
        Store.SalesOrderItem.BusinessLogic.SalesOrderItem oblSalesOrderItem = null;
        Store.SalesOrder.BusinessLogic.SalesOrder oblSalesOrder = new Store.SalesOrder.BusinessLogic.SalesOrder();
        Store.SalesOrder.BusinessObject.SalesOrderList objSalesList = new Store.SalesOrder.BusinessObject.SalesOrderList();
        Store.SalesOrder.BusinessObject.SalesOrder objSalesOrder = null;
        Store.SalesOrderItem.BusinessObject.SalesOrderItem objsalesOrderItem = null;
        Store.SalesOrder.BusinessObject.SalesOrder objSalesOrderList = null;
        Store.SalesOrderItem.BusinessObject.SalesOrderItemList objSalesOrderItemList = null;
        Store.Common.MessageInfo objMessageInfo = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindSalesOrder();
            }
        }
             

        protected void gvSOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int sid = Convert.ToInt32(gvSOrder.DataKeys[e.Row.RowIndex].Value.ToString());
                GridView gv = (GridView)e.Row.FindControl("gvSOrderItem");
                //gv.DataSource = BindPurchaseOrderItem(pid);
                gv.DataSource = BindSalesOrderItem(sid);
                gv.DataBind();
            }
        }
        void BindSalesOrder()
        {
            oblSalesOrder = new Store.SalesOrder.BusinessLogic.SalesOrder();


            try
            {
                objSalesList = oblSalesOrder.GetAllSalesOrderList(0, 0, "");

                if (objSalesList != null)
                {
                    gvSOrder.DataSource = objSalesList;
                    gvSOrder.DataBind();

                }
                else
                {
                    gvSOrder.DataSource = null;
                    gvSOrder.DataBind();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oblSalesOrder = null;
                objSalesOrderList = null;
            }


        }
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        { }
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
        //    cmdMode = CommandMode.D;
        //    objSalesOrder = new Store.SalesOrder.BusinessObject.SalesOrder();
        //    oblSalesOrder = new Store.SalesOrder.BusinessLogic.SalesOrder();
        //     objMessageInfo = new MessageInfo();
        //    try
        //    {

        //        ImageButton btndetails = sender as ImageButton;
        //        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //        objSalesOrder.SalesOrderID = Convert.ToInt32(gvSOrder.DataKeys[gvrow.RowIndex].Value.ToString());
        //        objMessageInfo = oblSalesOrder.ManageSaleOrder(objSalesOrder,Convert.ToInt32(cmdMode));
        //        BindSalesOrder();
        //        if (objMessageInfo.TranID != 0)

        //            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
        //        else if (objMessageInfo.ErrorCode == -101)
        //            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.ErrorMessage + "')", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {

        //        objMessageInfo = null;
        //        oblSalesOrder = null;
        //        objSalesOrder = null;

        //    }
        }
        Store.SalesOrderItem.BusinessObject.SalesOrderItemList BindSalesOrderItem(int id)
        {
            oblSalesOrderItem = new Store.SalesOrderItem.BusinessLogic.SalesOrderItem();
            try
            {
                objSalesOrderItemList = oblSalesOrderItem.GetAllSalesOrderItemList(id, 0, "");
                return objSalesOrderItemList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oblSalesOrderItem = null;
                objSalesOrderItemList = null;
            }
        }
    }
}