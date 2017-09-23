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

namespace StoreManagement.Admin
{
    public partial class SalesRtn : System.Web.UI.Page
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
        //#region grid
        //private void SetInitialRow()
        //{
        //    DataTable dt = new DataTable();
        //    DataRow dr = null;
        //    dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Column3", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Column4", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Column5", typeof(string)));
        //    dr = dt.NewRow();
        //    dr["RowNumber"] = 1;
        //    dr["Column1"] = string.Empty;
        //    dr["Column2"] = string.Empty;
        //    dr["Column3"] = string.Empty;
        //    dr["Column4"] = string.Empty;
        //    dr["Column5"] = string.Empty;
        //    dt.Rows.Add(dr);

        //    //Store the DataTable in ViewState
        //    ViewState["CurrentTable"] = dt;

        //    Gridview1.DataSource = dt;
        //    Gridview1.DataBind();
        //}
        //private void AddNewRowToGrid()
        //{
        //    int rowIndex = 0;

        //    if (ViewState["CurrentTable"] != null)
        //    {
        //        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        //        DataRow drCurrentRow = null;
        //        if (dtCurrentTable.Rows.Count > 0)
        //        {
        //            for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
        //            {
        //                //extract the TextBox values
        //                TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txtItemName");
        //                TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDec");
        //                TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtPrice");
        //                TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtQut");
        //                TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txttotal");
        //                drCurrentRow = dtCurrentTable.NewRow();
        //                drCurrentRow["RowNumber"] = i + 1;

        //                dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
        //                dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
        //                dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
        //                dtCurrentTable.Rows[i - 1]["Column4"] = box4.Text;
        //                dtCurrentTable.Rows[i - 1]["Column5"] = box5.Text;
        //                rowIndex++;
        //            }
        //            dtCurrentTable.Rows.Add(drCurrentRow);
        //            ViewState["CurrentTable"] = dtCurrentTable;

        //            Gridview1.DataSource = dtCurrentTable;
        //            Gridview1.DataBind();
        //        }
        //    }
        //    else
        //    {
        //        Response.Write("ViewState is null");
        //    }

        //    //Set Previous Data on Postbacks
        //    SetPreviousData();
        //}
        //private void SetPreviousData()
        //{
        //    int rowIndex = 0;
        //    if (ViewState["CurrentTable"] != null)
        //    {
        //        DataTable dt = (DataTable)ViewState["CurrentTable"];
        //        if (dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txtItemName");
        //                TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDec");
        //                TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtPrice");
        //                TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtQut");
        //                TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txttotal");
        //                box1.Text = dt.Rows[i]["Column1"].ToString();
        //                box2.Text = dt.Rows[i]["Column2"].ToString();
        //                box3.Text = dt.Rows[i]["Column3"].ToString();
        //                box4.Text = dt.Rows[i]["Column4"].ToString();
        //                box5.Text = dt.Rows[i]["Column5"].ToString();

        //                rowIndex++;
        //            }
        //        }
        //    }
        //}

