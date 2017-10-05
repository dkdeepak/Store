using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class TypeOfVendor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindTypeOfVendor();
            }

        }
        Store.TypeOfVendor.BusinessLogic.TypeOfVendor oblTypeOfVendor= null;
        Store.TypeOfVendor.BusinessObject.TypeOfVendorList obTypeOfVendorList = null;
        Store.TypeOfVendor.BusinessObject.TypeOfVendor objTypeOfVendor = null;
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
            txtTypeofVendorId.Text = dgvTypeofVendor.DataKeys[gvrow.RowIndex].Value.ToString();
            txtTypeofVendorName.Text = gvrow.Cells[0].Text;
            updateTypeofUserBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objTypeOfVendor = new Store.TypeOfVendor.BusinessObject.TypeOfVendor();
            oblTypeOfVendor = new Store.TypeOfVendor.BusinessLogic.TypeOfVendor();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objTypeOfVendor.TypeofVendorID = Convert.ToInt32(dgvTypeofVendor.DataKeys[gvrow.RowIndex].Value.ToString());
                objTypeOfVendor.TypeofVendorName = "";
                objTypeOfVendor.CreatedBy = 1;
                objMessageInfo = oblTypeOfVendor.ManageItemMaster(objTypeOfVendor, cmdMode);
                BindTypeOfVendor();
                updateTypeofUserBdInfo.Update();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(TypeOfVendor).FullName, 1);

            }
            finally
            {
                objTypeOfVendor = null;
                objMessageInfo = null;
                oblTypeOfVendor = null;
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
            Page.Validate("vgTVendor");
            if (Page.IsValid)
            {
                ManageTypeOfVendor();
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
                BindTypeOfVendor();
                updateTypeofUserBdInfo.Update();
                updateTypeofUser.Update();
                this.ModalPopupExtender1.Show();
            }
        }
        #endregion
        #region UserDefindeFunction
        void BindTypeOfVendor()
        {
            oblTypeOfVendor = new Store.TypeOfVendor.BusinessLogic.TypeOfVendor();
            try
            {
                obTypeOfVendorList = oblTypeOfVendor.GetAllTypeOfVendorList(0, 0, "");
                if (obTypeOfVendorList != null)
                {
                    dgvTypeofVendor.DataSource = obTypeOfVendorList;
                    dgvTypeofVendor.DataBind();
                }
                else
                {
                    dgvTypeofVendor.DataSource = null;
                    dgvTypeofVendor.DataBind();
                }
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(TypeOfVendor).FullName, 1);
            }
            finally
            {
                oblTypeOfVendor = null;
                obTypeOfVendorList = null;
            }


        }
        void ManageTypeOfVendor()
        {
            objTypeOfVendor = new Store.TypeOfVendor.BusinessObject.TypeOfVendor();
            oblTypeOfVendor = new Store.TypeOfVendor.BusinessLogic.TypeOfVendor();
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {
                    objTypeOfVendor.TypeofVendorID = Convert.ToInt32(txtTypeofVendorId.Text);
                    //objTypeOfUser.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                }
                else
                {
                    objTypeOfVendor.TypeofVendorID = 0;
                    //objTypeOfUser.CreatedBy = Convert.ToInt32(Session["UserId"]);
                }
                objTypeOfVendor.TypeofVendorName = Convert.ToString(txtTypeofVendorName.Text);
                objMessageInfo = oblTypeOfVendor.ManageItemMaster(objTypeOfVendor, cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(TypeOfVendor).FullName, 1);

            }
            finally
            {
                objTypeOfVendor = null;
                //objMessageInfo = null;
                oblTypeOfVendor = null;
            }

        }
        void ResetForm()
        {
            txtTypeofVendorId.Text = "";
            txtTypeofVendorName.Text = "";
            txtTypeofVendorName.Focus();
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