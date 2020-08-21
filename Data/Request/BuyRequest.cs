using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Request
{
    public class BuyRequest
    {
        public DateTime UploadDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int IdClient { get; set; }
        public int IdOrder { get; set; }
    }
}