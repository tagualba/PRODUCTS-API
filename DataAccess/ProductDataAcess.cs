using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using ProductsAPI.Data.Request;

namespace ProductsAPI.Models
{

    public class ProductDataAcess
    {

        public ProductDataAcess()
        {
        }


        #region GET
        
        public ProductResponse Get()
        {
            var response = new ProductResponse();
            return response;
        }

        public getCatalogResponse GetCatalog()
        {   
            var response = new getCatalogResponse();
            return response;
        }

        #endregion

        #region POST
        
        public int Post()
        {   
            return 200;
        }

        public int LoadCategory()
        {   
            return 200;
        }

        public int LoadSubCategory()
        {   
            return 200;
        }

        #endregion

    }
}
