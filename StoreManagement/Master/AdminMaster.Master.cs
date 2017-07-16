using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreManagement.Master
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        Store.Client.BusinessLogic.Client oblClient = null;
        Store.Client.BusinessObject.Client objClient = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserId"] != null)
            //{
            //    bindMenu();
            //}
            //else
            //{
            //    Response.Redirect("../Login.aspx");    
            //}
        }
        void bindMenu()
        {
            //int type = Convert.ToInt32(Session["UserType"].ToString());
            //if (type == 0)
            //{
            //    lblName.Text = "Super Admin";
            //    TRANSACTION.Visible = false;
            //    REPORT.Visible = false;
            //    TypeOfUser.Visible = false;
            //    User.Visible = false;
            //    Category.Visible = false;
            //    Unit.Visible = false;
            //    Item.Visible = false;
            //    Tax.Visible = false;
            //}
            //else if (type !=0)
            //{
            //    getDetail(Convert.ToInt32(Session["UserId"]));
            //    Country.Visible = false;
            //    State.Visible = false;
            //    City.Visible = false;
            //    District.Visible = false;
            //    Client.Visible = false;
            //}
            //else { }
        }
        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }
        void getDetail(int id)
        {
            try
            {
                objClient = new Store.Client.BusinessObject.Client();
                oblClient = new Store.Client.BusinessLogic.Client();
                objClient = oblClient.GetAllClient(id, 1, "1");
                lblName.Text = objClient.ClientDisplayName;
            }
            catch
            {

            }
            finally
            {
                objClient = null;
                oblClient = null;
            }
       }

    }
}