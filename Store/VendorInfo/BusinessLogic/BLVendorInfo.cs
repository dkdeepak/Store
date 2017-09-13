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
            catch 
            {
                throw;
            }
        }
        public Store.VendorInfo.BusinessObject.VendorInfo GetAllVendorInfo(int VendorInfoId, int Flag, string FlagValue)
        {
            try
            {
                return odlVendorInfo.GetAllVendorInfo(VendorInfoId, Flag, FlagValue);
            }
            catch
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.VendorInfo.BusinessObject.VendorInfo objVendorInfo, CommandMode cmdMode)
        {
            try
            {
                return odlVendorInfo.ManageVendorInfo(objVendorInfo, cmdMode);
            }
            catch
            {
                throw;            
            }
        }


    }
}