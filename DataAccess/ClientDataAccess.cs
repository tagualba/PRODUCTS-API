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
        private MASFARMACIADEVContext context;

        public ClientDataAccess()
        {
            context = new MASFARMACIADEVContext();
        }   


        #region GET


        public GetClientResponse GetById(int idClient)
        {
            var getClientResponse = new GetClientResponse();
            try
            {
                var query = context.ClientsEntity
                            .Where(c => c.IdClient == idClient)
                            .FirstOrDefault();
                            GetClientResponse getClientEntity = new GetClientResponse()
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
                            getClientResponse = getClientEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetById : ERROR : "+ex.Message);
                throw;
            }
            return getClientResponse;
        }

        public GetClientResponse GetByEmail(string email)
        {
            var getClientResponse = new GetClientResponse();
            try
            {
                var query = context.ClientsEntity
                            .Where(c => c.Email == email)
                            .FirstOrDefault();
                            GetClientResponse getClientEntity = new GetClientResponse()
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
                            getClientResponse = getClientEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetByEmail : ERROR : "+ex.Message);
                throw;
            }
            return getClientResponse;
        }


        public GetClientsResponse GetClients()
        {
            GetClientsResponse getClientsResponse = new GetClientsResponse();
            try
            {
                var query = from cl in context.ClientsEntity
                            select cl;
                getClientsResponse.ClientsEntities = query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetClients : ERROR : "+ex.Message);
                throw;
            }
            return getClientsResponse;
        }


        #endregion

        #region POST


        public int PostClient(LoadClientRequest request)
        {
            int idClientResponse;
            try
            {
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
                idClientResponse = clientEntity.IdClient;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ClientDataAccess.PostClient : ERROR : "+ex.Message);
                throw;
            }
            return idClientResponse;
        }

        public void LoadNewsLetter(LoadNewsLetterRequest request)
        {
            try
            {
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
