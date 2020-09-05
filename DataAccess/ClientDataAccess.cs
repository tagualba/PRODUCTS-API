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

        public GetClientResponse GetByEmail(GetClientRequest request)
        {
            GetClientResponse clientResponse = new GetClientResponse();
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = context.ClientsEntity.Where
                        (c => c.Email == request.Email).FirstOrDefault();
                GetClientResponse clientEntity = new GetClientResponse()
                {
                    IdClient = query.IdClient,
                    Name = query.Name,
                    Surname = query.Surname,
                    IdentificationNumber = query.IdentificationNumber,
                    IdTypeIdentification = query.IdTypeIdentification,
                    HomeStreet = query.HomeStreet,
                    HomeHeigth = query.HomeHeigth,
                    HomeDetails = query.HomeDetails,
                    Departament = query.Departament,
                    Region = query.Region,
                    IdPostalCode = query.IdPostalCode,
                    Email = query.Email,
                    Phone = query.Phone,
                    AdicionalInfo = query.AdicionalInfo
                };
                clientResponse = clientEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetByEmail : ERROR : "+ex.Message);
                throw;
            }
            return clientResponse;
        }

        public GetClientsResponse GetClients()
        {
            GetClientsResponse clientsResponse = new GetClientsResponse();
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = context.ClientsEntity.ToList();
                clientsResponse.ClientsEntities = query;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetClients : ERROR : "+ex.Message);
                throw;
            }
            return clientsResponse;
        }


        #endregion

        #region POST


        public void Insert(LoadClientRequest request)
        {
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                ClientsEntity clientEntity = new ClientsEntity()
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    IdentificationNumber = request.IdentificationNumber,
                    IdTypeIdentification = request.IdTypeIdentification,
                    HomeStreet = request.HomeStreet,
                    HomeHeigth = request.HomeHeigth,
                    HomeDetails = request.HomeDetails,
                    Departament = request.Departament,
                    Region = request.Region,
                    IdPostalCode = request.IdPostalCode,
                    Email = request.Email,
                    Phone = request.Phone,
                    AdicionalInfo = request.AdicionalInfo
                };
                context.ClientsEntity.Add(clientEntity);
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
                NewsletterEntity newsletterEntity = new NewsletterEntity()
                {
                    Email = request.Email,
                    Phone = request.Phone
                };
                context.NewsletterEntity.Add(newsletterEntity);
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
