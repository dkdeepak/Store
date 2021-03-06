﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
	public partial class PurchaseOrderItem : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPurchaseOrderItem();
                BindPurchaseOrder();
                BindItem();
               
            }
        }
        Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem oblPurchaseOrderItem = null;
        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem objPurchaseOrderItem = null;
        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList objPurchaseOrderItemList = null;
        Store.PurchaseOrder.BusinessLogic.PurchaseOrder oblPurchaseOrder = null;
        Store.PurchaseOrder.BusinessObject.PurchaseOrderList objPurchaseOrderList = null;
        Store.Item.BusinessLogic.Item oblItem = null;
        Store.Item.BusinessObject.ItemList objItemList = null;
        Store.Common.MessageInfo objMessageInfo = null;
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        #region ControlDefinedFunction

        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            ResetForm();
            objPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem();
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtPurchaseItemOrderID.Text = dgvPurchaseItemOrder.DataKeys[gvrow.RowIndex].Value.ToString();
            ddlPurchaseOrderId.SelectedItem.Selected = false;
            ddlPurchaseOrderId.Items.FindByText(gvrow.Cells[0].Text.ToString()).Selected=true;
            ddlItemId.SelectedItem.Selected = false;
            ddlItemId.Items.FindByText( gvrow.Cells[1].Text.ToString()).Selected=true;
            txtItemUnit.Text=gvrow.Cells[2].Text;
            txtDescription.Text = gvrow.Cells[3].Text;
            txtItemPrice.Text = gvrow.Cells[4].Text;
            int i=Convert.ToInt32(gvrow.Cells[5].Text);
            if (i == 1)
                chkBoxIsActive.Checked = true;
            else
                chkBoxIsActive.Checked = false;
            updatePurchasedItemOrderBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem();
            oblPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem();


            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objPurchaseOrderItem.PurchaseOrderItemID = Convert.ToInt32(dgvPurchaseItemOrder.DataKeys[gvrow.RowIndex].Value.ToString());                
                objPurchaseOrderItem.PurchaseOrderID = 0;
                objPurchaseOrderItem.ItemID = 0;
                objPurchaseOrderItem.ItemUnit = "";
                objPurchaseOrderItem.Description = "";
                objPurchaseOrderItem.ItemPrice = 0;
                objPurchaseOrderItem.ClientID = 0;
                objPurchaseOrderItem.CreatedBy = 1;
                objMessageInfo = oblPurchaseOrderItem.ManageItemMaster(objPurchaseOrderItem, cmdMode);
                BindPurchaseOrderItem();
                updatePurchasedItemOrderBdInfo.Update();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objPurchaseOrderItem = null;
                objMessageInfo = null;
                oblPurchaseOrderItem = null;

            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updatePurchasedItemOrderBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgPOItem");
            if (Page.IsValid)
            {
            ManagePurchaseItemRecived();
            if (objMessageInfo.ErrorCode == -101)
            {

                // ClientScript.RegisterStartupScript(this.GetType(), "newWindow", string.Format("<script>window.open('{0}');</script>", objMessageInfo.ErrorMessage));
                lblMsg.Text = Convert.ToString(objMessageInfo.ErrorMessage);
            }
            if (objMessageInfo.TranID > 0)
            {
                lblMsg.Text = Convert.ToString(objMessageInfo.TranMessage);
            }
            this.ModalPopupExtender1.Hide();
            BindPurchaseOrderItem();
            updatePurchasedItemOrderBdInfo.Update();
            }
        }
        #endregion
        #region UserDefinedFunction
        void BindPurchaseOrderItem()
        {
            oblPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem();

            try
            {
                objPurchaseOrderItemList = oblPurchaseOrderItem.GetAllPurchaseOrderItemList(0, 0, "");

                if (objPurchaseOrderItemList != null)
                {
                    dgvPurchaseItemOrder.DataSource = objPurchaseOrderItemList;
                    dgvPurchaseItemOrder.DataBind();
                }
                else
                {
                    dgvPurchaseItemOrder.DataSource = null;
                    dgvPurchaseItemOrder.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblPurchaseOrderItem = null;
                objPurchaseOrderItemList = null;
            }


        }
        void ManagePurchaseItemRecived()
        {
            objPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem();
            oblPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem();

            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objPurchaseOrderItem.PurchaseOrderItemID = Convert.ToInt32(txtPurchaseItemOrderID.Text);

                }
                else
                {
                    objPurchaseOrderItem.PurchaseOrderItemID = 0;

                }
                objPurchaseOrderItem.PurchaseOrderID = Convert.ToInt32(ddlPurchaseOrderId.SelectedItem.Value);
                objPurchaseOrderItem.ItemID = Convert.ToInt32(ddlItemId.SelectedItem.Value);
                objPurchaseOrderItem.ItemUnit = Convert.ToString(txtItemUnit.Text);
                objPurchaseOrderItem.Description = Convert.ToString(txtDescription.Text);
                objPurchaseOrderItem.ItemPrice = Convert.ToDecimal(txtItemPrice.Text);


                if (chkBoxIsActive.Checked)
                {
                    objPurchaseOrderItem.IsActive = 1;
                }
                else
                {
                    objPurchaseOrderItem.IsActive = 0;
                }

                objPurchaseOrderItem.CreatedBy = 1;
                objMessageInfo = oblPurchaseOrderItem.ManageItemMaster(objPurchaseOrderItem, cmdMode);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                objPurchaseOrderItem = null;
                //objMessageInfo = null;
                oblPurchaseOrderItem = null;

            }

        }
        void ResetForm()
        {
            txtPurchaseItemOrderID.Text = "";
            //ddlPurchaseOrderId.SelectedItem.Value = ;
            //ddlPurchaseOrderId.SelectedValue = "";
            // ddlItemUnit.SelectedItem.Value = "";
            //txtItemUnit.Text = "";
            txtDescription.Text = "";
            txtItemPrice.Text = "";

        }
        void BindPurchaseOrder()
        {
            oblPurchaseOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();

            try
            {
                objPurchaseOrderList = oblPurchaseOrder.GetAllPurchaseOrderList(0, 0, "");
                if (objPurchaseOrderList != null)
                {
                    ddlPurchaseOrderId.DataSource = objPurchaseOrderList;
                    ddlPurchaseOrderId.DataValueField = "PurchaseOrderID";
                    ddlPurchaseOrderId.DataBind();
                }
                else
                {
                    ddlPurchaseOrderId.DataSource = null;
                    ddlPurchaseOrderId.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblPurchaseOrder = null;
                objPurchaseOrderList = null;
            }


        }
        void BindItem()
        {
            oblItem = new Store.Item.BusinessLogic.Item();
            try
            {
                objItemList = oblItem.GetAllItemList(0, 0, "");
                if (objItemList != null)
                {
                    ddlItemId.DataSource = objItemList;
                    ddlItemId.DataTextField = "ItemPrefix";
                    ddlItemId.DataValueField = "ItemID";
                    ddlItemId.DataBind();
                }
                else
                {
                    ddlItemId.DataSource = null;
                    ddlItemId.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblItem = null;
                objItemList = null;
            }


        }
        
        
        #endregion

        protected void ddlItemId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlItemId.SelectedValue);
            Store.Item.BusinessObject.Item objItem = new Store.Item.BusinessObject.Item();
            oblItem = new Store.Item.BusinessLogic.Item();
            Store.ItemPrice.BusinessObject.ItemPrice objItemPrice = new Store.ItemPrice.BusinessObject.ItemPrice();
            Store.ItemPrice.BusinessLogic.ItemPrice oblItemPrice = new Store.ItemPrice.BusinessLogic.ItemPrice();
            objItemPrice = oblItemPrice.GetAllItemPrice(id, 0, "");
           // objItem = oblItem.GetAllItem(id, 0, "");
            txtItemUnit.Text = objItem.UnitName;
            txtDescription.Text = objItem.ItemDescription;
            txtItemPrice.Text =Convert.ToString(objItemPrice.ItemCostPricePerUnit);
        }
	}
}