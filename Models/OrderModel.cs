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

        private OrderDataAccess _orderDataAccess;
        public OrderModel()
        {
            _orderDataAccess = new OrderDataAccess();
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

        //  Avanza el state de una order
        public void NextStateOrder (int idOrder)
        {
            var getOrderDetailResponse = _orderDataAccess.GetOrderDetail(idOrder);
            var orderState = getOrderDetailResponse.IdState;
            switch (orderState)
            {
                case 0:
                    _orderDataAccess.NextStateOrder(getOrderDetailResponse.IdStateOrder);
                    //  Primer paso - state 0 a 1
                    //  Primer email su compra esta siendo procesada
                    break;
                case 1:
                    _orderDataAccess.NextStateOrder(getOrderDetailResponse.IdStateOrder);
                    //  state 1 a 2
                    //  Segundo email, su compra se encuentra en proceso
                    break;
                case 2:
                    _orderDataAccess.NextStateOrder(getOrderDetailResponse.IdStateOrder);
                    //  state 2 a 3
                    //  Muchas gracias por comprar
                    break;
                case 3:
                    //  DO NOTHING
                    break;
            }
        }
        
        #endregion

        

    }
}
