using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using ProductsAPI.Models;
using ProductsAPI.Data.Request;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;

        private ProductModel _productModel;

        public ProductController(ILogger<ProductController> logger)
        {
            _productModel = new ProductModel();
            _logger = logger;
        }


        #region GET
        
        [HttpGet]
        public ProductResponse Get(string request)
        {
            var getProductRequest = JsonSerializer.Deserialize<GetProductRequest>(request);
            return _productModel.Get(getProductRequest);
        }

        [HttpGet]
        public getCatalogResponse GetCatalog(string request)
        {   
            var getCatalogRequest = JsonSerializer.Deserialize<GetCatalogRequest>(request);
            return _productModel.GetCatalog(getCatalogRequest);
        }

        #endregion

        #region POST
        
        [HttpPost]
        public int Post(string request)
        {   
            var loadProductRequest = JsonSerializer.Deserialize<LoadProductRequest>(request);
            return _productModel.Post(loadProductRequest);
        }
        
        [HttpPost]
        public int LoadCategory(string request)
        {   
            var loadCategoryRequest = JsonSerializer.Deserialize<LoadCategoryRequest>(request);
            return _productModel.LoadCategory(loadCategoryRequest);
        }

        [HttpPost]
        public int LoadSubCategory(string request)
        {   
            var loadSubCategoryRequest = JsonSerializer.Deserialize<LoadSubCategoryRequest>(request);
            return _productModel.LoadSubCategory(loadSubCategoryRequest);
        }

        #endregion

    }
}
