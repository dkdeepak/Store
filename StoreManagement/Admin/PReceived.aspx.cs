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
using AjaxControlToolkit;

namespace StoreManagement.Admin
{
    public partial class PReceived : System.Web.UI.Page
    {
        Store.PurchaseOrder.BusinessLogic.PurchaseOrder oblPurchaseOrder = null;
        Store.PurchaseOrder.BusinessObject.PurchaseOrder objPurchaseOrder = null;
        Store.PurchaseOrder.BusinessObject.PurchaseOrderList objPurchaseOrderlist = null;

        Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem oblPurchaseOrderItem = null;
        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList objPurchaseOrderItemList = null;

        Store.PurchaseReceived.BusinessLogic.PurchaseReceived oblPurchaseReceived = null;
        Store.PurchaseReceivedItem.BusinessLogic.PurchaseReceivedItem oblPurchaseReceivedItem = null;
        Store.Common.MessageInfo objMessageInfo = null;
        Store.PurchaseReceived.BusinessObject.PurchaseReceived objPurchaseReceived = null;
        Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem objPurchaseReceivedItem = null;
        Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItemList objPurchaseReceivedItemList = null;

        Store.VendorInfo.BusinessLogic.VendorInfo oblVendorInfo = null;
        Store.VendorInfo.BusinessObject.VendorInfo objVendorInfo = null;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindPOder();
                divFrom.Style.Add("display", "none");
            }
        }
        void BindPOder()
        {
            oblPurchaseOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();
            try
            {
                objPurchaseOrderlist = oblPurchaseOrder.GetAllPurchaseOrderList(0, 0, "");
                if (objPurchaseOrderlist != null)
                {
                    gvPOrder.DataSource = objPurchaseOrderlist;
                    gvPOrder.DataBind();
                }
                else
                {
                    gvPOrder.DataSource = null;
                    gvPOrder.DataBind();
                }
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(PReceived).FullName, 1);

            }
            finally
            {
                oblPurchaseOrder = null;
                objPurchaseOrderlist = null;
            }
        }
        protected void gvPOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HiddenField hfVendorId = (HiddenField)gvPOrder.Rows[e.RowIndex].FindControl("hfVendorId");
            HiddenField hfPOrderId = (HiddenField)gvPOrder.Rows[e.RowIndex].FindControl("hfPOrderId");
            BindVendorInfo(Convert.ToInt32(hfVendorId.Value));
            BindPurchaseOrderItem(Convert.ToInt32(hfPOrderId.Value));
            BindPurchaseOrder(Convert.ToInt32(hfPOrderId.Value));
            txtSubTotal.Text = findSubTotal().ToString();
            divData.Style.Add("display", "none");
            divFrom.Style.Add("display", "block");
            upSummary.Update();
            hfVendor.Value = hfVendorId.Value;
            hfPOrder.Value = hfPOrderId.Value;
        }
        void BindVendorInfo( int id)
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
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(PReceived).FullName, 1);
            }
            finally
            {
                oblVendorInfo = null;
                objVendorInfo = null;
            }
            
        }
        void BindPurchaseOrder(int id)
        {
            oblPurchaseOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();

            try
            {
                objPurchaseOrder = oblPurchaseOrder.GetAllPurchaseOrder(id, 0, "");
                if (objPurchaseOrder != null)
                {
                    
                    txtSHC.Text = objPurchaseOrder.ShipingAndHandlingCost.ToString();
                    txtTax.Text = objPurchaseOrder.TaxValue.ToString();
                    txtMiscCost.Text = objPurchaseOrder.MiscCost.ToString();
                    txttotal.Text = objPurchaseOrder.PurchaseAmount.ToString();
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
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(PReceived).FullName, 1);
            }
            finally
            {
                oblPurchaseOrder = null;
                objPurchaseOrder = null;
            }
            upSummary.Update();
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
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(PReceived).FullName, 1);
            }
            finally
            {
                oblPurchaseOrderItem = null;
                objPurchaseOrderItemList = null;
            }


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
        decimal findSubTotal()
        {
            decimal price = 0,  qty = 0, total = 0;
            for (int i = 0; i < Gridview1.Rows.Count; i++)
            {
                TextBox item = (TextBox)Gridview1.Rows[i].FindControl("txtItemName");
                if (item.Text == "")
                    break;
                TextBox box1 = (TextBox)Gridview1.Rows[i].FindControl("txtPrice");
                TextBox box4 = (TextBox)Gridview1.Rows[i].FindControl("txtQut");
                TextBox box5 = (TextBox)Gridview1.Rows[i].FindControl("txtTotal");
                price += Convert.ToDecimal(box1.Text);
                qty += Convert.ToDecimal(box4.Text);
                total += Convert.ToDecimal(box5.Text);
            }
            TextBox box1T = (TextBox)Gridview1.FooterRow.FindControl("txtPriceT");
            TextBox box4T = (TextBox)Gridview1.FooterRow.FindControl("txtQutT");
            TextBox box5T = (TextBox)Gridview1.FooterRow.FindControl("txtTotalT");
            box1T.Text = price.ToString("0.00");
            box4T.Text = qty.ToString("0.00");
            box5T.Text = total.ToString("0.00");
            return total;

        }
        protected void txtMiscCost_TextChanged(object sender, EventArgs e)
        {
            double subtotal = Convert.ToDouble(txtSubTotal.Text);
            double tax = Convert.ToDouble(txtTax.Text);
            double shc = Convert.ToDouble(txtSHC.Text);
            double miss = Convert.ToDouble(txtMiscCost.Text);
            double total;
            total = subtotal + tax  + shc + miss;
            txttotal.Text = Convert.ToString(total);
            upForm.Update();
            txttotal.Focus();
        }
        public string insertReceived(string subtotal, string tax, string shc, string misccost, string ttotal)
        {

            oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
            objMessageInfo = new MessageInfo();
            objPurchaseReceived = new Store.PurchaseReceived.BusinessObject.PurchaseReceived();
            if (cmdMode == Store.Common.CommandMode.M)
            {
                objPurchaseReceived.PurchaseReceivedID = Convert.ToInt32(hfPId.Value);//PurchaseReceivedID which edit from data grid
            }
            else
            {
                objPurchaseReceived.PurchaseReceivedID = 0;
            }
            objPurchaseReceived.PurchaseOrderID = Convert.ToInt32(hfPOrder.Value);
            objPurchaseReceived.VendorID = Convert.ToInt32(hfVendor.Value);
            objPurchaseReceived.PurchaseAmount = Convert.ToDecimal(ttotal);
            objPurchaseReceived.TaxValue = Convert.ToDecimal(tax);
            objPurchaseReceived.ShipingAndHandlingCost = Convert.ToDecimal(shc);
            objPurchaseReceived.MiscCost = Convert.ToDecimal(misccost);
            objPurchaseReceived.IsActive = 1;
            objMessageInfo = oblPurchaseReceived.ManagePurchaseReceived(objPurchaseReceived, cmdMode);

            return objMessageInfo.TranID.ToString();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.mpopSummary.Show();
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
            txtAddress.Text ="";
            txtCountry.Text = "";
            txtState.Text = "";
            txtCity.Text = "";
            txtPin.Text = "";
            txtMobile.Text ="";
            txtEmail.Text = "";
            this.mpopSummary.Hide();            
            upSummary.Update();
            divFrom.Style.Add("display", "none");
            divData.Style.Add("display", "block");
            upForm.Update();

        }
        protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtQut = (TextBox)e.Row.FindControl("txtQut");
                txtQut.Attributes.Add("RowId", e.Row.RowIndex.ToString());
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }
        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                string transid = "";
                transid = insertReceived(txtSubTotal.Text,txtTax.Text, txtSHC.Text, txtMiscCost.Text, txttotal.Text);
                objPurchaseReceivedItemList = new Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItemList();
                for (int i = 0; i < Gridview1.Rows.Count ; i++)
                {
                    objPurchaseReceivedItem = new Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem();
                    TextBox txtItemNames = (TextBox)Gridview1.Rows[i].FindControl("txtItemName");
                    if (txtItemNames.Text == "")
                        break;
                    TextBox txtDecs = (TextBox)Gridview1.Rows[i].FindControl("txtDec");
                    TextBox txtPrices = (TextBox)Gridview1.Rows[i].FindControl("txtPrice");
                    TextBox txtQuts = (TextBox)Gridview1.Rows[i].FindControl("txtQut");
                    TextBox txtTotals = (TextBox)Gridview1.Rows[i].FindControl("txtTotal");
                    objPurchaseReceivedItem.ItemPrefix = txtItemNames.Text;
                    objPurchaseReceivedItem.Description = txtDecs.Text;
                    objPurchaseReceivedItem.ItemPrice = Convert.ToDecimal(txtPrices.Text);               
                    objPurchaseReceivedItem.ItemUnit = txtQuts.Text;
                    objPurchaseReceivedItem.TotalPrice = Convert.ToDecimal(txtTotals.Text);
                    objPurchaseReceivedItem.PurchaseReceivedID = Convert.ToInt32(transid);
                    objPurchaseReceivedItem.PurchaseOrderID = Convert.ToInt32(hfPOrder.Value);
                    objPurchaseReceivedItemList.Add(objPurchaseReceivedItem);
                }
                oblPurchaseReceivedItem = new Store.PurchaseReceivedItem.BusinessLogic.PurchaseReceivedItem();
                objMessageInfo = oblPurchaseReceivedItem.ManageItemMaster(objPurchaseReceivedItemList, cmdMode);
                reset();
            }
            catch (Exception ex)
            { Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(PReceived).FullName, 1); }
        }

        protected void btnCancelReceived_Click(object sender, EventArgs e)
        {
            this.mpopSummary.Hide();
        }

        protected void ibtnCloseSummary_Click(object sender, EventArgs e)
        {
            this.mpopSummary.Hide();
        }

        
    }




}

