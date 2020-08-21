using System;
using System.Collections.Generic;
using ProductsAPI.Data.Context.Entitys;

namespace ProductsAPI.Data.Request
{
    public class getCatalogResponse
    {
        public List<ProductsEntity> catalog { get; set; }
    }
}