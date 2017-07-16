using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class Stock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindItem();
                BindStock();
            }
        }
        Store.Item.BusinessLogic.Item oblItem = null;
        Store.Item.BusinessObject.ItemList obItemList = null;
        Store.Stock.BusinessLogic.Stock oblStock = null;
        Store.Stock.BusinessObject.Stock objStock = null;
        Store.Stock.BusinessObject.StockList objStockList = null;
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
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtStockId.Text = dgvStock.DataKeys[gvrow.RowIndex].Value.ToString();
            ddlItemId.SelectedItem.Selected = false;
            ddlItemId.Items.FindByText(gvrow.Cells[0].Text.ToString()).Selected=true;
            txtQuantity.Text = gvrow.Cells[1].Text;
            updateStockBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
            
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objStock = new Store.Stock.BusinessObject.Stock();
            oblStock = new Store.Stock.BusinessLogic.Stock();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objStock.StockID = Convert.ToInt32(dgvStock.DataKeys[gvrow.RowIndex].Value.ToString());
                objMessageInfo = oblStock.ManageStockMaster(objStock, cmdMode);
                BindStock();
                updateStockBdInfo.Update();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objStock = null;
                objMessageInfo = null;
                oblStock = null;
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateStockBdInfo.Update();
           
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgStock");
            if (Page.IsValid)
            {
                ManageStock();
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
                BindStock();
                updateStockBdInfo.Update();
                updateStock.Update();
                this.ModalPopupExtender1.Show();
            }
        }
        #endregion


        #region UserDefinedFunction
        void BindStock()
        {
            oblStock = new Store.Stock.BusinessLogic.Stock();
            try
            {
                objStockList = oblStock.GetAllStockList(0, 0, "");
                if (objStockList != null)
                {
                    dgvStock.DataSource = objStockList;
                    dgvStock.DataBind();
                }
                else
                {
                    dgvStock.DataSource = null;
                    dgvStock.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblStock = null;
                objStockList = null;
            }


        }
        void BindItem()
        {
            oblItem = new Store.Item.BusinessLogic.Item();
            try
            {
                obItemList = oblItem.GetAllItemList(0, 0, "");
                if (obItemList != null)
                {
                    ddlItemId.DataSource = obItemList;
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
                obItemList = null;
            }


        }
        void ManageStock()
        {
            objStock = new Store.Stock.BusinessObject.Stock();
            oblStock = new Store.Stock.BusinessLogic.Stock();
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objStock.StockID =Convert.ToInt32(txtStockId.Text);
                }
                else
                {
                    objStock.StockID = 0;
                }
                objStock.ItemID = Convert.ToInt32(ddlItemId.SelectedItem.Value);
                objStock.StockQuantity = Convert.ToInt32(txtQuantity.Text);
                objMessageInfo = oblStock.ManageStockMaster(objStock, cmdMode);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objStock = null;
               // objMessageInfo = null;
                oblStock = null;
            }

        }
        void ResetForm()
        {
            
            txtQuantity.Text = "";
        }

        #endregion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
            this.ModalPopupExtender1.Hide();
        }
    }
}