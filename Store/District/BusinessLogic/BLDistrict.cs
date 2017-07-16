using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.District.BusinessLogic
{
    public class District
    {
        Store.District.DataAccessLayer.District odlDistrict = new DataAccessLayer.District();
        public Store.District.BusinessObject.DistrictList GetAllDistrictList(int DistrictID, int Flag, string FlagValue)
        {
            try
            {
                return odlDistrict.GetAllDistrictList(DistrictID, Flag, FlagValue);
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
        public Store.District.BusinessObject.District GetAllDistrict(int DistrictID, int Flag, string FlagValue)
        {
            try
            {
                return odlDistrict.GetAllDistrict(DistrictID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.District.BusinessObject.District objDistrict, CommandMode cmdMode)
        {
            try
            {
                return odlDistrict.ManageDistrict(objDistrict, cmdMode);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}