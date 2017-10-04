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
            catch(Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(ItemUnit).FullName, 1);
                return null;
            }
        }
        public Store.ItemUnit.BusinessObject.ItemUnit GetAllItemUnit(int UnitId, int Flag, string FlagValue)
        {
            try
            {
                return odlItemUnit.GetAllItemUnit(UnitId, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(ItemUnit).FullName, 1);
                return null;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.ItemUnit.BusinessObject.ItemUnit objItemUnit, CommandMode cmdMode)
        {
            try
            {
                return odlItemUnit.ManageItemUnit(objItemUnit, cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(ItemUnit).FullName, 1);
                return null;
            }
        }


    }
}