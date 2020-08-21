using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProductsAPI.Data.Request;
using ProductsAPI.Data.Context;
using ProductsAPI.Data.Context.Entitys;


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


        public void Insert(LoadClientRequest request)
        {
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                ClientsEntity client = new ClientsEntity()
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    IdentificationNumber = request.IdentificationNumber,
                    IdTypeIdentification = request.IdTypeIdentification,
                    HomeStreet = request.HomeStreet,
                    HomeHeigth = request.HomeHeigth,
                    IdPostalCode = request.IdPostalCode,
                    Email = request.Email,
                    Phone = request.Phone
                };
                context.ClientsEntity.Add(client);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ClientDataAccess.Insert : ERROR : "+ex.Message);
                throw;
            }
        }

        public void LoadNewsLetter(LoadNewsLetterRequest request)
        {
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                NewsletterEntity newsletter = new NewsletterEntity()
                {
                    Email = request.Email,
                    Phone = request.Phone
                };
                context.NewsletterEntity.Add(newsletter);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ClientDataAccess.LoadNewsLetter : ERROR : "+ex.Message);
                throw;
            }
        }

        #endregion

    }
}
