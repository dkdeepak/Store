using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class Vendor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindVendor();
        }
        Store.Vendor.BusinessLogic.Vendor oblVendor = null;
        Store.Vendor.BusinessObject.VendorList obVendorList = null;
        Store.Vendor.BusinessObject.Vendor objVendor = null;
        Store.Common.MessageInfo objMessageInfo = null;
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
        #region ControlDefindeFunction
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            ResetForm();
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtVendorId.Text = dgvVendor.DataKeys[gvrow.RowIndex].Value.ToString();
            txtVendorName.Text = gvrow.Cells[0].Text;
            updateVendorBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objVendor = new Store.Vendor.BusinessObject.Vendor();
            oblVendor = new Store.Vendor.BusinessLogic.Vendor();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objVendor.VendorID = Convert.ToInt32(dgvVendor.DataKeys[gvrow.RowIndex].Value.ToString());
                objVendor.VendorName = "";
                objVendor.CreatedBy = 1;
                objMessageInfo = oblVendor.ManageItemMaster(objVendor, cmdMode);
                BindVendor();
                updateVendorBdInfo.Update();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objVendor = null;
                objMessageInfo = null;
                oblVendor = null;
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateVendorBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgVendor");
            if (Page.IsValid)
            {
                ManageVendor();
                if (objMessageInfo.ErrorCode == -101)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
                }
                if (objMessageInfo.TranID > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
                }
                this.ModalPopupExtender1.Hide();
                BindVendor();
                updateVendorBdInfo.Update();
                updateVendor.Update();
                this.ModalPopupExtender1.Show();
            }
        }
        #endregion
        #region UserDefindeFunction
        void BindVendor()
        {
            oblVendor = new Store.Vendor.BusinessLogic.Vendor();
            try
            {
                obVendorList = oblVendor.GetAllVendorList(0, 0, "");
                if (obVendorList != null)
                {
                    dgvVendor.DataSource = obVendorList;
                    dgvVendor.DataBind();
                }
                else
                {
                    dgvVendor.DataSource = null;
                    dgvVendor.DataBind();
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
        void ManageVendor()
        {
            objVendor = new Store.Vendor.BusinessObject.Vendor();
            oblVendor = new Store.Vendor.BusinessLogic.Vendor();
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objVendor.VendorID = Convert.ToInt32(txtVendorId.Text);
                }
                else
                {
                    objVendor.VendorID = 0;
                }
                objVendor.VendorName = Convert.ToString(txtVendorName.Text);
                objVendor.CreatedBy = 1;
                objMessageInfo = oblVendor.ManageItemMaster(objVendor, cmdMode);
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objVendor = null;
                //objMessageInfo = null;
                oblVendor = null;
            }

        }
        void ResetForm()
        {
            txtVendorId.Text = "";
            txtVendorName.Text = "";
            txtVendorName.Focus();
        }
        #endregion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
            this.ModalPopupExtender1.Hide();
        }
        protected void lbtnClose_Click(object sender, EventArgs e)
        {
            ResetForm();
            this.ModalPopupExtender1.Hide();
        }

    }
}