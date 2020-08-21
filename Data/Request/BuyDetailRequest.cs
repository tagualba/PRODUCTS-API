using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Request
{
    public class BuyDetailRequest
    {
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public int IdBuy { get; set; } 
    }
}