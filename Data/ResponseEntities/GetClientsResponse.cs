using System;
using System.Collections.Generic;
using ProductsAPI.Data.Context.Entitys;

namespace ProductsAPI.Data.Request
{
    public class GetClientsResponse
    {
        public List<ClientsEntity> ClientsEntities { get; set; }
    }
}