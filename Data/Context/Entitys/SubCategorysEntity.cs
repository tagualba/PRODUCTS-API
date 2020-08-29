using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Context.Entitys
{
    public partial class SubCategorysEntity
    {
        public int IdSubCategory { get; set; }
        public string Description { get; set; }
        public int IdCategory { get; set; }
    }
}
