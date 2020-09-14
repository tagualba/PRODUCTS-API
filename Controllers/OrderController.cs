using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsAPI.Data.Request;
using System.Text.Json;
using ProductsAPI.Models;
using Email.Service;
using Email.Service.Entity;
using ProductsAPI.Data.Context;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly ILogger<OrderController> _logger;
        private readonly IMailer _mailer;
        private OrderModel _orderModel;

        public OrderController(ILogger<OrderController> logger, IMailer mailer)
        {
            _logger = logger;
            _orderModel = new OrderModel();
            _mailer = mailer;
        }

        #region GET

        [HttpGet]
        public GetOrderDetailResponse GetOrderDetail(string request)
        {
            var getOrderDetailRequest = JsonSerializer.Deserialize<GetOrderDetailRequest>(request);
            return _orderModel.GetOrderDetail(getOrderDetailRequest);
        }

        [HttpGet]
        public GetOrderSummaryResponse GetOrderSummary(string request)
        {
            var getOrderSummaryRequest = JsonSerializer.Deserialize<GetOrderSummaryRequest>(request);
            return _orderModel.GetOrderSummary(getOrderSummaryRequest);
        }

        [HttpGet]
        public GetOrdersDetailsResponse GetOrdersDetails(string request)
        {
            var getOrdersDetailsRequest = JsonSerializer.Deserialize<GetOrdersDetailsRequest>(request);
            return _orderModel.GetOrdersDetails(getOrdersDetailsRequest);
        }

        [HttpGet]
        public GetOrdersSummarysResponse GetOrdersSummarys(string request)
        {
            var getOrdersSummarysRequest = JsonSerializer.Deserialize<GetOrdersSummarysRequest>(request);
            return _orderModel.GetOrdersSummarys(getOrdersSummarysRequest);
        }

        #endregion
        
        #region POST
        
        [HttpPost]
        [Route("post")]
        public int Post(string request)
        {
            var loadOrderRequest = JsonSerializer.Deserialize<LoadOrderRequest>(request);
            return _orderModel.Post(loadOrderRequest);
        }

        [HttpGet]
        [Route("export")]
        public async Task<IActionResult> ExportDate()
        {
            MASFARMACIADEVContext context = new MASFARMACIADEVContext();
            var query = context.EmailsFormatEntity.Find(1);
            var sendEmailEntity = new SendEmailEntity()
            {
                Email = "agustingonzalez660@gmail.com",
                NameEmail = "Remitente",
                Subject = "Orden de compra n°" + 0001,
                Body = query.Format
            };
            await _mailer.SendEmailAsync(sendEmailEntity);
            return NoContent();
        }
        
        #endregion

        

    }
}
