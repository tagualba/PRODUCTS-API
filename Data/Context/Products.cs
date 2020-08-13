using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Context
{
    public partial class Products
    {
        public int IdProduct { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int IdCategory { get; set; }
        public int IdSubCategory { get; set; }
        public int? Recipe { get; set; }
        public int? IdResoruce { get; set; }
    }
}
