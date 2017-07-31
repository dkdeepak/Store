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


namespace StoreManagement.ReportSection
{
    public partial class PurchaseReceived : System.Web.UI.Page
    {
        Store.PurchaseOrder.BusinessLogic.PurchaseOrder odlPOrder = null;
        Store.PurchaseOrder.BusinessObject.PurchaseOrder objPOrder = null;
        Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem oblPurchaseOrderItem = null;
        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList objPurchaseOrderItemList = null;
        Store.PurchaseReceived.BusinessLogic.PurchaseReceived oblPurchaseReceived = null;
        Store.Common.MessageInfo objMessageInfo = null;
        Store.PurchaseReceived.BusinessObject.PurchaseReceived objPurchaseReceived = null;
        Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem objPurchaseReceivedItem = null;
        Store.PurchaseReceived.BusinessObject.PurchaseReceivedList objPurchaseReceivedList = null;
        Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItemList objPurchaseReceivedItemList = null;
        Store.PurchaseReceivedItem.BusinessLogic.PurchaseReceivedItem oblPurchaseReceivedItem = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               // divForm.Style.Add("display", "none");
                //divSerach.Style.Add("display", "block");
                //up1.Update();
                bindPRecived();
            }

        }
        private void bindPRecived()
        {

            try
            {
                oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
                objPurchaseReceivedList = new Store.PurchaseReceived.BusinessObject.PurchaseReceivedList();
                objPurchaseReceivedList = oblPurchaseReceived.GetAllPurchaseReceivedList(0, 0, "");
                if (objPurchaseReceivedList != null)
                {
                    gvPOrder.DataSource = objPurchaseReceivedList;
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
                oblPurchaseReceived = null;
                objPurchaseReceivedList = null;
            }
        }
        Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItemList BindPurchaseReceivedItem(int id)
        {


            try
            {
                oblPurchaseReceivedItem = new Store.PurchaseReceivedItem.BusinessLogic.PurchaseReceivedItem();
                objPurchaseReceivedItemList = new Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItemList();
                objPurchaseReceivedItemList = oblPurchaseReceivedItem.GetAllPurchaseReceivedItemList(id, 0, "");
                return objPurchaseReceivedItemList;
            }
            catch (Exception ex)
            {
                //return null;
                throw ex;
            }
            finally
            {

                oblPurchaseReceivedItem = null;
                objPurchaseReceivedItemList = null;
            }


        }
        protected void gvPOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int pid = Convert.ToInt32(gvPOrder.DataKeys[e.Row.RowIndex].Value.ToString());
                GridView gv = (GridView)e.Row.FindControl("gvPoItem");
                gv.DataSource = BindPurchaseReceivedItem(pid);
                gv.DataBind();
            }
        }
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            //objPurchaseOrder = new Store.PurchaseOrder.BusinessObject.PurchaseOrder();
            //oblPurchaseOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();
            //objPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem();
            //oblPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem();
            //try
            //{

            //    ImageButton btndetails = sender as ImageButton;
            //    GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            //    int id = Convert.ToInt32(gvPOrder.DataKeys[gvrow.RowIndex].Value.ToString());
            //    int rt = checkPRvied(id);
            //    if (rt == 1)
            //    {
            //        reset();
            //        hfPId.Value = id.ToString();
            //        objPurchaseOrder = oblPurchaseOrder.GetAllPurchaseOrder(id, 0, "");
            //        if (objPurchaseOrder != null)
            //        {
            //            txtDic.Text = objPurchaseOrder.PDiscount.ToString();
            //            txtDicPre.Text = objPurchaseOrder.PDiscountPre.ToString();
            //            txtMiscCost.Text = objPurchaseOrder.MiscCost.ToString();
            //            txtSHC.Text = objPurchaseOrder.ShipingAndHandlingCost.ToString();
            //            txtTax.Text = objPurchaseOrder.TaxValue.ToString();
            //            txttotal.Text = objPurchaseOrder.PurchaseAmount.ToString();
            //            objPurchaseOrderItemList = oblPurchaseOrderItem.GetAllPurchaseOrderItemList(id, 0, "");
            //            if (objPurchaseOrderItemList != null)
            //            {
            //                Gridview1.DataSource = null;
            //                Gridview1.DataBind();
            //                Gridview1.DataSource = objPurchaseOrderItemList;
            //                Gridview1.DataBind();
            //            }
            //        }
            //        upForm.Update();
            //    }
            //    //edit logic
            //}
            //catch (Exception ex)
            //{ }
            //finally
            //{
            //    objPurchaseOrder = null;
            //    oblPurchaseOrder = null;
            //    objPurchaseOrderItem = null;
            //    oblPurchaseOrderItem = null;
            //}
            //cmdMode = CommandMode.M;
        }
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
            objPurchaseReceived = new Store.PurchaseReceived.BusinessObject.PurchaseReceived();

            objMessageInfo = new MessageInfo();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objPurchaseReceived.PurchaseReceivedID = Convert.ToInt32(gvPOrder.DataKeys[gvrow.RowIndex].Value.ToString());                     
                bindPRecived();
                if (objMessageInfo.TranID != 0)
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
                else if (objMessageInfo.ErrorCode == -101)
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.ErrorMessage + "')", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                objMessageInfo = null;
                objPurchaseReceived = null;
                oblPurchaseReceived = null;

            }
        }
    }
}