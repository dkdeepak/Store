using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Services;
using Store.Common;


namespace StoreManagement
{
    public partial class SalesReturn : System.Web.UI.Page
    {
        Store.SaleReturnItem.BusinessObject.SaleReturnItem objsalesRtnItem = null;
        Store.SalesReturned.BusinessObject.SalesReturnedList objsalesRtnList = null;
        Store.SaleReturnItem.BusinessObject.SaleReturnItemList objsalesRtnItemList = null;
        Store.SaleReturnItem.BusinessLogic.SaleReturnItem oblsalesRtnItem = null;
        Store.SalesReturned.BusinessLogic.SalesReturned oblSalesRtn = null;
        Store.Common.MessageInfo objMessageInfo = null;
        Store.SalesReturned.BusinessObject.SalesReturned objSalesRtn = null;
        Store.Item.BusinessLogic.Item oblItem = new Store.Item.BusinessLogic.Item();
        Store.Item.BusinessObject.ItemList objItemList = new Store.Item.BusinessObject.ItemList();
        Store.SalesOrder.BusinessObject.SalesOrder objSales = null;
        Store.SalesOrder.BusinessLogic.SalesOrder oblSales = null;
        Store.SalesOrderItem.BusinessObject.SalesOrderItemList objSalesItemList = null;
        Store.SalesOrderItem.BusinessLogic.SalesOrderItem oblSalesItem = null;

