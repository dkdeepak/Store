using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class ItemUnit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindItemUnit();
                BindCategory();
            }
        }
        Store.Category.BusinessLogic.Category oblCategory = null;
        Store.Category.BusinessObject.CategoryList obCategoryList = null;
        Store.ItemUnit.BusinessLogic.ItemUnit oblItemUnit = null;
        Store.ItemUnit.BusinessObject.ItemUnitList obItemUnitList = null;
        Store.ItemUnit.BusinessObject.ItemUnit objItemUnit = null;
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
            txtUnitId.Text = dgvItemUnit.DataKeys[gvrow.RowIndex].Value.ToString();
            txtUnitName.Text = gvrow.Cells[0].Text;
            ddlCategory.SelectedItem.Selected = false;
            ddlCategory.Items.FindByText(gvrow.Cells[1].Text.ToString()).Selected = true;
            updateItemUnitBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objItemUnit = new Store.ItemUnit.BusinessObject.ItemUnit();
            oblItemUnit = new Store.ItemUnit.BusinessLogic.ItemUnit();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objItemUnit.UnitID = Convert.ToInt32(dgvItemUnit.DataKeys[gvrow.RowIndex].Value.ToString());
                objItemUnit.UnitName = "";
                objItemUnit.CategoryID = 1;
                objItemUnit.CreatedBy = 1;
                objMessageInfo = oblItemUnit.ManageItemMaster(objItemUnit, cmdMode);
                BindItemUnit();
                updateItemUnitBdInfo.Update();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objItemUnit = null;
                //objMessageInfo = null;
                oblItemUnit = null;
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateItemUnitBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgItemUnit");
            if (Page.IsValid)
            {
                ManageItemUnit();
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
                BindItemUnit();
                updateItemUnitBdInfo.Update();
                updateItemUnit.Update();
                this.ModalPopupExtender1.Show();
            }
        }
        #endregion
        #region UserDefindeFunction
        void BindItemUnit()
        {
            oblItemUnit = new Store.ItemUnit.BusinessLogic.ItemUnit();
            try
            {
                obItemUnitList = oblItemUnit.GetAllItemUnitList(0, 0, "");
                if (obItemUnitList != null)
                {
                    dgvItemUnit.DataSource = obItemUnitList;
                    dgvItemUnit.DataBind();
                }
                else
                {
                    dgvItemUnit.DataSource = null;
                    dgvItemUnit.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblItemUnit = null;
                obItemUnitList = null;
            }


        }
        void BindCategory()
        {
            oblCategory = new Store.Category.BusinessLogic.Category();
            try
            {
                obCategoryList = oblCategory.GetAllCategoryList(0, 0, "");
                if (obCategoryList != null)
                {
                    ddlCategory.DataSource = obCategoryList;
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, "<--Select Category-->");
                }
                else
                {
                    ddlCategory.DataSource = null;
                    ddlCategory.DataBind();
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
        void ManageItemUnit()
        {
            objItemUnit = new Store.ItemUnit.BusinessObject.ItemUnit();
            oblItemUnit = new Store.ItemUnit.BusinessLogic.ItemUnit();
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objItemUnit.UnitID = Convert.ToInt32(txtUnitId.Text);
                    objItemUnit.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                }
                else
                {
                    objItemUnit.UnitID = 0;
                }
                objItemUnit.UnitName = Convert.ToString(txtUnitName.Text);
                objItemUnit.CategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
                objItemUnit.CreatedBy = Convert.ToInt32(Session["UserId"]);
                objMessageInfo = oblItemUnit.ManageItemMaster(objItemUnit, cmdMode);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objItemUnit = null;
                //objMessageInfo = null;
                oblItemUnit = null;
            }

        }
        void ResetForm()
        {
            txtUnitId.Text = "";
            txtUnitName.Text = "";
            ddlCategory.ClearSelection();
            ddlCategory.Focus();
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