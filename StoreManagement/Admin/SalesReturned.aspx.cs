using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class SalesReturned : System.Web.UI.Page
    {
        Store.Vendor.BusinessLogic.Vendor oblVendor = null;
        Store.Vendor.BusinessObject.VendorList obVendorList = null;
        Store.SalesReturned.BusinessLogic.SalesReturned oblSalesReturned = null;
        Store.SalesReturned.BusinessObject.SalesReturned objSalesReturned = null;
        Store.SalesReturned.BusinessObject.SalesReturnedList objSalesReturnedList = null;
        Store.SalesOrder.BusinessLogic.SalesOrder odlSalesOrder = null;
        Store.SalesOrder.BusinessObject.SalesOrderList objSalesOrderList = null;
        Store.Common.MessageInfo objMessageInfo = null;

        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        #region ControlDefinedFunction
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSalesReturned();
                BindSalesOrder();
                BindVendor();
            }

        }
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            ResetForm();
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtSalesReturnedID.Text =dgvSalesReturned.DataKeys[gvrow.RowIndex].Value.ToString();
            ddlVendor.SelectedItem.Selected = false;
            ddlVendor.Items.FindByText(gvrow.Cells[0].Text.ToString()).Selected=true;
            txtSalesReturnDate.Text = gvrow.Cells[1].Text;
            txtTotalSalesReturnAmount.Text = gvrow.Cells[2].Text;
            txtTaxValue.Text = gvrow.Cells[3].Text;
            txtShippingHandlingCost.Text = gvrow.Cells[4].Text;
            txtMiscCost.Text = gvrow.Cells[5].Text;
            ddlSalesOrderID.SelectedItem.Selected = false;
            ddlSalesOrderID.Items.FindByText(gvrow.Cells[6].Text.ToString()).Selected=true;
            int i = Convert.ToInt32(gvrow.Cells[5].Text);
            if (i == 1)
                cbIsActive.Checked = true;
            else
                cbIsActive.Checked = false;
           
           updateSalesReturnedBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objSalesReturned = new Store.SalesReturned.BusinessObject.SalesReturned();
            oblSalesReturned = new Store.SalesReturned.BusinessLogic.SalesReturned();


            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objSalesReturned.SalesReturnedID = Convert.ToInt32(dgvSalesReturned.DataKeys[gvrow.RowIndex].Value.ToString());
                objSalesReturned.VendorID=0;
                objSalesReturned.SalesReturnDate = DateTime.Now;
                objSalesReturned.TotalSalesReturnAmount = 0;
                objSalesReturned.TaxValue = 0;
                objSalesReturned.ShippingAndHandlingCost = 0;
                objSalesReturned.MiscCost = 0;
                objSalesReturned.SalesOrderID = 0;
                objSalesReturned.ClientID = 0;
                objSalesReturned.CreatedBy = 1;
                objMessageInfo = oblSalesReturned.ManageItemMaster(objSalesReturned, cmdMode);
                BindSalesReturned();
               updateSalesReturnedBdInfo.Update();
               
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objSalesReturned = null;
                objMessageInfo = null;
                oblSalesReturned = null;
               
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateSalesReturnedBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgSRtn");
            if (Page.IsValid)
            {
                ManageSalesReturned();
                if (objMessageInfo.ErrorCode == -101)
                {

                    // ClientScript.RegisterStartupScript(this.GetType(), "newWindow", string.Format("<script>window.open('{0}');</script>", objMessageInfo.ErrorMessage));
                    lblMsg.Text = Convert.ToString(objMessageInfo.ErrorMessage);
                }
                if (objMessageInfo.TranID > 0)
                {
                    lblMsg.Text = Convert.ToString(objMessageInfo.TranMessage);
                }
                this.ModalPopupExtender1.Hide();
                BindSalesReturned();
                updateSalesReturnedBdInfo.Update();
            }
        }
	    #endregion
        #region UserDefinedFunction
        void BindSalesReturned()
        {
           oblSalesReturned = new Store.SalesReturned.BusinessLogic.SalesReturned ();
            
            try
            {
               objSalesReturnedList=oblSalesReturned.GetAllSalesReturnedList(0, 0, "");

               if (objSalesReturnedList != null)
                {
                   dgvSalesReturned.DataSource =objSalesReturnedList;
                   dgvSalesReturned.DataBind();
                }
                else
                {
                    dgvSalesReturned.DataSource = null;
                    dgvSalesReturned.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblSalesReturned= null;
               objSalesReturnedList= null;
            }


        }
        void BindVendor()
        {
            oblVendor = new Store.Vendor.BusinessLogic.Vendor();
            try
            {
                obVendorList = oblVendor.GetAllVendorList(0, 0, "");
                if (obVendorList != null)
                {
                    ddlVendor.DataSource = obVendorList;
                    ddlVendor.DataTextField = "VendorName";
                    ddlVendor.DataValueField = "VendorID";
                    ddlVendor.DataBind();
                }
                else
                {
                    ddlVendor.DataSource = null;
                    ddlVendor.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblVendor = null;
                obVendorList = null;
            }


        }
        void ManageSalesReturned()
        {
           objSalesReturned= new Store.SalesReturned.BusinessObject.SalesReturned();
           oblSalesReturned= new Store.SalesReturned.BusinessLogic.SalesReturned();
           
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                
                {
                    objSalesReturned.SalesReturnedID= Convert.ToInt32(txtSalesReturnedID.Text);
                    
                }
                else
                {
                   objSalesReturned.SalesReturnedID= 0;
                    
                }
                objSalesReturned.VendorID = Convert.ToInt32(ddlVendor.SelectedItem.Value);
                objSalesReturned.SalesReturnDate = Convert.ToDateTime(txtSalesReturnDate.Text);
                objSalesReturned.TotalSalesReturnAmount = Convert.ToDecimal(txtTotalSalesReturnAmount.Text);
                objSalesReturned.TaxValue = Convert.ToDecimal(txtTaxValue.Text);
                objSalesReturned.ShippingAndHandlingCost = Convert.ToDecimal(txtShippingHandlingCost.Text);
                objSalesReturned.MiscCost = Convert.ToDecimal(txtMiscCost.Text);
                objSalesReturned.SalesOrderID = Convert.ToInt32(ddlSalesOrderID.SelectedItem.Value);
                if (cbIsActive.Checked)
                {
                    objSalesReturned.IsActive = 1;
                }
                else
                {
                    objSalesReturned.IsActive = 0;
                }
                
                objSalesReturned.CreatedBy = 1;
                objMessageInfo =oblSalesReturned.ManageItemMaster(objSalesReturned, cmdMode);
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objSalesReturned= null;
                //objMessageInfo = null;
                oblSalesReturned = null;
               
            }

        }
        void BindSalesOrder()
        {
            odlSalesOrder = new Store.SalesOrder.BusinessLogic.SalesOrder();

            try
            {
                objSalesOrderList = odlSalesOrder.GetAllSalesOrderList(0, 0, "");
                if (objSalesOrderList != null)
                {
                    ddlSalesOrderID.DataSource = objSalesOrderList;
                    ddlSalesOrderID.DataValueField = "SalesOrderID";
                    ddlSalesOrderID.DataBind();
                }
                else
                {
                    ddlSalesOrderID.DataSource = null;
                    ddlSalesOrderID.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                odlSalesOrder = null;
                objSalesOrderList = null;
            }


        }
        void ResetForm()
        {
            txtSalesReturnedID.Text = "";
           // txtVendorID.Text = "";
            txtTaxValue.Text = "";
            txtSalesReturnDate.Text = "";
            txtTotalSalesReturnAmount.Text = "";
            txtShippingHandlingCost.Text = "";
            txtTotalSalesReturnAmount.Text = "";
            txtMiscCost.Text = "";
            ddlSalesOrderID.SelectedIndex = 0;

        }
        #endregion
       
    }
}