        Store.VendorInfo.BusinessLogic.VendorInfo oblVendorInfo = null;
        Store.VendorInfo.BusinessObject.VendorInfo objVendorInfo = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindSaleOrder();
                divFrom.Style.Add("display", "none");
            }
        }
        void BindSaleOrder()
        {
            oblSalesRtn = new Store.SalesReturned.BusinessLogic.SalesReturned();
           // oblPurchaseOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();
            try
            {
                objsalesRtnList = oblSalesRtn.GetAllSalesReturnedList(0,0,"");
                //objPurchaseOrderlist = oblPurchaseOrder.GetAllPurchaseOrderList(0, 0, "");
                if (objsalesRtnList != null)
                {
                    gvSaleRtn.DataSource = objsalesRtnList;
                    gvSaleRtn.DataBind();
                }
                else
                {
                    gvSaleRtn.DataSource = null;
                    gvSaleRtn.DataBind();
                }
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesReturn).FullName, 1);
            }
            finally
            {
                oblSalesRtn = null;
                objsalesRtnList = null;
            }
        }

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
        void BindVendorInfo(int id)
        {
            oblVendorInfo = new Store.VendorInfo.BusinessLogic.VendorInfo();
            try
            {
                objVendorInfo = oblVendorInfo.GetAllVendorInfo(id, 0, "");
                if (objVendorInfo != null)
                {
                    hfVendor.Value = objVendorInfo.VendorID.ToString();
                    txtVendor.Text = objVendorInfo.VendorName;
                    txtAddress.Text = objVendorInfo.Address;
                    txtCountry.Text = objVendorInfo.CountryName;
                    txtState.Text = objVendorInfo.StateName;
                    txtCity.Text = objVendorInfo.CityName;
                    txtPin.Text = objVendorInfo.PinID.ToString();
                    txtMobile.Text = objVendorInfo.MobileNo.ToString();
                    txtEmail.Text = objVendorInfo.EmailID;
                }
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesReturn).FullName, 1);
            }
            finally
            {
                oblVendorInfo = null;
                objVendorInfo = null;
            }

        }
        protected void gvSaleRtn_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HiddenField hfVendorId = (HiddenField)gvSaleRtn.Rows[e.RowIndex].FindControl("hfVendorId");
            HiddenField hfSaleRtnId = (HiddenField)gvSaleRtn.Rows[e.RowIndex].FindControl("hfSaleRtnId");
            BindVendorInfo(Convert.ToInt32(hfVendorId.Value));
            BindSaleOrderItem(Convert.ToInt32(hfSaleRtnId.Value));
            BindSaleOrder(Convert.ToInt32(hfSaleRtnId.Value));
            txtSubTotal.Text = findSubTotal().ToString();
            divData.Style.Add("display", "none");
            divFrom.Style.Add("display", "block");
            upSummary.Update();
            hfVendor.Value = hfVendorId.Value;
            hfSaleOrder.Value = hfSaleRtnId.Value;
        }
        void BindSaleOrder(int id)
        {
            oblSalesRtn = new Store.SalesReturned.BusinessLogic.SalesReturned();
           // oblPurchaseOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();

            try
            {
                objSalesRtn = oblSalesRtn.GetAllSalesReturned(id,0,"");
                objSalesRtn = oblSalesRtn.GetAllSalesReturned(id, 0, "");
                if (objSalesRtn != null)
                {

                    txtSHC.Text = objSalesRtn.ShippingAndHandlingCost.ToString();
                    txtTax.Text = objSalesRtn.TaxValue.ToString();
                    txtMiscCost.Text = objSalesRtn.MiscCost.ToString();
                    txttotal.Text = objSalesRtn.TotalSalesReturnAmount.ToString();
                }
                else
                {
                    txtSHC.Text = "";
                    txtTax.Text = "";
                    txttotal.Text = "";
                }
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesReturn).FullName, 1);
            }
            finally
            {
                oblSalesRtn = null;
                objSalesRtn = null;
            }
            upSummary.Update();
        }
        void BindSaleOrderItem(int id)
        {
            oblsalesRtnItem = new Store.SaleReturnItem.BusinessLogic.SaleReturnItem();
          
            try
            {
                objsalesRtnItemList = oblsalesRtnItem.GetAllSaleReturnItemList(id, 0, "");
              
                if (objsalesRtnItemList != null)
                {
                    Gridview1.DataSource = objsalesRtnItemList;
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
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesReturn).FullName, 1);
            }
            finally
            {
                oblsalesRtnItem = null;
                objsalesRtnItemList = null;
            }


        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.mpopSummary.Show();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void reset()
        {
            txtMiscCost.Text = string.Empty;
            txtSHC.Text = string.Empty;
            txtTax.Text = string.Empty;
            txttotal.Text = string.Empty;
            txtSubTotal.Text = string.Empty;
            Gridview1.DataSource = null;
            Gridview1.DataBind();
            hfVendor.Value = "";
            txtVendor.Text = "";
            txtAddress.Text = "";
            txtCountry.Text = "";
            txtState.Text = "";
            txtCity.Text = "";
            txtPin.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            this.mpopSummary.Hide();
            upForm.Update();
            divFrom.Style.Add("display", "block");
            divData.Style.Add("display", "none");

        }
        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                string transid = "";
                transid = insertSalesReturn(txtSubTotal.Text, txtTax.Text, txtSHC.Text, txtMiscCost.Text, txttotal.Text);
                objsalesRtnItemList = new Store.SaleReturnItem.BusinessObject.SaleReturnItemList();
               // objPurchaseReceivedItemList = new Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItemList();
                for (int i = 0; i < Gridview1.Rows.Count; i++)
                {
                   
                    objsalesRtnItem = new Store.SaleReturnItem.BusinessObject.SaleReturnItem();        
                   TextBox txtItemNames = (TextBox)Gridview1.Rows[i].FindControl("txtItemName");
                    if (txtItemNames.Text == "")
                        break;
                    TextBox txtDecs = (TextBox)Gridview1.Rows[i].FindControl("txtDec");
                    TextBox txtPrices = (TextBox)Gridview1.Rows[i].FindControl("txtSPrice");
                    //  TextBox txtDisPres = (TextBox)Gridview1.Rows[i].FindControl("txtDisPre");
                    // TextBox txtDiss = (TextBox)Gridview1.Rows[i].FindControl("txtDis");
                    TextBox txtQuts = (TextBox)Gridview1.Rows[i].FindControl("txtQut");
                    TextBox txtTotals = (TextBox)Gridview1.Rows[i].FindControl("txtTotal");
                    objsalesRtnItem.ItemPrefix = txtItemNames.Text;
                    objsalesRtnItem.Description = txtDecs.Text;
                    objsalesRtnItem.ItemPrice = Convert.ToDecimal(txtPrices.Text);

                    // objPurchaseReceivedItem.DiscountPre = Convert.ToDecimal(txtDisPres.Text);
                    //objPurchaseReceivedItem.Discount = Convert.ToDecimal(txtDiss.Text);
                    objsalesRtnItem.ItemUnit = txtQuts.Text;
                    objsalesRtnItem.ItemPrice = Convert.ToDecimal(txtTotals.Text);
                    objsalesRtnItem.SalesReturnID = Convert.ToInt32(transid);
                    objsalesRtnItem.SalesOrderID = Convert.ToInt32(hfSaleOrder.Value);
                    objsalesRtnItemList.Add(objsalesRtnItem);
                }
                oblsalesRtnItem = new Store.SaleReturnItem.BusinessLogic.SaleReturnItem();
                //oblSalesItem = new Store.SalesOrderItem.BusinessLogic.SalesOrderItem();
                //oblPurchaseReceivedItem = new Store.PurchaseReceivedItem.BusinessLogic.PurchaseReceivedItem();
                objMessageInfo = oblsalesRtnItem.ManageItemMaster(objsalesRtnItem, cmdMode);
                reset();
                
            }
            catch (Exception ex)
            { Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(SalesReturn).FullName, 1); }
        }
        protected void btnCancelsaleRtn_Click(object sender, EventArgs e)
        {
            this.mpopSummary.Hide();
        }
        protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtQut = (TextBox)e.Row.FindControl("txtQut");
                txtQut.Attributes.Add("RowId", e.Row.RowIndex.ToString());
            }
        }
        protected void ibtnCloseSummary_Click(object sender, EventArgs e)
        {
            this.mpopSummary.Hide();
        }
        public string insertSalesReturn(string subtotal, string tax, string shc, string misccost, string ttotal)
        {
            oblSalesRtn = new Store.SalesReturned.BusinessLogic.SalesReturned();
           // oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
            objMessageInfo = new MessageInfo();

            objSalesRtn = new Store.SalesReturned.BusinessObject.SalesReturned();
            if (cmdMode == Store.Common.CommandMode.M)
            {
                objSalesRtn.SalesReturnedID = Convert.ToInt32(hfPId.Value);
               // objPurchaseReceived.PurchaseReceivedID = Convert.ToInt32(hfPId.Value);//PurchaseReceivedID which edit from data grid
            }
            else
            {
               // objPurchaseReceived.PurchaseReceivedID = 0;
            }

            objSalesRtn.SalesReturnedID = Convert.ToInt32(hfSaleOrder.Value);
            objSalesRtn.VendorID = Convert.ToInt32(hfVendor.Value);
            objSalesRtn.TotalSalesReturnAmount = Convert.ToDecimal(ttotal);
            objSalesRtn.TaxValue = Convert.ToDecimal(tax);
            objSalesRtn.ShippingAndHandlingCost = Convert.ToDecimal(shc);
            objSalesRtn.MiscCost = Convert.ToDecimal(misccost);
            objSalesRtn.IsActive = 1;
            objMessageInfo = oblSalesRtn.ManageSalesRetuned(objSalesRtn, cmdMode);

            return objMessageInfo.TranID.ToString();
        }
        protected void txtMiscCost_TextChanged(object sender, EventArgs e)
        {
            double subtotal = Convert.ToDouble(txtSubTotal.Text);
            double tax = Convert.ToDouble(txtTax.Text);
            double shc = Convert.ToDouble(txtSHC.Text);
            double miss = Convert.ToDouble(txtMiscCost.Text);
            double total;
            total = subtotal + tax + shc + miss;
            txttotal.Text = Convert.ToString(total);
            upForm.Update();
            txttotal.Focus();
        }
        decimal findSubTotal()
        {
            decimal Saleprice = 0, qty = 0, total = 0;
            for (int i = 0; i < Gridview1.Rows.Count; i++)
            {
                TextBox item = (TextBox)Gridview1.Rows[i].FindControl("txtItemName");
                if (item.Text == "")
                    break;
                TextBox box1 = (TextBox)Gridview1.Rows[i].FindControl("txtSPrice");
                TextBox box4 = (TextBox)Gridview1.Rows[i].FindControl("txtQut");
                TextBox box5 = (TextBox)Gridview1.Rows[i].FindControl("txtTotal");
                Saleprice += Convert.ToDecimal(box1.Text);
                qty += Convert.ToDecimal(box4.Text);
                total += Convert.ToDecimal(box5.Text);
            }
            TextBox box1T = (TextBox)Gridview1.FooterRow.FindControl("txtSPriceT");
            TextBox box4T = (TextBox)Gridview1.FooterRow.FindControl("txtQutT");
            TextBox box5T = (TextBox)Gridview1.FooterRow.FindControl("txtTotalT");
            box1T.Text = Saleprice.ToString("0.00");
            box4T.Text = qty.ToString("0.00");
            box5T.Text = total.ToString("0.00");
            return total;

        }
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        protected void txtQut_TextChanged(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(((TextBox)sender).Attributes["RowId"].ToString());
            TextBox price = (TextBox)Gridview1.Rows[rows].FindControl("txtPrice");
            TextBox qut = (TextBox)Gridview1.Rows[rows].FindControl("txtQut");
            TextBox ttl = (TextBox)Gridview1.Rows[rows].FindControl("txtTotal");
            double pri = Convert.ToDouble(price.Text);

            double total = pri * Convert.ToInt32(qut.Text);
            ttl.Text = Convert.ToString(total);
            txtSubTotal.Text = Convert.ToString(findSubTotal());
            upForm.Update();
            upSummary.Update();
            ttl.Focus();
        }
    }
}