using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Request
{
    public class GetCatalogRequest
    {
        public List<int> IdFilteredCategories { get; set; }
        public List<int> IdFilteredSubCategories { get; set; }
        public List<int> IdFilteredMarcas { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
    }
}