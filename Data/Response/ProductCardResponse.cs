using System;
using System.Collections.Generic;
using ProductsAPI.Data.Context.Entitys;

namespace ProductsAPI.Data.Request
{
    public class ProductCardResponse
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string Marca { get; set; }
        public decimal Price { get; set; }
        public string Path { get; set; }
    }
}

