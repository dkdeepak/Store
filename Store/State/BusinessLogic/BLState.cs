using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.State.BusinessLogic
{
    public class State
    {
        Store.State.DataAcessLayer.State oblState = new DataAcessLayer.State();
        public Store.State.BusinessObject.State GetAllState(int StateID, int Flag, string FlagValue)
        {
            try
            {
                return oblState.GetAllState(StateID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                Store.Common.Utility.ExceptionLog.Exceptionlogs(ex.Message, Store.Common.Utility.ExceptionLog.LineNumber(ex), typeof(State).FullName, 1);
                return null;
            }
        }
        public Store.State.BusinessObject.StateList GetAllStateList(int StateID, int Flag, string FlagValue)
        {
            try
            {
                return oblState.GetAllStateList(StateID, Flag, FlagValue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManageItemMaster(Store.State.BusinessObject.State objState, CommandMode cmdMode)
        {
            try
            {
                return oblState.ManageState(objState, cmdMode);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}