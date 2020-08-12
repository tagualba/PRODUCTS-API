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
            var response =  200;
            return response;
        }

        #endregion





    }
}
