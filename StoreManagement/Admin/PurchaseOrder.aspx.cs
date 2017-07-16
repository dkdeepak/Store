using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class PurchaseOrder : System.Web.UI.Page
    {
        Store.Vendor.BusinessLogic.Vendor oblVendor = null;
        Store.Vendor.BusinessObject.VendorList obVendorList = null;
        Store.PurchaseOrder.BusinessLogic.PurchaseOrder odlPOrder = null;
        Store.PurchaseOrder.BusinessObject.PurchaseOrder objPOrder = null;
        Store.PurchaseOrder.BusinessObject.PurchaseOrderList objPOrderList = null;
        Store.Common.MessageInfo objMessageInfo = null;
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        //#region ControlDefinedFunction
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        BindPurchaseOrder();
        //        BindVendor();
        //    }

        //}

        //protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        //{
        //    ResetForm();
        //    ImageButton btndetails = sender as ImageButton;
        //    GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //    txtPOId.Text = dgvPOrder.DataKeys[gvrow.RowIndex].Value.ToString();
        //    ddlVendor.SelectedItem.Selected = false;
        //    ddlVendor.Items.FindByText(gvrow.Cells[0].Text.ToString()).Selected=true;
        //    txtPDate.Text = gvrow.Cells[1].Text;
        //    txtPAmount.Text = gvrow.Cells[2].Text;
        //    txtTaxValue.Text = gvrow.Cells[3].Text;
        //    txtSHCost.Text = gvrow.Cells[4].Text;
        //    txtMiscCost.Text = gvrow.Cells[5].Text;
        //    int i=Convert.ToInt32(gvrow.Cells[6].Text);
        //    if (i == 1)
        //        cbIsActive.Checked = true;
        //    else
        //        cbIsActive.Checked = false;
        //    updatePOrderBdInfo.Update();
        //    this.ModalPopupExtender1.Show();
        //    cmdMode = CommandMode.M;

           
        //}
        //protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        //{
        //    cmdMode = CommandMode.D;
        //   objPOrder = new Store.PurchaseOrder.BusinessObject.PurchaseOrder();
        //   odlPOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();
            

        //    try
        //    {
        //        ImageButton btndetails = sender as ImageButton;
        //        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //        objPOrder.PurchaseOrderID = Convert.ToInt32(dgvPOrder.DataKeys[gvrow.RowIndex].Value.ToString());
        //        objPOrder.VendorID =0;
        //        objPOrder.PurchaseDate = DateTime.Now;
        //        objPOrder.PurchaseAmount = 0;
        //        objPOrder.TaxValue = 0;
        //        objPOrder.ShipingAndHandlingCost = 0;
        //        objPOrder.MiscCost = 0;
        //        objPOrder.ClientID = 0;
        //        objPOrder.CreatedBy = 1;
        //        objMessageInfo=odlPOrder.ManagePurchaseOrderMaster(objPurchaseOrderItem,
        //        objMessageInfo = odlPOrder.ManagePurchaseOrderMaster(objPOrder, cmdMode);
        //        BindPurchaseOrder();
        //        updatePOrderBdInfo.Update();
                
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        objPOrder = null;
        //        objMessageInfo = null;
        //        odlPOrder = null;
               
        //    }
        //}

        //protected void linkButton_Click(object sender, EventArgs e)
        //{
        //    cmdMode = CommandMode.N;
        //    ResetForm();
        //    updatePOrderBdInfo.Update();
        //    this.ModalPopupExtender1.Show();
        //}
        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    Page.Validate("VgPOrder");
        //    if (Page.IsValid)
        //    {
        //        ManagePurchaseOrder();
        //        if (objMessageInfo.ErrorCode == -101)
        //        {

        //            // ClientScript.RegisterStartupScript(this.GetType(), "newWindow", string.Format("<script>window.open('{0}');</script>", objMessageInfo.ErrorMessage));
        //            lblMsg.Text = Convert.ToString(objMessageInfo.ErrorMessage);
        //        }
        //        if (objMessageInfo.TranID > 0)
        //        {
        //            lblMsg.Text = Convert.ToString(objMessageInfo.TranMessage);
        //        }
        //        this.ModalPopupExtender1.Hide();
        //        BindPurchaseOrder();
        //        updatePOrderBdInfo.Update();
        //       updatePOrder.Update();
        //        this.ModalPopupExtender1.Show();
        //    }
        //}
        //#endregion
        //#region UserDefinedFunction
        //void BindPurchaseOrder()
        //{
        //   odlPOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();
           
        //    try
        //    {
        //       objPOrderList =odlPOrder.GetAllPurchaseOrderList(0, 0, "");
        //       if (objPOrderList != null)
        //        {
        //           dgvPOrder.DataSource = objPOrderList;
        //           dgvPOrder.DataBind();
        //        }
        //        else
        //        {
        //            dgvPOrder.DataSource = null;
        //            dgvPOrder.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //       odlPOrder = null;
        //       objPOrderList = null;
        //    }


        //}
        //void BindVendor()
        //{
        //    oblVendor = new Store.Vendor.BusinessLogic.Vendor();
        //    try
        //    {
        //        obVendorList = oblVendor.GetAllVendorList(0, 0, "");
        //        if (obVendorList != null)
        //        {
        //            ddlVendor.DataSource = obVendorList;
        //            ddlVendor.DataTextField = "VendorName";
        //            ddlVendor.DataValueField = "VendorID";
        //            ddlVendor.DataBind();
        //        }
        //        else
        //        {
        //            ddlVendor.DataSource = null;
        //            ddlVendor.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        oblVendor = null;
        //        obVendorList = null;
        //    }


        //}
        //void ManagePurchaseOrder()
        //{
        //   objPOrder = new Store.PurchaseOrder.BusinessObject.PurchaseOrder();
        //   odlPOrder = new Store.PurchaseOrder.BusinessLogic.PurchaseOrder();
            
            
        //    try
        //    {
        //        if (cmdMode == Store.Common.CommandMode.M)
                
        //        {
        //           objPOrder.PurchaseOrderID = Convert.ToInt32( txtPOId.Text);
                   
        //        }
        //        else
        //        {
        //           objPOrder.PurchaseOrderID = 0;
                    
        //        }
        //       objPOrder.VendorID = Convert.ToInt32(ddlVendor.SelectedItem.Value);
        //       DateTime date = DateTime.Parse(txtPDate.Text);
        //       objPOrder.PurchaseDate = date;
        //       objPOrder.PurchaseAmount = Convert.ToDecimal(txtPAmount.Text);
        //       objPOrder.TaxValue = Convert.ToDecimal(txtTaxValue.Text);
        //       objPOrder.ShipingAndHandlingCost = Convert.ToDecimal(txtSHCost.Text);
        //       objPOrder.MiscCost = Convert.ToDecimal(txtMiscCost.Text);
               
        //       if (cbIsActive.Checked)
        //       {
        //           objPOrder.IsActive = 1;

        //       }
        //       else 
        //       {
        //           objPOrder.IsActive = 0;
        //       }
               
                
        //       objPOrder.CreatedBy = 1;
        //       objMessageInfo = odlPOrder.ManagePurchaseOrderMaster(objPOrder, cmdMode);
                
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        objPOrder = null;
        //        //objMessageInfo = null;
        //       odlPOrder = null;
        //    }

        //}

        //void ResetForm()
        //{
        //  txtPOId.Text = "";
            
            
        //    txtPDate.Text = "";
        //    txtPAmount.Text ="";
        //    txtTaxValue.Text="";
        //    txtSHCost.Text ="";
        //    txtMiscCost.Text = "";

        //}
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    ResetForm();
        //    this.ModalPopupExtender1.Hide();
        //}
        //#endregion

    }
}