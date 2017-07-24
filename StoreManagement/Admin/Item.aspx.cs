using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class Item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindItem();
                BindCategory();
                BindItemUnit();
            }
        }
        Store.Category.BusinessLogic.Category oblCategory = null;
        Store.Category.BusinessObject.CategoryList objCategorylist = null;
        Store.ItemUnit.BusinessLogic.ItemUnit oblItemUnit = null;
        Store.ItemUnit.BusinessObject.ItemUnitList objItemUnitlist = null;
        Store.Item.BusinessLogic.Item oblItem = null;
        Store.Item.BusinessObject.Item objItem = null;
        Store.Item.BusinessObject.ItemList objItemList = null;
        Store.Common.MessageInfo objMessageInfo = null;
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        #region ControlDefindeFunction
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            //txtItemDiscountPerUnit   txtDiscount
            ResetForm();
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtItemId.Text =dgvItem.DataKeys[gvrow.RowIndex].Value.ToString();
            txtItemPrefix.Text = gvrow.Cells[0].Text;
            txtItemCode.Text = gvrow.Cells[1].Text;
            txtBarcode.Text = gvrow.Cells[2].Text;
            txtItemDecription.Text = gvrow.Cells[3].Text;
            ddlItemUnitId.SelectedItem.Selected = false;
            ddlItemUnitId.Items.FindByText(gvrow.Cells[4].Text.ToString()).Selected=true;
            //txtCostPrice.Text = gvrow.Cells[5].Text;
            //txtSalePrice.Text = gvrow.Cells[6].Text;
            //txtItemDiscountPerUnit.Text = gvrow.Cells[7].Text;
            //txtFrom.Text = gvrow.Cells[8].Text;
            //txtTo.Text = gvrow.Cells[9].Text;
            //txtBatchNo.Text = gvrow.Cells[10].Text;
            ddlCategoryId.SelectedItem.Selected = false;
            ddlCategoryId.Items.FindByText(gvrow.Cells[5].Text.ToString()).Selected=true;
            updateItemBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objItem = new Store.Item.BusinessObject.Item();
            oblItem = new Store.Item.BusinessLogic.Item();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objItem.ItemID = Convert.ToInt32(dgvItem.DataKeys[gvrow.RowIndex].Value.ToString());
                objItem.ItemPrefix = "";
                objItem.ItemCode = "";
                objItem.Barcode = "";
                objItem.ItemDescription = "";              
                objItem.ItemUnitId = 1;
                objItem.CategoryID = 1;
                //objItem.ItemCostPricePerUnit = 1;
                //objItem.ItemSalePricePerUnit = 1;
                //objItem.ItemDiscountPercentagePerUnit = 1;
                //objItem.WindowFrom = DateTime.Now;
                //objItem.WindowTo = DateTime.Now;
                //objItem.BatchNo = "";
                //objItem.CreatedBy = 1;
                objMessageInfo = oblItem.ManageItemMaster(objItem, cmdMode);
                BindItem();
                updateItemBdInfo.Update();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objItem = null;
                objMessageInfo = null;
                oblItem = null;
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateItemBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgItem");
            if (Page.IsValid)
            {
                ManageItem();
                if (objMessageInfo.ErrorCode == -101)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
                }
                if (objMessageInfo.TranID > 0)
                {
                    ResetForm();
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
                }
                this.ModalPopupExtender1.Hide();
                BindItem();
                updateItemBdInfo.Update();
                updateItem.Update();
                this.ModalPopupExtender1.Show();
            }
        }
        #endregion

        #region UserDefindeFunction
        void BindItem()
        {
            oblItem = new Store.Item.BusinessLogic.Item();
            try
            {
                objItemList = oblItem.GetAllItemList(0, 0, "");
                if (objItemList != null)
                {
                    dgvItem.DataSource = objItemList;
                    dgvItem.DataBind();
                }
                else
                {
                    dgvItem.DataSource = null;
                    dgvItem.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oblItem = null;
                objItemList = null;
            }


        }
        void BindCategory()
        {
            oblCategory = new Store.Category.BusinessLogic.Category();
            try
            {
                objCategorylist = oblCategory.GetAllCategoryList(0, 0, "");
                if (objCategorylist != null)
                {
                    ddlCategoryId.DataSource = objCategorylist;
                    ddlCategoryId.DataTextField = "CategoryName";
                    ddlCategoryId.DataValueField = "CategoryID";
                    ddlCategoryId.DataBind();
                    ddlCategoryId.Items.Insert(0, "<--Select Category-->");
                }
                else
                {
                    ddlCategoryId.DataSource = null;
                    ddlCategoryId.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblCategory = null;
                objCategorylist = null;
            }


        }
        void BindItemUnit()
        {
            oblItemUnit = new Store.ItemUnit.BusinessLogic.ItemUnit();
            try
            {
                objItemUnitlist = oblItemUnit.GetAllItemUnitList(0, 0, "");
                if (objItemUnitlist != null)
                {
                    ddlItemUnitId.DataSource = objItemUnitlist;
                    ddlItemUnitId.DataTextField = "UnitName";
                    ddlItemUnitId.DataValueField = "UnitID";
                    ddlItemUnitId.DataBind();
                    ddlItemUnitId.Items.Insert(0, "<--Select Item Unit-->");
                }
                else
                {
                    ddlItemUnitId.DataSource = null;
                    ddlItemUnitId.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblItemUnit = null;
                objItemUnitlist = null;
            }


        }
        void ManageItem()
        {
            objItem = new Store.Item.BusinessObject.Item();
            oblItem = new Store.Item.BusinessLogic.Item();
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objItem.ItemID = Convert.ToInt32(txtItemId.Text);
                    //objItem.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                    //objItem.ItemPriceID = Convert.ToInt32(txtItemPriceId.Text);
                }
                else
                {
                    objItem.ItemID = 0;
                    //objItem.CreatedBy = Convert.ToInt32(Session["UserId"]);
                    //objItem.ItemPriceID = 0;
                }
                objItem.ItemPrefix = Convert.ToString(txtItemPrefix.Text);

                objItem.ItemCode = Convert.ToString(txtItemCode.Text);
                objItem.Barcode = Convert.ToString(txtBarcode.Text);
                objItem.ItemDescription = Convert.ToString(txtItemDecription.Text);
                objItem.ItemUnitId = Convert.ToInt32(ddlItemUnitId.SelectedItem.Value);
                objItem.CategoryID = Convert.ToInt32(ddlCategoryId.SelectedItem.Value);
                //objItem.ItemCostPricePerUnit = Convert.ToDecimal(txtCostPrice.Text);
                //objItem.ItemSalePricePerUnit = Convert.ToDecimal(txtSalePrice.Text);
                //objItem.ItemDiscountPercentagePerUnit = Convert.ToDecimal(txtItemDiscountPerUnit.Text);
                //objItem.WindowFrom = Convert.ToDateTime(txtFrom.Text);
                //objItem.WindowTo = Convert.ToDateTime(txtTo.Text);
                //objItem.BatchNo = Convert.ToString(txtBatchNo.Text);
               
                
                objMessageInfo = oblItem.ManageItemMaster(objItem, cmdMode);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objItem = null;
                //objMessageInfo = null;
                oblItem = null;
            }

        }
        void ResetForm()
        {
            txtItemId.Text = "";
            txtItemPrefix.Text = "";
            txtItemCode.Text = "";
            txtBarcode.Text = "";
            txtItemDecription.Text = "";
            ddlItemUnitId.ClearSelection();
            ddlCategoryId.ClearSelection();
            //txtCostPrice.Text = "";
            //txtSalePrice.Text = "";
            //txtItemDiscountPerUnit.Text = "";
            //txtFrom.Text = "";
            //txtTo.Text = "";
            //txtBatchNo.Text = "";
            txtItemPrefix.Focus();


        }
        #endregion
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
            this.ModalPopupExtender1.Hide();
        }
        protected void lbtnClose_Click(object sender, EventArgs e)
        {
            ResetForm();
            this.ModalPopupExtender1.Hide();
        }

    }
}