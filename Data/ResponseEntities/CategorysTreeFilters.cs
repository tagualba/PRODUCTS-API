using System;
using System.Collections.Generic;
using ProductsAPI.Data.Context.Entitys;

namespace ProductsAPI.Data.Request
{
    public class CategorysTreeFilters
    {
        public int IdCategory { get; set; }
        public string Description { get; set; }
        public List <SubCategorysEntity> SubCategorysFilters { get; set; }

    }
}