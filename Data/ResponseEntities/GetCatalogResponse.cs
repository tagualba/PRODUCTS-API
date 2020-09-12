using System.Collections.Generic;
using ProductsAPI.Data.Context.Entitys;

namespace ProductsAPI.Data.Request
{
    public class GetCatalogResponse
    {
        public List<GetProductResponse> ProductsEntities { get; set; }
        public List<CategorysEntity> CategorysUsed { get; set; }
        public List<SubCategorysEntity> SubCategorysUsed { get; set; }
        public List<MarcasEntity> MarcasUsed { get; set; }
    }
}