﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.TypeOfVendor.BusinessLogic
{
    public class TypeOfVendor
    {
        Store.TypeOfVendor.DataAccessLayer.TypeOfVendor odlTypeOfVendor = new DataAccessLayer.TypeOfVendor();
        public Store.TypeOfVendor.BusinessObject.TypeOfVendorList GetAllTypeOfVendorList(int TypeofVendorId, int Flag, string FlagValue)
        {
            try
            {
                return odlTypeOfVendor.GetAllTypeOfVendorList(TypeofVendorId, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(TypeOfVendor).FullName, 1);
                return null;
            }
        }
        public Store.TypeOfVendor.BusinessObject.TypeOfVendor GetAllTypeOfVendor(int TypeOfVendorID, int Flag, string FlagValue)
        {
            try
            {
                return odlTypeOfVendor.GetAllTypeOfVendor(TypeOfVendorID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(TypeOfVendor).FullName, 1);
                return null;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.TypeOfVendor.BusinessObject.TypeOfVendor objTypeOfVendor, CommandMode cmdMode)
        {
            try
            {
                return odlTypeOfVendor.ManageTypeOfVendor(objTypeOfVendor, cmdMode);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(TypeOfVendor).FullName, 1);
                return null; 
            }

        }
    }
}