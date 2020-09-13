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

    public class OrderDataAccess
    {
        private MASFARMACIADEVContext context;

        public OrderDataAccess()
        {
            context = new MASFARMACIADEVContext();
        }

        #region GET

        public GetOrderDetailResponse GetOrderDetail(int IdOrder)
        {
            var getOrderDetailResponse = new GetOrderDetailResponse();
            try
            {
                var query = from or in context.OrdersEntity
                            join stat in context.StatesOrdersEntity on or.IdOrder equals stat.IdOrder
                            where (or.IdOrder == IdOrder)
                            select new 
                            {
                                orderDetail = new GetOrderDetailResponse
                                {
                                    IdOrder = or.IdOrder,
                                    IdOrderType = or.IdTypeOrder,
                                    IdState = stat.IdState,
                                    IdStateOrder = stat.IdStateOrder
                                }
                            };
                foreach (var obj in query)
                {
                    if (obj.orderDetail == null)
                    {
                        getOrderDetailResponse.IdState = 0;
                        getOrderDetailResponse.StateDescription = "Numero de orden equivocado";
                    }
                    else
                    {
                        getOrderDetailResponse = obj.orderDetail;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("OrderDataAccess.GetOrderDetail : ERROR : "+ex.Message);
                throw;
            }
            return getOrderDetailResponse;
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


        public int PostOrder(int newOrder)
        {
            int idOrderResponse;
            try
            {
                OrdersEntity orderEntity = new OrdersEntity()
                {
                    IdTypeOrder = newOrder
                };
                context.OrdersEntity.Add(orderEntity);
                context.SaveChanges();
                idOrderResponse = orderEntity.IdOrder;
            }
            catch (Exception ex)
            {
                Console.WriteLine("OrderDataAccess.PostOrder : ERROR : "+ex.Message);
                throw;
            }
            return idOrderResponse;
        }

        public void NextStateOrder (int IdStateOrder)
        {
            try
            {
                StatesOrdersEntity actualState = context.StatesOrdersEntity.Find(IdStateOrder);
                if (actualState != null)
                {
                    actualState.IdState = actualState.IdState + 1;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("OrderDataAccess.NextStateOrder : ERROR : "+ex.Message);
                throw;
            }
        }


        #endregion
   

    }
}

