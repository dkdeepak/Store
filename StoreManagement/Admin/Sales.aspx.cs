using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreManagement.Admin
{
    public partial class Sales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //pnlpopup

        }
        //#region controlDefinedFunction
        //protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        //{
        //    ResetForm();
        //    ImageButton btndetails = sender as ImageButton;
        //    GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //    txtPurchaseReceivedID.Text = dgvPurchaseReceived.DataKeys[gvrow.RowIndex].Value.ToString();
        //    txtPurchaseReceivedID.Text = gvrow.Cells[0].Text;
        //    txtVendorID.Text = gvrow.Cells[1].Text;
        //    txtPurchaseAmount.Text = gvrow.Cells[2].Text;
        //    txtTaxValue.Text = gvrow.Cells[3].Text;
        //    txtShippingHandlingCost.Text = gvrow.Cells[4].Text;
        //    txtMiscCost.Text = gvrow.Cells[5].Text;
        //    ddlPurchaseOrderID.SelectedValue = gvrow.Cells[6].Text;
        //    if (chkBoxIsActive.Checked)
        //    {
        //        objPurchaseReceived.IsActive = 1;
        //    }
        //    else
        //    {
        //        objPurchaseReceived.IsActive = 0;
        //    }

        //}
        //protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        //{
        //    cmdMode = CommandMode.D;
        //    objPurchaseReceived = new Store.PurchaseReceived.BusinessObject.PurchaseReceived();
        //    oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
        //    try
        //    {
        //        ImageButton btndetails = sender as ImageButton;
        //        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //        objPurchaseReceived.PurchaseReceivedID = Convert.ToInt32(dgvPurchaseReceived.DataKeys[gvrow.RowIndex].Value.ToString());
        //        objPurchaseReceived.VendorID = 1;
        //        objPurchaseReceived.PurchaseRecivedDate = DateTime.Now;
        //        objPurchaseReceived.PurchaseAmount = 2;
        //        objPurchaseReceived.TaxValue = 3;
        //        objPurchaseReceived.ShippingHandlingCost = 4;
        //        objPurchaseReceived.PurchaseOrderID = 5;
        //        objPurchaseReceived.CreatedBy = 1;
        //        objMessageInfo = oblPurchaseReceived.ManagePurchaseOrderMaster(objPurchaseReceived, cmdMode);
        //        // BindPurchaseReceived();
        //        updatePurchasedReceivedBdInfo.Update();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        objPurchaseReceived = null;
        //        objMessageInfo = null;
        //        oblPurchaseReceived = null;

        //    }
        //}
        //protected void linkButton_Click(object sender, EventArgs e)
        //{
        //    cmdMode = CommandMode.N;
        //    ResetForm();
        //    updatePurchasedReceivedBdInfo.Update();
        //    //this.ModalPopupExtender1.Show();
        //}
        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    ManagePurchaseReceived();
        //    //this.ModalPopupExtender1.Hide();
        //    // BindPurchaseReceived();
        //    updatePurchasedReceivedBdInfo.Update();
        //}
        //#endregion
        //#region userDefinedFunction
        //void BindCountry()
        //{
        //    oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();
        //    try
        //    {
        //        objPurchaseReceivedList = oblPurchaseReceived.GetAllPurchaseReceivedList(0, 0, "");

        //        if (objPurchaseReceivedList != null)
        //        {
        //            dgvPurchaseReceived.DataSource = objPurchaseReceivedList;
        //            dgvPurchaseReceived.DataBind();
        //        }
        //        else
        //        {
        //            dgvPurchaseReceived.DataSource = null;
        //            dgvPurchaseReceived.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        oblPurchaseReceived = null;
        //        objPurchaseReceivedList = null;
        //    }


        //}
        //void ManagePurchaseReceived()
        //{
        //    objPurchaseReceived = new Store.PurchaseReceived.BusinessObject.PurchaseReceived();
        //    oblPurchaseReceived = new Store.PurchaseReceived.BusinessLogic.PurchaseReceived();

        //    try
        //    {
        //        if (cmdMode == Store.Common.CommandMode.M)
        //        {
        //            objPurchaseReceived.PurchaseReceivedID = Convert.ToInt32(txtPurchaseReceivedID.Text);

        //        }
        //        else
        //        {
        //            objPurchaseReceived.PurchaseReceivedID = 0;

        //        }
        //        objPurchaseReceived.VendorID = Convert.ToInt16(txtVendorID.Text);
        //        objPurchaseReceived.PurchaseRecivedDate = Convert.ToDateTime(txtPurchaseReceivedDate.Text);
        //        objPurchaseReceived.PurchaseAmount = Convert.ToDecimal(txtPurchaseAmount.Text);
        //        objPurchaseReceived.TaxValue = Convert.ToDecimal(txtTaxValue.Text);
        //        objPurchaseReceived.ShippingHandlingCost = Convert.ToDecimal(txtShippingHandlingCost.Text);
        //        objPurchaseReceived.MiscCost = Convert.ToDecimal(txtMiscCost.Text);
        //        objPurchaseReceived.PurchaseOrderID = Convert.ToInt16(ddlPurchaseOrderID.SelectedIndex);
        //        if (chkBoxIsActive.Checked)
        //        {
        //            objPurchaseReceived.IsActive = 1;
        //        }
        //        else
        //        {
        //            objPurchaseReceived.IsActive = 0;
        //        }

        //        objPurchaseReceived.CreatedBy = 1;
        //        objMessageInfo = oblPurchaseReceived.ManagePurchaseOrderMaster(objPurchaseReceived, cmdMode);

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        objPurchaseReceived = null;
        //        objMessageInfo = null;
        //        oblPurchaseReceived = null;

        //    }

        //}

        //void ResetForm()
        //{
        //    //txtVendorID=1;
        //    //txtPurchaseReceivedDate = DateTime.Now;

        //}
        //#endregion

        
    }
}