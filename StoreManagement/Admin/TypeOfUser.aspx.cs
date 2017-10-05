using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class TypeOfUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindTypeOfUser();
            }

        }
        Store.TypeOfUser.BusinessLogic.TypeOfUser oblTypeOfUser = null;
        Store.TypeOfUser.BusinessObject.TypeOfUserList obTypeOfUserList = null;
        Store.TypeOfUser.BusinessObject.TypeOfUser objTypeOfUser = null;
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
            txtTypeofUserId.Text = dgvTypeofUser.DataKeys[gvrow.RowIndex].Value.ToString();
            txtTypeofUserName.Text = gvrow.Cells[0].Text;
            updateTypeofUserBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objTypeOfUser = new Store.TypeOfUser.BusinessObject.TypeOfUser();
            oblTypeOfUser = new Store.TypeOfUser.BusinessLogic.TypeOfUser();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objTypeOfUser.TypeofUserID = Convert.ToInt32(dgvTypeofUser.DataKeys[gvrow.RowIndex].Value.ToString());
                objTypeOfUser.TypeofUserName = "";
                objTypeOfUser.CreatedBy = 1;
                objMessageInfo = oblTypeOfUser.ManageItemMaster(objTypeOfUser, cmdMode);
                BindTypeOfUser();
                updateTypeofUserBdInfo.Update();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(TypeOfUser).FullName, 1);
            }
            finally
            {
                objTypeOfUser = null;
                objMessageInfo = null;
                oblTypeOfUser = null;
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateTypeofUserBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.Validate("vgTUser");
            if (Page.IsValid)
            {
                ManageTypeOfUser();
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
                BindTypeOfUser();
                updateTypeofUserBdInfo.Update();
                updateTypeofUser.Update();
                this.ModalPopupExtender1.Show();
            }
        }
        #endregion
        #region UserDefindeFunction
        void BindTypeOfUser()
        {
            oblTypeOfUser = new Store.TypeOfUser.BusinessLogic.TypeOfUser();
            try
            {
                obTypeOfUserList = oblTypeOfUser.GetAllTypeOfUserList(0, 0, "");
                if (obTypeOfUserList != null)
                {
                    dgvTypeofUser.DataSource = obTypeOfUserList;
                    dgvTypeofUser.DataBind();
                }
                else
                {
                    dgvTypeofUser.DataSource = null;
                    dgvTypeofUser.DataBind();
                }
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(TypeOfUser).FullName, 1);
            }
            finally
            {
                oblTypeOfUser = null;
                obTypeOfUserList = null;
            }


        }
        void ManageTypeOfUser()
        {
            objTypeOfUser = new Store.TypeOfUser.BusinessObject.TypeOfUser();
            oblTypeOfUser = new Store.TypeOfUser.BusinessLogic.TypeOfUser();
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objTypeOfUser.TypeofUserID = Convert.ToInt32(txtTypeofUserId.Text);
                    //objTypeOfUser.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                }
                else
                {
                    objTypeOfUser.TypeofUserID = 0;
                    //objTypeOfUser.CreatedBy = Convert.ToInt32(Session["UserId"]);
                }
                objTypeOfUser.TypeofUserName = Convert.ToString(txtTypeofUserName.Text);
                objMessageInfo = oblTypeOfUser.ManageItemMaster(objTypeOfUser, cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(TypeOfUser).FullName, 1);
            }
            finally
            {
                objTypeOfUser = null;
                //objMessageInfo = null;
                oblTypeOfUser = null;
            }

        }
        void ResetForm()
        {
            txtTypeofUserId.Text = "";
            txtTypeofUserName.Text = "";
            txtTypeofUserName.Focus();
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