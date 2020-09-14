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
            getCatalogResponse.Products = listCardsTemp.Take(60).GroupBy(x => x.IdProduct).Select(y => y.First()).ToList();
            var listCategorysUniques = listCategorysTemp.GroupBy(x => x.IdCategory).Select(y => y.First()).ToList();
            var listSubCategorysUniques = listSubCategorysTemp.GroupBy(x => x.IdSubCategory).Select(y => y.First()).ToList();
            getCatalogResponse.Marcas = listMarcasTemp.GroupBy(x => x.IdMarca).Select(y => y.First()).ToList();
            
            var listTrees = new List<GetCatalogResponse.CategorysCatalog>();
            foreach (var cat in listCategorysUniques)
            {
                var categoryTree = new GetCatalogResponse.CategorysCatalog();
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
                categoryTree.SubCategorys = listSubCategorysTree;
                listTrees.Add(categoryTree);
            }
            getCatalogResponse.Categorys = listTrees;
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
            var tempObj = _dataAccessResponse;
            if (request.IdFilteredCategories.Count > 0)
            {
                tempObj = tempObj.Select(P => P).Where(P => request.IdFilteredCategories.Contains(P.ProductEntity.IdCategory)).ToList();
            }
            if (request.IdFilteredSubCategories.Count > 0)
            {
                tempObj = tempObj.Select(P => P).Where(P => request.IdFilteredSubCategories.Contains(P.ProductEntity.IdSubCategory)).ToList();
            }
            if (request.IdFilteredMarcas.Count > 0)
            {
                tempObj = tempObj.Select(P => P).Where(P => request.IdFilteredMarcas.Contains(P.ProductEntity.IdMarca)).ToList();
            }
            foreach (var obj in tempObj)
            {
                listCardsTemp.Add(obj.ProductEntity);
                listCategorysTemp.Add(obj.CategoryUsed);
                listSubCategorysTemp.Add(obj.SubCategoryUsed);
                listMarcasTemp.Add(obj.MarcaUsed);
            }
            getCatalogResponse.Products = listCardsTemp.Take(60).GroupBy(x => x.IdProduct).Select(y => y.First()).ToList();
            var listCategorysUniques = listCategorysTemp.GroupBy(x => x.IdCategory).Select(y => y.First()).ToList();
            var listSubCategorysUniques = listSubCategorysTemp.GroupBy(x => x.IdSubCategory).Select(y => y.First()).ToList();
            getCatalogResponse.Marcas = listMarcasTemp.GroupBy(x => x.IdMarca).Select(y => y.First()).ToList();
            
            var listTrees = new List<GetCatalogResponse.CategorysCatalog>();
            foreach (var cat in listCategorysUniques)
            {
                var categoryTree = new GetCatalogResponse.CategorysCatalog();
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
                categoryTree.SubCategorys = listSubCategorysTree;
                listTrees.Add(categoryTree);
            }
            getCatalogResponse.Categorys = listTrees;
            return getCatalogResponse;
        }
    }
}