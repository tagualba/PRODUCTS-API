using System;
using System.Collections.Generic;
using ProductsAPI.Data.Context.Entitys;

namespace ProductsAPI.Data.Request
{
    public class GetClientResponse
    {
        public ClientsEntity ClientEntity { get; set; }
    }
}