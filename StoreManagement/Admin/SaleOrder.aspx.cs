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
    public partial class SaleOrder : System.Web.UI.Page
    {
        Store.SalesOrderItem.BusinessLogic.SalesOrderItem oblSalesOrderItem = null;
        Store.SalesOrder.BusinessLogic.SalesOrder oblSalesOrder = new Store.SalesOrder.BusinessLogic.SalesOrder();
        Store.SalesOrder.BusinessObject.SalesOrderList objSalesList = new Store.SalesOrder.BusinessObject.SalesOrderList();
        Store.SalesOrder.BusinessObject.SalesOrder objSalesOrder = null;
        Store.SalesOrderItem.BusinessObject.SalesOrderItem objsalesOrderItem = null;
        Store.SalesOrder.BusinessObject.SalesOrder objSalesOrderList = null;
        Store.SalesOrderItem.BusinessObject.SalesOrderItemList objSalesOrderItemList = null;
        Store.Common.MessageInfo objMessageInfo = null;

        Store.VendorInfo.BusinessLogic.VendorInfo oblVendorInfo = null;
        Store.VendorInfo.BusinessObject.VendorInfo objVendorInfo = null;
        Store.VendorInfo.BusinessObject.VendorInfoList objVendorInfoList = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetInitialRow();
                if (Request.QueryString["id"] != null)
                {
                    BindVendorInfo();
                }
                           }
        }
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
            dt.Columns.Add(new DataColumn("Column8", typeof(string)));

            for (int i = 0; i < 5; i++)
            {
                dr = dt.NewRow();
                dr["RowNumber"] = i + 1;
                dr["Column1"] = string.Empty;
                dr["Column2"] = string.Empty;
                dr["Column3"] = string.Empty;
                dr["Column4"] = string.Empty;
                dr["Column5"] = string.Empty;
                dr["Column6"] = string.Empty;
                dr["Column7"] = string.Empty;
                dr["Column8"] = string.Empty;
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
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCPrice");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtSPrice");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txtDisPre");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txtDis");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txtQut");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txtTotal");
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                        dtCurrentTable.Rows[i - 1]["Column4"] = box4.Text;
                        dtCurrentTable.Rows[i - 1]["Column5"] = box5.Text;
                        dtCurrentTable.Rows[i - 1]["Column6"] = box6.Text;
                        dtCurrentTable.Rows[i - 1]["Column7"] = box7.Text;
                        dtCurrentTable.Rows[i - 1]["Column8"] = box8.Text;
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
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCPrice");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtSPrice");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txtDisPre");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txtDis");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txtQut");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txtTotal");

                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        box4.Text = dt.Rows[i]["Column4"].ToString();
                        box5.Text = dt.Rows[i]["Column5"].ToString();
                        box6.Text = dt.Rows[i]["Column6"].ToString();
                        box7.Text = dt.Rows[i]["Column7"].ToString();
                        box8.Text = dt.Rows[i]["Column8"].ToString();

                        rowIndex++;
                    }
                }
            }
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
        protected void txtMiscCost_TextChanged(object sender, EventArgs e)
        {
            double cpsubtotal = Convert.ToDouble(txtCPSubTotal.Text);
            double spsubtotal = Convert.ToDouble(txtSPSubTotal.Text);
            double tax = Convert.ToDouble(txtTax.Text);
            double dic = Convert.ToDouble(txtDic.Text);
            double shc = Convert.ToDouble(txtSHC.Text);
            double miss = Convert.ToDouble(txtMiscCost.Text);
            double total;
            total = spsubtotal + tax - dic + shc + miss;
            txttotal.Text = Convert.ToString(total);
            upForm.Update();
            txttotal.Focus();
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
        protected void txtDisPre_TextChanged(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(((TextBox)sender).Attributes["RowId"].ToString());
            TextBox costprice = (TextBox)Gridview1.Rows[rows].FindControl("txtCPrice");
            TextBox saleprice = (TextBox)Gridview1.Rows[rows].FindControl("txtSPrice");
            TextBox dicpre = (TextBox)Gridview1.Rows[rows].FindControl("txtDisPre");
            TextBox dic = (TextBox)Gridview1.Rows[rows].FindControl("txtDis");
            TextBox qty = (TextBox)Gridview1.Rows[rows].FindControl("txtQut");
            dic.Text = Convert.ToString(((Convert.ToDouble(saleprice.Text)) * (Convert.ToDouble(dicpre.Text))) / 100);
            qty.Focus();
        }
        protected void txtQut_TextChanged(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(((TextBox)sender).Attributes["RowId"].ToString());
            TextBox saleprice = (TextBox)Gridview1.Rows[rows].FindControl("txtSPrice");
            TextBox dic = (TextBox)Gridview1.Rows[rows].FindControl("txtDis");
            TextBox qut = (TextBox)Gridview1.Rows[rows].FindControl("txtQut");
            TextBox ttl = (TextBox)Gridview1.Rows[rows].FindControl("txtTotal");
            double pri = Convert.ToDouble(saleprice.Text) - Convert.ToDouble(dic.Text);

            double total = pri * Convert.ToInt32(qut.Text);
            ttl.Text = Convert.ToString(total);
            txtSPSubTotal.Text = Convert.ToString(findSubTotal());
            upForm.Update();
            upSummary.Update();
            int row = rows + 1;
            if (row % 5 == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    AddNewRowToGrid();
                }
            }
            TextBox item = (TextBox)Gridview1.Rows[rows + 1].FindControl("txtItemName");
            item.Focus();
        }
        decimal findSubTotal()
        {
            decimal saleprice = 0, disPre = 0, dis = 0, qty = 0, total = 0;
           // decimal costprice = 0, disPre = 0, dis = 0, qty = 0, total = 0;
            for (int i = 0; i < Gridview1.Rows.Count; i++)
            {
                TextBox item = (TextBox)Gridview1.Rows[i].FindControl("txtItemName");
                if (item.Text == "")
                    break;
                TextBox box1 = (TextBox)Gridview1.Rows[i].FindControl("txtCPrice");
                TextBox box2 = (TextBox)Gridview1.Rows[i].FindControl("txtSPrice");
                TextBox box3 = (TextBox)Gridview1.Rows[i].FindControl("txtDisPre");
                TextBox box4 = (TextBox)Gridview1.Rows[i].FindControl("txtDis");
                TextBox box5 = (TextBox)Gridview1.Rows[i].FindControl("txtQut");
                TextBox box6 = (TextBox)Gridview1.Rows[i].FindControl("txtTotal");
                saleprice += Convert.ToDecimal(box2.Text);

                disPre += Convert.ToDecimal(box3.Text);
                dis += Convert.ToDecimal(box4.Text);
                qty += Convert.ToDecimal(box5.Text);
                total += Convert.ToDecimal(box6.Text);
            }
            TextBox box1T = (TextBox)Gridview1.FooterRow.FindControl("txtSPriceT");
            TextBox box2T = (TextBox)Gridview1.FooterRow.FindControl("txtDisPreT");
            TextBox box3T = (TextBox)Gridview1.FooterRow.FindControl("txtDisT");
            TextBox box4T = (TextBox)Gridview1.FooterRow.FindControl("txtQutT");
            TextBox box5T = (TextBox)Gridview1.FooterRow.FindControl("txtTotalT");
            box1T.Text = saleprice.ToString("0.00");
            box2T.Text = disPre.ToString("0.00");
            box3T.Text = dis.ToString("0.00");
            box4T.Text = qty.ToString("0.00");
            box5T.Text = total.ToString("0.00");

            return total;

        }
        protected void txtDicPre_TextChanged1(object sender, EventArgs e)
        {
            double dic;
            double salePricesubtotal = Convert.ToDouble(txtSPSubTotal.Text);
            double dicPre = Convert.ToDouble(txtDicPre.Text);
            double tax;
            dic = (salePricesubtotal * dicPre) / 100;
            tax = (salePricesubtotal - dic) * .125;
            txtDic.Text = Convert.ToString(dic);
            txtTax.Text = Convert.ToString(tax);
            upForm.Update();
            txtTax.Focus();
        }
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
            txtSPSubTotal.Text = string.Empty;
            Gridview1.DataSource = null;
            Gridview1.DataBind();
            SetInitialRow();
            ViewState["CurrentTable"] = null;
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

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("VendorInfo.aspx?page=" + "SaleOrder.aspx");
        }
        protected void lbtnClose_Click(object sender, EventArgs e)
        {
            this.mpopVendor.Hide();
        }
        protected void dgvVendorInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            hfVendor.Value = dgvVendorInfo.Rows[e.RowIndex].Cells[0].Text;
            txtVendor.Text = dgvVendorInfo.Rows[e.RowIndex].Cells[1].Text;
            txtAddress.Text = dgvVendorInfo.Rows[e.RowIndex].Cells[2].Text;
            txtCountry.Text = dgvVendorInfo.Rows[e.RowIndex].Cells[3].Text;
            txtState.Text = dgvVendorInfo.Rows[e.RowIndex].Cells[4].Text;
            txtCity.Text = dgvVendorInfo.Rows[e.RowIndex].Cells[5].Text;
            txtPin.Text = dgvVendorInfo.Rows[e.RowIndex].Cells[6].Text;
            txtMobile.Text = dgvVendorInfo.Rows[e.RowIndex].Cells[7].Text;
            txtEmail.Text = dgvVendorInfo.Rows[e.RowIndex].Cells[8].Text;
            this.mpopVendor.Hide();
            upForm.Update();
        }
        protected void ibtnCloseSummary_Click(object sender, EventArgs e)
        {
            this.mpopSummary.Hide();
        }
        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            this.mpopSummary.Hide();
        }
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        public string insertSalesOrder(string cpsubtotal, string spsubtotal,string dicpre, string dic, string tax, string shc, string misccost, string ttotal)
        {
            oblSalesOrder = new Store.SalesOrder.BusinessLogic.SalesOrder();
            //oblPurchaseOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();
            objMessageInfo = new MessageInfo();
            objSalesOrder = new Store.SalesOrder.BusinessObject.SalesOrder();
            //objPurchaseOrder = new Store.PurchaseOrder.BusinessObject.PurchaseOrder();
            if (cmdMode == Store.Common.CommandMode.M)
            {
                objSalesOrder.SalesOrderID = Convert.ToInt32(hfPId.Value);
               // objPurchaseOrder.PurchaseOrderID = Convert.ToInt32(hfPId.Value);//PurchaseOrderID which edit from data grid
            }
            else
            {
                objSalesOrder.SalesOrderID = 0;
                //objPurchaseOrder.PurchaseOrderID = 0;
            }
            objSalesOrder.SalesOrderID = 0;
            objSalesOrder.VendorID = Convert.ToInt32(hfVendor.Value);
            objSalesOrder.TotalCostAmount = Convert.ToDecimal(cpsubtotal);
            objSalesOrder.TotalSaleAmount = Convert.ToDecimal(spsubtotal);
            objSalesOrder.TotalTaxValue = Convert.ToDecimal(tax);
            objSalesOrder.ShipingAndHandlingCost = Convert.ToDecimal(shc);
            objSalesOrder.MiscSaleAmount = Convert.ToDecimal(misccost);
            objSalesOrder.DiscountPer = Convert.ToDecimal(dicpre);
            objSalesOrder.Discount = Convert.ToDecimal(dic);
            objSalesOrder.IsActive = 1;
            objMessageInfo = oblSalesOrder.ManageSaleOrder(objSalesOrder,cmdMode);

            return objMessageInfo.TranID.ToString();
        }
        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                string transid = "";
                transid = insertSalesOrder(txtCPSubTotal.Text, txtSPSubTotal.Text, txtDicPre.Text, txtDic.Text, txtTax.Text, txtSHC.Text, txtMiscCost.Text, txttotal.Text);
                objSalesOrderItemList = new Store.SalesOrderItem.BusinessObject.SalesOrderItemList();
                for (int i = 0; i < Gridview1.Rows.Count - 1; i++)
                {
                    objsalesOrderItem = new Store.SalesOrderItem.BusinessObject.SalesOrderItem();
                   TextBox txtItemNames = (TextBox)Gridview1.Rows[i].FindControl("txtItemName");
                    if (txtItemNames.Text == "")
                        break;
                    TextBox txtDecs = (TextBox)Gridview1.Rows[i].FindControl("txtDec");
                    TextBox txtCPrices = (TextBox)Gridview1.Rows[i].FindControl("txtCPrice");
                    TextBox txtSPrices = (TextBox)Gridview1.Rows[i].FindControl("txtSPrice");
                    TextBox txtDisPres = (TextBox)Gridview1.Rows[i].FindControl("txtDisPre");
                    TextBox txtDiss = (TextBox)Gridview1.Rows[i].FindControl("txtDis");
                    TextBox txtQuts = (TextBox)Gridview1.Rows[i].FindControl("txtQut");
                    TextBox txtTotals = (TextBox)Gridview1.Rows[i].FindControl("txtTotal");
                    objsalesOrderItem.ItemPrefix = txtItemNames.Text;
                    objsalesOrderItem.Description = txtDecs.Text;
                    objsalesOrderItem.ItemCostPrice= Convert.ToDecimal(txtCPrices.Text);
                    objsalesOrderItem.ItemSalePrice = Convert.ToDecimal(txtSPrices.Text);
                    objsalesOrderItem.ItemDiscountPercentage = Convert.ToDecimal(txtDisPres.Text);
                    objsalesOrderItem.ItemDiscount = Convert.ToDecimal(txtDiss.Text);
                    objsalesOrderItem.ItemUnit = txtQuts.Text;
                    objsalesOrderItem.TotalPrice = Convert.ToDecimal(txtTotals.Text);
                    objsalesOrderItem.SalesOrderID = Convert.ToInt32(transid);
                    objSalesOrderItemList.Add(objsalesOrderItem);
                }

                oblSalesOrderItem=new Store.SalesOrderItem.BusinessLogic.SalesOrderItem();
                objMessageInfo =oblSalesOrderItem.ManageItemMaster(objsalesOrderItem, cmdMode);
                reset();
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}