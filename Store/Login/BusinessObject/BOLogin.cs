using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Login.BusinessObject
{
    public class Login
    {
        public int LoginID { get; set; }
        public int UserID{ get; set; }
        public string Password{ get; set; }
        public string OldPassword{ get; set; }
        public int IsActive{ get; set; }
        public DateTime LastLoginDate{ get; set; }
        public int UserTypeID{ get; set; }
        public int ClientID{ get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public int ReferenceID { get; set; }
    }
    public class LoginList : List<Login>
    { 
    
    }
}