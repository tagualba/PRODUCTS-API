using System.Collections.Generic;
using ProductsAPI.Data.Context.Entitys;

namespace ProductsAPI.Data.Request
{
    public class GetFiltersResponse
    {
        public List<CategorysTreeFilters> CategorysFilters { get; set; }
        public List<MarcasEntity> MarcasFilters { get; set; }
    }
}