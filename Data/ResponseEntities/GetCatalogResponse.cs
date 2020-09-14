using System.Collections.Generic;
using ProductsAPI.Data.Context.Entitys;

namespace ProductsAPI.Data.Request
{
    public class GetCatalogResponse
    {
        public List<GetProductResponse> Products { get; set; }
        public List<CategorysCatalog> Categorys { get; set; }        
        public List<MarcasEntity> Marcas { get; set; }

        public class CategorysCatalog
        {
            public int IdCategory { get; set; }
            public string Description { get; set; }
            public List<SubCategorysEntity> SubCategorys { get; set; }
            
        }
    }
}