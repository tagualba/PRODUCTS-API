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
        
        public BuyModel()
        {
        }


        #region GET
        

        public BuyDetailResponse Detail(LoadBuyDetailRequest request)
        {
            var response = new BuyDetailResponse();
            return response;
        } 
    
        public BuySummaryResponse Summary(BuySummaryRequest request)
        {
            var response = new BuySummaryResponse();
            return response;
        } 

        public SalesDetailsResponse SalesDetails(SalesDetailsRequest request)
        {
            var response = new SalesDetailsResponse();
            return response;
        } 

        public SalesSummaryResponse SalesSummary(SalesSummaryRequest request)
        {
            var response = new SalesSummaryResponse();
            return response;
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
                ClientDataAccess _clientDataAccess = new ClientDataAccess();
                request.IdClient = _clientDataAccess.PostClient(request.NewClient);

                //  Inserta una compra y retorna el id creado
                BuyDataAccess _buyDataAccess = new BuyDataAccess();
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
