using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Context
{
    public partial class StatesOrders
    {
        public int IdStateOrder { get; set; }
        public int IdOrder { get; set; }
        public int IdState { get; set; }
    }
}
