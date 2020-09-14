using System;
using System.Collections.Generic;
using ProductsAPI.Data.Context.Entitys;

namespace ProductsAPI.Data.Request
{
    public class GetOrderDetailResponse
    {
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientEmail { get; set; }
        public int IdOrder { get; set; }
        public int IdOrderType { get; set; }
        public string TypeDescription { get; set; }
        public int IdState { get; set; }
        public string StateDescription { get; set; }
        public int IdStateOrder { get; set; }
    }
}