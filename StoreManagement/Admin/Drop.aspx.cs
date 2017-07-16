using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreManagement.Admin
{
    public partial class Drop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
           
            this.ModalPopupExtender1.Hide();

        }
        protected void lbtnClose_Click(object sender, EventArgs e)
        {
            
            this.ModalPopupExtender1.Hide();
        }
        protected void linkButton_Click(object sender, EventArgs e)
        {
           
            updateCategoryBdInfo.Update();
            this.ModalPopupExtender1.Show();
        }
    }
}