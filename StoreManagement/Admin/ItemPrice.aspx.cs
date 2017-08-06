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
using System.Data;

namespace StoreManagement.Admin
{
    public partial class ItemPrice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                divForm.Style.Add("display", "none");
                divSerach.Style.Add("display", "block");
                up1.Update();
               
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




        #endregion
        #region UserDefindeFunction
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtPoId.Text);
                bindGrid(id);

                hfPoderId.Value = id.ToString();
                if (Gridview1.DataSource != null)
                {
                    divForm.Style.Add("display", "block");
                    divSerach.Style.Add("display", "none");
                    up1.Update();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void bindGrid(int id)
        {
            try
            {
                oblItemprice = new Store.ItemPrice.BusinessLogic.ItemPrice();
                string query = "select i.ItemPrefix, i.ItemID from tbl_tPurchaseReceivedItem p inner join tbl_mItem i on p.ItemId = i.ItemID where p.PurchaseReceivedID = " + id;
                DataTable dt = new DataTable();
                dt = oblItemprice.runQuery(query);
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oblItemprice = null;
            }

        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            for(int i=0;i<Gridview1.Rows.Count;i++)
            {
                HiddenField hfid = (HiddenField)Gridview1.Rows[i].FindControl("hfItemId");
                
                TextBox txtSalesPrice = (TextBox)Gridview1.Rows[i].FindControl("txtSalesPrice");
                TextBox txtWindowFrom = (TextBox)Gridview1.Rows[i].FindControl("txtWindowFrom");
                TextBox txtWindowTo = (TextBox)Gridview1.Rows[i].FindControl("txtWindowTo");
                TextBox txtDiscount = (TextBox)Gridview1.Rows[i].FindControl("txtDiscount");
                objItemPrice = new Store.ItemPrice.BusinessObject.ItemPrice();

                objItemPrice.BatchNo = Convert.ToString(txtPoId.Text);
                objItemPrice.ItemID = Convert.ToInt32(hfid.Value);
                objItemPrice.ItemSalePricePerUnit = Convert.ToInt32(txtSalesPrice.Text);
                objItemPrice.WindowFrom = Convert.ToDateTime(txtWindowFrom.Text);
                objItemPrice.WindowTo = Convert.ToDateTime(txtWindowTo.Text);
                objItemPrice.ItemDiscountPercentagePerUnit = Convert.ToInt32(txtDiscount.Text);

                oblItemprice = new Store.ItemPrice.BusinessLogic.ItemPrice();
                oblItemprice.ManageItemMaster(objItemPrice, cmdMode);







            }
        }
    }
}