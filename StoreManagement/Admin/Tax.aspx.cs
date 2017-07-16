using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class Tax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindTax();
            }

        }
        Store.Tax.BusinessLogic.Tax oblTax=null;
        Store.Tax.BusinessObject.TaxList obTaxList = null;
        Store.Tax.BusinessObject.Tax objTax = null;
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
            txtTaxId.Text = dgvTax.DataKeys[gvrow.RowIndex].Value.ToString();
            txtTaxName.Text = gvrow.Cells[0].Text;
            txtTaxDisplayName.Text = gvrow.Cells[1].Text;
            txtTaxValue.Text = gvrow.Cells[2].Text;
            updateTaxBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objTax = new Store.Tax.BusinessObject.Tax();
            oblTax = new Store.Tax.BusinessLogic.Tax();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objTax.TaxID = Convert.ToInt32(dgvTax.DataKeys[gvrow.RowIndex].Value.ToString());
                objTax.TaxName = "";
                objTax.TaxDisplayName = "";
                objTax.TaxValue = 0;
                objTax.CreatedBy = 1;
                objMessageInfo = oblTax.ManageItemMaster(objTax, cmdMode);
                BindTax();
                updateTaxBdInfo.Update();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objTax = null;
                objMessageInfo = null;
                oblTax = null;
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateTaxBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgTax");
            if (Page.IsValid)
            {
                ManageTax();

                if (objMessageInfo.ErrorCode == -101)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.ErrorMessage + "')", true);
                }
                if (objMessageInfo.TranID > 0)
                {
                    ResetForm();
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
                }
                this.ModalPopupExtender1.Hide();
                BindTax();
                updateTaxBdInfo.Update();
                updateTax.Update();
                this.ModalPopupExtender1.Show();
            }
        }
        #endregion

        #region UserDefindeFunction
        void BindTax()
        {
            oblTax = new Store.Tax.BusinessLogic.Tax();
            try
            {
                obTaxList = oblTax.GetAllTaxList(0, 0, "");
                //objExamCatgList = oblExamCategory.GetAllExamCategoryList(0, 0, "");
                if (obTaxList != null)
                {
                    dgvTax.DataSource = obTaxList;
                    dgvTax.DataBind();
                }
                else
                {
                    dgvTax.DataSource = null;
                    dgvTax.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblTax = null;
                obTaxList = null;
            }


        }
        void ManageTax()
        {
            objTax = new Store.Tax.BusinessObject.Tax();
            oblTax = new Store.Tax.BusinessLogic.Tax();
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objTax.TaxID= Convert.ToInt32(txtTaxId.Text);
                    objTax.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                }
                else
                {
                    objTax.TaxID=0;
                }
                objTax.TaxName= Convert.ToString(txtTaxName.Text);
                objTax.TaxDisplayName = Convert.ToString(txtTaxDisplayName.Text);
                objTax.TaxValue = Convert.ToDecimal(txtTaxValue.Text);
                objTax.CreatedBy = 1;
                objMessageInfo = oblTax.ManageItemMaster(objTax, cmdMode);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objTax = null;
                //objMessageInfo = null;
                oblTax = null;
            }

        }
        void ResetForm()
        {
            txtTaxId.Text = "";
            txtTaxName.Text = "";
            txtTaxDisplayName.Text = "";
            txtTaxValue.Text = "";
            txtTaxName.Focus();
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