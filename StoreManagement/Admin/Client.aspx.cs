using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class Client : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserId"] != null)
            //{
                if (!IsPostBack)
                {
                    BindClient();
                    BindCountry();
                }
            //}

        }
        Store.Client.BusinessLogic.Client oblClient = null;
        Store.Client.BusinessObject.Client objClient = null;
        Store.Client.BusinessObject.ClientList objClientList = null;
        Store.Common.MessageInfo objMessageInfo = null;
        Store.Country.BusinessLogic.Country oblCountry = null;
        Store.Country.BusinessObject.CountryList objCountrylist = null;
        Store.City.BusinessLogic.City oblCity = null;
        Store.City.BusinessObject.CityList objCitylist = null;
        Store.State.BusinessLogic.State oblState = null;
        Store.State.BusinessObject.StateList objStatelist = null;
        Store.District.BusinessLogic.District oblDistrict = null;
        Store.District.BusinessObject.DistrictList objDistrictlist = null;
        public Store.Common.CommandMode cmdMode
        {
            get { return ViewState["cmdMode"] != null ? (Store.Common.CommandMode)ViewState["cmdMode"] : Store.Common.CommandMode.N; }
            set { ViewState["cmdMode"] = value; }
        }

        #region CustomDefinedFunction
        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            ResetForm();
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txtClientId.Text =dgvClient.DataKeys[gvrow.RowIndex].Value.ToString();
            txtClientName.Text = gvrow.Cells[0].Text;
            txtClientDisplayName.Text = gvrow.Cells[1].Text;
            txtAddress.Text = gvrow.Cells[2].Text;
            ddlCountry.SelectedItem.Selected = false;
            ddlCountry.Items.FindByText(gvrow.Cells[3].Text.ToString()).Selected = true;
            int ids = Convert.ToInt32(ddlCountry.SelectedValue);
            bindState(ids);
            ddlState.SelectedItem.Selected = false;
            ddlState.Items.FindByText(gvrow.Cells[4].Text.ToString()).Selected = true;
            int idc = Convert.ToInt32(ddlState.SelectedValue);
            bindCity(idc);
            ddlCity.SelectedItem.Selected = false;
            ddlCity.Items.FindByText(gvrow.Cells[5].Text.ToString()).Selected = true;
            txtPinId.Text = gvrow.Cells[6].Text;
            int i = Convert.ToInt32(gvrow.Cells[7].Text);
            if (i == 1)
                cbIsActive.Checked = true;
            else
                cbIsActive.Checked = false;
            string txtStatus = gvrow.Cells[1].Text;
            updateClientBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
            
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objClient = new Store.Client.BusinessObject.Client();
            oblClient = new Store.Client.BusinessLogic.Client();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objClient.ClientID = Convert.ToInt32(dgvClient.DataKeys[gvrow.RowIndex].Value.ToString());
                objClient.ClientName = "";
                objClient.ClientDisplayName = "";
                objClient.Address = "";
                objClient.CityID = 0;
                objClient.StateID = 1;
                objClient.CountryID = 2;
                objClient.PinID = 3;
                objClient.CreatedBy = 1;
                objMessageInfo =oblClient.ManageClientMaster(objClient, cmdMode);
                BindClient();
                updateClientBdInfo.Update();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);

            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Client).FullName, 1);
            }
            finally
            {
                objClient = null;
                objMessageInfo = null;
                oblClient = null;
               
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateClientBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgClient");
            if (Page.IsValid)
            {
                ManageClientCategory();
                if (objMessageInfo.ErrorCode == -101)
                {

                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.ErrorMessage + "')", true);
                }
                if (objMessageInfo.TranID > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
                }
                this.ModalPopupExtender1.Hide();
                BindClient();
                updateClientBdInfo.Update();
                updateClient.Update();
                this.ModalPopupExtender1.Show();
            }
        }
        #endregion

        #region UserDefinedFunction
        void BindClient()
        {
           oblClient = new Store.Client.BusinessLogic.Client();
            
            try
            {
               objClientList =oblClient.GetAllClientList(0, 0, "");
                
                if (objClientList != null)
                {
                   dgvClient.DataSource =objClientList;
                   dgvClient.DataBind();
                }
                else
                {
                    dgvClient.DataSource = null;
                    dgvClient.DataBind();
                }
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Client).FullName, 1);
            }
            finally
            {
               oblClient = null;
               objClientList = null;
            }


        }
        void ManageClientCategory()
        {
           objClient = new Store. Client.BusinessObject.Client();
           oblClient = new Store.Client.BusinessLogic.Client();
           
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                
                {
                   objClient.ClientID = Convert.ToInt32(txtClientId.Text);
                   //objClient.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());

                }
                else
                {
                    objClient.ClientID = 0;
                    //objClient.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                }
                objClient.ClientName = Convert.ToString(txtClientName.Text);
                objClient.ClientDisplayName = Convert.ToString(txtClientDisplayName.Text);
                objClient.Address = Convert.ToString(txtAddress.Text);
                objClient.CityID = Convert.ToInt32(ddlCity.SelectedItem.Value);
                objClient.StateID = Convert.ToInt32(ddlState.SelectedItem.Value);
                objClient.CountryID = Convert.ToInt32(ddlCountry.SelectedItem.Value);
                objClient.PinID = Convert.ToInt32(txtPinId.Text);
                if (cbIsActive.Checked)
                    objClient.IsActive = 1;
                else
                    objClient.IsActive = 0;
                objMessageInfo = oblClient.ManageClientMaster(objClient, cmdMode);
                
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Client).FullName, 1);
            }
            finally
            {
                objClient = null;
                //objMessageInfo = null;
                oblClient = null;
               
            }

        }
        void ResetForm()
        {
            txtClientId.Text = "";
            txtAddress.Text = "";
            txtClientDisplayName.Text = "";
            txtClientName.Text = "";
            txtPinId.Text = "";
            ddlCountry.ClearSelection();
            ddlState.ClearSelection();
            ddlCity.ClearSelection();
            txtClientName.Focus();
        }
        #endregion
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
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Client).FullName, 1);
            }
            finally
            {
                oblCountry = null;
                objCountrylist = null;
            }


        }
        void bindCity(int id)
        {
            oblCity = new Store.City.BusinessLogic.City();
            try
            {
                objCitylist = oblCity.GetAllCityList(id, 0, "");
                if (objCitylist != null)
                {
                    ddlCity.DataSource = objCitylist;
                    ddlCity.DataTextField = "CityName";
                    ddlCity.DataValueField = "CityID";
                    ddlCity.DataBind();
                    ddlCity.Items.Insert(0, "<--Select City-->");
                }
                else
                {
                    ddlCity.DataSource = null;
                    ddlCity.DataBind();
                }
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Client).FullName, 1);
            }
            finally
            {
                oblCity = null;
                objCitylist = null;
            }


        }
        void bindState(int id)
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
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Client).FullName, 1);
            }
            finally
            {
                oblState = null;
                objStatelist = null;
            }
        }
        protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            bindState(id);
            ddlState.Focus();
        }

        protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlState.SelectedItem.Value);
            bindCity(id);
            ddlCity.Focus();
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