        //#endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                divForm.Style.Add("display", "none");
                divSerach.Style.Add("display", "block");
                up1.Update();
              //  SetInitialRow();
                //BindSalesReturn();
            }
        }
        #region Event

        #region gridevent
        protected void txtItemName_TextChanged(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(((TextBox)sender).Attributes["RowId"].ToString());
            TextBox name = (TextBox)Gridview1.Rows[rows].Cells[1].FindControl("txtItemName");
            TextBox dec = (TextBox)Gridview1.Rows[rows].Cells[2].FindControl("txtDec");
            TextBox price = (TextBox)Gridview1.Rows[rows].Cells[3].FindControl("txtPrice");
            string item = name.Text;
            Store.Item.BusinessObject.Item objItem = new Store.Item.BusinessObject.Item();
            oblItem = new Store.Item.BusinessLogic.Item();
            objItem = oblItem.GetAllItem(item, 0, "");

            dec.Text = objItem.ItemDescription;
            //sale price will come from itemPrice table.
            //price.Text = Convert.ToString(objItem.ItemSalePricePerUnit);
        }
        protected void txtQut_TextChanged(object sender, EventArgs e)
        {
            int rows=Convert.ToInt32(((TextBox)sender).Attributes["RowId"].ToString());
            TextBox price = (TextBox)Gridview1.Rows[rows].Cells[3].FindControl("txtPrice");
            TextBox qnt = (TextBox)Gridview1.Rows[rows].Cells[4].FindControl("txtQut");
            TextBox total = (TextBox)Gridview1.Rows[rows].Cells[5].FindControl("txtTotal");
            total.Text = Convert.ToString(Convert.ToDecimal(price.Text) * Convert.ToInt32(qnt.Text));
            txtSubTotal.Text = Convert.ToString(findsubtotal());
        }
        #endregion
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
        #endregion
        #region webmethod
        public  string insertOrder(string tax, string shc, string misccost, string ttotal)
        {
            Store.SalesReturned.BusinessObject.SalesReturned objSalesReturned = new Store.SalesReturned.BusinessObject.SalesReturned();
            Store.SalesReturned.BusinessLogic.SalesReturned oblSalesReturned = new Store.SalesReturned.BusinessLogic.SalesReturned();
            //Store.PurchaseReceived.BusinessLogic.PurchaseReceived oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
            Store.Common.MessageInfo objMessageInfo = new MessageInfo();
            //Store.PurchaseReceived.BusinessObject.PurchaseReceived objPurchaseReceived = new Store.PurchaseReceived.BusinessObject.PurchaseReceived();
            objSalesReturned.SalesReturnedID = 0;
            objSalesReturned.SalesOrderID = Convert.ToInt32(txtPoId.Text);
            objSalesReturned.TotalSalesReturnAmount = Convert.ToDecimal(ttotal);
            objSalesReturned.VendorID = 0;
            objSalesReturned.TaxValue = Convert.ToDecimal(tax);
            objSalesReturned.ShippingAndHandlingCost = Convert.ToDecimal(shc);
            objSalesReturned.MiscCost = Convert.ToDecimal(misccost);
          //  objMessageInfo = oblSalesReturned.ManageSalesRetuned(objSalesReturned,cmdMode);
            //objMessageInfo = oblPurchaseReceived.ManagePurchaseReceived(objPurchaseReceived, 1);

            return objMessageInfo.TranID.ToString();
        }

        public  string insertItem(string name, string description, string unitprice, string quantity,string tranID)
        {
            Store.SalesReturned.BusinessLogic.SalesReturned oblSaleReturnItem = new Store.SalesReturned.BusinessLogic.SalesReturned();
            Store.SaleReturnItem.BusinessObject.SaleReturnItem objSaleReturnItem = new Store.SaleReturnItem.BusinessObject.SaleReturnItem();

            //Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem objPurchaseReceivedItem = new Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem();
            Store.Common.MessageInfo objMessageInfo = new MessageInfo();
            //Store.PurchaseReceived.BusinessLogic.PurchaseReceived oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
            objSaleReturnItem.SaleReturnItemID = 0;
            objSaleReturnItem.SalesOrderID = Convert.ToInt32(txtPoId.Text);
            objSaleReturnItem.SalesReturnID =Convert.ToInt32(tranID);
            objSaleReturnItem.ItemPrefix = name;
            objSaleReturnItem.ItemUnit = quantity;
            objSaleReturnItem.Description = description;
            objSaleReturnItem.ItemPrice = Convert.ToDecimal(unitprice);
            objMessageInfo = oblSaleReturnItem.ManageSalesRetunedItem(objSaleReturnItem, 1);

            //objPurchaseOrder = new Store.PurchaseOrder.BusinessObject.PurchaseOrder();

            return "";
        }

        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string trancId = "";
            trancId=insertOrder(txtTax.Text, txtSHC.Text, "0",txtSubTotal.Text);
            for (int i = 0; i < Gridview1.Rows.Count; i++)
            {
                TextBox txtItemName = (TextBox)Gridview1.Rows[i].FindControl("txtItemName");
                TextBox txtDec = (TextBox)Gridview1.Rows[i].FindControl("txtDec");
                TextBox txtPrice = (TextBox)Gridview1.Rows[i].FindControl("txtPrice");
                TextBox txtQut = (TextBox)Gridview1.Rows[i].FindControl("txtQut");
                TextBox txtTotal = (TextBox)Gridview1.Rows[i].FindControl("txtTotal");


                insertItem(txtItemName.Text, txtDec.Text, txtPrice.Text, txtQut.Text, trancId);

            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtPoId.Text);
                bindSales(id);
                bindSalesItem(id);
                txtSubTotal.Text = findsubtotal().ToString();
                up1.Update();
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
        void bindSales(int id)
        {
            oblSales = new Store.SalesOrder.BusinessLogic.SalesOrder();

            try
            {
                objSales = oblSales.GetAllSalesOrder(id, 0, "");
                if (objSales != null)
                {
                    txtSubTotal.Text = objSales.TotalSaleAmount.ToString();
                    txtTax.Text = objSales.TotalTaxValue.ToString();
                    txtSHC.Text = objSales.ShipingAndHandlingCost.ToString();
                    txtMiscCost.Text = objSales.MiscSaleAmount.ToString();

                    
                }
                else
                {
                   txtSubTotal.Text = "";
                   txtTax.Text = "";
                   txtSHC.Text = "";
                }  txtMiscCost.Text = "";
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblSales = null;
                objSales = null;
            }
        }
        void bindSalesItem(int id)
        {
            oblSalesItem = new Store.SalesOrderItem.BusinessLogic.SalesOrderItem();

            try
            {
                objSalesItemList = oblSalesItem.GetAllSalesOrderItemList(id, 0, "");

                if (objSalesItemList != null)
                {
                    Gridview1.DataSource = objSalesItemList;
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
                objSalesItemList = null;
            }
        }

        protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TextBox txtQut = (TextBox)e.Row.FindControl("txtQut");
                TextBox txtPrice = (TextBox)e.Row.FindControl("txtPrice");
                TextBox txtTotal = (TextBox)e.Row.FindControl("txtTotal");
                decimal qty = Convert.ToDecimal(txtQut.Text);
                decimal price = Convert.ToDecimal(txtPrice.Text);
                decimal total = qty * price;
                txtTotal.Text = total.ToString();
                txtQut.Attributes.Add("RowId", e.Row.RowIndex.ToString());


            }
        }

        //    void BindSalesRtnItem(int id)
        //    {
        //        oblsalesRtnItem = new Store.SaleReturnItem.BusinessLogic.SaleReturnItem();


        //        try
        //        {
        //            objsalesRtnItemList = oblsalesRtnItem.GetAllSaleReturnItemList(id, 0, "");



        //            if (objsalesRtnItemList != null)
        //            {
        //                Gridview1.DataSource = objsalesRtnItemList;
        //                Gridview1.DataBind();
        //            }
        //            else
        //            {
        //                Gridview1.DataSource = null;
        //                Gridview1.DataBind();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            oblsalesRtnItem = null;
        //            objsalesRtnItemList = null;
        //        }


        //    }
        //    private void BindSalesReturn()
        //    {

        //            try
        //            {
        //            oblSalesRtn = new Store.SalesReturned.BusinessLogic.SalesReturned();
        //            objsalesRtnList = new Store.SalesReturned.BusinessObject.SalesReturnedList();
        //            objsalesRtnList = oblSalesRtn.GetAllSalesReturnedList(0,0,"");



        //            if (objsalesRtnList != null)
        //            {
        //                gvSalesRtn.DataSource = objsalesRtnList;
        //                gvSalesRtn.DataBind();
        //            }
        //            else
        //            {
        //                gvSalesRtn.DataSource = null;
        //                gvSalesRtn.DataBind();


        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            oblSalesRtn = null;
        //            objsalesRtnList = null;
        //        }
        //    }
        //    protected void gvSalesRtn_RowDataBound(object sender, GridViewRowEventArgs e)
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            int SRtnId = Convert.ToInt32(gvSalesRtn.DataKeys[e.Row.RowIndex].Value.ToString());
        //            GridView gv = (GridView)e.Row.FindControl("gvSalesReturn");
        //            gv.DataSource = BindSalesReturnItem(SRtnId);
        //            gv.DataBind();
        //        }
        //    }
        //    Store.SaleReturnItem.BusinessObject.SaleReturnItemList BindSalesReturnItem(int id)

        //    {


        //        try
        //        {
        //            oblsalesRtnItem = new Store.SaleReturnItem.BusinessLogic.SaleReturnItem();
        //            objsalesRtnItemList = new Store.SaleReturnItem.BusinessObject.SaleReturnItemList();
        //            objsalesRtnItemList = oblsalesRtnItem.GetAllSaleReturnItemList(id, 0, "");                
        //            return objsalesRtnItemList;
        //        }
        //        catch (Exception ex)
        //        {
        //            //return null;
        //            throw ex;
        //        }
        //        finally
        //        {

        //            oblsalesRtnItem = null;
        //            objsalesRtnItemList = null;
        //        }


        //    }
        //    protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        //    {
        //    }

        //    protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        //    {

        //    }
        private void reset()
        {
            txtPoId.Text = string.Empty;
            txtMiscCost.Text = string.Empty;
            txtPoId.Text = string.Empty;
            txtSHC.Text = string.Empty;
            txtSubTotal.Text = string.Empty;
            txtTax.Text = string.Empty;
            Gridview1.DataSource = null;
            Gridview1.DataBind();
            hfPoderId.Value = string.Empty;
            divForm.Style.Add("display", "none");
            divSerach.Style.Add("display", "block");
            up1.Update();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }




    }
}