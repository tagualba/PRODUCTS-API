using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Request
{
    public class GetOrderDetailResponse
    {
        public int IdOrder { get; set; }
        public int IdOrderType { get; set; }
        public string TypeDescription { get; set; }
        public int IdState { get; set; }
        public string StateDescription { get; set; }
        public int IdStateOrder { get; set; }
    }
}