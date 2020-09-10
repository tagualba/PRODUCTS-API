using System;
using System.Collections.Generic;
using ProductsAPI.Data.Context.Entitys;

namespace ProductsAPI.Data.Request
{
    public class GetBuysSummaryResponse
    {
        public List<BuysEntity> BuysEntites { get; set; }
    }
}