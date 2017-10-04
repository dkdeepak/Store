using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;
using System.Web.UI.HtmlControls;

namespace StoreManagement.Admin
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserId"] != null)
            //{
            if (!Page.IsPostBack)
            {
                BindCategory();
                divCategory.Style.Add("display", "none");
            }
            //}
            //else {
            //  Response.Redirect("../Login.aspx");
            //}
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
            if(gvrow.Cells[0].Text!="")
            {
                cbParant.Checked = true;
                ddlCategory.SelectedItem.Selected = false;
                ddlCategory.Items.FindByText(gvrow.Cells[1].Text.ToString()).Selected = true;
                divCategory.Style.Add("display", "block");
            }
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
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Category).FullName, 1);
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
                    ddlCategory.DataSource = obCategoryList;
                    ddlCategory.DataTextField = "CategoryNam";
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataBind();

                }
                else
                {
                    dgvCategory.DataSource = null;
                    dgvCategory.DataBind();
                }
                
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Category).FullName, 1);
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
                    //objCategory.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());
                }
                else
                {
                    objCategory.CategoryID = 0;
                    //objCategory.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                }
                if (cbParant.Checked)
                    objCategory.ParentCategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                else
                    objCategory.ParentCategoryID = 0;
                objCategory.CategoryName = Convert.ToString(txtCategoryName.Text);
                objMessageInfo = oblCategory.ManageItemMaster(objCategory, cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Category).FullName, 1);
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
            divCategory.Style.Add("display", "none");
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

        protected void cbParant_CheckedChanged(object sender, EventArgs e)
        {
            if(cbParant.Checked)
                divCategory.Style.Add("display", "block");
            else
                divCategory.Style.Add("display", "none");

        }
    }
}