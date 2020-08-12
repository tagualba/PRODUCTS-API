using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProductsAPI.Data.Request;

namespace ProductsAPI.Models
{

    public class ClientModel 
    {

        public ClientModel()
        {
        }   

        #region GET

        public GetClientResponse Get(GetClientRequest request)
        {
            var response = new GetClientResponse();
            return response;
        }

        public GetClientsResponse GetClients(GetClientsRequest request)
        {
            var response = new GetClientsResponse();
            return response;
        }


        #endregion

        #region POST


        public int Post(LoadClientRequest request)
        {
            return 200;
        }

        public int LoadNewsLetter(LoadNewsLetterRequest request)
        {
            return 200;
        }

        #endregion

    }
}
