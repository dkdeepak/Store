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
        Store.Item.BusinessLogic.Item oblItem = null;
        Store.Item.BusinessObject.ItemList objItemList = null;
        Store.ItemPrice.BusinessLogic.ItemPrice oblItemPrice = null;
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
                if (ds.Tables[0].Rows.Count >0)
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
    }
}