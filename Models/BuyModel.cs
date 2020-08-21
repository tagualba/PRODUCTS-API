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
        
        public BuyDetailResponse Detail(BuyDetailRequest request)
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

  
        public int Post(BuyRequest request)
        {
            try
            {
                BuyDataAccess _dataAccess = new BuyDataAccess();
                _dataAccess.Insert(request);
                //Retorna 204: La peticion ha sido manejada con exito y la respuesta no tiene contenido
                return 204;
            }
            catch (Exception ex)
            {
                Console.WriteLine("BuyModel.Post : ERROR : "+ex.Message);
                //Error interno del servidor
                return 500;
            }
        }

        public int PostDetail(BuyDetailRequest request)
        {
            try
            {
                BuyDataAccess _dataAccess = new BuyDataAccess();
                _dataAccess.InsertDetail(request);
                //Retorna 204: La peticion ha sido manejada con exito y la respuesta no tiene contenido
                return 204;
            }
            catch (Exception ex)
            {
                Console.WriteLine("BuyModel.PostDetail : ERROR : "+ex.Message);
                //Error interno del servidor
                return 500;
            }
        }

        #endregion





    }
}
