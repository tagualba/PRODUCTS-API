using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProductsAPI.Data.Request;

namespace ProductsAPI.Models
{
    public class BuyModel
    {
        private BuyDataAccess _buyDataAccess;
        private ClientDataAccess _clientDataAccess;
        
        public BuyModel()
        {
            _buyDataAccess = new BuyDataAccess();
            _clientDataAccess = new ClientDataAccess();
        }


        #region GET
        

        public GetBuyDetailResponse GetBuy(GetBuyDetailRequest request)
        {
            var getBuyDetailResponse = new GetBuyDetailResponse();
            try
            {
                BuyDataAccess _dataAccess = new BuyDataAccess();
                getBuyDetailResponse = _dataAccess.GetBuy(request);
                // Datos de compra generales

                // Datos del detalle

                // Datos del cliente
                ClientDataAccess _clientDataAccess = new ClientDataAccess();
                var clientResponse = _clientDataAccess.GetById(getBuyDetailResponse.ClientEntity.IdClient);
            }
            catch (Exception ex)
            {
                Console.WriteLine("BuyModel.GetBuyDetail : ERROR : "+ex.Message);
                //  Error interno del servidor
                throw;
            }
            return getBuyDetailResponse;
        } 

        public GetBuysSummaryResponse GetBuysSummary()
        {
            var getBuysSummaryResponse = new GetBuysSummaryResponse();
            try
            {
                BuyDataAccess _dataAccess = new BuyDataAccess();
                getBuysSummaryResponse = _dataAccess.GetBuysSummary();
            }
            catch (Exception ex)
            {
                Console.WriteLine("BuyModel.GetBuysSummary : ERROR : "+ex.Message);
                //  Error interno del servidor
                throw;
            }
            return getBuysSummaryResponse;
        } 

        public GetBuysDetailsResponse GetBuysDetails()
        {
            var getBuysDetailsResponse = new GetBuysDetailsResponse();
            try
            {
                BuyDataAccess _dataAccess = new BuyDataAccess();
                getBuysDetailsResponse = _dataAccess.GetBuysDetails();
                //TO DO
            }
            catch (Exception ex)
            {
                Console.WriteLine("BuyModel.GetBuysDetails : ERROR : "+ex.Message);
                //  Error interno del servidor
                throw;
            }
            return getBuysDetailsResponse;
        } 


        #endregion
        
        
        #region POST

  
        public int PostBuy(LoadBuyRequest request)
        {
            try
            {
                //  Asigno Fecha de hoy
                request.UploadDate = DateTime.Today;

                //  Inserta un nuevo cliente y retorna el id creado
                request.IdClient = _clientDataAccess.PostClient(request.NewClient);

                //  Inserta una compra y retorna el id creado
                request.IdBuy = _buyDataAccess.PostBuy(request);

                //  Inserta un detalle de compra
                _buyDataAccess.PostBuyDetail(request);

                //  Retorna 204: La peticion ha sido manejada con exito y la respuesta no tiene contenido
                return 204;
            }
            catch (Exception ex)
            {
                Console.WriteLine("BuyModel.PostBuy : ERROR : "+ex.Message);
                //  Error interno del servidor
                return 500;
            }
        }


        #endregion
    }
}
