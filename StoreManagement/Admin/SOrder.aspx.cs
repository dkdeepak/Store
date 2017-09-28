using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Store.Common;


namespace StoreManagement.Admin
{
    public partial class SOrder : System.Web.UI.Page
    {
      

        Store.SalesOrderItem.BusinessLogic.SalesOrderItem oblSalesOrderItem = null;
        Store.SalesOrder.BusinessLogic.SalesOrder oblSalesOrder = new Store.SalesOrder.BusinessLogic.SalesOrder();
        Store.SalesOrder.BusinessObject.SalesOrderList objSalesList = new Store.SalesOrder.BusinessObject.SalesOrderList();
        Store.SalesOrder.BusinessObject.SalesOrder objSalesOrder = null;
        Store.SalesOrderItem.BusinessObject.SalesOrderItem objsalesOrderItem = null;
        Store.SalesOrder.BusinessObject.SalesOrder objSalesOrderList = null;
        Store.SalesOrderItem.BusinessObject.SalesOrderItemList objSalesOrderItemList = null;     
       
       

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

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dr["Column4"] = string.Empty;
            dr["Column5"] = string.Empty;
            dr["Column6"] = string.Empty;
            dr["Column7"] = string.Empty;
            dt.Rows.Add(dr);

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
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDis");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCostAmount");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtSaleAmount");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txtDisPer");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txtDisAmt");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txtQut");

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
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtDis");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txtCostAmount");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txtSaleAmount");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txtDisPer");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txtDisAmt");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txtQut");

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
        //static int  i ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //hfpo.Value =Convert.ToString(i);
                //i = Convert.ToInt32( hfpo.Value);
                SetInitialRow();
                //BindSalesOrder();
            }
        }
        #endregion
        #region Event
        #region gridevent
        protected void txtItemName_TextChanged(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(((TextBox)sender).Attributes["Rowid"].ToString());
            TextBox name = (TextBox)Gridview1.Rows[rows].FindControl("txtItemName");
            TextBox dec = (TextBox)Gridview1.Rows[rows].FindControl("txtDis");
            TextBox priceS = (TextBox)Gridview1.Rows[rows].FindControl("txtSaleAmount");
            TextBox dicPre = (TextBox)Gridview1.Rows[rows].FindControl("txtDisPer");
            TextBox disAmt = (TextBox)Gridview1.Rows[rows].FindControl("txtDisAmt");
            TextBox priceC = (TextBox)Gridview1.Rows[rows].FindControl("txtCostAmount");
            TextBox qut = (TextBox)Gridview1.Rows[rows].FindControl("txtQut");

            string item = name.Text;
            Store.Item.BusinessObject.Item objItem = new Store.Item.BusinessObject.Item();
            Store.Item.BusinessLogic.Item oblItem = new Store.Item.BusinessLogic.Item();
            objItem = oblItem.GetAllItem(item, 0, "");

            dec.Text = objItem.ItemDescription;

            Store.ItemPrice.BusinessObject.ItemPrice objItemPrice = new Store.ItemPrice.BusinessObject.ItemPrice();
            Store.ItemPrice.BusinessLogic.ItemPrice oblItemPrice = new Store.ItemPrice.BusinessLogic.ItemPrice();
            objItemPrice = oblItemPrice.GetAllItemPrice(0, 0, "");
            //Cost price and sale price will come from itemPrice table
            priceC.Text = Convert.ToString(objItemPrice.ItemCostPricePerUnit);
            priceS.Text = Convert.ToString(objItemPrice.ItemSalePricePerUnit);
            dicPre.Text = Convert.ToString(objItemPrice.ItemDiscountPercentagePerUnit);
            disAmt.Text = Convert.ToString((Convert.ToDouble(priceS.Text) * Convert.ToDouble(dicPre.Text)) / 100);
            qut.Focus();
        }
        protected void txtQut_TextChanged(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(((TextBox)sender).Attributes["Rowid"].ToString());
            TextBox price = (TextBox)Gridview1.Rows[rows].FindControl("txtSaleAmount");
            TextBox dic = (TextBox)Gridview1.Rows[rows].FindControl("txtDisAmt");
            TextBox qut = (TextBox)Gridview1.Rows[rows].FindControl("txtQut");
            double pri = Convert.ToDouble(price.Text) - Convert.ToDouble(dic.Text);

            txtPriceCT.Text = Convert.ToString(findCostTotal());
            txtPriceST.Text = Convert.ToString(findSaleTotal());
            txtDisT.Text = Convert.ToString(findDicTotal());
           
            
            up1.Update();
            AddNewRowToGrid();
            price.Focus();

        }
        #endregion
        double findCostTotal()
        {

            double ttl = 0;
            for (int i = 0; i < Gridview1.Rows.Count; i++)
            {
                TextBox box3 = (TextBox)Gridview1.Rows[i].FindControl("txtCostAmount");
                ttl += Convert.ToDouble(box3.Text);
            }
            return (ttl);

        }
        double findSaleTotal()
        {

            double ttl = 0;
            for (int i = 0; i < Gridview1.Rows.Count; i++)
            {
                TextBox box4 = (TextBox)Gridview1.Rows[i].FindControl("txtSaleAmount");
                ttl += Convert.ToDouble(box4.Text);
            }
            return (ttl);

        }
        double findDicTotal()
        {
            double ttl = 0;

            for (int i = 0; i < Gridview1.Rows.Count; i++)
            {
                TextBox box6 = (TextBox)Gridview1.Rows[i].FindControl("txtDisAmt");
                ttl += Convert.ToDouble(box6.Text);
            }
            return (ttl);

        }
       
      



        #endregion
        #region webmethod
        public  string insertOrder(string totalc, string totals, string totald, string tax, string shc, string misccost)
        {
            Store.SalesOrder.BusinessLogic.SalesOrder oblSalesOrder = new Store.SalesOrder.BusinessLogic.SalesOrder();
            Store.Common.MessageInfo objMessageInfo = new MessageInfo();
            Store.SalesOrder.BusinessObject.SalesOrder objSalesOrder = new Store.SalesOrder.BusinessObject.SalesOrder();
            objSalesOrder.SalesOrderID = 0;
            objSalesOrder.VendorID = 0;
            //objSalesOrder.SaleDate=
            objSalesOrder.TotalCostAmount = Convert.ToDecimal(totalc);
            objSalesOrder.TotalSaleAmount = Convert.ToDecimal(totals);
            objSalesOrder.TotalDiscountAmount = Convert.ToDecimal(totald);
            objSalesOrder.TotalTaxValue = Convert.ToDecimal(tax);
            objSalesOrder.ShipingAndHandlingCost = Convert.ToDecimal(shc);
            objSalesOrder.MiscSaleAmount = Convert.ToDecimal(misccost);
           // objMessageInfo = oblSalesOrder.ManageSaleOrder(objSalesOrder,cmdMode);
            return objMessageInfo.TranID.ToString();
        }

        public  string insertItem(string name, string description, string pricec, string prices, string discountper, string discount, string quantity, string transId)
        {
            Store.SalesOrderItem.BusinessLogic.SalesOrderItem oblSalesOrderItem = new Store.SalesOrderItem.BusinessLogic.SalesOrderItem();
            Store.SalesOrderItem.BusinessObject.SalesOrderItem objSalesOrderItem = new Store.SalesOrderItem.BusinessObject.SalesOrderItem();
            Store.SalesOrder.BusinessLogic.SalesOrder oblSalesOrder = new Store.SalesOrder.BusinessLogic.SalesOrder();
            Store.Common.MessageInfo objMessageInfo = new MessageInfo();
            objSalesOrderItem.SaleOrderItemID = 0;
            objSalesOrderItem.SalesOrderID = Convert.ToInt32(transId);
            objSalesOrderItem.ItemPrefix = name;           
            objSalesOrderItem.Description = description;
             objSalesOrderItem.ItemCostPrice = Convert.ToDecimal(pricec);
            objSalesOrderItem.ItemSalePrice = Convert.ToDecimal(prices);
            objSalesOrderItem.ItemDiscountPercentage = Convert.ToDecimal(discountper);
            objSalesOrderItem.ItemDiscount = Convert.ToDecimal(discount);
            objSalesOrderItem.ItemUnit = quantity;
            //objMessageInfo = oblSalesOrder.ManageSaleOrderItem(objSalesOrderItem, cmdMode);


            return "";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string trancId = "";
            trancId = insertOrder(txtPriceCT.Text, txtPriceST.Text, txtDisT.Text, txtTax.Text, txtSHC.Text, txtMiscCost.Text);
            for (int i = 0; i < Gridview1.Rows.Count-1; i++)
            {


                TextBox txtItemName = (TextBox)Gridview1.Rows[i].FindControl("txtItemName");
                TextBox txtDis = (TextBox)Gridview1.Rows[i].FindControl("txtDis");
                TextBox txtCostAmount = (TextBox)Gridview1.Rows[i].FindControl("txtCostAmount");
                TextBox txtSaleAmount = (TextBox)Gridview1.Rows[i].FindControl("txtSaleAmount");
                TextBox txtDisPer = (TextBox)Gridview1.Rows[i].FindControl("txtDisPer");
                TextBox txtDisAmt = (TextBox)Gridview1.Rows[i].FindControl("txtDisAmt");
                TextBox txtQut = (TextBox)Gridview1.Rows[i].FindControl("txtQut");

                insertItem(txtItemName.Text, txtDis.Text, txtCostAmount.Text, txtSaleAmount.Text, txtDisPer.Text, txtDisAmt.Text, txtQut.Text, trancId);

            }



        }
        private void reset()
        {
            Gridview1.DataSource = null;
            Gridview1.DataBind();
            txtDisT.Text = string.Empty;
            txtMiscCost.Text = string.Empty;
            txtPriceCT.Text = string.Empty;
            txtPriceST.Text = string.Empty;
            txtSHC.Text = string.Empty;
            txtTax.Text = string.Empty;
            SetInitialRow();
            ViewState["CurrentTable"] = null;
        }
        #endregion



       protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
       {
           if (e.Row.RowType == DataControlRowType.DataRow)
           {
               TextBox txtItemName = (TextBox)e.Row.FindControl("txtItemName");
               TextBox txtQut = (TextBox)e.Row.FindControl("txtQut");
               txtItemName.Attributes.Add("RowId",e.Row.RowIndex.ToString());
               txtQut.Attributes.Add("RowId", e.Row.RowIndex.ToString());
           }
       }

        //protected void gvSOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        int sid = Convert.ToInt32(gvSOrder.DataKeys[e.Row.RowIndex].Value.ToString());
        //        GridView gv = (GridView)e.Row.FindControl("gvSOrderItem");
        //        //gv.DataSource = BindPurchaseOrderItem(pid);
        //        gv.DataSource = BindSalesOrderItem(sid);
        //        gv.DataBind();
        //    }
        //}
        //void BindSalesOrder()
        //{
        //    oblSalesOrder = new Store.SalesOrder.BusinessLogic.SalesOrder();


        //    try
        //    {
        //        objSalesList = oblSalesOrder.GetAllSalesOrderList(0,0,"");

        //        if (objSalesList != null)
        //        {
        //            gvSOrder.DataSource = objSalesList;
        //            gvSOrder.DataBind();

        //        }
        //        else
        //        {
        //            gvSOrder.DataSource = null;
        //            gvSOrder.DataBind();


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //       oblSalesOrder = null;
        //      objSalesOrderList = null;
        //    }


        //}

        //protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        //{ }
        //protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        //{ }

        //Store.SalesOrderItem.BusinessObject.SalesOrderItemList BindSalesOrderItem(int id)
        //{
        //    oblSalesOrderItem = new Store.SalesOrderItem.BusinessLogic.SalesOrderItem();
        //    try
        //    {
        //        objSalesOrderItemList = oblSalesOrderItem.GetAllSalesOrderItemList(id, 0, "");
        //        return objSalesOrderItemList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        oblSalesOrderItem = null;
        //        objSalesOrderItemList = null;
        //    }
        //}

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }


    }
}


