using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class City : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserId"] != null)
            //{
                if (!Page.IsPostBack)
                {
                    BindCity();
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
        Store.District.BusinessLogic.District oblDistrict = null;
        Store.District.BusinessObject.DistrictList objDistrictlist = null;
        Store.City.BusinessLogic.City oblCity = null;
        Store.City.BusinessObject.CityList objCitylist = null;
        Store.City.BusinessObject.City objCity = null;
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
            txtCityId.Text = dgvCity.DataKeys[gvrow.RowIndex].Value.ToString();
            txtCity.Text = gvrow.Cells[0].Text;
            ddlCountry.SelectedItem.Selected = false;
            ddlCountry.Items.FindByText(gvrow.Cells[1].Text.ToString()).Selected = true;
            int idc = Convert.ToInt32(ddlCountry.SelectedValue);
            BindState(idc);
            ddlState.SelectedItem.Selected = false;
            ddlState.Items.FindByText(gvrow.Cells[3].Text.ToString()).Selected = true;
            int id = Convert.ToInt32(ddlState.SelectedValue);
            bindDistrict(id);
            ddlDistrict.SelectedItem.Selected = false;
            ddlDistrict.Items.FindByText(gvrow.Cells[2].Text.ToString()).Selected = true;
            
            updateCityBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
                      
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objCity = new Store.City.BusinessObject.City();
            oblCity = new Store.City.BusinessLogic.City();               

            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objCity.CityID = Convert.ToInt32(dgvCity.DataKeys[gvrow.RowIndex].Value.ToString());
                objCity.CityName = "";
                objCity.StateID = 0;
                //objCity.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                objMessageInfo = oblCity.ManageItemMaster(objCity, cmdMode);
                BindCity();
                updateCityBdInfo.Update();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);

            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(City).FullName, 1);
            }
            finally
            {
                objCity = null;
                objMessageInfo = null;
                oblCity = null;
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateCityBdInfo.Update();
            this.ModalPopupExtender1.Show();

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgCity");
            if (Page.IsValid)
            {
                ManageCity();
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
                BindCity();
                updateCityBdInfo.Update();
                updateCity.Update();
                this.ModalPopupExtender1.Show();

            }
        }
        #endregion
        #region UserDefindeFunction

        void BindCity()
        {
            oblCity = new Store.City.BusinessLogic.City();
            try
            {
                objCitylist = oblCity.GetAllCityList(0, 0, "");
                if (objCitylist != null)
                {
                    dgvCity.DataSource = objCitylist;
                    dgvCity.DataBind();
                }
                else
                {
                    dgvCity.DataSource = null;
                    dgvCity.DataBind();
                }
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(City).FullName, 1);
            }
            finally
            {
                oblCity = null;
                objCitylist = null;
            }


        }
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
        
        void ManageCity()
        {
            objCity = new Store.City.BusinessObject.City();
            oblCity = new Store.City.BusinessLogic.City();
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objCity.CityID = Convert.ToInt32(txtCityId.Text);
                    //objCity.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());
                }
                else
                {
                    objCity.CityID = 0;
                    //objCity.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                }
                objCity.CityName = Convert.ToString(txtCity.Text);
                objCity.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
                objCity.StateID = Convert.ToInt32(ddlState.SelectedItem.Value);
                objCity.DistrictID = Convert.ToInt32(ddlDistrict.SelectedItem.Value);
                objMessageInfo = oblCity.ManageItemMaster(objCity, cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(City).FullName, 1);
            }
            finally
            {
                objCity = null;
                //objMessageInfo = null;
                oblCity = null;
            }

        }

        void ResetForm()
        {
            ddlCountry.ClearSelection();
            ddlState.ClearSelection();
            ddlDistrict.ClearSelection();
            txtCity.Text = "";
            ddlCountry.Focus();
        }
        void bindDistrict( int id)
        {
            oblDistrict = new Store.District.BusinessLogic.District();
            try
            {
                objDistrictlist = oblDistrict.GetAllDistrictList(id, 0, "");
                if (objDistrictlist != null)
                {
                    ddlDistrict.DataSource = objDistrictlist;
                    ddlDistrict.DataTextField = "DistrictName";
                    ddlDistrict.DataValueField = "DistrictID";
                    ddlDistrict.DataBind();
                    ddlDistrict.Items.Insert(0, "<--Select District-->");
                }
                else
                {
                    ddlDistrict.DataSource = null;
                    ddlDistrict.DataBind();
                }
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(City).FullName, 1);
            }
            finally
            {
                oblDistrict = null;
                objDistrictlist = null;
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
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataValueField = "CountryID";
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
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(City).FullName, 1);
            }
            finally
            {
                oblCountry = null;
                objCountrylist = null;
            }


        }
        #endregion

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id =Convert.ToInt32(ddlState.SelectedItem.Value);
            bindDistrict(id);
            ddlDistrict.Focus();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
            this.ModalPopupExtender1.Hide();
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlCountry.SelectedValue);
            BindState(id);
            ddlState.Focus();
        }
        protected void lbtnClose_Click(object sender, EventArgs e)
        {
            ResetForm();
            this.ModalPopupExtender1.Hide();
        }

    }
}
