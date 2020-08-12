using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProductsAPI.Data.Request;

namespace ProductsAPI.Models
{

    public class OrderModel
    {


        public OrderModel()
        {
        }

        #region GET

        public GetOrderDetailResponse GetOrderDetail(GetOrderDetailRequest request)
        {
            var response = new GetOrderDetailResponse();
            return response;
        }

        public GetOrderSummaryResponse GetOrderSummary(GetOrderSummaryRequest request)
        {
            var response = new GetOrderSummaryResponse();
            return response;
        }

        public GetOrdersDetailsResponse GetOrdersDetails(GetOrdersDetailsRequest request)
        {
            var response = new GetOrdersDetailsResponse();
            return response;
        }

        public GetOrdersSummarysResponse GetOrdersSummarys(GetOrdersSummarysRequest request)
        {
            var response = new GetOrdersSummarysResponse();
            return response;
        }

        #endregion
        
        #region POST
        
        public int Post(LoadOrderRequest request)
        {
            return 200;
        }
        
        #endregion

        

    }
}
