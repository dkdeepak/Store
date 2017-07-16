using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common;

namespace Store.Client.BusinessLogic
{
    public class Client
    {
        Store.Client.DataAccessLayer.Client odlClient = new DataAccessLayer.Client();
        public Store.Client.BusinessObject.Client GetAllClient(int ClientID, int Flag, string FlagValue)
        {
            try
            {
                return odlClient.GetAllClient(ClientID, Flag, FlagValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.Client.BusinessObject.ClientList GetAllClientList(int ClientID, int Flag, string FlagValue)
        {
            try
            {
                return odlClient.GetAllClientList(ClientID, Flag, FlagValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Store.Common.MessageInfo ManageClientMaster(Store.Client.BusinessObject.Client objClient, CommandMode cmdMode)
        {
            try
            {
                return odlClient.ManageClient(objClient, cmdMode);
            }
            catch (Exception)
            {
                throw; 
            }
        }
    }
}