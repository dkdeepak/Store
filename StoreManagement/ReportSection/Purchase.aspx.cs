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
    public partial class Purchase : System.Web.UI.Page
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

        //protected void linkButton_Click(object sender, EventArgs e)
        //{
        //    cmdMode = CommandMode.N;
        //    ResetForm();
        //    updateCountryBdInfo.Update();
        //    gvPOrder.Visible = false;
        //    this.ModalPopupExtender1.Show();
        //}
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
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            //    objPurchaseOrder = new Store.PurchaseOrder.BusinessObject.PurchaseOrder();
            //    oblPurchaseOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();
            //    objPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem();
            //    oblPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem();
            //    try
            //    {

            //        ImageButton btndetails = sender as ImageButton;
            //        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            //        int id = Convert.ToInt32(gvPOrder.DataKeys[gvrow.RowIndex].Value.ToString());
            //        int rt = checkPRvied(id);
            //        if (rt == 1)
            //        {
            //            reset();
            //            hfPId.Value = id.ToString();
            //            objPurchaseOrder = oblPurchaseOrder.GetAllPurchaseOrder(id, 0, "");
            //            if (objPurchaseOrder != null)
            //            {
            //                txtDic.Text = objPurchaseOrder.PDiscount.ToString();
            //                txtDicPre.Text = objPurchaseOrder.PDiscountPre.ToString();
            //                txtMiscCost.Text = objPurchaseOrder.MiscCost.ToString();
            //                txtSHC.Text = objPurchaseOrder.ShipingAndHandlingCost.ToString();
            //                txtTax.Text = objPurchaseOrder.TaxValue.ToString();
            //                txttotal.Text = objPurchaseOrder.PurchaseAmount.ToString();
            //                objPurchaseOrderItemList = oblPurchaseOrderItem.GetAllPurchaseOrderItemList(id, 0, "");
            //                if (objPurchaseOrderItemList != null)
            //                {
            //                    Gridview1.DataSource = null;
            //                    Gridview1.DataBind();
            //                    Gridview1.DataSource = objPurchaseOrderItemList;
            //                    Gridview1.DataBind();
            //                }
            //            }
            //            upForm.Update();
            //        }
            //        //edit logic
            //    }
            //    catch (Exception ex)
            //    { }
            //    finally
            //    {
            //        objPurchaseOrder = null;
            //        oblPurchaseOrder = null;
            //        objPurchaseOrderItem = null;
            //        oblPurchaseOrderItem = null;
            //    }
            //    cmdMode = CommandMode.M;
        }
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;

            oblPurchaseOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();
            objPurchaseOrder = new Store.PurchaseOrder.BusinessObject.PurchaseOrder();
            objMessageInfo = new MessageInfo();
            try
            {

                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objPurchaseOrder.PurchaseOrderID = Convert.ToInt32(gvPOrder.DataKeys[gvrow.RowIndex].Value.ToString());
                objMessageInfo = oblPurchaseOrder.ManagePurchaseOrder(objPurchaseOrder, cmdMode);
                BindPurchaseOrder();
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
                oblPurchaseOrder = null;
                objPurchaseOrder = null;

            }
        }
        protected void gvPOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int pid = Convert.ToInt32(gvPOrder.DataKeys[e.Row.RowIndex].Value.ToString());
                GridView gv = (GridView)e.Row.FindControl("gvPoItem");
                gv.DataSource = BindPurchaseOrderItem(pid);
                gv.DataBind();
            }
        }



    }
}