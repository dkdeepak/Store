using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;
using System.Globalization;
namespace StoreManagement.Admin
{
    public partial class Country : System.Web.UI.Page
    {
        
        Store.Country.BusinessLogic.Country oblCountry = null;
        Store.Country.BusinessObject.CountryList objCountrylist = null;
        Store.Country.BusinessObject.Country objCountry = null;
        Store.Common.MessageInfo objMessageInfo = null;
        
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }
       
        #region ControlDefindeFunction
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserId"] != null)
            //{
                if (!IsPostBack)
                {
                    BindCountry();
                }
            //}
            //else
            //{
              //  Response.Redirect("../Login.aspx");
            //}
            

        }

        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            ResetForm();
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtCountryId.Text = dgvCountry.DataKeys[gvrow.RowIndex].Value.ToString();
            txtCountry.Text = gvrow.Cells[0].Text;
            updateCountryBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objCountry = new Store.Country.BusinessObject.Country();
            oblCountry = new Store.Country.BusinessLogic.Country();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objCountry.CountryID = Convert.ToInt32(dgvCountry.DataKeys[gvrow.RowIndex].Value.ToString());
                objCountry.CountryName = "";
                objCountry.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                objMessageInfo = oblCountry.ManageItemMaster(objCountry, cmdMode);
                BindCountry();
                updateCountryBdInfo.Update();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objCountry = null;
                oblCountry = null;
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateCountryBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgCountry");
            if (Page.IsValid)
            {
                ManageCountry();
                if (objMessageInfo.ErrorCode == -101)
                {

                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.ErrorMessage + "')", true);
                }
                if (objMessageInfo.TranID > 0)
                {
                    ResetForm();
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
                }
                BindCountry();
                updateCountryBdInfo.Update();
                updateCountry.Update();
                this.ModalPopupExtender1.Show();
            }
        }
        #endregion
        #region UserDefindeFunction

        void BindCountry()
        {
            oblCountry = new Store.Country.BusinessLogic.Country();
            try
            {
                objCountrylist = oblCountry.GetAllCountryList(0, 0, "");
                if (objCountrylist != null)
                {
                    dgvCountry.DataSource = objCountrylist;
                    dgvCountry.DataBind();
                }
                else
                {
                    dgvCountry.DataSource = null;
                    dgvCountry.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw;

            }
            finally
            {
                oblCountry = null;
                objCountrylist = null;
            }


        }
        void ManageCountry()
        {   
            objCountry = new Store.Country.BusinessObject.Country();
            oblCountry = new Store.Country.BusinessLogic.Country();
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objCountry.CountryID = Convert.ToInt32(txtCountryId.Text);
                    //objCountry.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());
                }
                else
                {
                    objCountry.CountryID = 0;
                    //objCountry.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                }
                objCountry.CountryName = Convert.ToString(txtCountry.Text);
                objMessageInfo = oblCountry.ManageItemMaster(objCountry, cmdMode);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objCountry = null;
                oblCountry = null;

            }

        }

        void ResetForm()
        {
            txtCountry.Text = "";
            txtCountryId.Text = "";
            txtCountry.Focus();
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