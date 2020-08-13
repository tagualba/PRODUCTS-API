using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Context
{
    public partial class PostalCodes
    {
        public int IdPostalCode { get; set; }
        public string PostalCode { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
