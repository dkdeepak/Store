using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;

namespace StoreManagement.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Store.Item.BusinessLogic.Item oblItem = new Store.Item.BusinessLogic.Item();
        Store.Item.BusinessObject.ItemList objItemList = new Store.Item.BusinessObject.ItemList();
        Store.PurchaseOrder.BusinessLogic.PurchaseOrder odlPOrder = null;
        Store.PurchaseOrder.BusinessObject.PurchaseOrder objPOrder = null;
        Store.PurchaseOrder.BusinessObject.PurchaseOrderList objPOrderList = new Store.PurchaseOrder.BusinessObject.PurchaseOrderList();
        Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem oblPurchaseOrderItem = null;
        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem objPurchaseOrderItem = null;
        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList objPurchaseOrderItemList = null;

        #region Autocompelet
        //[System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText, int count)
        {


            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ShopDB"].ConnectionString;
                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "select ItemID,ItemPrefix from tbl_mItem where " + "ItemPrefix like @Search + '%' or ItemCode like @Search + '%'";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> ItemPrefix = new List<string>();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ItemPrefix.Add(sdr["ItemPrefix"].ToString());
                        }
                    }
                    con.Close();
                    return ItemPrefix;


                }

            }

        }
        #endregion

        #region Event

        #region gridevent
        
        protected void txtQut_TextChanged(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(((TextBox)sender).Attributes["Rowid"].ToString());
            TextBox price = (TextBox)Gridview1.Rows[rows].Cells[3].FindControl("txtPrice");
            TextBox qnt = (TextBox)Gridview1.Rows[rows].Cells[4].FindControl("txtQut");
            TextBox total = (TextBox)Gridview1.Rows[rows].Cells[5].FindControl("txtTotal");
            total.Text = Convert.ToString(Convert.ToDecimal(price.Text) * Convert.ToInt32(qnt.Text));
            txtSubTotal.Text = Convert.ToString(findsubtotal());
        }
        #endregion

        #endregion
        
        #region webmethod
        public string insertOrder(string tax, string shc, string misccost, string ttotal)
        {
            Store.PurchaseReceived.BusinessLogic.PurchaseReceived oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
            Store.Common.MessageInfo objMessageInfo = new MessageInfo();
            Store.PurchaseReceived.BusinessObject.PurchaseReceived objPurchaseReceived = new Store.PurchaseReceived.BusinessObject.PurchaseReceived();
            objPurchaseReceived.PurchaseOrderID = Convert.ToInt32(0);
            objPurchaseReceived.PurchaseReceivedID = 0;
            objPurchaseReceived.VendorID = 0;
            objPurchaseReceived.PurchaseAmount = Convert.ToDecimal(ttotal);
            objPurchaseReceived.TaxValue = Convert.ToDecimal(tax);
            objPurchaseReceived.ShipingAndHandlingCost = Convert.ToDecimal(shc);
            objPurchaseReceived.MiscCost = Convert.ToDecimal(misccost);
            objPurchaseReceived.IsActive = 1;
            objMessageInfo = oblPurchaseReceived.ManagePurchaseReceived(objPurchaseReceived, 1);

            return objMessageInfo.TranID.ToString();
        }

        public string insertItem(string name, string description, string unitprice, string quantity, string transId)
        {

            Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem objPurchaseReceivedItem = new Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem();
            Store.Common.MessageInfo objMessageInfo = new MessageInfo();
            Store.PurchaseReceived.BusinessLogic.PurchaseReceived oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
            objPurchaseReceivedItem.PurchaseItemReceivedID = 0;
            objPurchaseReceivedItem.PurchaseOrderID = Convert.ToInt32(hfPoderId.Value);
            objPurchaseReceivedItem.PurchaseReceivedID = Convert.ToInt32(transId);
            objPurchaseReceivedItem.ItemID = 0;
            objPurchaseReceivedItem.ItemPrefix = name;
            objPurchaseReceivedItem.ItemUnit = quantity;
            objPurchaseReceivedItem.Description = description;
            objPurchaseReceivedItem.ItemPrice = Convert.ToDecimal(unitprice);
            objPurchaseReceivedItem.IsActive = 1;
            objMessageInfo = oblPurchaseReceived.ManagePurchaseReceivedItem(objPurchaseReceivedItem, 1);

            //objPurchaseOrder = new Store.PurchaseOrder.BusinessObject.PurchaseOrder();

            return "";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string transid = "";
            transid=insertOrder(txtTax.Text, txtSHC.Text, txtMiscCost.Text, txtTotal.Text);
            for (int i = 0; i < Gridview1.Rows.Count; i++)
            {
                TextBox txtItemName = (TextBox)Gridview1.Rows[i].FindControl("txtItemName");
                TextBox txtDec = (TextBox)Gridview1.Rows[i].FindControl("txtDec");
                TextBox txtPrice = (TextBox)Gridview1.Rows[i].FindControl("txtPrice");
                TextBox txtQut = (TextBox)Gridview1.Rows[i].FindControl("txtQut");
                // txtTotal = (TextBox)Gridview1.Rows[i].FindControl("txtTotal");

                insertItem(txtItemName.Text, txtDec.Text, txtPrice.Text, txtQut.Text, transid);
            }
            reset();
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtPoId.Text);
                BindPurchaseOrder(id);
                BindPurchaseOrderItem(id);
                txtSubTotal.Text = findsubtotal().ToString();
                up1.Update();
                hfPoderId.Value = id.ToString();
            }
            catch (Exception ex)
            { }
        }
        #region UserDefinedFunction
        void BindPurchaseOrder(int id)
        {
            odlPOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();

            try
            {
                objPOrder = odlPOrder.GetAllPurchaseOrder(id, 0, "");
                if (objPOrder != null)
                {
                    txtSHC.Text = objPOrder.ShipingAndHandlingCost.ToString();
                    txtTax.Text = objPOrder.TaxValue.ToString();
                    txtMiscCost.Text = objPOrder.MiscCost.ToString();
                    txtTotal.Text = objPOrder.PurchaseAmount.ToString();
                    up1.Update();
                }
                else
                {
                    txtSHC.Text = "";
                    txtTax.Text = "";
                    txtTotal.Text = "";
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                odlPOrder = null;
                objPOrderList = null;
            }
            #endregion
        }
        void BindPurchaseOrderItem(int id)
        {
            oblPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem();

            try
            {
                objPurchaseOrderItemList = oblPurchaseOrderItem.GetAllPurchaseOrderItemList(id, 0, "");

                if (objPurchaseOrderItemList != null)
                {
                    Gridview1.DataSource = objPurchaseOrderItemList;
                    Gridview1.DataBind();
                }
                else
                {
                    Gridview1.DataSource = null;
                    Gridview1.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblPurchaseOrderItem = null;
                objPurchaseOrderItemList = null;
            }


        }
        double findsubtotal()
        {

            double ttl = 0;
            for (int i = 0; i < Gridview1.Rows.Count; i++)
            {
                TextBox box5 = (TextBox)Gridview1.Rows[i].Cells[3].FindControl("txtTotal");
                ttl += Convert.ToDouble(box5.Text);
            }
            return (ttl);

        }

        private void reset()
        {
            txtPoId.Text = string.Empty;
            txtMiscCost.Text = string.Empty;
            txtPoId.Text = string.Empty;
            txtSHC.Text = string.Empty;
            txtSubTotal.Text = string.Empty;
            txtTax.Text = string.Empty;
            txtTotal.Text = string.Empty;
            Gridview1.DataSource = null;
            Gridview1.DataBind();
            hfPoderId.Value = string.Empty;
        }

      
        protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtQut = (TextBox)e.Row.FindControl("txtQut");
                txtQut.Attributes.Add("RowId", e.Row.RowIndex.ToString());

            }
        }
    }
}