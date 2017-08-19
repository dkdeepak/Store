using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreManagement.ReportSection
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Store.PurchaseOrder.BusinessLogic.PurchaseOrder oblPurchaseOrder = null;
        Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem oblPurchaseOrderItem = null;
        Store.Common.MessageInfo objMessageInfo = null;
        Store.PurchaseOrder.BusinessObject.PurchaseOrder objPurchaseOrder = null;
        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem objPurchaseOrderItem = null;
        Store.PurchaseOrder.BusinessObject.PurchaseOrderList objPurchaseOrderList = null;
        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList objPurchaseOrderItemList = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindPurchaseOrder();
              //  BindPurchaseOrderItem();

            }
        }
        void BindPurchaseOrder()
        {
            oblPurchaseOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();

            try
            {
                objPurchaseOrderList = oblPurchaseOrder.GetAllPurchaseOrderList(0, 0, "");
                if (objPurchaseOrderList != null)
                {
                    gvPOrder.DataSource = objPurchaseOrderList;
                    gvPOrder.DataBind();

                }
                else
                {
                    gvPOrder.DataSource = null;
                    gvPOrder.DataBind();




                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oblPurchaseOrder = null;
                objPurchaseOrderList = null;
            }

        }

        
        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList BindPurchaseOrderItem(int id)
        {
            oblPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem();

            try
            {
                objPurchaseOrderItemList = oblPurchaseOrderItem.GetAllPurchaseOrderItemList(id, 0, "");
                return objPurchaseOrderItemList;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

                oblPurchaseOrderItem = null;
                objPurchaseOrderItemList = null;
            }


        }
       
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
       
     
        //protected void gvPOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    { 
        //        int pid = Convert.ToInt32(gvPOrder.DataKeys[e.Row.RowIndex].Value.ToString());
        //        GridView gv = (GridView)e.Row.FindControl("gv1");
        //        gv.DataSource = BindPurchaseOrderItem(pid);
        //        gv.DataBind();
        //    }
        //}

        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsPostBack)
            {

                  pnl.Visible = true;
                //gv1.Visible = true;
                gvPOrder.Visible = false;
                   int pid = Convert.ToInt32(gvPOrder.DataKeys.ToString());
                    GridView gv = (GridView)FindControl("gv1");
                    gv1.DataSource = BindPurchaseOrderItem(pid);
                    gv1.DataBind();
                

            }
        }
    }

}