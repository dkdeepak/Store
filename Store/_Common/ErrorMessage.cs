using System;
using System.Data;
using System.Configuration;
using System.Web;


namespace Store.Common
{
    public class MessageInfo
    {
        public int ErrorCode {get;set;}
        public string ErrorMessage {get;set;}
        public int TranID {get;set;}
        public string TranCode {get;set;}
        public string TranMessage { get; set; }
    }

}
