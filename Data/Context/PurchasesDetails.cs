using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Context
{
    public partial class PurchasesDetails
    {
        public int IdPurchaseDetail { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public int IdPurchase { get; set; }
    }
}
