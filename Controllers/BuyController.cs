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
        [Route("getbuydetail")]
        //todo de la venta
        //objeto: cliente
        //        resumen y detalle de venta
        public GetBuyDetailResponse GetBuy(string request)
        {
            var getBuyDetailRequest = JsonSerializer.Deserialize<GetBuyDetailRequest>(request);
            return _buyModel.GetBuy(getBuyDetailRequest);
        } 

        [HttpGet]
        [Route("getbuyssummary")]
        //obtiene buysEntites
        public GetBuysSummaryResponse GetBuysSummary()
        {
            return _buyModel.GetBuysSummary();
        } 

        [HttpGet]
        [Route("getbuysdetails")]
        //obtiene lista de buy entities con sus respectivos buy details
        public GetBuysDetailsResponse GetBuysDetails()
        {
            return _buyModel.GetBuysDetails();
        }


        #endregion
        
        
        #region POST


        [HttpPost]
        [Route("postbuy")]
        // Carga una venta
        public int PostBuy(string request)
        {
            var loadBuyRequest = JsonSerializer.Deserialize<LoadBuyRequest>(request);
            return _buyModel.PostBuy(loadBuyRequest);
        }


        #endregion
    }
}