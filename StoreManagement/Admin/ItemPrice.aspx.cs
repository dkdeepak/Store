using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class ItemPrice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindItemPrice();
                BindCategory();
                BindItem();
            }

        }
        Store.Category.BusinessLogic.Category oblCategory = null;
        Store.Category.BusinessObject.CategoryList obCategoryList = null;
        Store.Item.BusinessLogic.Item oblItem = null;
        Store.Item.BusinessObject.ItemList obItemList = null;
        Store.ItemPrice.BusinessObject.ItemPrice objItemPrice = null;
        Store.ItemPrice.BusinessObject.ItemPriceList objItemPriceList = null;
        Store.ItemPrice.BusinessLogic.ItemPrice oblItemprice = null;
        Store.Common.MessageInfo objMessageInfo = null;
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        #region ControlDefindeFunction
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            ResetForm();
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtItemPriceId.Text = dgvItemPrice.DataKeys[gvrow.RowIndex].Value.ToString();
            ddlItemName.SelectedItem.Selected = false;
            ddlItemName.Items.FindByText( gvrow.Cells[1].Text.ToString()).Selected=true;
            txtCostPrice.Text = gvrow.Cells[2].Text;
            txtSalePrice.Text = gvrow.Cells[3].Text;
            txtDiscount.Text = gvrow.Cells[4].Text;
            txtFrom.Text = gvrow.Cells[5].Text;
            txtTo.Text =gvrow.Cells[6].Text;
            ddlCategory.SelectedItem.Selected = false;
            ddlCategory.Items.FindByText( gvrow.Cells[7].Text.ToString()).Selected=true;
            txtBatchNo.Text = gvrow.Cells[8].Text;
            updateItemPriceBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
           
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objItemPrice = new Store.ItemPrice.BusinessObject.ItemPrice();
            oblItemprice = new Store.ItemPrice.BusinessLogic.ItemPrice();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objItemPrice.ItemPriceID = Convert.ToInt32(dgvItemPrice.DataKeys[gvrow.RowIndex].Value.ToString());
                objItemPrice.ItemID = 0;
                objItemPrice.CategoryID = 0;
                objItemPrice.ItemCostPricePerUnit = 0;
                objItemPrice.ItemSalePricePerUnit = 0;
                objItemPrice.ItemDiscountPercentagePerUnit = 0;
                objItemPrice.WindowFrom = DateTime.Now;
                objItemPrice.WindowTo = DateTime.Now;
                objItemPrice.BatchNo = "";
                objItemPrice.CreatedBy = 1;
                objMessageInfo = oblItemprice.ManageItemMaster(objItemPrice, cmdMode);
                BindItemPrice();
                updateItemPriceBdInfo.Update();
             }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objItemPrice = null;
                objMessageInfo = null;
                oblItemprice = null;
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateItemPriceBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgIPrice");
            if (Page.IsValid)
            {
                ManageItemPrice();
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
                BindItemPrice();
                updateItemPriceBdInfo.Update();
            }
        }
        #endregion
        #region UserDefindeFunction
        void BindItem()
        {
            oblItem = new Store.Item.BusinessLogic.Item();
            try
            {
                obItemList = oblItem.GetAllItemList(0, 0, "");
                if (obItemList != null)
                {
                    ddlItemName.DataSource = obItemList;
                    ddlItemName.DataTextField = "ItemPrefix";
                    ddlItemName.DataValueField = "ItemID";
                    ddlItemName.DataBind();
                }
                else
                {
                    ddlItemName.DataSource = null;
                    ddlItemName.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblItem = null;
                obItemList = null;
            }


        }
        void BindCategory()
        {
            oblCategory = new Store.Category.BusinessLogic.Category();
            try
            {
                obCategoryList = oblCategory.GetAllCategoryList(0, 0, "");
                if (obCategoryList != null)
                {
                    ddlCategory.DataSource = obCategoryList;
                   ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataBind();
                }
                else
                {
                    ddlCategory.DataSource = null;
                    ddlCategory.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblCategory = null;
                obCategoryList = null;
            }


        }
        void BindItemPrice()
        {
            oblItemprice = new Store.ItemPrice.BusinessLogic.ItemPrice();
            try
            {
                objItemPriceList=oblItemprice.GetAllItemPriceList(0,0,"");
                if (objItemPriceList != null)
                {
                    dgvItemPrice.DataSource = objItemPriceList;
                    dgvItemPrice.DataBind();
                }
                else
                {
                    dgvItemPrice.DataSource = null;
                    dgvItemPrice.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblItemprice = null;
                objItemPriceList = null;
            }


        }
        void ManageItemPrice()
        {
            objItemPrice = new Store.ItemPrice.BusinessObject.ItemPrice();
            oblItemprice = new Store.ItemPrice.BusinessLogic.ItemPrice();
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objItemPrice.ItemPriceID=Convert.ToInt32(txtItemPriceId.Text);
                }
                else
                {
                    objItemPrice.ItemPriceID=0;
                }
                objItemPrice.ItemID = Convert.ToInt32(ddlItemName.SelectedItem.Value);
                objItemPrice.CategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
                objItemPrice.ItemCostPricePerUnit = Convert.ToDecimal(txtCostPrice.Text);
                objItemPrice.ItemSalePricePerUnit = Convert.ToDecimal(txtSalePrice.Text);
                objItemPrice.ItemDiscountPercentagePerUnit = Convert.ToDecimal(txtDiscount.Text);
                DateTime fdate = DateTime.Parse(txtFrom.Text);
                objItemPrice.WindowFrom = fdate;
                DateTime tdate = DateTime.Parse(txtTo.Text);
                objItemPrice.WindowTo = tdate;
                objItemPrice.BatchNo = Convert.ToString(txtBatchNo.Text);
                objItemPrice.CreatedBy = 1;
                objMessageInfo = oblItemprice.ManageItemMaster(objItemPrice, cmdMode);
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objItemPrice = null;
               // objMessageInfo = null;
                oblItemprice = null;
            }

        }

        void ResetForm()
        {
            txtItemPriceId.Text = "";
            txtCostPrice.Text = "";
            txtSalePrice.Text = "";
            txtDiscount.Text = "";
            txtFrom.Text = "";
            txtTo.Text = "";
            txtBatchNo.Text = "";
        }

        #endregion
    }
}