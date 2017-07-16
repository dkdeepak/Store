using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;
using Store.DatabaseHelper;

namespace StoreManagement.Admin
{
    public partial class SalesReturnedItem : System.Web.UI.Page
    {
       
        Store.Item.BusinessLogic.Item oblItem = null;
        Store.Item.BusinessObject.ItemList objItemList = null;
        Store.ItemUnit.BusinessLogic.ItemUnit oblItemUnit = null;
        Store.ItemUnit.BusinessObject.ItemUnitList obItemUnitList = null;
        Store.SalesOrder.BusinessLogic.SalesOrder oblSaleOrder = null;
        Store.SalesOrder.BusinessObject.SalesOrderList objSaleOrderList = null;
        Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem oblPurchaseOrderItem = null;
        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList objPurchaseOrderItemList = null;
        Store.SalesReturned.BusinessLogic.SalesReturned oblSalesReturn = null;
        Store.SalesReturned.BusinessObject.SalesReturnedList objSalesReturnList = null;

        Store.SaleReturnItem.BusinessLogic.SaleReturnItem oblSalesreturnItem = null;
        Store.SaleReturnItem.BusinessObject.SaleReturnItem objSalesReturnItem = null;
        Store.SaleReturnItem.BusinessObject.SaleReturnItemList objSalesReturnItemList = null;
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
                BindSalesReturned();
                BindSalesReturnItem();                
                BindItem();
                BindSalesOrder();
               
            }
        }
       
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            ResetForm();
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtSalesReturnItemId.Text =dgvSalesReturnedItem.DataKeys[gvrow.RowIndex].Value.ToString();
            ddlSalesReturnID.SelectedItem.Value = gvrow.Cells[0].Text;
            ddlSalesOrderId.SelectedItem.Value = gvrow.Cells[1].Text;
            ddlItemId.SelectedItem.Selected = false;
            ddlItemId.Items.FindByText(gvrow.Cells[2].Text.ToString()).Selected=true;
            txtItemUnit.Text = gvrow.Cells[3].Text;
            txtDescription.Text = gvrow.Cells[4].Text;
            txtItemPrice.Text = gvrow.Cells[5].Text;
            int i = Convert.ToInt32(gvrow.Cells[6].Text);
            if (i == 1)
                cbIsActive.Checked = true;
            else
                cbIsActive.Checked = false;
           
            updateSalesReturnedItemBdInfo.Update();
            this.ModalPopupExtender1.Show();            
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objSalesReturnItem=new Store.SaleReturnItem.BusinessObject.SaleReturnItem();
            oblSalesreturnItem=new Store.SaleReturnItem.BusinessLogic.SaleReturnItem();


            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objSalesReturnItem.SaleReturnItemID= Convert.ToInt32(dgvSalesReturnedItem.DataKeys[gvrow.RowIndex].Value.ToString());
                objSalesReturnItem.SalesOrderID = 0;
                objSalesReturnItem.SalesReturnID=0;
                objSalesReturnItem.SalesOrderID=0;
                objSalesReturnItem.ItemId=0;
                objSalesReturnItem.ItemUnit="";               
                objSalesReturnItem.Description = "";
                objSalesReturnItem.ItemPrice = 0;
                objSalesReturnItem.CreatedBy = 1;
                objMessageInfo =oblSalesreturnItem.ManageItemMaster(objSalesReturnItem, cmdMode);
                BindSalesReturnItem();
                updateSalesReturnedItemBdInfo.Update();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
               objSalesReturnItem= null;
                objMessageInfo = null;
               oblSalesreturnItem= null;

            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateSalesReturnedItemBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgRtnItem");
            if (Page.IsValid)
            {
                ManageSalesReturnItem();
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
                BindSalesReturnItem();
                updateSalesReturnedItemBdInfo.Update();
            }
        }
        #endregion

        #region UserDefinedFunction
        void BindSalesReturnItem()
        {
           oblSalesreturnItem=new Store.SaleReturnItem.BusinessLogic.SaleReturnItem();

            try
            {
               objSalesReturnItemList=oblSalesreturnItem.GetAllSaleReturnItemList(0, 0, "");

                if (objSalesReturnItemList!= null)
                {
                   dgvSalesReturnedItem.DataSource =objSalesReturnItemList;
                   dgvSalesReturnedItem.DataBind();
                }
                else
                {
                    dgvSalesReturnedItem.DataSource = null;
                    dgvSalesReturnedItem.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
               oblSalesreturnItem= null;
               objSalesReturnItemList= null;
            }


        }
        void ManageSalesReturnItem()
        {
           objSalesReturnItem=new Store.SaleReturnItem.BusinessObject.SaleReturnItem();
           oblSalesreturnItem=new Store.SaleReturnItem.BusinessLogic.SaleReturnItem();

            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objSalesReturnItem.SaleReturnItemID = Convert.ToInt32(txtSalesReturnItemId.Text);

                }
                else
                {
                    objSalesReturnItem.SaleReturnItemID = 0;

                }
                objSalesReturnItem.SalesReturnID= Convert.ToInt32(ddlSalesReturnID.SelectedItem.Value);
                objSalesReturnItem.SalesOrderID = Convert.ToInt32(ddlSalesOrderId.SelectedItem.Value);
                objSalesReturnItem.ItemId = Convert.ToInt32(ddlItemId.SelectedItem.Value);
                objSalesReturnItem.ItemUnit = Convert.ToString(txtItemUnit.Text);
                objSalesReturnItem.Description = Convert.ToString(txtDescription.Text);
                objSalesReturnItem.ItemPrice = Convert.ToDecimal(txtItemPrice.Text);
                if (cbIsActive.Checked)
                    objSalesReturnItem.IsActive = 1;
                else
                    objSalesReturnItem.IsActive = 0;
                objSalesReturnItem.CreatedBy = 1;
                objMessageInfo =oblSalesreturnItem.ManageItemMaster(objSalesReturnItem, cmdMode);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                objSalesReturnItem = null;
                //objMessageInfo = null;
               oblSalesreturnItem= null;

            }

        }
        void ResetForm()
        {
            txtDescription.Text = "";
            txtItemPrice.Text = "";
            txtSalesReturnItemId.Text = "";
            

        }
        
        void BindSalesReturned()
        {
            oblSalesReturn = new Store.SalesReturned.BusinessLogic.SalesReturned();
            try
            {
                objSalesReturnList = oblSalesReturn.GetAllSalesReturnedList(0, 0, "");
                if (objSalesReturnList != null)
                {
                    ddlSalesReturnID.DataSource = objSalesReturnList;
                    ddlSalesReturnID.DataValueField = "SalesReturnedID";
                    //ddlSalesReturnID.DataTextField = "SaleReturnedID";
                    ddlSalesReturnID.DataBind();

                }
                else
                {
                    ddlSalesReturnID.DataSource = null;
                    ddlSalesReturnID.DataBind();

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oblSalesReturn = null;
                objSalesReturnList = null;
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
        void BindSalesOrder()
        {
            oblSaleOrder = new Store.SalesOrder.BusinessLogic.SalesOrder();
            try
            {
                objSaleOrderList = oblSaleOrder.GetAllSalesOrderList(0, 0, "");
                if (objSaleOrderList != null)
                {
                    ddlSalesOrderId.DataSource = objSaleOrderList;

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
                oblSaleOrder = null;
                objSaleOrderList = null;
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
            //objItem = oblItem.GetAllItem(id, 0, "");
            txtItemUnit.Text = objItem.UnitName;
            txtDescription.Text = objItem.ItemDescription;
            txtItemPrice.Text = Convert.ToString(objItemPrice.ItemSalePricePerUnit);
            
        }
    }
}