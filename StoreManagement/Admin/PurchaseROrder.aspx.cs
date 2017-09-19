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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                divForm.Style.Add("display", "none");
                divSerach.Style.Add("display", "block");
                up1.Update();
                //bindPRecived();
            }
        }
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        Store.PurchaseOrder.BusinessLogic.PurchaseOrder odlPOrder = null;
        Store.PurchaseOrder.BusinessObject.PurchaseOrder objPOrder = null;
        Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem oblPurchaseOrderItem = null;
        Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItemList objPurchaseOrderItemList = null;
        Store.PurchaseReceived.BusinessLogic.PurchaseReceived oblPurchaseReceived = null;
        Store.Common.MessageInfo objMessageInfo = null;
        Store.PurchaseReceived.BusinessObject.PurchaseReceived objPurchaseReceived = null;
        Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem objPurchaseReceivedItem = null;
        Store.PurchaseReceived.BusinessObject.PurchaseReceivedList objPurchaseReceivedList = null;
        Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItemList objPurchaseReceivedItemList = null;
        Store.PurchaseReceivedItem.BusinessLogic.PurchaseReceivedItem oblPurchaseReceivedItem = null;
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
            try
            {
                objPurchaseReceived = new Store.PurchaseReceived.BusinessObject.PurchaseReceived();
                objMessageInfo = new MessageInfo();
                oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
                objPurchaseReceived.PurchaseOrderID = Convert.ToInt32(txtPoId.Text);
                objPurchaseReceived.PurchaseReceivedID = 0;
                objPurchaseReceived.VendorID = 0;
                objPurchaseReceived.PurchaseAmount = Convert.ToDecimal(ttotal);
                objPurchaseReceived.TaxValue = Convert.ToDecimal(tax);
                objPurchaseReceived.ShipingAndHandlingCost = Convert.ToDecimal(shc);
                objPurchaseReceived.MiscCost = Convert.ToDecimal(misccost);
                objPurchaseReceived.IsActive = 1;
                //objMessageInfo = oblPurchaseReceived.ManagePurchaseReceived(objPurchaseReceived,1);by depk
                objMessageInfo = oblPurchaseReceived.ManagePurchaseReceived(objPurchaseReceived,cmdMode);

                return objMessageInfo.TranID.ToString();
            }
            catch { throw; }
            finally
            {
                objMessageInfo = null;
                objPurchaseReceived = null;
                oblPurchaseReceived = null;
            }
        }

        public string insertItem(string name, string description, string unitprice, string quantity, string transId)
        {
            try
            {
                objPurchaseReceivedItem = new Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItem();
                objMessageInfo = new MessageInfo();
                oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
                objPurchaseReceivedItem.PurchaseItemReceivedID = 0;
                objPurchaseReceivedItem.PurchaseOrderID = Convert.ToInt32(txtPoId.Text);
                objPurchaseReceivedItem.PurchaseReceivedID = Convert.ToInt32(transId);
                objPurchaseReceivedItem.ItemID = 0;
                objPurchaseReceivedItem.ItemPrefix = name;
                objPurchaseReceivedItem.ItemUnit = quantity;
                objPurchaseReceivedItem.Description = description;
                objPurchaseReceivedItem.ItemPrice = Convert.ToDecimal(unitprice);
                objPurchaseReceivedItem.IsActive = 1;
                objMessageInfo = oblPurchaseReceived.ManagePurchaseReceivedItem(objPurchaseReceivedItem, cmdMode);

                //objPurchaseOrder = new Store.PurchaseOrder.BusinessObject.PurchaseOrder();

                return "";
            }
            catch { throw; }
            finally
            {
                objPurchaseReceivedItem = null;
                oblPurchaseReceived = null;
                objMessageInfo = null;
            }
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
                throw ex;
            }
            finally
            {
                odlPOrder = null;
                objPOrder = null;
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
                throw ex;
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
            divForm.Style.Add("display", "none");
            divSerach.Style.Add("display", "block");
            up1.Update();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }
        //private void bindPRecived()
        //{
            
        //    try
        //    {
        //        oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
        //        objPurchaseReceivedList = new Store.PurchaseReceived.BusinessObject.PurchaseReceivedList();
        //        objPurchaseReceivedList = oblPurchaseReceived.GetAllPurchaseReceivedList(0,0, "");
        //        if (objPurchaseReceivedList != null)
        //        {
        //            gvPOrder.DataSource = objPurchaseReceivedList;
        //            gvPOrder.DataBind();
        //        }
        //        else
        //        {
        //            gvPOrder.DataSource = null;
        //            gvPOrder.DataBind();


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        oblPurchaseReceived = null;
        //        objPurchaseReceivedList = null;
        //    }
        //}
        //Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItemList BindPurchaseReceivedItem(int id)
        //{
            
            
        //    try
        //    {
        //        oblPurchaseReceivedItem = new Store.PurchaseReceivedItem.BusinessLogic.PurchaseReceivedItem();
        //        objPurchaseReceivedItemList = new Store.PurchaseReceivedItem.BusinessObject.PurchaseReceivedItemList();
        //        objPurchaseReceivedItemList = oblPurchaseReceivedItem.GetAllPurchaseReceivedItemList(id, 0, "");
        //        return objPurchaseReceivedItemList;
        //    }
        //    catch (Exception ex)
        //    {
        //        //return null;
        //        throw ex;
        //    }
        //    finally
        //    {

        //        oblPurchaseReceivedItem = null;
        //        objPurchaseReceivedItemList = null;
        //    }


        //}
        //protected void gvPOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        int pid = Convert.ToInt32(gvPOrder.DataKeys[e.Row.RowIndex].Value.ToString());
        //        GridView gv = (GridView)e.Row.FindControl("gvPoItem");
        //        gv.DataSource = BindPurchaseReceivedItem(pid);
        //        gv.DataBind();
        //    }
        //}
        //protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        //{
        //    //objPurchaseOrder = new Store.PurchaseOrder.BusinessObject.PurchaseOrder();
        //    //oblPurchaseOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();
        //    //objPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessObject.PurchaseOrderItem();
        //    //oblPurchaseOrderItem = new Store.PurchaseOrderItem.BusinessLogic.PurchaseOrderItem();
        //    //try
        //    //{

        //    //    ImageButton btndetails = sender as ImageButton;
        //    //    GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //    //    int id = Convert.ToInt32(gvPOrder.DataKeys[gvrow.RowIndex].Value.ToString());
        //    //    int rt = checkPRvied(id);
        //    //    if (rt == 1)
        //    //    {
        //    //        reset();
        //    //        hfPId.Value = id.ToString();
        //    //        objPurchaseOrder = oblPurchaseOrder.GetAllPurchaseOrder(id, 0, "");
        //    //        if (objPurchaseOrder != null)
        //    //        {
        //    //            txtDic.Text = objPurchaseOrder.PDiscount.ToString();
        //    //            txtDicPre.Text = objPurchaseOrder.PDiscountPre.ToString();
        //    //            txtMiscCost.Text = objPurchaseOrder.MiscCost.ToString();
        //    //            txtSHC.Text = objPurchaseOrder.ShipingAndHandlingCost.ToString();
        //    //            txtTax.Text = objPurchaseOrder.TaxValue.ToString();
        //    //            txttotal.Text = objPurchaseOrder.PurchaseAmount.ToString();
        //    //            objPurchaseOrderItemList = oblPurchaseOrderItem.GetAllPurchaseOrderItemList(id, 0, "");
        //    //            if (objPurchaseOrderItemList != null)
        //    //            {
        //    //                Gridview1.DataSource = null;
        //    //                Gridview1.DataBind();
        //    //                Gridview1.DataSource = objPurchaseOrderItemList;
        //    //                Gridview1.DataBind();
        //    //            }
        //    //        }
        //    //        upForm.Update();
        //    //    }
        //    //    //edit logic
        //    //}
        //    //catch (Exception ex)
        //    //{ }
        //    //finally
        //    //{
        //    //    objPurchaseOrder = null;
        //    //    oblPurchaseOrder = null;
        //    //    objPurchaseOrderItem = null;
        //    //    oblPurchaseOrderItem = null;
        //    //}
        //    //cmdMode = CommandMode.M;
        //}
        
        //protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        //{
        //    //cmdMode = CommandMode.D;
        //    //oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
        //    //objPurchaseReceived = new Store.PurchaseReceived.BusinessObject.PurchaseReceived();
          
        //    //objMessageInfo = new MessageInfo();
        //    //try
        //    //{
        //    //    ImageButton btndetails = sender as ImageButton;
        //    //    GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //    //    objPurchaseReceived.PurchaseReceivedID= Convert.ToInt32(gvPOrder.DataKeys[gvrow.RowIndex].Value.ToString());
                
        //    //    //objMessageInfo = oblPurchaseReceived.ManagePurchaseReceived(objPurchaseReceived,cmdMode);
        //    //    bindPRecived();
        //    //    if (objMessageInfo.TranID != 0)
        //    //        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
        //    //    else if (objMessageInfo.ErrorCode == -101)
        //    //        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.ErrorMessage + "')", true);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}
        //    //finally
        //    //{

        //    //    objMessageInfo = null;
        //    //    //objPurchaseOrder = null;
        //    //    //oblPurchaseOrder = null;

        //    //}
        //}
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