using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Context.Entitys
{
    public partial class PostalCodesEntity
    {
        public int IdPostalCode { get; set; }
        public string PostalCode { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
