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
                throw ex;

                // Global.WriteErrorLog("Error Occured" +ex.ToString());

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
                throw ex;
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

        }

        protected void dgvBatch_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
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
                   // ResetForm();
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
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objItemPrice.ItemPriceID = Convert.ToInt32(hfItemPriceId.Value);
                    
                }
                else
                {
                    objItemPrice.ItemPriceID = 0;
                    
                }
                //TextBox txt1 = (TextBox)pnlForm.FindControl("txtSP");
                //TextBox txt2 = (TextBox)pnlForm.FindControl("txtDisPerUnit");
                //TextBox txt3 = (TextBox)pnlForm.FindControl("txtApplicableFrom");
                //TextBox txt4 = (TextBox)pnlForm.FindControl("txtApplicableTo");
                objItemPrice.ItemSalePricePerUnit = Convert.ToDecimal(txtSP.Text);
                objItemPrice.ItemDiscountPercentagePerUnit = Convert.ToDecimal(txtDisPerUnit.Text);
                objItemPrice.ApplicableFrom = Convert.ToDateTime(txtApplicableFrom.Text);
                objItemPrice.ApplicableTo = Convert.ToDateTime(txtApplicableTo.Text);
                objMessageInfo = oblItemPrice.ManageItemMaster(objItemPrice, cmdMode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objItemPrice = null;
                oblItemPrice = null;
            }

        }

    }
}