using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class PurchaseReceived : System.Web.UI.Page
    {

        Store.Vendor.BusinessLogic.Vendor oblVendor = null;
        Store.Vendor.BusinessObject.VendorList obVendorList = null;
        Store.PurchaseOrder.BusinessLogic.PurchaseOrder oblPurchaseOrder = null;
        Store.PurchaseOrder.BusinessObject.PurchaseOrderList objPurchaseOrderList = null;
        Store.PurchaseReceived.BusinessLogic.PurchaseReceived oblPurchaseReceived = null;
        Store.PurchaseReceived.BusinessObject.PurchaseReceived objPurchaseReceived = null;
        Store.PurchaseReceived.BusinessObject.PurchaseReceivedList objPurchaseReceivedList = null;
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
                BindPurchaseReceived();
                BindPurchaseOrder();
                BindVendor();
            }
        }
        
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            ResetForm();
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtPurchaseReceivedID.Text = dgvPurchaseReceived.DataKeys[gvrow.RowIndex].Value.ToString();
            ddlVendor.SelectedItem.Selected = false;
            ddlVendor.Items.FindByText(gvrow.Cells[0].Text.ToString()).Selected=true;
            txtPurchaseReceivedDate.Text = gvrow.Cells[1].Text;
            txtPurchaseAmount.Text = gvrow.Cells[2].Text;
            txtTaxValue.Text = gvrow.Cells[3].Text;
            txtShippingHandlingCost.Text = gvrow.Cells[4].Text;
            txtMiscCost.Text = gvrow.Cells[5].Text;
            ddlPurchaseOrderID.SelectedItem.Selected = false;
            ddlPurchaseOrderID.Items.FindByText(gvrow.Cells[6].Text.ToString()).Selected=true;
            int i = Convert.ToInt32(gvrow.Cells[7].Text);
            if (i == 1)
                chkBoxIsActive.Checked = true;
            else
                chkBoxIsActive.Checked = false;
            updatePurchasedReceivedBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;

        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objPurchaseReceived= new Store.PurchaseReceived.BusinessObject.PurchaseReceived();
            oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
               objPurchaseReceived.PurchaseReceivedID = Convert.ToInt32(dgvPurchaseReceived.DataKeys[gvrow.RowIndex].Value.ToString());
               objPurchaseReceived.VendorID=1;
               objPurchaseReceived.PurchaseRecivedDate = DateTime.Now;
               objPurchaseReceived.PurchaseAmount = 2;
               objPurchaseReceived.TaxValue = 3;
               objPurchaseReceived.ShipingAndHandlingCost = 4;
               objPurchaseReceived.PurchaseOrderID = 5;
               objPurchaseReceived.CreatedBy = 1;
                //objMessageInfo =oblPurchaseReceived.ManagePurchaseOrderMaster(objPurchaseReceived, cmdMode);
                BindPurchaseReceived();
               updatePurchasedReceivedBdInfo.Update();
               
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
               objPurchaseReceived = null;
               objMessageInfo = null;
               oblPurchaseReceived = null;
                
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updatePurchasedReceivedBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgPRcv");
            if(Page.IsValid)
            {
                ManagePurchaseReceived();
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
                BindPurchaseReceived();
                updatePurchasedReceivedBdInfo.Update();
            }
        }
        #endregion
        #region userDefinedFunction
        void BindPurchaseReceived()
        {
           oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
            try
            {
               objPurchaseReceivedList =oblPurchaseReceived.GetAllPurchaseReceivedList(0, 0, "");

               if (objPurchaseReceivedList != null)
                {
                   dgvPurchaseReceived.DataSource = objPurchaseReceivedList;
                   dgvPurchaseReceived.DataBind();
                }
                else
                {
                    dgvPurchaseReceived.DataSource = null;
                    dgvPurchaseReceived.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
               oblPurchaseReceived = null;
                objPurchaseReceivedList = null;
            }


        }
        void ManagePurchaseReceived()
        {
           objPurchaseReceived = new Store.PurchaseReceived.BusinessObject.PurchaseReceived();
           oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
            
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
               
                {
                    objPurchaseReceived.PurchaseReceivedID = Convert.ToInt32(txtPurchaseReceivedID.Text);
                   
                }
                else
                {
                    objPurchaseReceived.PurchaseReceivedID = 0;
                    
                }
                objPurchaseReceived.VendorID = Convert.ToInt32(ddlVendor.SelectedItem.Value);
                objPurchaseReceived.PurchaseRecivedDate=Convert.ToDateTime(txtPurchaseReceivedDate.Text);
                objPurchaseReceived.PurchaseAmount = Convert.ToDecimal(txtPurchaseAmount.Text);
                objPurchaseReceived.TaxValue = Convert.ToDecimal(txtTaxValue.Text);
                objPurchaseReceived.ShipingAndHandlingCost = Convert.ToDecimal(txtShippingHandlingCost.Text);
                objPurchaseReceived.MiscCost = Convert.ToDecimal(txtMiscCost.Text);
                objPurchaseReceived.PurchaseOrderID = Convert.ToInt16(ddlPurchaseOrderID.SelectedItem.Value);
                if (chkBoxIsActive.Checked)
                {
                    objPurchaseReceived.IsActive = 1;
                }
                else
                {
                    objPurchaseReceived.IsActive = 0;
                }
                
                objPurchaseReceived.CreatedBy = 1;
                //objMessageInfo =oblPurchaseReceived.ManagePurchaseOrderMaster(objPurchaseReceived, cmdMode);
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objPurchaseReceived = null;
                //objMessageInfo = null;
                oblPurchaseReceived= null;
               
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
        void BindPurchaseOrder()
        {
            oblPurchaseOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();
            try
            {
                objPurchaseOrderList = oblPurchaseOrder.GetAllPurchaseOrderList(0, 0, "");
                if (objPurchaseOrderList != null)
                {
                    ddlPurchaseOrderID.DataSource = objPurchaseOrderList;
                    ddlPurchaseOrderID.DataValueField = "PurchaseOrderID";
                    ddlPurchaseOrderID.DataBind();
                }
                else
                {
                    ddlPurchaseOrderID.DataSource = null;
                    ddlPurchaseOrderID.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblPurchaseOrder = null;
                objPurchaseOrderList = null;
            }


        }
        void ResetForm()
        {
            txtPurchaseReceivedDate.Text="";
            txtPurchaseAmount.Text="";
            txtTaxValue.Text="";
            txtShippingHandlingCost.Text="";
            txtMiscCost.Text = "";
        }
        #endregion
    }
       
}