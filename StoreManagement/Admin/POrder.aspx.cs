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
    public partial class POrder : System.Web.UI.Page
    {
        Store.PurchaseOrder.BusinessLogic.PurchaseOrder oblPurchaseOrder = null;
        Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem oblPurchaseOrderItem = null;
        Store.Common.MessageInfo objMessageInfo = null;
        Store.PurchaseOrder.BusinessObject.PurchaseOrder objPurchaseOrder = null;
        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem objPurchaseOrderItem = null;
        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList objPurchaseOrderItemList = null;

        Store.VendorInfo.BusinessLogic.VendorInfo oblVendorInfo = null;
        Store.VendorInfo.BusinessObject.VendorInfo objVendorInfo = null;
        Store.VendorInfo.BusinessObject.VendorInfoList objVendorInfoList = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetInitialRow();
                if(Request.QueryString["id"]!=null)
                {
                    BindVendorInfo();
                }
               // BindPurchaseOrder();

            }
        }
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        #region Autocompelet
        [System.Web.Services.WebMethod]
        public static string[] GetCompletionList(string prefixText, int count)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ShopDB"].ConnectionString;
                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "select ItemPrefix,ItemID from mItem where " + "ItemPrefix like @Search + '%' or ItemCode like @Search + '%'";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    Dictionary<Int32, string> objDictonr = new Dictionary<int, string>();
                    // List<string> ItemPrefix = new List<string>();
                    List<string> ItemPrefix = new List<string>();
                    string item = string.Empty;
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            item = AutoCompleteExtender.CreateAutoCompleteItem(sdr[0].ToString(), sdr[1].ToString());
                            ItemPrefix.Add(item);

                            //objDictonr.Add(Convert.ToInt32(sdr["ItemID"].ToString()), sdr["ItemPrefix"].ToString());
                            //ItemPrefix.Add(sdr["ItemPrefix"].ToString());
                        }
                    }
                    con.Close();
                    return ItemPrefix.ToArray();
                    //return objDictonr;

                }

            }

        }
        #endregion
        #region Event
        #region gridevent

        protected void txtDisPre_TextChanged(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(((TextBox)sender).Attributes["RowId"].ToString());
            TextBox price = (TextBox)Gridview1.Rows[rows].FindControl("txtPrice");
            TextBox dicpre = (TextBox)Gridview1.Rows[rows].FindControl("txtDisPre");
            TextBox dic = (TextBox)Gridview1.Rows[rows].FindControl("txtDis");
            TextBox qty = (TextBox)Gridview1.Rows[rows].FindControl("txtQut");
            dic.Text = Convert.ToString(((Convert.ToDouble(price.Text)) * (Convert.ToDouble(dicpre.Text))) / 100);
            qty.Focus();
        }
        protected void txtQut_TextChanged(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(((TextBox)sender).Attributes["RowId"].ToString());
            TextBox price = (TextBox)Gridview1.Rows[rows].FindControl("txtPrice");
            TextBox dic = (TextBox)Gridview1.Rows[rows].FindControl("txtDis");
            TextBox qut = (TextBox)Gridview1.Rows[rows].FindControl("txtQut");
            TextBox ttl = (TextBox)Gridview1.Rows[rows].FindControl("txtTotal");
            double pri = Convert.ToDouble(price.Text) - Convert.ToDouble(dic.Text);

            double total = pri * Convert.ToInt32(qut.Text);
            ttl.Text = Convert.ToString(total);
            txtSubTotal.Text = Convert.ToString(findSubTotal());
            upForm.Update();
            upSummary.Update();
            int row = rows + 1;
            if (row%5==0)
            {
                for (int i = 0; i < 5; i++)
                {
                    AddNewRowToGrid();
                }
            }
            TextBox item = (TextBox)Gridview1.Rows[rows+1].FindControl("txtItemName");
            item.Focus();
        }
        #endregion

        decimal findSubTotal()
        {
            decimal price = 0, disPre = 0, dis = 0, qty = 0, total = 0;
            for (int i = 0; i < Gridview1.Rows.Count; i++)
            {
                TextBox item = (TextBox)Gridview1.Rows[i].FindControl("txtItemName");
                if (item.Text == "")
                    break;
                TextBox box1 = (TextBox)Gridview1.Rows[i].FindControl("txtPrice");
                TextBox box2 = (TextBox)Gridview1.Rows[i].FindControl("txtDisPre");
                TextBox box3 = (TextBox)Gridview1.Rows[i].FindControl("txtDis");
                TextBox box4 = (TextBox)Gridview1.Rows[i].FindControl("txtQut");
                TextBox box5 = (TextBox)Gridview1.Rows[i].FindControl("txtTotal");
                price += Convert.ToDecimal(box1.Text);
                disPre += Convert.ToDecimal(box2.Text);
                dis += Convert.ToDecimal(box3.Text);
                qty += Convert.ToDecimal(box4.Text);
                total += Convert.ToDecimal(box5.Text);
            }
            TextBox box1T = (TextBox)Gridview1.FooterRow.FindControl("txtPriceT");
            TextBox box2T = (TextBox)Gridview1.FooterRow.FindControl("txtDisPreT");
            TextBox box3T = (TextBox)Gridview1.FooterRow.FindControl("txtDisT");
            TextBox box4T = (TextBox)Gridview1.FooterRow.FindControl("txtQutT");
            TextBox box5T = (TextBox)Gridview1.FooterRow.FindControl("txtTotalT");
            box1T.Text = price.ToString("0.00");
            box2T.Text = disPre.ToString("0.00");
            box3T.Text = dis.ToString("0.00");
            box4T.Text = qty.ToString("0.00");
            box5T.Text = total.ToString("0.00");

            return total;

        }
        protected void txtDicPre_TextChanged1(object sender, EventArgs e)
        {
            double dic;
            double subtotal = Convert.ToDouble(txtSubTotal.Text);
            double dicPre = Convert.ToDouble(txtDicPre.Text);
            double tax;
            dic = (subtotal * dicPre) / 100;
            tax = (subtotal - dic) * .125;
            txtDic.Text = Convert.ToString(dic);
            txtTax.Text = Convert.ToString(tax);
            upForm.Update();
            txtTax.Focus();
        }

        protected void txtMiscCost_TextChanged(object sender, EventArgs e)
        {
            double subtotal = Convert.ToDouble(txtSubTotal.Text);
            double tax = Convert.ToDouble(txtTax.Text);
            double dic = Convert.ToDouble(txtDic.Text);
            double shc = Convert.ToDouble(txtSHC.Text);
            double miss = Convert.ToDouble(txtMiscCost.Text);
            double total;
            total = subtotal + tax - dic + shc + miss;
            txttotal.Text = Convert.ToString(total);
            upForm.Update();
            txttotal.Focus();
        }

        #endregion
        #region grid
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));
            dt.Columns.Add(new DataColumn("Column5", typeof(string)));
            dt.Columns.Add(new DataColumn("Column6", typeof(string)));
            dt.Columns.Add(new DataColumn("Column7", typeof(string)));

            for (int i = 0; i < 5; i++)
            {
                dr = dt.NewRow();
                dr["RowNumber"] = i+1;
                dr["Column1"] = string.Empty;
                dr["Column2"] = string.Empty;
                dr["Column3"] = string.Empty;
                dr["Column4"] = string.Empty;
                dr["Column5"] = string.Empty;
                dr["Column6"] = string.Empty;
                dr["Column7"] = string.Empty;
                dt.Rows.Add(dr);
            }
           

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;

            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txtItemName");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDec");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtPrice");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtDisPre");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txtDis");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txtQut");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txtTotal");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                        dtCurrentTable.Rows[i - 1]["Column4"] = box4.Text;
                        dtCurrentTable.Rows[i - 1]["Column5"] = box5.Text;
                        dtCurrentTable.Rows[i - 1]["Column6"] = box6.Text;
                        dtCurrentTable.Rows[i - 1]["Column7"] = box7.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    Gridview1.DataSource = dtCurrentTable;
                    Gridview1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txtItemName");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDec");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtPrice");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtDisPre");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txtDis");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txtQut");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txtTotal");

                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        box4.Text = dt.Rows[i]["Column4"].ToString();
                        box5.Text = dt.Rows[i]["Column5"].ToString();
                        box6.Text = dt.Rows[i]["Column6"].ToString();
                        box7.Text = dt.Rows[i]["Column7"].ToString();

                        rowIndex++;
                    }
                }
            }
        }
       
        #endregion
        #region method
        public string insertOrder(string subtotal, string dicpre, string dic, string tax, string shc, string misccost, string ttotal)
        {

            oblPurchaseOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();
            objMessageInfo = new MessageInfo();
            objPurchaseOrder = new Store.PurchaseOrder.BusinessObject.PurchaseOrder();
            if (cmdMode == Store.Common.CommandMode.M)
            {
                objPurchaseOrder.PurchaseOrderID = Convert.ToInt32(hfPId.Value);//PurchaseOrderID which edit from data grid
            }
            else
            {
                objPurchaseOrder.PurchaseOrderID = 0;
            }
            objPurchaseOrder.PurchaseOrderID = 0;
            objPurchaseOrder.VendorID = Convert.ToInt32(hfVendor.Value);
            objPurchaseOrder.PurchaseAmount = Convert.ToDecimal(ttotal);
            objPurchaseOrder.TaxValue = Convert.ToDecimal(tax);
            objPurchaseOrder.ShipingAndHandlingCost = Convert.ToDecimal(shc);
            objPurchaseOrder.MiscCost = Convert.ToDecimal(misccost);
            objPurchaseOrder.PDiscountPre = Convert.ToDecimal(dicpre);
            objPurchaseOrder.PDiscount = Convert.ToDecimal(dic);
            objPurchaseOrder.IsActive = 1;
            objMessageInfo = oblPurchaseOrder.ManagePurchaseOrder(objPurchaseOrder, cmdMode);

            return objMessageInfo.TranID.ToString();
        }
       
        #endregion
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.mpopSummary.Show();
        }
        private void reset()
        {
            txtDic.Text = string.Empty;
            txtDicPre.Text = string.Empty;
            txtMiscCost.Text = string.Empty;
            txtSHC.Text = string.Empty;
            txtTax.Text = string.Empty;
            txttotal.Text = string.Empty;
            txtSubTotal.Text = string.Empty;
            Gridview1.DataSource = null;
            Gridview1.DataBind();
            SetInitialRow();
            ViewState["CurrentTable"] = null;
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
            upForm.Update();

        }

        protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtDisPre = (TextBox)e.Row.FindControl("txtDisPre");
                TextBox txtQut = (TextBox)e.Row.FindControl("txtQut");

                txtDisPre.Attributes.Add("RowId", e.Row.RowIndex.ToString());
                txtQut.Attributes.Add("RowId", e.Row.RowIndex.ToString());
            }
        }
        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }
      

        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindVendorInfo();
        }

        void BindVendorInfo()
        {

            oblVendorInfo = new Store.VendorInfo.BusinessLogic.VendorInfo();
            try
            {
                objVendorInfoList = oblVendorInfo.GetAllVendorInfoList(0, 0, "");
                if (objVendorInfoList != null)
                {
                    dgvVendorInfo.DataSource = objVendorInfoList;
                    dgvVendorInfo.DataBind();
                }
                else
                {
                    dgvVendorInfo.DataSource = null;
                    dgvVendorInfo.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblVendorInfo = null;
                objVendorInfoList = null;
            }
            updateSupplierBdInfo.Update();
            this.mpopVendor.Show();

        }

       

        protected void dgvVendorInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            hfVendor.Value=dgvVendorInfo.Rows[e.RowIndex].Cells[0].Text;
            txtVendor.Text= dgvVendorInfo.Rows[e.RowIndex].Cells[1].Text;
            txtAddress.Text= dgvVendorInfo.Rows[e.RowIndex].Cells[2].Text;
            txtCountry.Text= dgvVendorInfo.Rows[e.RowIndex].Cells[3].Text;
            txtState.Text= dgvVendorInfo.Rows[e.RowIndex].Cells[4].Text;
            txtCity.Text= dgvVendorInfo.Rows[e.RowIndex].Cells[5].Text;
            txtPin.Text= dgvVendorInfo.Rows[e.RowIndex].Cells[6].Text;
            txtMobile.Text= dgvVendorInfo.Rows[e.RowIndex].Cells[7].Text;
            txtEmail.Text= dgvVendorInfo.Rows[e.RowIndex].Cells[8].Text;
            this.mpopVendor.Hide();
            upForm.Update();
        }
        protected void lbtnClose_Click(object sender, EventArgs e)
        {
            this.mpopVendor.Hide();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("VendorInfo.aspx?page=" + "porder.aspx");
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                string transid = "";
                transid = insertOrder(txtSubTotal.Text, txtDicPre.Text, txtDic.Text, txtTax.Text, txtSHC.Text, txtMiscCost.Text, txttotal.Text);
                objPurchaseOrderItemList = new Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList();
                for (int i = 0; i < Gridview1.Rows.Count - 1; i++)
                {
                    objPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem();
                    TextBox txtItemNames = (TextBox)Gridview1.Rows[i].FindControl("txtItemName");
                    if (txtItemNames.Text == "")
                        break;
                    TextBox txtDecs = (TextBox)Gridview1.Rows[i].FindControl("txtDec");
                    TextBox txtPrices = (TextBox)Gridview1.Rows[i].FindControl("txtPrice");
                    TextBox txtDisPres = (TextBox)Gridview1.Rows[i].FindControl("txtDisPre");
                    TextBox txtDiss = (TextBox)Gridview1.Rows[i].FindControl("txtDis");
                    TextBox txtQuts = (TextBox)Gridview1.Rows[i].FindControl("txtQut");
                    TextBox txtTotals = (TextBox)Gridview1.Rows[i].FindControl("txtTotal");
                    objPurchaseOrderItem.ItemPrefix = txtItemNames.Text;
                    objPurchaseOrderItem.Description = txtDecs.Text;
                    objPurchaseOrderItem.ItemPrice = Convert.ToDecimal(txtPrices.Text);
                    objPurchaseOrderItem.DiscountPre = Convert.ToDecimal(txtDisPres.Text);
                    objPurchaseOrderItem.Discount = Convert.ToDecimal(txtDiss.Text);
                    objPurchaseOrderItem.ItemUnit = txtQuts.Text;
                    objPurchaseOrderItem.TotalPrice = Convert.ToDecimal(txtTotals.Text);
                    objPurchaseOrderItem.PurchaseOrderID = Convert.ToInt32(transid);
                    objPurchaseOrderItemList.Add(objPurchaseOrderItem);
                }
                oblPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem();
                objMessageInfo = oblPurchaseOrderItem.ManageItemMaster(objPurchaseOrderItemList, cmdMode);
                reset();
            }
            catch (Exception ex)
            { throw ex; }
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            this.mpopSummary.Hide();
        }

        protected void ibtnCloseSummary_Click(object sender, EventArgs e)
        {
            this.mpopSummary.Hide();
        }
    }




}

