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
            try
            {
                ClientDataAccess _dataAccess = new ClientDataAccess();
                _dataAccess.Insert(request);
                //Retorna 204: La peticion ha sido manejada con exito y la respuesta no tiene contenido
                return 204;   
            }
            catch (Exception ex)
            {
                Console.WriteLine("ClientModel.Post : ERROR : "+ex.Message);
                //Error interno del servidor
                return 500;
            }
        }

        public int LoadNewsLetter(LoadNewsLetterRequest request)
        {
            try
            {
                ClientDataAccess _dataAccess = new ClientDataAccess();
                _dataAccess.LoadNewsLetter(request);
                //Retorna 204: La peticion ha sido manejada con exito y la respuesta no tiene contenido
                return 204;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ClientModel.LoadNewsLetter : ERROR : "+ex.Message);
                //Error interno del servidor
                return 500;
            }
        }

        #endregion

    }
}
