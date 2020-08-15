using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Context.Entitys
{
    public partial class BuysDetailsEntity
    {
        public int IdBuyDetail { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public int IdBuy { get; set; }
    }
}
