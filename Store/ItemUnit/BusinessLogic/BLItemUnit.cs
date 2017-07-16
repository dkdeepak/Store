using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.ItemUnit.BusinessLogic
{
    public class ItemUnit
    {
        Store.ItemUnit.DataAccessLayer.ItemUnit odlItemUnit = new DataAccessLayer.ItemUnit();
        public Store.ItemUnit.BusinessObject.ItemUnitList GetAllItemUnitList(int UnitId, int Flag, string FlagValue)
        {
            try
            {
                return odlItemUnit.GetAllItemUnitList(UnitId, Flag, FlagValue);
            }
            catch 
            {
                throw;
            }
        }
        public Store.ItemUnit.BusinessObject.ItemUnit GetAllItemUnit(int UnitId, int Flag, string FlagValue)
        {
            try
            {
                return odlItemUnit.GetAllItemUnit(UnitId, Flag, FlagValue);
            }
            catch
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.ItemUnit.BusinessObject.ItemUnit objItemUnit, CommandMode cmdMode)
        {
            try
            {
                return odlItemUnit.ManageItemUnit(objItemUnit, cmdMode);
            }
            catch
            {
                throw;            
            }
        }


    }
}