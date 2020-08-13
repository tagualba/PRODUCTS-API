using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Context
{
    public partial class Purchases
    {
        public int IdPurchase { get; set; }
        public DateTime UploadDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int IdClient { get; set; }
        public int IdOrder { get; set; }
    }
}
