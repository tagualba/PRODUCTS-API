using System;
using System.Collections.Generic;
using ProductsAPI.Data.Context.Entitys;

namespace ProductsAPI.Data.Request
{
    public class GetIdenTypesResponse
    {
        public List<IdentificationsTypesEntity> IdenTypes { get; set; }
    }
}