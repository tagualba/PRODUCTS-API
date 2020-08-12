using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using ProductsAPI.Data.Request;

namespace ProductsAPI.Models
{

    public class ProductModel
    {

        public ProductModel()
        {
        }


        #region GET
        
        public ProductResponse Get(GetProductRequest request)
        {
            var response = new ProductResponse();
            return response;
        }

        public getCatalogResponse GetCatalog(GetCatalogRequest request)
        {   
            var response = new getCatalogResponse();
            return response;
        }

        #endregion

        #region POST
        
        public int Post(LoadProductRequest request)
        {   
            return 200;
        }

        public int LoadCategory(LoadCategoryRequest request)
        {   
            return 200;
        }

        public int LoadSubCategory(LoadSubCategoryRequest request)
        {   
            return 200;
        }

        #endregion

    }
}
