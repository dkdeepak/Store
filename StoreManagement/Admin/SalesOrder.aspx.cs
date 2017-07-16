using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class SalesOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindSalesOrder();
                BindVendor();
            }
        }
        Store.Vendor.BusinessLogic.Vendor oblVendor = null;
        Store.Vendor.BusinessObject.VendorList obVendorList = null;
        Store.SalesOrder.BusinessLogic.SalesOrder odlSalesOrder = null;
        Store.SalesOrder.BusinessObject.SalesOrder objSalesOrder = null;
        Store.SalesOrder.BusinessObject.SalesOrderList objSalesOrderList = null;
        Store.Common.MessageInfo objMessageInfo = null;
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        #region ControlDefinedFunction
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            ResetForm();
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtSalesOrderID.Text = dgvSalesOrder.DataKeys[gvrow.RowIndex].Value.ToString();
            ddlVendor.SelectedItem.Selected = false;
            ddlVendor.Items.FindByText(gvrow.Cells[0].Text.ToString()).Selected=true;
            txtSDate.Text = gvrow.Cells[1].Text;
            txtTotalCostAmount.Text = gvrow.Cells[2].Text;
            txtTotalSaleAmount.Text = gvrow.Cells[3].Text;
            txtTotalDiscountAmount.Text = gvrow.Cells[4].Text;
            txtTaxValue.Text = gvrow.Cells[5].Text;
            txtSHCost.Text = gvrow.Cells[6].Text;
            txtMiscCost.Text = gvrow.Cells[7].Text;
            int i = Convert.ToInt32(gvrow.Cells[8].Text);
            if (i == 1)
                cbIsActive.Checked = true;
            else
                cbIsActive.Checked = false;
            updateSalesOrderBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objSalesOrder = new Store.SalesOrder.BusinessObject.SalesOrder();
            odlSalesOrder = new Store.SalesOrder.BusinessLogic.SalesOrder();


            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objSalesOrder.SalesOrderID = Convert.ToInt32(dgvSalesOrder.DataKeys[gvrow.RowIndex].Value.ToString());
                objSalesOrder.VendorID = 0;
                objSalesOrder.SaleDate = DateTime.Now;
                objSalesOrder.TotalCostAmount = 0;
                objSalesOrder.TotalSaleAmount = 0;
                objSalesOrder.TotalTaxValue = 0;
                objSalesOrder.TotalDiscountAmount = 0;
                objSalesOrder.ShipingAndHandlingCost = 0;
                objSalesOrder.MiscSaleAmount = 0;
                objSalesOrder.IsActive = 1;
                objSalesOrder.ClientID = 0;
                objSalesOrder.CreatedBy = 1;
                objMessageInfo = odlSalesOrder.ManageItemMaster(objSalesOrder, cmdMode);
                BindSalesOrder();
                updateSalesOrderBdInfo.Update();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objSalesOrder = null;
                objMessageInfo = null;
                odlSalesOrder = null;

            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateSalesOrderBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgSOrder");
            if (Page.IsValid)
            {
                ManageSalesOrder();
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
                BindSalesOrder();
                updateSalesOrderBdInfo.Update();
            }
        }
        #endregion
        #region UserDefinedFunction
        void BindSalesOrder()
        {
            odlSalesOrder = new Store.SalesOrder.BusinessLogic.SalesOrder();

            try
            {
                objSalesOrderList = odlSalesOrder.GetAllSalesOrderList(0, 0, "");
                if (objSalesOrderList != null)
                {
                    dgvSalesOrder.DataSource = objSalesOrderList;
                    dgvSalesOrder.DataBind();
                }
                else
                {
                    dgvSalesOrder.DataSource = null;
                    dgvSalesOrder.DataBind();
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
        void ManageSalesOrder()
        {
            objSalesOrder = new Store.SalesOrder.BusinessObject.SalesOrder();
            odlSalesOrder = new Store.SalesOrder.BusinessLogic.SalesOrder();


            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objSalesOrder.SalesOrderID = Convert.ToInt32(txtSalesOrderID.Text);

                }
                else
                {
                    objSalesOrder.SalesOrderID = 0;

                }
                objSalesOrder.VendorID = Convert.ToInt16(ddlVendor.SelectedItem.Value);
                DateTime date = DateTime.Parse(txtSDate.Text);
                objSalesOrder.SaleDate = date;
                objSalesOrder.TotalCostAmount = Convert.ToDecimal(txtTotalCostAmount.Text);
                objSalesOrder.TotalSaleAmount = Convert.ToDecimal(txtTotalSaleAmount.Text);
                objSalesOrder.TotalDiscountAmount = Convert.ToDecimal(txtTotalDiscountAmount.Text);
                objSalesOrder.TotalTaxValue = Convert.ToDecimal(txtTaxValue.Text);
                objSalesOrder.ShipingAndHandlingCost = Convert.ToDecimal(txtSHCost.Text);
                objSalesOrder.MiscSaleAmount = Convert.ToDecimal(txtMiscCost.Text);

                if (cbIsActive.Checked)
                {
                    objSalesOrder.IsActive = 1;

                }
                else
                {
                    objSalesOrder.IsActive = 0;
                }


                objSalesOrder.CreatedBy = 1;
                objMessageInfo = odlSalesOrder.ManageItemMaster(objSalesOrder, cmdMode);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                objSalesOrder = null;
                //objMessageInfo = null;
                odlSalesOrder = null;
            }

        }
        void ResetForm()
        {
            txtSalesOrderID.Text =""; 
           //txtVendorId.Text = "";
            txtSDate.Text = "";
            txtTotalCostAmount.Text="";
            txtTotalSaleAmount.Text="";
            txtTaxValue.Text = "";
            txtSHCost.Text ="";
            txtMiscCost.Text = "";
        }
        #endregion
    }
}