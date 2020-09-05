using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsAPI.Models;
using ProductsAPI.Data.Request;
using System.Text.Json;


namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyController : ControllerBase
    {
        private readonly ILogger<BuyController> _logger;
        private BuyModel _buyModel;

        public BuyController(ILogger<BuyController> logger)
        {
            _logger = logger;
            _buyModel = new BuyModel();
        }


        #region GET
        

        [HttpGet]
        //todo de la venta
        //objeto: cliente
        //        resumen y detalle de venta
        public BuyDetailResponse Detail(string request)
        {
            var buyDetailRequest = JsonSerializer.Deserialize<LoadBuyDetailRequest>(request);
            return _buyModel.Detail(buyDetailRequest);
        } 

        [HttpGet]
        //resumen de venta, solo encabezado
        public BuySummaryResponse Summary(string request)
        {
            var buySummaryRequest = JsonSerializer.Deserialize<BuySummaryRequest>(request);
            return _buyModel.Summary(buySummaryRequest);
        } 

        [HttpGet]
        //buys + details
        public SalesDetailsResponse SalesDetails(string request)
        {
            var salesDetailsRequest = JsonSerializer.Deserialize<SalesDetailsRequest>(request);
            return _buyModel.SalesDetails(salesDetailsRequest);
        } 

        [HttpGet]
        //buys
        public SalesSummaryResponse SalesSummary(string request)
        {
            var salesSummaryRequest = JsonSerializer.Deserialize<SalesSummaryRequest>(request);
            return _buyModel.SalesSummary(salesSummaryRequest);
        } 


        #endregion
        
        
        #region POST


        [HttpPost]
        [Route("postbuy")]
        public int PostBuy(string request)
        {
            var loadBuyRequest = JsonSerializer.Deserialize<LoadBuyRequest>(request);
            return _buyModel.PostBuy(loadBuyRequest);
        }


        #endregion
    }
}