using System;
using System.Collections.Generic;
using System.Linq;using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;


namespace StoreManagement.Admin
{
    public partial class ItemPrice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindItem();
            }

        }
        Store.Common.MessageInfo objMessageInfo = null;
        Store.Item.BusinessLogic.Item oblItem = null;
        Store.Item.BusinessObject.ItemList objItemList = null;
        Store.ItemPrice.BusinessLogic.ItemPrice oblItemPrice = new Store.ItemPrice.BusinessLogic.ItemPrice();
        Store.ItemPrice.BusinessLogic.ItemPrice objItemprice = new Store.ItemPrice.BusinessLogic.ItemPrice();
        Store.ItemPrice.BusinessObject.ItemPrice objItemPrice = new Store.ItemPrice.BusinessObject.ItemPrice();
        Store.ItemPrice.BusinessObject.ItemPriceList objItemPriceList = new Store.ItemPrice.BusinessObject.ItemPriceList();
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
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(ItemPrice).FullName, 1);

            }
            finally
            {
                oblItem = null;
                objItemList = null;
            }


        }
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        protected void dgvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HiddenField hfItemId = (HiddenField)dgvItem.Rows[e.RowIndex].FindControl("hfItemId");
            bindBatch(Convert.ToInt32(hfItemId.Value));

        }
        void bindBatch(int ItemId)
        {
            oblItemPrice = new Store.ItemPrice.BusinessLogic.ItemPrice();
            DataSet ds = new DataSet();
            try
            {

                ds = oblItemPrice.getBatch(ItemId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvBatch.DataSource = ds;
                    dgvBatch.DataBind();
                    this.mpopBatch.Show();
                }
                else
                {
                    dgvBatch.DataSource = null;
                    dgvBatch.DataBind();
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('There is no batch for select item')", true);

                }
                upBatch.Update();
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(ItemPrice).FullName, 1);
            }
            finally
            {
                oblItemPrice = null;
                ds = null;
            }
        }

        protected void ibtnCloseBatch_Click(object sender, EventArgs e)
        {
            this.mpopBatch.Hide();
        }

        protected void ibtnCloseForm_Click(object sender, EventArgs e)
        {
            this.mpopForm.Hide();
            hfItemPriceId.Value = "";
            upForm.Update();
        }

        protected void dgvBatch_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HiddenField hfItemPrice = (HiddenField)dgvBatch.Rows[e.RowIndex].FindControl("hfItemPriceId");
            hfItemPriceId.Value = hfItemPrice.Value;
            upForm.Update();
            this.mpopBatch.Hide();
            this.mpopForm.Show();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            HiddenField hfItemPriceID = (HiddenField)pnlForm.FindControl("hfItemPriceId");
            if (Page.IsValid)
            {
                UpdateItemPrice();
                if (objMessageInfo.ErrorCode == -101)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
                }
                if (objMessageInfo.TranID > 0)
                {
                    reset();
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
                }
                this.mpopForm.Hide();
                BindItem();
                upForm.Update();
                upBatch.Update();
                this.mpopForm.Show();
            }


        }
        void UpdateItemPrice()
        {
            objItemPrice = new Store.ItemPrice.BusinessObject.ItemPrice();
            oblItemPrice = new Store.ItemPrice.BusinessLogic.ItemPrice();
             
           
            try
            {
                objItemPrice.ItemPriceID = Convert.ToInt32(hfItemPriceId.Value);
                objItemPrice.ItemSalePricePerUnit = Convert.ToDecimal(txtSP.Text);
                objItemPrice.ItemDiscountPercentagePerUnit = Convert.ToDecimal(txtDisPerUnit.Text);
                objItemPrice.ApplicableFrom = Convert.ToDateTime(txtApplicableFrom.Text);
                objItemPrice.ApplicableTo = Convert.ToDateTime(txtApplicableTo.Text);
                objMessageInfo = oblItemPrice.ManageItemMaster(objItemPrice, cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(ItemPrice).FullName, 1);
            }
            finally
            {
                objItemPrice = null;
                oblItemPrice = null;
            }

        }
        void reset()
        {
            this.mpopForm.Hide();
            txtSP.Text = "";
            txtDisPerUnit.Text = "";
            txtApplicableFrom.Text = "";
            txtApplicableTo.Text = "";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {  
            reset();
        }
    }
}