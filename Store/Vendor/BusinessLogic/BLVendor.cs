using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.Vendor.BusinessLogic
{
    public class Vendor
    {
        Store.Vendor.DataAccessLayer.Vendor odlVendor = new DataAccessLayer.Vendor();
        public Store.Vendor.BusinessObject.VendorList GetAllVendorList(int VendorId, int Flag, string FlagValue)
        {
            try
            {
                return odlVendor.GetAllVendorList(VendorId, Flag, FlagValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.Vendor.BusinessObject.Vendor GetAllVendor(int VendorID, int Flag, string FlagValue)
        {
            try
            {
                return odlVendor.GetAllVendor(VendorID, Flag, FlagValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.Vendor.BusinessObject.Vendor objVendor, CommandMode cmdMode)
        {
            try
            {
                return odlVendor.ManageVendor(objVendor, cmdMode);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}