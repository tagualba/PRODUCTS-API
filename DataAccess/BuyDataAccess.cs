using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProductsAPI.Data.Request;
using ProductsAPI.Data.Context.Entitys;
using ProductsAPI.Data.Context;
 
namespace ProductsAPI.Models
{
    public class BuyDataAccess
    {
        
        public BuyDataAccess()
        {
        }

        #region GET
        
        public BuyDetailResponse Detail()
        {
            var response = new BuyDetailResponse();
            return response;
        } 
    
        public BuySummaryResponse Summary()
        {
            var response = new BuySummaryResponse();
            return response;
        } 

        public SalesDetailsResponse SalesDetails()
        {
            var response = new SalesDetailsResponse();
            return response;
        } 

        public SalesSummaryResponse SalesSummary()
        {
            var response = new SalesSummaryResponse();
            return response;
        } 

        #endregion
        
        
        #region POST

  
        public void insert(string request)
        {
            var b = new MASFARMACIADEVContext();
            var buy = new BuysEntity();
            var res = b.BuysEntity.Add(buy);
        }

        #endregion





    }
}
