using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.VendorInfo.BusinessLogic
{
    public class VendorInfo
    {
        Store.VendorInfo.DataAccessLayer.VendorInfo odlVendorInfo = new DataAccessLayer.VendorInfo();
        public Store.VendorInfo.BusinessObject.VendorInfoList GetAllVendorInfoList(int VendorInfoId, int Flag, string FlagValue)
        {
            try
            {
                return odlVendorInfo.GetAllVendorInfoList(VendorInfoId, Flag, FlagValue);
            }
            catch(Exception ex) 
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(VendorInfo).FullName, 1);
                return null;
            }
        }
        public Store.VendorInfo.BusinessObject.VendorInfo GetAllVendorInfo(int VendorId, int Flag, string FlagValue)
        {
            try
            {
                return odlVendorInfo.GetAllVendorInfo(VendorId, Flag, FlagValue);
            }
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(VendorInfo).FullName, 1);
                return null;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.VendorInfo.BusinessObject.VendorInfo objVendorInfo, CommandMode cmdMode)
        {
            try
            {
                return odlVendorInfo.ManageVendorInfo(objVendorInfo, cmdMode);
            }
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(VendorInfo).FullName, 1);
                return null;
            }
        }


    }
}