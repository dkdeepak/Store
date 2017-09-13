using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class VendorInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                BindVendorInfo();
                BindCountry();
                BindTypeOfVendor();
                if (Request.QueryString["page"] != null)
                {
                    this.ModalPopupExtender1.Show();
                }
            }
        }
        Store.TypeOfVendor.BusinessLogic.TypeOfVendor oblTypeOfVendor = null;
        Store.TypeOfVendor.BusinessObject.TypeOfVendorList obTypeOfVendorList = null;
        Store.State.BusinessLogic.State oblState = null;
        Store.State.BusinessObject.StateList objStatelist = null;
        Store.City.BusinessLogic.City oblCity = null;
        Store.City.BusinessObject.CityList objCitylist = null;
        Store.Country.BusinessLogic.Country oblCountry = null;
        Store.Country.BusinessObject.CountryList objCountrylist = null;
        
        Store.VendorInfo.BusinessLogic.VendorInfo oblVendorInfo = null;
        Store.VendorInfo.BusinessObject.VendorInfo objVendorInfo = null;
        Store.VendorInfo.BusinessObject.VendorInfoList objVendorInfoList = null;
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
            txtVendorID.Text = dgvVendorInfo.DataKeys[gvrow.RowIndex].Value.ToString();
            txtVendorName.Text = gvrow.Cells[0].Text;
            txtVendorDisplayName.Text = gvrow.Cells[1].Text;
            ddlTypeofVendorID.SelectedItem.Selected = false;
            ddlTypeofVendorID.Items.FindByText(gvrow.Cells[2].Text.ToString()).Selected = true;
            txtAddress.Text = gvrow.Cells[3].Text;
            ddlCountryID.SelectedItem.Selected = false;
            ddlCountryID.Items.FindByText(gvrow.Cells[4].Text.ToString()).Selected = true;
            int idc = Convert.ToInt32(ddlCountryID.SelectedValue);
            bindState(idc);
            ddlStateID.SelectedItem.Selected = false;
            ddlStateID.Items.FindByText(gvrow.Cells[5].Text.ToString()).Selected = true;
            int ids = Convert.ToInt32(ddlStateID.SelectedValue);
            bindCity(ids);
            ddlCityID.SelectedItem.Selected = false;
            ddlCityID.Items.FindByText(gvrow.Cells[6].Text.ToString()).Selected = true;
            txtPinID.Text = gvrow.Cells[7].Text;
            txtConcernPerson.Text = gvrow.Cells[8].Text;
            txtPhoneNo.Text = gvrow.Cells[9].Text;
            txtMobileNo.Text = gvrow.Cells[10].Text;
            txtEmailID.Text = gvrow.Cells[11].Text;
            txtWebsiteAddress.Text = gvrow.Cells[12].Text;
            txtPanNo.Text = gvrow.Cells[13].Text;
            txtGstNo.Text = gvrow.Cells[14].Text;
            txtServiceTaxNo.Text = gvrow.Cells[15].Text;
            int i=Convert.ToInt32(gvrow.Cells[13].Text);
            if (i == 1)
                cbIsActive.Checked = true;
            else
                cbIsActive.Checked = false;
            updateVendorBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objVendorInfo = new Store.VendorInfo.BusinessObject.VendorInfo();
            oblVendorInfo = new Store.VendorInfo.BusinessLogic.VendorInfo();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objVendorInfo.VendorID = Convert.ToInt32(dgvVendorInfo.DataKeys[gvrow.RowIndex].Value.ToString());
                objVendorInfo.VendorName = "";
                objVendorInfo.VendorDisplayName = "";
                objVendorInfo.TypeofVendorID = 0;
                objVendorInfo.Address = "";
                objVendorInfo.CityID = 0;
                objVendorInfo.StateID = 0;
                objVendorInfo.CountryID = 0;
                objVendorInfo.PinID = 0;
                objVendorInfo.ConcernPerson = 0;
                objVendorInfo.PhoneNo = 0;
                objVendorInfo.MobileNo = 0;
                objVendorInfo.EmailID ="";
                objVendorInfo.WebsiteAddress = "";
                objVendorInfo.PanNo = "";
                objVendorInfo.GstNo = "";
                objVendorInfo.ServiceTaxNo = "";
                objVendorInfo.CreatedBy = 1;
                objMessageInfo = oblVendorInfo.ManageItemMaster(objVendorInfo, cmdMode);
                BindVendorInfo();
                updateVendorBdInfo.Update();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
            }
            catch (Exception ex)
            {

            }
            finally
            {
               objVendorInfo= null;
                objMessageInfo = null;
                oblTypeOfVendor = null;
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateVendorBdInfo.Update();
            this.ModalPopupExtender1.Show();
            updateVendorInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgVendorInfo");
            if (Page.IsValid)
            {
                ManageVendorInfo();
                if (objMessageInfo.ErrorCode == -101)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.ErrorMessage + "')", true);
                }
                if (objMessageInfo.TranID > 0)
                {
                    ResetForm();
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
                    if (Request.QueryString["page"] != null)
                    {
                        Response.Redirect(Request.QueryString["page"].ToString()+"?id="+objMessageInfo.TranID);
                    }
                }
                this.ModalPopupExtender1.Hide();
                BindVendorInfo();
                updateVendorBdInfo.Update();
                updateVendorInfo.Update();
                this.ModalPopupExtender1.Show();
            }
        }
        #endregion
        #region VendorDefindeFunction
        void BindVendorInfo()
        {
            oblVendorInfo = new Store.VendorInfo.BusinessLogic.VendorInfo();
            try
            {
                objVendorInfoList = oblVendorInfo.GetAllVendorInfoList(0, 0, "");
                if (objVendorInfoList != null)
                {
                    dgvVendorInfo.DataSource = objVendorInfoList;
                    dgvVendorInfo.DataBind();
                }
                else
                {
                    dgvVendorInfo.DataSource = null;
                    dgvVendorInfo.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblVendorInfo = null;
                objVendorInfoList = null;
            }


        }
        void ManageVendorInfo()
        {
            objVendorInfo = new Store.VendorInfo.BusinessObject.VendorInfo();
            oblVendorInfo = new Store.VendorInfo.BusinessLogic.VendorInfo();
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objVendorInfo.VendorID = Convert.ToInt32(txtVendorID.Text);
                    //objVendorInfo.ModifiedBy = Convert.ToInt32(Session["VendorId"]);
                }
                else
                {
                    objVendorInfo.VendorID = 0;
                    //objVendorInfo.CreatedBy = Convert.ToInt32(Session["VendorId"]);
                }
                objVendorInfo.VendorName = Convert.ToString(txtVendorName.Text);
                objVendorInfo.VendorDisplayName = Convert.ToString(txtVendorDisplayName.Text);
                objVendorInfo.TypeofVendorID = Convert.ToInt32(ddlTypeofVendorID.SelectedItem.Value);
                objVendorInfo.Address = Convert.ToString(txtAddress.Text);
                objVendorInfo.CityID = Convert.ToInt32(ddlCityID.SelectedItem.Value);
                objVendorInfo.StateID = Convert.ToInt32(ddlStateID.SelectedItem.Value);
                objVendorInfo.CountryID = Convert.ToInt32(ddlCountryID.SelectedItem.Value);
                objVendorInfo.PinID = Convert.ToInt32(txtPinID.Text);
                objVendorInfo.ConcernPerson = Convert.ToInt32(txtConcernPerson.Text);
                objVendorInfo.PhoneNo = Convert.ToInt32(txtPhoneNo.Text);
                objVendorInfo.MobileNo = Convert.ToInt32(txtMobileNo.Text);
                objVendorInfo.EmailID = Convert.ToString(txtEmailID.Text);
                objVendorInfo.WebsiteAddress = Convert.ToString(txtWebsiteAddress.Text);
                objVendorInfo.PanNo = Convert.ToString(txtPanNo.Text);
                objVendorInfo.GstNo = Convert.ToString(txtGstNo.Text);
                objVendorInfo.ServiceTaxNo = Convert.ToString(txtServiceTaxNo.Text);
                if (cbIsActive.Checked)
                    objVendorInfo.IsActive = 1;
                else
                    objVendorInfo.IsActive = 0;
                
                objMessageInfo = oblVendorInfo.ManageItemMaster(objVendorInfo, cmdMode);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                objVendorInfo = null;
                //objMessageInfo = null;
                oblVendorInfo = null;
            }

        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        void ResetForm()
        {
            txtVendorID.Text = "";
            txtVendorName.Text = "";
            txtVendorDisplayName.Text = "";
            ddlTypeofVendorID.ClearSelection();
            txtAddress.Text = "";
            ddlCountryID.ClearSelection();
            ddlCityID.ClearSelection();
            ddlStateID.ClearSelection();
            txtPinID.Text = "";
            txtConcernPerson.Text = "";
            txtPhoneNo.Text = "";
            txtMobileNo.Text = "";
            txtEmailID.Text = "";
            txtWebsiteAddress.Text = "";
            cbIsActive.Checked = false;
            txtPanNo.Text = "";
            txtGstNo.Text = "";
            txtServiceTaxNo.Text = "";
            txtVendorName.Focus();
        }
        void BindCountry()
        {
            oblCountry = new Store.Country.BusinessLogic.Country();
            try
            {
                objCountrylist = oblCountry.GetAllCountryList(0, 0, "");
                if (objCountrylist != null)
                {
                    ddlCountryID.DataSource = objCountrylist;
                    ddlCountryID.DataTextField = "CountryName";
                    ddlCountryID.DataValueField = "CountryID";
                    ddlCountryID.DataBind();
                    ddlCountryID.Items.Insert(0, "<--Select Country-->");

                }
                else
                {
                    ddlCountryID.DataSource = null;
                    ddlCountryID.DataBind();
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
        void BindTypeOfVendor()
        {
            oblTypeOfVendor = new Store.TypeOfVendor.BusinessLogic.TypeOfVendor();
            try
            {
                obTypeOfVendorList = oblTypeOfVendor.GetAllTypeOfVendorList(0, 0, "");
                if (obTypeOfVendorList != null)
                {
                    ddlTypeofVendorID.DataSource = obTypeOfVendorList;
                    ddlTypeofVendorID.DataTextField = "TypeofVendorName";
                    ddlTypeofVendorID.DataValueField = "TypeOfVendorID";
                    ddlTypeofVendorID.DataBind();
                    ddlTypeofVendorID.Items.Insert(0, "<--Select Vendor Type-->");
                }
                else
                {
                    ddlTypeofVendorID.DataSource = null;
                    ddlTypeofVendorID.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oblTypeOfVendor = null;
                obTypeOfVendorList = null;
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
                    ddlStateID.DataSource = objStatelist;
                    ddlStateID.DataTextField = "StateName";
                    ddlStateID.DataValueField = "StateID";
                    ddlStateID.DataBind();
                    ddlStateID.Items.Insert(0, "<--Select State-->");
                }
                else
                {
                    ddlStateID.DataSource = null;
                    ddlStateID.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oblState = null;
                objStatelist = null;
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
                    ddlCityID.DataSource = objCitylist;
                    ddlCityID.DataValueField = "CityID";
                    ddlCityID.DataTextField = "CityName";
                    ddlCityID.DataBind();
                    ddlCityID.Items.Insert(0, "<--Select City-->");
                }
                else
                {
                    ddlCityID.DataSource = null;
                    ddlCityID.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oblCity = null;
                objCitylist = null;
            }
        }
        #endregion

        protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlCountryID.SelectedItem.Value);
            bindState(id);
            ddlStateID.Focus();
        }

        protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlStateID.SelectedItem.Value);
            bindCity(id);
            ddlCityID.Focus();
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