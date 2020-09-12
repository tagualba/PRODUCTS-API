using ProductsAPI.Data.Context.Entitys;
using ProductsAPI.Data.Request;
using System.Linq;
using System;
using System.Collections.Generic;

namespace ProductsAPI.Models.Helpers
{
    public class ProductHelper
    {
        public GetCatalogResponse CreateList (List<ProductDataAccessResponse> _dataAccessResponse)
        {
            GetCatalogResponse getCatalogResponse = new GetCatalogResponse();
            var listCardsTemp = new List<GetProductResponse>();
            var listCategorysTemp = new List<CategorysEntity>();
            var listSubCategorysTemp = new List<SubCategorysEntity>();
            var listMarcasTemp = new List<MarcasEntity>();
            foreach (var obj in _dataAccessResponse)
            {
                listCardsTemp.Add(obj.ProductEntity);
                listCategorysTemp.Add(obj.CategoryUsed);
                listSubCategorysTemp.Add(obj.SubCategoryUsed);
                listMarcasTemp.Add(obj.MarcaUsed);
            }
            getCatalogResponse.ProductsEntities = listCardsTemp.Take(60).ToList();
            getCatalogResponse.CategorysUsed = listCategorysTemp.GroupBy(x => x.IdCategory).Select(y => y.First()).ToList();
            getCatalogResponse.SubCategorysUsed = listSubCategorysTemp.GroupBy(x => x.IdSubCategory).Select(y => y.First()).ToList();
            getCatalogResponse.MarcasUsed = listMarcasTemp.GroupBy(x => x.IdMarca).Select(y => y.First()).ToList();
            return getCatalogResponse;
        }

        public GetFiltersResponse CreateCategoryTree (List<ProductDataAccessResponse> _dataAccessResponse)
        {
            GetFiltersResponse getFiltersResponse = new GetFiltersResponse();      
            var listCategorysTemp = new List<CategorysEntity>();
            var listSubCategorysTemp = new List<SubCategorysEntity>();
            var listMarcasTemp = new List<MarcasEntity>();
            var listTrees = new List<CategorysTreeFilters>();
            foreach (var obj in _dataAccessResponse)
            {
                listCategorysTemp.Add(obj.CategoryUsed);
                listSubCategorysTemp.Add(obj.SubCategoryUsed);
                listMarcasTemp.Add(obj.MarcaUsed);
            }
            
            //Elimino las repeticiones
            var listCategorysUniques = listCategorysTemp.GroupBy(x => x.IdCategory).Select(y => y.First()).ToList();
            var listSubCategorysUniques = listSubCategorysTemp.GroupBy(x => x.IdSubCategory).Select(y => y.First()).ToList();
            var listMarcasUniques = listMarcasTemp.GroupBy(x => x.IdMarca).Select(y => y.First()).ToList();
            //Construyo el arbol
            foreach (var cat in listCategorysUniques)
            {
                var categoryTree = new CategorysTreeFilters();
                categoryTree.IdCategory = cat.IdCategory;
                categoryTree.Description = cat.Description;
                var listSubCategorysTree = new List<SubCategorysEntity>();
                foreach (var subcat in listSubCategorysUniques)
                {
                    if (subcat.IdCategory == cat.IdCategory)
                    {
                        listSubCategorysTree.Add(subcat);
                    }
                }
                categoryTree.SubCategorysFilters = listSubCategorysTree;
                listTrees.Add(categoryTree);
            }
            getFiltersResponse.CategorysFilters = listTrees;
            getFiltersResponse.MarcasFilters = listMarcasUniques;
            return getFiltersResponse;
        }
        
        public GetCatalogResponse CatalogFilter (List<ProductDataAccessResponse> _dataAccessResponse, GetCatalogRequest request)
        {
            GetCatalogResponse getCatalogResponse = new GetCatalogResponse();
            var listCardsTemp = new List<GetProductResponse>();
            var listCategorysTemp = new List<CategorysEntity>();
            var listSubCategorysTemp = new List<SubCategorysEntity>();
            var listMarcasTemp = new List<MarcasEntity>();
            foreach (var obj in _dataAccessResponse)
            {
                //Filtro por categoria
                if (request.IdFilteredCategories.Contains(obj.CategoryUsed.IdCategory))
                {
                    listCardsTemp.Add(obj.ProductEntity);
                    listCategorysTemp.Add(obj.CategoryUsed);
                    listSubCategorysTemp.Add(obj.SubCategoryUsed);
                    listMarcasTemp.Add(obj.MarcaUsed);
                }
                //Filtro por subcategoria
                if (request.IdFilteredSubCategories.Contains(obj.SubCategoryUsed.IdSubCategory))
                {
                    listCardsTemp.Add(obj.ProductEntity);
                    listCategorysTemp.Add(obj.CategoryUsed);
                    listSubCategorysTemp.Add(obj.SubCategoryUsed);
                    listMarcasTemp.Add(obj.MarcaUsed);
                }
                //Filtro por marca
                if (request.IdFilteredMarcas.Contains(obj.MarcaUsed.IdMarca))
                {
                    listCardsTemp.Add(obj.ProductEntity);
                    listCategorysTemp.Add(obj.CategoryUsed);
                    listSubCategorysTemp.Add(obj.SubCategoryUsed);
                    listMarcasTemp.Add(obj.MarcaUsed);
                }
            };
            //Elimino repetidos y inserto en el objeto
            getCatalogResponse.ProductsEntities = listCardsTemp.GroupBy(x => x.IdProduct).Select(y => y.First()).ToList();
            getCatalogResponse.CategorysUsed = listCategorysTemp.GroupBy(x => x.IdCategory).Select(y => y.First()).ToList();
            getCatalogResponse.SubCategorysUsed = listSubCategorysTemp.GroupBy(x => x.IdSubCategory).Select(y => y.First()).ToList();
            getCatalogResponse.MarcasUsed = listMarcasTemp.GroupBy(x => x.IdMarca).Select(y => y.First()).ToList();
            return getCatalogResponse;
        }
    }
}