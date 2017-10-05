using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindUserInfo();
                BindCountry();
                BindTypeOfUser();
            }
        }
        Store.TypeOfUser.BusinessLogic.TypeOfUser oblTypeOfUser = null;
        Store.TypeOfUser.BusinessObject.TypeOfUserList obTypeOfUserList = null;
        Store.State.BusinessLogic.State oblState = null;
        Store.State.BusinessObject.StateList objStatelist = null;
        Store.City.BusinessLogic.City oblCity = null;
        Store.City.BusinessObject.CityList objCitylist = null;
        Store.Country.BusinessLogic.Country oblCountry = null;
        Store.Country.BusinessObject.CountryList objCountrylist = null;
        
        Store.UserInfo.BusinessLogic.UserInfo oblUserInfo = null;
        Store.UserInfo.BusinessObject.UserInfo objUserInfo = null;
        Store.UserInfo.BusinessObject.UserInfoList objUserInfoList = null;
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
            txtUserID.Text = dgvUserInfo.DataKeys[gvrow.RowIndex].Value.ToString();
            txtUserName.Text = gvrow.Cells[0].Text;
            txtUserDisplayName.Text = gvrow.Cells[1].Text;
            ddlTypeofUserID.SelectedItem.Selected = false;
            ddlTypeofUserID.Items.FindByText(gvrow.Cells[2].Text.ToString()).Selected = true;
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
            int i=Convert.ToInt32(gvrow.Cells[13].Text);
            if (i == 1)
                cbIsActive.Checked = true;
            else
                cbIsActive.Checked = false;
            updateUserBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objUserInfo = new Store.UserInfo.BusinessObject.UserInfo();
            oblUserInfo = new Store.UserInfo.BusinessLogic.UserInfo();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objUserInfo.UserID = Convert.ToInt32(dgvUserInfo.DataKeys[gvrow.RowIndex].Value.ToString());
                objUserInfo.UserName = "";
                objUserInfo.UserDisplayName = "";
                objUserInfo.TypeofUserID = 0;
                objUserInfo.Address = "";
                objUserInfo.CityID = 0;
                objUserInfo.StateID = 0;
                objUserInfo.CountryID = 0;
                objUserInfo.PinID = 0;
                objUserInfo.ConcernPerson = 0;
                objUserInfo.PhoneNo = 0;
                objUserInfo.MobileNo = 0;
                objUserInfo.EmailID ="";
                objUserInfo.WebsiteAddress = "";
                objUserInfo.CreatedBy = 1;
                objMessageInfo = oblUserInfo.ManageItemMaster(objUserInfo, cmdMode);
                BindUserInfo();
                updateUserBdInfo.Update();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(UserInfo).FullName, 1);
            }
            finally
            {
               objUserInfo= null;
                objMessageInfo = null;
                oblTypeOfUser = null;
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateUserBdInfo.Update();
            this.ModalPopupExtender1.Show();
            updateUserInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgUserInfo");
            if (Page.IsValid)
            {
                ManageUserInfo();
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
                BindUserInfo();
                updateUserBdInfo.Update();
                updateUserInfo.Update();
                this.ModalPopupExtender1.Show();
            }
        }
        #endregion
        #region UserDefindeFunction
        void BindUserInfo()
        {
            oblUserInfo = new Store.UserInfo.BusinessLogic.UserInfo();
            try
            {
                objUserInfoList = oblUserInfo.GetAllUserInfoList(0, 0, "");
                if (objUserInfoList != null)
                {
                    dgvUserInfo.DataSource = objUserInfoList;
                    dgvUserInfo.DataBind();
                }
                else
                {
                    dgvUserInfo.DataSource = null;
                    dgvUserInfo.DataBind();
                }
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(UserInfo).FullName, 1);

            }
            finally
            {
                oblUserInfo = null;
                objUserInfoList = null;
            }


        }
        void ManageUserInfo()
        {
            objUserInfo = new Store.UserInfo.BusinessObject.UserInfo();
            oblUserInfo = new Store.UserInfo.BusinessLogic.UserInfo();
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objUserInfo.UserID = Convert.ToInt32(txtUserID.Text);
                    //objUserInfo.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                }
                else
                {
                    objUserInfo.UserID = 0;
                    //objUserInfo.CreatedBy = Convert.ToInt32(Session["UserId"]);
                }
                objUserInfo.UserName = Convert.ToString(txtUserName.Text);
                objUserInfo.UserDisplayName = Convert.ToString(txtUserDisplayName.Text);
                objUserInfo.TypeofUserID = Convert.ToInt32(ddlTypeofUserID.SelectedItem.Value);
                objUserInfo.Address = Convert.ToString(txtAddress.Text);
                objUserInfo.CityID = Convert.ToInt32(ddlCityID.SelectedItem.Value);
                objUserInfo.StateID = Convert.ToInt32(ddlStateID.SelectedItem.Value);
                objUserInfo.CountryID = Convert.ToInt32(ddlCountryID.SelectedItem.Value);
                objUserInfo.PinID = Convert.ToInt32(txtPinID.Text);
                objUserInfo.ConcernPerson = Convert.ToInt32(txtConcernPerson.Text);
                objUserInfo.PhoneNo = Convert.ToInt32(txtPhoneNo.Text);
                objUserInfo.MobileNo = Convert.ToInt32(txtMobileNo.Text);
                objUserInfo.EmailID = Convert.ToString(txtEmailID.Text);
                objUserInfo.WebsiteAddress = Convert.ToString(txtWebsiteAddress.Text);
                if (cbIsActive.Checked)
                    objUserInfo.IsActive = 1;
                else
                    objUserInfo.IsActive = 0;
                
                objMessageInfo = oblUserInfo.ManageItemMaster(objUserInfo, cmdMode);

            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(UserInfo).FullName, 1);
            }
            finally
            {
                objUserInfo = null;
                //objMessageInfo = null;
                oblUserInfo = null;
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
            txtUserID.Text = "";
            txtUserName.Text = "";
            txtUserDisplayName.Text = "";
            ddlTypeofUserID.ClearSelection();
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
            txtUserName.Focus();
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
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(UserInfo).FullName, 1);
            }
            finally
            {
                oblCountry = null;
                objCountrylist = null;
            }


        }
        void BindTypeOfUser()
        {
            oblTypeOfUser = new Store.TypeOfUser.BusinessLogic.TypeOfUser();
            try
            {
                obTypeOfUserList = oblTypeOfUser.GetAllTypeOfUserList(0, 0, "");
                if (obTypeOfUserList != null)
                {
                    ddlTypeofUserID.DataSource = obTypeOfUserList;
                    ddlTypeofUserID.DataTextField = "TypeofUserName";
                    ddlTypeofUserID.DataValueField = "TypeOfUserID";
                    ddlTypeofUserID.DataBind();
                    ddlTypeofUserID.Items.Insert(0, "<--Select User Type-->");
                }
                else
                {
                    ddlTypeofUserID.DataSource = null;
                    ddlTypeofUserID.DataBind();
                }
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(UserInfo).FullName, 1);
            }
            finally
            {
                oblTypeOfUser = null;
                obTypeOfUserList = null;
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
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(UserInfo).FullName, 1);
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
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(UserInfo).FullName, 1);
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