using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;
using System.Data;

namespace StoreManagement.Admin
{
   
    public partial class District : System.Web.UI.Page
    {
         
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserId"] != null)
            //{
                if (!Page.IsPostBack)
                {
                    BindDistrict();
                    BindCountry();
                }
            //}
        }
        Store.State.BusinessLogic.State oblState = null;
        Store.State.BusinessObject.StateList objStatelist = null;
        Store.District.BusinessLogic.District oblDistrict = null;
        Store.District.BusinessObject.DistrictList objDistrictlist = null;
        Store.District.BusinessObject.District objDistrict = null;
        Store.Country.BusinessLogic.Country oblCountry = null;
        Store.Country.BusinessObject.CountryList objCountrylist = null;
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
            txtDistrictId.Text = dgvDistrict.DataKeys[gvrow.RowIndex].Value.ToString();
            txtDistrict.Text = gvrow.Cells[0].Text;
            ddlCountry.SelectedItem.Selected = false;
            ddlCountry.Items.FindByText(gvrow.Cells[1].Text.ToString()).Selected = true;
            int id = Convert.ToInt32(ddlCountry.SelectedValue);
            BindState(id);
            ddlState.SelectedItem.Selected = false;
            ddlState.Items.FindByText(gvrow.Cells[2].Text.ToString()).Selected = true;
            updateDistrictBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objDistrict = new Store.District.BusinessObject.District();
            oblDistrict = new Store.District.BusinessLogic.District();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objDistrict.DistrictID = Convert.ToInt32(dgvDistrict.DataKeys[gvrow.RowIndex].Value.ToString());
                objDistrict.DistrictName = "";
                objDistrict.StateID = 0;
                //objDistrict.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                objMessageInfo = oblDistrict.ManageItemMaster(objDistrict, cmdMode);
                BindDistrict();
                updateDistrictBdInfo.Update();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDistrict = null;
                //objMessageInfo = null;
                oblDistrict = null;
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateDistrictBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgDistrict");
            if (Page.IsValid)
            {
                ManageDistrict();
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
                BindDistrict();
                updateDistrictBdInfo.Update();
                updateDistrict.Update();
                this.ModalPopupExtender1.Show();
            }
        }
        #endregion
        #region UserDefindeFunction
        void BindState(int id)
        {
            
            oblState = new Store.State.BusinessLogic.State();
            try
            {
                objStatelist = oblState.GetAllStateList(id, 0, "");
                if (objStatelist != null)
                {
                    ddlState.DataSource = objStatelist;
                    ddlState.DataTextField = "StateName";
                    ddlState.DataValueField = "StateID";
                    ddlState.DataBind();
                    ddlState.Items.Insert(0, "<--Select State-->");
                }
                else
                {
                    ddlState.DataSource = null;
                    ddlState.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                oblState = null;
                objStatelist = null;
            }
        }
        void BindDistrict()
        {
            oblDistrict = new Store.District.BusinessLogic.District();
            try
            {
                objDistrictlist = oblDistrict.GetAllDistrictList(0, 0, "");
                if (objDistrictlist != null)
                {
                    dgvDistrict.DataSource = objDistrictlist;
                    dgvDistrict.DataBind();
                }
                else
                {
                    dgvDistrict.DataSource = null;
                    dgvDistrict.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                oblDistrict = null;
                objDistrictlist = null;
            }


        }
        void ManageDistrict()
        {
            objDistrict = new Store.District.BusinessObject.District();
            oblDistrict = new Store.District.BusinessLogic.District();
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objDistrict.DistrictID = Convert.ToInt32(txtDistrictId.Text);
                    //objDistrict.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());
                }
                else
                {
                    objDistrict.DistrictID = 0;
                    //objDistrict.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                }
                objDistrict.DistrictName = Convert.ToString(txtDistrict.Text);
                objDistrict.CountryID = Convert.ToInt32(ddlCountry.SelectedItem.Value);
                objDistrict.StateID = Convert.ToInt32(ddlState.SelectedItem.Value);
                objDistrict.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                objMessageInfo = oblDistrict.ManageItemMaster(objDistrict, cmdMode);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objDistrict = null;
                //objMessageInfo = null;
                oblDistrict = null;
            }

        }
        void BindCountry()
        {
            oblCountry = new Store.Country.BusinessLogic.Country();
            try
            {
                objCountrylist = oblCountry.GetAllCountryList(0, 0, "");
                if (objCountrylist != null)
                {
                    ddlCountry.DataSource = objCountrylist;
                    ddlCountry.DataValueField = "CountryID";
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataBind();
                    ddlCountry.Items.Insert(0, "<--Select Country-->");
                }
                else
                {
                    ddlCountry.DataSource = null;
                    ddlCountry.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblCountry = null;
                objCountrylist = null;
            }


        }
        void ResetForm()
        {
            txtDistrict.Text = "";
            ddlCountry.ClearSelection();
            ddlState.ClearSelection();
            ddlCountry.Focus();
        }

        #endregion

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlCountry.SelectedValue);
            BindState(id);
            ddlState.Focus();
        }
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
