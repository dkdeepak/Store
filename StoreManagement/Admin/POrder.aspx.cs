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
        Store.PurchaseOrder.BusinessObject.PurchaseOrderList objPurchaseOrderList = null;
        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList objPurchaseOrderItemList = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetInitialRow();
                BindPurchaseOrder();

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
                    com.CommandText = "select ItemPrefix,ItemID from tbl_mItem where " + "ItemPrefix like @Search + '%' or ItemCode like @Search + '%'";

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
            TextBox price = (TextBox)Gridview1.Rows[rows].Cells[3].FindControl("txtPrice");
            TextBox dicpre = (TextBox)Gridview1.Rows[rows].Cells[4].FindControl("txtDisPre");
            TextBox dic = (TextBox)Gridview1.Rows[rows].Cells[5].FindControl("txtDis");
            dic.Text = Convert.ToString(((Convert.ToDouble(price.Text)) * (Convert.ToDouble(dicpre.Text))) / 100);
            dic.Focus();
        }
        protected void txtQut_TextChanged(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(((TextBox)sender).Attributes["RowId"].ToString());
            TextBox price = (TextBox)Gridview1.Rows[rows].Cells[3].FindControl("txtPrice");
            TextBox dic = (TextBox)Gridview1.Rows[rows].Cells[5].FindControl("txtDis");
            TextBox qut = (TextBox)Gridview1.Rows[rows].Cells[6].FindControl("txtQut");
            TextBox ttl = (TextBox)Gridview1.Rows[rows].Cells[7].FindControl("txtTotal");
            double pri = Convert.ToDouble(price.Text) - Convert.ToDouble(dic.Text);

            double total = pri * Convert.ToInt32(qut.Text);
            ttl.Text = Convert.ToString(total);
            txtSubTotal.Text = Convert.ToString(findSubTotal());
            up1.Update();
            AddNewRowToGrid();
            ttl.Focus();

        }
        #endregion

        double findSubTotal()
        {

            double ttl = 0;

            for (int i = 0; i < Gridview1.Rows.Count; i++)
            {
                TextBox box5 = (TextBox)Gridview1.Rows[i].Cells[7].FindControl("txtTotal");
                ttl += Convert.ToDouble(box5.Text);
            }
            return (ttl);

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
            up1.Update();
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
            up1.Update();
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
        //static int  i ;

        #endregion
        #region method
        public string insertOrder(string subtotal, string dicpre, string dic, string tax, string shc, string misccost, string ttotal)
        {

            oblPurchaseOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();
            objMessageInfo = new MessageInfo();
            objPurchaseOrder = new Store.PurchaseOrder.BusinessObject.PurchaseOrder();
            if (cmdMode == Store.Common.CommandMode.M)
            {
                objPurchaseOrder.PurchaseOrderID = 1;//PurchaseOrderID which edit from data grid

            }
            else
            {
                objPurchaseOrder.PurchaseOrderID = 0;
            }
            objPurchaseOrder.PurchaseOrderID = 0;
            objPurchaseOrder.VendorID = 0;
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
        public string insertItem(string name, string description, string unitprice, string discountper, string discount, string quantity, string total, string transId)
        {
            objPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem();
            objMessageInfo = new MessageInfo();
            oblPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem();
            if (cmdMode == Store.Common.CommandMode.M)
            {
                objPurchaseOrderItem.PurchaseOrderID = 1;//PurchaseOrderID which edit from data grid

            }
            else
            {
                objPurchaseOrderItem.PurchaseOrderItemID = 0;
            }
            objPurchaseOrderItem.PurchaseOrderItemID = 0;
            objPurchaseOrderItem.PurchaseOrderID = Convert.ToInt32(transId);
            objPurchaseOrderItem.ItemID = 0;
            objPurchaseOrderItem.ItemPrefix = name;
            objPurchaseOrderItem.ItemUnit = quantity;
            objPurchaseOrderItem.Description = description;
            objPurchaseOrderItem.ItemPrice = Convert.ToDecimal(unitprice);
            objPurchaseOrderItem.TotalPrice = Convert.ToDecimal(total);
            objPurchaseOrderItem.DiscountPre = Convert.ToDecimal(discountper);
            objPurchaseOrderItem.Discount = Convert.ToDecimal(discount);
            objPurchaseOrderItem.IsActive = 1;
            objMessageInfo = oblPurchaseOrderItem.ManageItemMaster(objPurchaseOrderItem, cmdMode);
            return "";
        }
        #endregion
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string transid = "";
                transid = insertOrder(txtSubTotal.Text, txtDicPre.Text, txtDic.Text, txtTax.Text, txtSHC.Text, txtMiscCost.Text, txttotal.Text);
                for (int i = 0; i < Gridview1.Rows.Count - 1; i++)
                {
                    TextBox txtItemNames = (TextBox)Gridview1.Rows[i].FindControl("txtItemName");
                    TextBox txtDecs = (TextBox)Gridview1.Rows[i].FindControl("txtDec");
                    TextBox txtPrices = (TextBox)Gridview1.Rows[i].FindControl("txtPrice");
                    TextBox txtDisPres = (TextBox)Gridview1.Rows[i].FindControl("txtDisPre");
                    TextBox txtDiss = (TextBox)Gridview1.Rows[i].FindControl("txtDis");
                    TextBox txtQuts = (TextBox)Gridview1.Rows[i].FindControl("txtQut");
                    TextBox txtTotals = (TextBox)Gridview1.Rows[i].FindControl("txtTotal");
                    insertItem(txtItemNames.Text, txtDecs.Text, txtPrices.Text, txtDisPres.Text, txtDiss.Text, txtQuts.Text, txtTotals.Text, transid);
                }
                reset();
            }
            catch (Exception ex)
            { throw ex; }
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
        void BindPurchaseOrder()
        {
            oblPurchaseOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();

            try
            {
                objPurchaseOrderList = oblPurchaseOrder.GetAllPurchaseOrderList(0, 0, "");
                if (objPurchaseOrderList != null)
                {
                    gvPOrder.DataSource = objPurchaseOrderList;
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
                throw ex;
            }
            finally
            {
                oblPurchaseOrder = null;
                objPurchaseOrderList = null;
            }

        }










        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList BindPurchaseOrderItem(int id)
        {
            oblPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem();

            try
            {
                objPurchaseOrderItemList = oblPurchaseOrderItem.GetAllPurchaseOrderItemList(id, 0, "");
                return objPurchaseOrderItemList;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

                oblPurchaseOrderItem = null;
                objPurchaseOrderItemList = null;
            }


        }


        protected void imgbtnfrView_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            GridView gv = (GridView)gvPOrder.Rows[gvrow.RowIndex].FindControl("gvPoItem");
            if (gv.Visible == false)
                gv.Visible = true;
            else
                gv.Visible = false;

        }


        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            reset();
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            objPurchaseOrder.PurchaseOrderID = Convert.ToInt32(gvPOrder.DataKeys[gvrow.RowIndex].Value.ToString());
            //edit logic
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objPurchaseOrder.PurchaseOrderID = Convert.ToInt32(gvPOrder.DataKeys[gvrow.RowIndex].Value.ToString());
                //delete logic
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                objMessageInfo = null;

            }
        }

        protected void gvPOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int pid=Convert.ToInt32(gvPOrder.DataKeys[e.Row.RowIndex].Value.ToString());
                GridView gv = (GridView)e.Row.FindControl("gvPoItem");
                gv.DataSource = BindPurchaseOrderItem(pid);
                gv.DataBind();
            }
        }
    }




    }

