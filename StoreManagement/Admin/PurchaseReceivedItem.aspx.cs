using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class PurchaseReceivedItem : System.Web.UI.Page
    {
        Store.PurchaseReceived.BusinessLogic.PurchaseReceived oblPurchaseReceived = null;
        Store.PurchaseReceived.BusinessObject.PurchaseReceivedList objPurchaseReceivedList = null;
        Store.PurchaseOrder.BusinessLogic.PurchaseOrder oblPurchaseOrder = null;
        Store.PurchaseOrder.BusinessObject.PurchaseOrderList objPurchaseOrderList = null;
        Store.Item.BusinessLogic.Item oblItem = null;
        Store.Item.BusinessObject.ItemList objItemList = null;
        Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem oblPurchaseOrderItem = null;
        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList objPurchaseOrderItemList = null;
        Store.ItemUnit.BusinessLogic.ItemUnit oblItemUnit = null;
        Store.ItemUnit.BusinessObject.ItemUnitList obItemUnitList = null;
        Store.PurchaseReceivedItem.BusinessLogic.PurchaseReceivedItem oblPurchaseReceivedItem = null;
        Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem objPurchaseReceivedItem = null;
        Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItemList objPurchaseReceivedItemList = null;
        Store.Common.MessageInfo objMessageInfo = null;
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        #region ControlDefinedFunction
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPurchaseReceivedItem();
                BindPurchaseReceived();
                BindPurchaseOrder();
                BindItem();
                
                
            }
        }
        
        
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            ResetForm();
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtPurchaseItemReceivedID.Text =dgvPurchaseItemReceived.DataKeys[gvrow.RowIndex].Value.ToString();
            ddlPurchaseReceivedId.SelectedItem.Selected = false;
            ddlPurchaseReceivedId.Items.FindByText(gvrow.Cells[0].Text.ToString()).Selected=true;
            ddlPurchaseOrderId.SelectedItem.Selected = false;
            ddlPurchaseOrderId.Items.FindByText(gvrow.Cells[1].Text.ToString()).Selected=true;
            ddlItemId.SelectedItem.Selected = false;
            ddlItemId.Items.FindByText(gvrow.Cells[2].Text.ToString()).Selected=true;
            txtItemUnit.Text = gvrow.Cells[3].Text;
            txtDescription.Text = gvrow.Cells[4].Text;
            txtItemPrice.Text = gvrow.Cells[5].Text;
            int i=Convert.ToInt32(gvrow.Cells[6].Text);
            if (i == 1)
                chkBoxIsActive.Checked = true;
            else
                chkBoxIsActive.Checked = false;
            updatePurchasedItemReceivedBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objPurchaseReceivedItem= new Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem();
            oblPurchaseReceivedItem = new Store.PurchaseReceivedItem.BusinessLogic.PurchaseReceivedItem();


            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objPurchaseReceivedItem.PurchaseItemReceivedID= Convert.ToInt32(dgvPurchaseItemReceived.DataKeys[gvrow.RowIndex].Value.ToString());
                objPurchaseReceivedItem.PurchaseReceivedID= 0;
                objPurchaseReceivedItem.PurchaseOrderID= 0;
                objPurchaseReceivedItem.ItemID = 0;
                objPurchaseReceivedItem.ItemUnit="";
                objPurchaseReceivedItem.Description ="";
                objPurchaseReceivedItem.ItemPrice = 0;
                objPurchaseReceivedItem.ClientID = 0;
                objPurchaseReceivedItem.CreatedBy = 1;
                objMessageInfo =oblPurchaseReceivedItem.ManageItemMaster(objPurchaseReceivedItem, cmdMode);
                BindPurchaseReceivedItem();
               updatePurchasedItemReceivedBdInfo.Update();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objPurchaseReceivedItem = null;
                objMessageInfo = null;
                oblPurchaseReceivedItem = null;

            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updatePurchasedItemReceivedBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgPRcvItem");
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
                BindPurchaseReceivedItem();
                updatePurchasedItemReceivedBdInfo.Update();
            }
        }
        #endregion
        #region UserDefinedFunction
        void BindPurchaseReceivedItem()
        {
           oblPurchaseReceivedItem= new Store.PurchaseReceivedItem.BusinessLogic.PurchaseReceivedItem();

            try
            {
               objPurchaseReceivedItemList=oblPurchaseReceivedItem .GetAllPurchaseReceivedItemList(0, 0, "");

               if (objPurchaseReceivedItemList != null)
                {
                   dgvPurchaseItemReceived.DataSource =objPurchaseReceivedItemList;
                   dgvPurchaseItemReceived.DataBind();
                }
                else
                {
                    dgvPurchaseItemReceived.DataSource = null;
                    dgvPurchaseItemReceived.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
               oblPurchaseReceivedItem= null;
               objPurchaseReceivedItemList= null;
            }


        }
        
        void ManagePurchaseItemRecived()
        {
           objPurchaseReceivedItem= new Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem();
           oblPurchaseReceivedItem = new Store.PurchaseReceivedItem.BusinessLogic.PurchaseReceivedItem();

            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                   objPurchaseReceivedItem.PurchaseItemReceivedID= Convert.ToInt32(txtPurchaseItemReceivedID.Text);

                }
                else
                {
                   objPurchaseReceivedItem.PurchaseItemReceivedID= 0;

                }
                objPurchaseReceivedItem.PurchaseReceivedID = Convert.ToInt16(ddlPurchaseReceivedId.SelectedItem.Value);
                objPurchaseReceivedItem.PurchaseOrderID = Convert.ToInt16(ddlPurchaseOrderId.SelectedItem.Value);
                objPurchaseReceivedItem.ItemID = Convert.ToInt16(ddlItemId.SelectedItem.Value);
                objPurchaseReceivedItem.ItemUnit = Convert.ToString(txtItemUnit.Text);
                objPurchaseReceivedItem.Description = Convert.ToString(txtDescription.Text);
                objPurchaseReceivedItem.ItemPrice = Convert.ToDecimal(txtItemPrice.Text);
              
               
                if (chkBoxIsActive.Checked)
                {
                    objPurchaseReceivedItem.IsActive = 1;
                }
                else
                {
                    objPurchaseReceivedItem.IsActive = 0;
                }

                objPurchaseReceivedItem.CreatedBy = 1;
                objMessageInfo =oblPurchaseReceivedItem.ManageItemMaster(objPurchaseReceivedItem, cmdMode);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                objPurchaseReceivedItem = null;
                //objMessageInfo = null;
               oblPurchaseReceivedItem= null;

            }

        }
        void BindPurchaseReceived()
        {
            oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
            try
            {
                objPurchaseReceivedList = oblPurchaseReceived.GetAllPurchaseReceivedList(0, 0, "");
                if (objPurchaseReceivedList != null)
                {
                    ddlPurchaseReceivedId.DataSource = objPurchaseReceivedList;
                    // ddlPurchaseOrderId.DataTextField = "StateName";
                    ddlPurchaseReceivedId.DataValueField = "PurchaseReceivedID";
                    ddlPurchaseReceivedId.DataBind();
                    //ddlState.Items.FindByValue(db.Table.Rows[0]["StateID"].ToString()).Selected=true;
                }
                else
                {
                    ddlPurchaseReceivedId.DataSource = null;
                    ddlPurchaseReceivedId.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oblPurchaseReceived = null;
                objPurchaseReceivedList = null;
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
                    ddlPurchaseOrderId.DataSource = objPurchaseOrderList;
                    // ddlPurchaseOrderId.DataTextField = "StateName";
                    ddlPurchaseOrderId.DataValueField = "PurchaseOrderID";
                    ddlPurchaseOrderId.DataBind();
                    //ddlState.Items.FindByValue(db.Table.Rows[0]["StateID"].ToString()).Selected=true;
                }
                else
                {
                    ddlPurchaseOrderId.DataSource = null;
                    ddlPurchaseOrderId.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
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
                    ddlItemId.DataValueField = "ItemID";
                    ddlItemId.DataTextField = "ItemPrefix";
                    ddlItemId.DataBind();
                }
                else
                {
                    ddlItemId.DataSource = null;
                    ddlItemId.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oblItem = null;
                objItemList = null;
            }



        }
        void ResetForm()
        {
            txtPurchaseItemReceivedID.Text = "";
           
            txtDescription.Text = "";
            txtItemPrice.Text = "";

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
            //objItem = oblItem.GetAllItem(id, 0, "");
            txtItemUnit.Text = objItem.UnitName;
            txtDescription.Text = objItem.ItemDescription;
            txtItemPrice.Text = Convert.ToString(objItemPrice.ItemSalePricePerUnit);
        }
    }
}