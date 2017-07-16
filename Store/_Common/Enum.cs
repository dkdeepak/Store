using System;
using System.Data;
using System.Configuration;
using System.Web;


namespace Store
{
    namespace Common
    {
        public enum CommandMode
        {
            N  = 1,
            M = 2,
            D = 3,
            S = 4 
        }
       
        public enum ControlOrientation
        {
            Vertical = 1,
            Horizonal = 2
        }
    }
}
