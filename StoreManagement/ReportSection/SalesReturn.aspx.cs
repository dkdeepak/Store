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
    public partial class SalesReturn : System.Web.UI.Page
    {
        Store.SaleReturnItem.BusinessObject.SaleReturnItem objsalesRtnItem = null;
        Store.SalesReturned.BusinessObject.SalesReturnedList objsalesRtnList = null;
        Store.SaleReturnItem.BusinessObject.SaleReturnItemList objsalesRtnItemList = null;
        Store.SaleReturnItem.BusinessLogic.SaleReturnItem oblsalesRtnItem = null;
        Store.SalesReturned.BusinessLogic.SalesReturned oblSalesRtn = null;
        Store.Common.MessageInfo objMessageInfo = null;
        Store.SalesReturned.BusinessObject.SalesReturned objSalesRtn = null;
        Store.Item.BusinessLogic.Item oblItem = new Store.Item.BusinessLogic.Item();
        Store.Item.BusinessObject.ItemList objItemList = new Store.Item.BusinessObject.ItemList();
        Store.SalesOrder.BusinessObject.SalesOrder objSales = null;
        Store.SalesOrder.BusinessLogic.SalesOrder oblSales = null;
        Store.SalesOrderItem.BusinessObject.SalesOrderItemList objSalesItemList = null;
        Store.SalesOrderItem.BusinessLogic.SalesOrderItem oblSalesItem = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindSalesReturn();
            }

        }
        
        private void BindSalesReturn()
        {
            
                try
                {
                oblSalesRtn = new Store.SalesReturned.BusinessLogic.SalesReturned();
                objsalesRtnList = new Store.SalesReturned.BusinessObject.SalesReturnedList();
                objsalesRtnList = oblSalesRtn.GetAllSalesReturnedList(0,0,"");
                            
               
             
                if (objsalesRtnList != null)
                {
                    gvSalesRtn.DataSource = objsalesRtnList;
                    gvSalesRtn.DataBind();
                }
                else
                {
                    gvSalesRtn.DataSource = null;
                    gvSalesRtn.DataBind();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oblSalesRtn = null;
                objsalesRtnList = null;
            }
        }
        protected void gvSalesRtn_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int SRtnId = Convert.ToInt32(gvSalesRtn.DataKeys[e.Row.RowIndex].Value.ToString());
                GridView gv = (GridView)e.Row.FindControl("gvSalesReturn");
                gv.DataSource = BindSalesReturnItem(SRtnId);
                gv.DataBind();
            }
        }
        Store.SaleReturnItem.BusinessObject.SaleReturnItemList BindSalesReturnItem(int id)
              
        {


            try
            {
                oblsalesRtnItem = new Store.SaleReturnItem.BusinessLogic.SaleReturnItem();
                objsalesRtnItemList = new Store.SaleReturnItem.BusinessObject.SaleReturnItemList();
                objsalesRtnItemList = oblsalesRtnItem.GetAllSaleReturnItemList(id, 0, "");                
                return objsalesRtnItemList;
            }
            catch (Exception ex)
            {
                //return null;
                throw ex;
            }
            finally
            {

                oblsalesRtnItem = null;
                objsalesRtnItemList = null;
            }


        }
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
        }
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
    //        cmdMode = CommandMode.D;
    //        objSalesRtn =new Store.SalesReturned.BusinessObject.SalesReturned();
    //        oblSalesRtn =new Store.SalesReturned.BusinessLogic.SalesReturned();
    //        objMessageInfo = new MessageInfo();
    //        try
    //        {

    //            ImageButton btndetails = sender as ImageButton;
    //            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
    //            objSalesRtn.SalesReturnedID = Convert.ToInt32(gvSalesRtn.DataKeys[gvrow.RowIndex].Value.ToString());
    //            objMessageInfo = oblSalesRtn.ManageSalesRetuned(objSalesRtn,Convert.ToInt32(cmdMode));
    //            BindSalesReturn();
    //            if (objMessageInfo.TranID != 0)

    //                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
    //            else if (objMessageInfo.ErrorCode == -101)
    //                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.ErrorMessage + "')", true);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {

    //            objMessageInfo = null;
    //            oblSalesRtn = null;
    //            objSalesRtn = null;

    //        }


        }




    }
}