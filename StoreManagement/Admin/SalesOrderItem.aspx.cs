using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class SalesOrderItem : System.Web.UI.Page
    {
        Store.SalesOrder.BusinessLogic.SalesOrder oblSalesOrder = null;
        Store.SalesOrder.BusinessObject.SalesOrderList objSalesOrderList = null;
        Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem oblPurchaseOrderItem = null;
        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList objPurchaseOrderItemList = null;
        Store.Item.BusinessLogic.Item oblItem = null;
        Store.Item.BusinessObject.ItemList objItemList = null;
        Store.ItemUnit.BusinessLogic.ItemUnit oblItemUnit = null;
        Store.ItemUnit.BusinessObject.ItemUnitList obItemUnitList = null;
        Store.SalesOrderItem.BusinessLogic.SalesOrderItem oblSalesOrderItem= null;
        Store.SalesOrderItem.BusinessObject.SalesOrderItemList objSalesOrderItemlist = null;
        Store.SalesOrderItem.BusinessObject.SalesOrderItem objSalesOrderItem= null;
        Store.Common.MessageInfo objMessageInfo = null;
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        #region ControlDefinedFunction
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindSalesOrderItem();
                BindSalesOrder();
                BindItem();
               
            }
        }
       
        
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            ResetForm();
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtSalesOrderId.Text =dgvSaleOrderItem.DataKeys[gvrow.RowIndex].Value.ToString();
            ddlSalesOrderId.SelectedItem.Selected = false;
            ddlSalesOrderId.Items.FindByText(gvrow.Cells[0].Text.ToString()).Selected=true;
            ddlItemId.SelectedItem.Value = gvrow.Cells[1].Text;
            txtItemUnit.Text = gvrow.Cells[2].Text;
            txtDescription.Text = gvrow.Cells[3].Text;
            txtItemCostPrice.Text = gvrow.Cells[4].Text;
            txtItemSalePrice.Text = gvrow.Cells[5].Text;
            txtItemDiscountPercentage.Text = gvrow.Cells[6].Text;
            txtItemDiscount.Text = gvrow.Cells[7].Text;
            int i = Convert.ToInt32(gvrow.Cells[8].Text);
            if (i == 1)
                cbIsActive.Checked = true;
            else
                cbIsActive.Checked = false;
            updateSaleOrderItemBdInfo.Update();
             this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objSalesOrderItem=new Store.SalesOrderItem.BusinessObject.SalesOrderItem();
            oblSalesOrderItem =new Store.SalesOrderItem.BusinessLogic.SalesOrderItem();
           

            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objSalesOrderItem.SaleOrderItemID= Convert.ToInt32(dgvSaleOrderItem.DataKeys[gvrow.RowIndex].Value.ToString());
                objSalesOrderItem.SalesOrderID =0;
                objSalesOrderItem.ItemId = 0;
                objSalesOrderItem.ItemUnit = "";
                objSalesOrderItem.Description = "";
                objSalesOrderItem.ItemCostPrice = 0;
                objSalesOrderItem.ItemSalePrice = 0;
                objSalesOrderItem.ItemDiscountPercentage = 0;
                objSalesOrderItem.ItemDiscount = 0;
                objSalesOrderItem.CreatedBy = 1;
                objMessageInfo =oblSalesOrderItem.ManageItemMaster(objSalesOrderItem, cmdMode);
                BindSalesOrderItem();
                updateSaleOrderItemBdInfo.Update();
                
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objSalesOrderItem = null;
                objMessageInfo = null;
                oblSalesOrderItem= null;
               
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateSaleOrderItemBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgSItem");
            if (Page.IsValid)
            {
                ManageSalesOrderItem();
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
                BindSalesOrderItem();
                updateSaleOrderItemBdInfo.Update();
            }
        }
        #endregion

        #region UserDefinedFunction
         void BindSalesOrder()
        {
            oblSalesOrder = new Store.SalesOrder.BusinessLogic.SalesOrder();
            try
            {
                objSalesOrderList = oblSalesOrder.GetAllSalesOrderList(0, 0, "");
                if (objSalesOrderList != null)
                {
                    ddlSalesOrderId.DataSource = objSalesOrderList;

                    ddlSalesOrderId.DataValueField = "SalesOrderID";
                    ddlSalesOrderId.DataBind();

                }
                else
                {
                    ddlSalesOrderId.DataSource = null;
                    ddlSalesOrderId.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oblSalesOrder = null;
                objSalesOrderList = null;
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

                    ddlItemId.DataValueField = "ItemId";
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
         
         void BindSalesOrderItem()
        {
            oblSalesOrderItem=new Store.SalesOrderItem.BusinessLogic.SalesOrderItem();
           
            try
            {
                objSalesOrderItemlist=oblSalesOrderItem.GetAllSalesOrderItemList(0, 0, "");
           
                if (objSalesOrderItemlist != null)
                {
                   dgvSaleOrderItem.DataSource =objSalesOrderItemlist;
                   dgvSaleOrderItem.DataBind();
                }
                else
                {
                   dgvSaleOrderItem.DataSource = null;
                   dgvSaleOrderItem.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblSalesOrderItem= null;
                objSalesOrderItemlist= null;
            }


        }
         void ManageSalesOrderItem()
         {
            objSalesOrderItem=new Store.SalesOrderItem.BusinessObject.SalesOrderItem();
             oblSalesOrderItem =new Store.SalesOrderItem.BusinessLogic.SalesOrderItem();
            
             try
             {
                 if (cmdMode == Store.Common.CommandMode.M)
                 {
                     objSalesOrderItem.SaleOrderItemID = Convert.ToInt32(txtSalesOrderId.Text);
                 }
                 else
                 {
                     objSalesOrderItem.SaleOrderItemID = 0;
                 }
                 objSalesOrderItem.SalesOrderID= Convert.ToInt32(ddlSalesOrderId.SelectedItem.Value);
                 objSalesOrderItem.ItemId = Convert.ToInt32(ddlItemId.SelectedItem.Value);
                 objSalesOrderItem.ItemUnit = Convert.ToString(txtItemUnit.Text);
                 objSalesOrderItem.Description = Convert.ToString(txtDescription.Text);
                 objSalesOrderItem.ItemCostPrice = Convert.ToDecimal(txtItemCostPrice.Text);
                 objSalesOrderItem.ItemSalePrice = Convert.ToDecimal(txtItemSalePrice.Text);
                 objSalesOrderItem.ItemDiscountPercentage = Convert.ToDecimal(txtItemDiscountPercentage.Text);
                 objSalesOrderItem.ItemDiscount = Convert.ToDecimal(txtItemDiscount.Text);
                 if (cbIsActive.Checked)
                     objSalesOrderItem.IsActive = 1;
                 else
                     objSalesOrderItem.IsActive = 0;
                 objSalesOrderItem.CreatedBy = 1;
                 objMessageInfo = oblSalesOrderItem.ManageItemMaster(objSalesOrderItem, cmdMode);
                 
             }
             catch (Exception ex)
             {

             }
             finally
             {
                 objSalesOrderItem = null;
                 //objMessageInfo = null;
                  oblSalesOrderItem= null;
                 
             }

         }
         void ResetForm()
         {
            txtDescription.Text = "";
            txtItemCostPrice.Text = "";
            txtItemDiscount.Text = "";
            txtItemDiscountPercentage.Text = "";
            txtItemSalePrice.Text = "";
            txtSalesOrderId.Text = "";
             
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
             txtItemCostPrice.Text = Convert.ToString(objItemPrice.ItemCostPricePerUnit);
             txtItemSalePrice.Text = Convert.ToString(objItemPrice.ItemSalePricePerUnit);
             txtItemDiscountPercentage.Text = Convert.ToString(objItemPrice.ItemDiscountPercentagePerUnit);
             decimal sale=Convert.ToDecimal(objItemPrice.ItemSalePricePerUnit);
             decimal discp=Convert.ToDecimal(objItemPrice.ItemDiscountPercentagePerUnit);
             decimal discount=(sale*discp)/100;
             txtItemDiscount.Text = Convert.ToString(discount);
         }

       
    }
}