using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProductsAPI.Data.Request;

namespace ProductsAPI.Models
{

    public class OrderDataAccess
    {


        public OrderDataAccess()
        {
        }

        #region GET

        public GetOrderDetailResponse GetOrderDetail()
        {
            var response = new GetOrderDetailResponse();
            return response;
        }

        public GetOrderSummaryResponse GetOrderSummary()
        {
            var response = new GetOrderSummaryResponse();
            return response;
        }

        public GetOrdersDetailsResponse GetOrdersDetails()
        {
            var response = new GetOrdersDetailsResponse();
            return response;
        }

        public GetOrdersSummarysResponse GetOrdersSummarys()
        {
            var response = new GetOrdersSummarysResponse();
            return response;
        }

        #endregion
        
        #region POST
        
        public int Post()
        {
            return 200;
        }
        
        #endregion

        

    }
}
