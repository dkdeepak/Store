using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.Category.BusinessLogic
{
    public class Category
    {
        Store.Category.DataAccessLayer.Category odlCategory = new DataAccessLayer.Category();
        public Store.Category.BusinessObject.CategoryList GetAllCategoryList(int CategoryId, int Flag, string FlagValue)
        {
            try
            {
                return odlCategory.GetAllCategoryList(CategoryId, Flag, FlagValue);
            }
            catch (Exception ex)
            {

                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Category).FullName, 1);
                return null;
            }
        }
        public Store.Category.BusinessObject.Category GetAllCategory(int CategoryID, int Flag, string FlagValue)
        {
            try
            {
                return odlCategory.GetAllCategory(CategoryID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Category).FullName, 1);
                return null;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.Category.BusinessObject.Category objCategory, CommandMode cmdMode)
        {
            try
            {
                return odlCategory.ManageCategory(objCategory, cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(Category).FullName, 1);
                return null;
            }

        }
    }
}