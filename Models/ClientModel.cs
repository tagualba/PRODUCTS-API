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


        public GetClientResponse GetByEmail(GetClientRequest request)
        {
            GetClientResponse clientResponse = new GetClientResponse();
            try
            {
                ClientDataAccess _dataAccess = new ClientDataAccess();
                clientResponse = _dataAccess.GetByEmail(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductModel.GetByEmail : ERROR : "+ex.Message);
                throw;
            }
            return clientResponse;
        }

        public GetClientsResponse GetClients()
        {   
            GetClientsResponse clientsResponse = new GetClientsResponse();
            try
            {
                ClientDataAccess _dataAccess = new ClientDataAccess();
                clientsResponse = _dataAccess.GetClients();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductModel.GetClients : ERROR : "+ex.Message);
                throw;
            }
            return clientsResponse;
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
