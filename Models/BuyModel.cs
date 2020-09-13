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
        private OrderDataAccess _orderDataAccess;
        private OrderModel _orderModel;
        
        public BuyModel()
        {
            _buyDataAccess = new BuyDataAccess();
            _clientDataAccess = new ClientDataAccess();
            _orderDataAccess = new OrderDataAccess();
            _orderModel = new OrderModel();
        }


        #region GET
        

        public GetBuyDetailResponse GetBuy(GetBuyDetailRequest request)
        {
            var getBuyDetailResponse = new GetBuyDetailResponse();
            try
            {
                //  Datos de la compra
                getBuyDetailResponse = _buyDataAccess.GetBuy(request);

                // Datos del cliente
                var clientResponse = _clientDataAccess.GetById(getBuyDetailResponse.IdClient);
                getBuyDetailResponse.ClientEntity = clientResponse.ClientEntity;
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
                getBuysSummaryResponse = _buyDataAccess.GetBuysSummary();
            }
            catch (Exception ex)
            {
                Console.WriteLine("BuyModel.GetBuysSummary : ERROR : "+ex.Message);
                //  Error interno del servidor
                throw;
            }
            return getBuysSummaryResponse;
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

                //  Insertar el tipo de order para obtener el idOrder de la compra
                request.IdOrder = _orderDataAccess.PostOrder(request.IdTypeOrder);

                //  Inserta una compra y retorna el id creado
                request.IdBuy = _buyDataAccess.PostBuy(request);

                //  Inserta un detalle de compra
                _buyDataAccess.PostBuyDetail(request);

                //  Seteo el stateorder en 1 -> Pedido pendiente
                _orderModel.NextStateOrder(request.IdOrder);

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
