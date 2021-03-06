﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StoreManagement.Admin
{
    public partial class poerder3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                if (!Page.IsPostBack)
                {
                  //  BindCategory();
                }
            }
            else {
                Response.Redirect("../Login.aspx");
            }
        }
        
       
        protected void linkButton_Click(object sender, EventArgs e)
        {
            SetInitialRow();
            updateCategoryBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }
      
        

        protected void btnCancel_Click(object sender, EventArgs e)
        {
           
            this.ModalPopupExtender1.Hide();

        }
        protected void lbtnClose_Click(object sender, EventArgs e)
        {
         
            this.ModalPopupExtender1.Hide();
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
            //txtSubTotal.Text = Convert.ToString(findSubTotal());
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
        //protected void txtDicPre_TextChanged1(object sender, EventArgs e)
        //{
        //    double dic;
        //    double subtotal = Convert.ToDouble(txtSubTotal.Text);
        //    double dicPre = Convert.ToDouble(txtDicPre.Text);
        //    double tax;
        //    dic = (subtotal * dicPre) / 100;
        //    tax = (subtotal - dic) * .125;
        //    txtDic.Text = Convert.ToString(dic);
        //    txtTax.Text = Convert.ToString(tax);
        //    txtTax.Focus();
        //    upTotal.Update();

        //}

        //protected void txtMiscCost_TextChanged(object sender, EventArgs e)
        //{
        //    double subtotal = Convert.ToDouble(txtSubTotal.Text);
        //    double tax = Convert.ToDouble(txtTax.Text);
        //    double dic = Convert.ToDouble(txtDic.Text);
        //    double shc = Convert.ToDouble(txtSHC.Text);
        //    double miss = Convert.ToDouble(txtMiscCost.Text);
        //    double total;
        //    total = subtotal + tax - dic + shc + miss;
        //    txttotal.Text = Convert.ToString(total);
        //    txttotal.Focus();
        //    upTotal.Update();
        //}
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

    }
}