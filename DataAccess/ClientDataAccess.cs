using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProductsAPI.Data.Request;

namespace ProductsAPI.Models
{

    public class ClientDataAccess 
    {

        public ClientDataAccess()
        {
        }   

        #region GET

        public GetClientResponse Get()
        {
            var response = new GetClientResponse();
            return response;
        }

        public GetClientsResponse GetClients()
        {
            var response = new GetClientsResponse();
            return response;
        }


        #endregion

        #region POST


        public int Post()
        {
            return 200;
        }

        public int LoadNewsLetter()
        {
            return 200;
        }

        #endregion

    }
}
