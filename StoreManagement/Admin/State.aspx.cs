
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;
using System.Collections;

namespace StoreManagement.Admin
{
    public partial class State : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserId"] != null)
            //{
                if (!Page.IsPostBack)
                {
                    BindState();
                    BindCountry();
                }
            //}
            //else
            //{
              //  Response.Redirect("../Login.aspx");
            //}
        }
        Store.Country.BusinessLogic.Country oblCountry = null;
        Store.Country.BusinessObject.CountryList objCountrylist = null;
        Store.State.BusinessLogic.State oblState = null;
        Store.State.BusinessObject.StateList objStatelist = null;
        Store.State.BusinessObject.State objState = null;
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
            txtStateId.Text = dgvState.DataKeys[gvrow.RowIndex].Value.ToString();
            txtState.Text = gvrow.Cells[0].Text;
            //ddlCountry.SelectedItem.Value= gvrow.Cells[1].Text;
            ddlCountry.SelectedItem.Selected = false;
            ddlCountry.Items.FindByText(gvrow.Cells[1].Text.ToString()).Selected = true;
            updateStateBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objState = new Store.State.BusinessObject.State();
            oblState = new Store.State.BusinessLogic.State();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objState.StateID = Convert.ToInt32(dgvState.DataKeys[gvrow.RowIndex].Value.ToString());
                objState.StateName = "";
                //objState.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                objMessageInfo = oblState.ManageItemMaster(objState, cmdMode);
                BindState();
                updateStateBdInfo.Update();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objState = null;
                objMessageInfo = null;
                oblState = null;
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateStateBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgState");
            if (Page.IsValid)
            {
                ManageState();
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
                BindState();
                updateStateBdInfo.Update();
                updateState.Update();
                this.ModalPopupExtender1.Show();
            }
        }
        #endregion
        #region UserDefindeFunction

        void BindState()
        {
            oblState = new Store.State.BusinessLogic.State();
            try
            {
                objStatelist = oblState.GetAllStateList(0, 0, "");
                if (objStatelist != null)
                {
                    dgvState.DataSource = objStatelist;
                    dgvState.DataBind();
                }
                else
                {
                    dgvState.DataSource = null;
                    dgvState.DataBind();
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
        void ManageState()
        {
            objState = new Store.State.BusinessObject.State();
            oblState = new Store.State.BusinessLogic.State();
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objState.StateID = Convert.ToInt32(txtStateId.Text);
                    //objState.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());
                   
                }
                else
                {
                    objState.StateID = 0;
                    //objState.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                }
                objState.StateName = Convert.ToString(txtState.Text);
                objState.CountryID = Convert.ToInt32(ddlCountry.SelectedItem.Value);
                //objState.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                objMessageInfo = oblState.ManageItemMaster(objState, cmdMode);
            }
            catch (Exception ex)
            {
                throw ex;
             //   Global.WriteErrorLog("Error Occured" + ex.ToString());
            }
            finally
            {
                objState = null;
                //objMessageInfo = null;
                oblState = null;
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
                    //ddlCountry.Items.Add(new ListItem("Select", "-1", true));
                    ddlCountry.DataSource = objCountrylist;
                    ddlCountry.DataValueField = "CountryID";
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataBind();
                    ddlCountry.Items.Insert(0, "<--Select Country-->");
                    //ddlCountry.Items.Add()
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
            txtState.Text = "";
            ddlCountry.ClearSelection();
            ddlCountry.Focus();
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