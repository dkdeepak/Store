using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Store.Common;

namespace StoreManagement.Admin
{
    public partial class Currency : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserId"] != null)
            //{
            if (!Page.IsPostBack)
            {
                BindCurrency();
                
            }
            //}
            //else {
            //  Response.Redirect("../Login.aspx");
            //}
        }
        Store.Currency.BusinessLogic.Currency oblCurrency = null;
        Store.Currency.BusinessObject.CurrencyList obCurrencyList = null;
        Store.Currency.BusinessObject.Currency objCurrency = null;
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
            txtCurrencyId.Text = dgvCurrency.DataKeys[gvrow.RowIndex].Value.ToString();
            txtCurrencyName.Text = gvrow.Cells[0].Text;
           
            updateCurrencyBdInfo.Update();
            this.ModalPopupExtender1.Show();
            cmdMode = CommandMode.M;
        }
        protected void imgbtnfrDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdMode = CommandMode.D;
            objCurrency = new Store.Currency.BusinessObject.Currency();
            oblCurrency = new Store.Currency.BusinessLogic.Currency();
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                objCurrency.CurrencyID = Convert.ToInt32(dgvCurrency.DataKeys[gvrow.RowIndex].Value.ToString());
                objCurrency.CurrencyName = "";
                objCurrency.CreatedBy = 1;
                objMessageInfo = oblCurrency.ManageItemMaster(objCurrency, cmdMode);
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + objMessageInfo.TranMessage + "')", true);
                BindCurrency();
                updateCurrencyBdInfo.Update();
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Currency).FullName, 1);
            }
            finally
            {
                objCurrency = null;
                objMessageInfo = null;
                oblCurrency = null;
            }
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
            cmdMode = CommandMode.N;
            ResetForm();
            updateCurrencyBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            objMessageInfo = new MessageInfo();
            Page.Validate("vgCat");
            if (Page.IsValid)
            {
                ManageCurrency();
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
                BindCurrency();
                updateCurrencyBdInfo.Update();
                updateCurrency.Update();
                this.ModalPopupExtender1.Show();
            }
        }
        #endregion
        #region UserDefindeFunction
        void BindCurrency()
        {
            oblCurrency = new Store.Currency.BusinessLogic.Currency();
            try
            {
                obCurrencyList = oblCurrency.GetAllCurrencyList(0, 0, "");
                if (obCurrencyList != null)
                {
                    dgvCurrency.DataSource = obCurrencyList;
                    dgvCurrency.DataBind();
                    

                }
                else
                {
                    dgvCurrency.DataSource = null;
                    dgvCurrency.DataBind();
                }
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Currency).FullName, 1);
            }
            finally
            {
                oblCurrency = null;
                obCurrencyList = null;
            }


        }
        void ManageCurrency()
        {
            objCurrency = new Store.Currency.BusinessObject.Currency();
            oblCurrency = new Store.Currency.BusinessLogic.Currency();
            try
            {
                if (cmdMode == Store.Common.CommandMode.M)
                {

                    objCurrency.CurrencyID = Convert.ToInt32(txtCurrencyId.Text);
                    //objCurrency.ModifiedBy = Convert.ToInt32(Session["UserId"].ToString());
                }
                else
                {
                    objCurrency.CurrencyID = 0;
                    //objCurrency.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                }
                objCurrency.Sign = "";
                objCurrency.CurrencyName = Convert.ToString(txtCurrencyName.Text);
                objMessageInfo = oblCurrency.ManageItemMaster(objCurrency, cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Currency).FullName, 1);
            }
            finally
            {
                objCurrency = null;
                oblCurrency = null;
            }

        }
        void ResetForm()
        {
            txtCurrencyId.Text = "";
            txtCurrencyName.Text = "";
            txtCurrencyName.Focus();
            
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