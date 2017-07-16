using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                if (!Page.IsPostBack)
                {
                    BindCategory();
                }
            }
            else {
                Response.Redirect("../Login.aspx");
            }
        }
        Store.Category.BusinessLogic.Category oblCategory = null;
        Store.Category.BusinessObject.CategoryList obCategoryList = null;
        Store.Category.BusinessObject.Category objCategory = null;
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
            txtCategoryId.Text = dgvCategory.DataKeys[gvrow.RowIndex].Value.ToString();
            txtCategoryName.Text = gvrow.Cells[0].Text;
            updateCategoryBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objCategory = new Store.Category.BusinessObject.Category();
            oblCategory = new Store.Category.BusinessLogic.Category();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objCategory.CategoryID = Convert.ToInt32(dgvCategory.DataKeys[gvrow.RowIndex].Value.ToString());
                objCategory.CategoryName = "";
                objCategory.CreatedBy = 1;
                objMessageInfo = oblCategory.ManageItemMaster(objCategory, cmdMode);
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
                BindCategory();
                updateCategoryBdInfo.Update();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objCategory = null;
                objMessageInfo = null;
                oblCategory = null;
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateCategoryBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            objMessageInfo = new MessageInfo();
            Page.Validate("vgCat");
            if (Page.IsValid)
            {
                ManageCategory();
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
                BindCategory();
                updateCategoryBdInfo.Update();
                updateCategory.Update();
                this.ModalPopupExtender1.Show();
            }
        }
        #endregion
        #region UserDefindeFunction
        void BindCategory()
        {
            oblCategory = new Store.Category.BusinessLogic.Category();
            try
            {
                obCategoryList = oblCategory.GetAllCategoryList(0, 0, "");
                if (obCategoryList != null)
                {
                    dgvCategory.DataSource = obCategoryList;
                    dgvCategory.DataBind();
                }
                else
                {
                    dgvCategory.DataSource = null;
                    dgvCategory.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblCategory = null;
                obCategoryList = null;
            }


        }
        void ManageCategory()
        {
            objCategory = new Store.Category.BusinessObject.Category();
            oblCategory = new Store.Category.BusinessLogic.Category();
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                   
                    objCategory.CategoryID = Convert.ToInt32(txtCategoryId.Text);
                    objCategory.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());
                }
                else
                {
                    objCategory.CategoryID = 0;
                }
                objCategory.CategoryName = Convert.ToString(txtCategoryName.Text);
                objCategory.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());                
                objMessageInfo = oblCategory.ManageItemMaster(objCategory, cmdMode);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objCategory = null;
                oblCategory = null;
            }

        }
        void ResetForm()
        {
            txtCategoryId.Text = "";
            txtCategoryName.Text = "";
            txtCategoryName.Focus();
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