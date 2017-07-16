using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.City.BusinessLogic
{
    public class City
    {
        Store.City.DataAccessLayer.City odlCity = new DataAccessLayer.City();
        public Store.City.BusinessObject.CityList GetAllCityList(int CityID, int Flag, string FlagValue)
        {
            try
            {
                return odlCity.GetAllCityList(CityID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Store.City.BusinessObject.City GetAllCity(int CityID, int Flag, string FlagValue)
        {
            try
            {
                return odlCity.GetAllCity(CityID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.City.BusinessObject.City objCity, CommandMode cmdMode)
        {
            try
            {
                return odlCity.ManageCity(objCity, cmdMode);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}