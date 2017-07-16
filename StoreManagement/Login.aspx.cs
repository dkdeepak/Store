using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
namespace StoreManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text != "" && txtUserPass.Text != "")
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopDB"].ToString());
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_checkLogin";
                    cmd.Parameters.AddWithValue("@UserId", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserPass", txtUserPass.Text.Trim());
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    con.Close();
                    if (dt.Rows.Count > 0)
                    {
                        Session["UserType"] = dt.Rows[0]["UserTypeID"].ToString();
                        if (dt.Rows[0]["UserTypeID"].ToString() == "0")
                        {
                            Session["UserId"] = dt.Rows[0]["Id"].ToString();
                        }
                        else
                        {
                            Session["UserId"] = dt.Rows[0]["ClientID"].ToString();
                        }
                        
                        Response.Redirect("Admin/MangePanle.aspx",false);
                    }
                    else
                    {
                        //Page.ClientScript(this.ClientScript) invalid user id or passward
                    }
                }
                else
                {
                    //enter userName and pass
                }
            }
            catch (Exception ex)
            { }

        }

    }
}