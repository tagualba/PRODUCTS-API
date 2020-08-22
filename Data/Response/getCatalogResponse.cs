using System;
using System.Collections.Generic;
using ProductsAPI.Data.Context.Entitys;

namespace ProductsAPI.Data.Request
{
    public class GetCatalogResponse
    {
        public List<ProductsEntity> ProductsEntities { get; set; }
    }
}