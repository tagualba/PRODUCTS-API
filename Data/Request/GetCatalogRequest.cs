using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Request
{
    public class GetCatalogRequest
    {
        public string Description { get; set; }
        public string Marca { get; set; }
        public int Stock { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; } 
        public int IdCategory { get; set; }
        public int IdSubCategory { get; set; }
        public int? Recipe { get; set; }
        public int? IdResoruce { get; set; }
    }
}