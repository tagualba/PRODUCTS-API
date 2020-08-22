using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using ProductsAPI.Data.Request;
using ProductsAPI.Data.Context.Entitys;
using ProductsAPI.Data.Context;

namespace ProductsAPI.Models
{

    public class ProductDataAcess
    {

        public ProductDataAcess()
        {
        }


        #region GET
        

        public ProductResponse GetByID(GetProductRequest request)
        {
            ProductResponse productResponse = new ProductResponse();
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = context.ProductsEntity.Find(request.IdProduct);
                ProductResponse productEntity = new ProductResponse()
                {
                    IdProduct = query.IdProduct,
                    Description = query.Description,
                    Marca = query.Marca,
                    Stock = query.Stock,
                    Price = query.Price,
                    IdCategory = query.IdCategory,
                    IdSubCategory = query.IdSubCategory,
                    Recipe = query.Recipe,
                    IdResoruce = query.IdResoruce
                };
                productResponse = productEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetByID : ERROR : "+ex.Message);
                throw;
            }
            return productResponse;
        }

        public GetCatalogResponse GetCatalogAll()
        {   
            GetCatalogResponse getCatalogResponse = new GetCatalogResponse(); 
            try
            {  
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = context.ProductsEntity.ToList();
                getCatalogResponse.ProductsEntities = query;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetCatalogAll : ERROR : "+ex.Message);
                throw;
            }
            return getCatalogResponse;
        }

        public GetCatalogResponse GetCatalogSearchBar(GetCatalogRequest request)
        {   
            GetCatalogResponse getCatalogResponse = new GetCatalogResponse(); 
            try
            {  
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = context.ProductsEntity.Where 
                        (p => p.Description.Contains(request.Description)
                        || p.Marca.Contains(request.Marca)
                        && p.Stock > 0
                        ).ToList();
                getCatalogResponse.ProductsEntities = query;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetCatalogSearchBar : ERROR : "+ex.Message);
                throw;
            }
            return getCatalogResponse;
        }

        public GetCatalogResponse GetCatalogFilterByCategory(GetCatalogRequest request)
        {   
            GetCatalogResponse getCatalogResponse = new GetCatalogResponse(); 
            try
            {  
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = context.ProductsEntity.Where 
                        (p => p.IdCategory == request.IdCategory
                        && p.Stock > 0
                        && p.Price >= request.PriceMin
                        && p.Price <= request.PriceMax
                        ).ToList();
                getCatalogResponse.ProductsEntities = query;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetCatalogFilterByCategory : ERROR : "+ex.Message);
                throw;
            }
            return getCatalogResponse;
        }

        public GetCatalogResponse GetCatalogFilterBySubCategory(GetCatalogRequest request)
        {   
            GetCatalogResponse getCatalogResponse = new GetCatalogResponse(); 
            try
            {  
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = context.ProductsEntity.Where 
                        (p => p.IdSubCategory == request.IdSubCategory
                        && p.Stock > 0
                        && p.Price >= request.PriceMin
                        && p.Price <= request.PriceMax
                        ).ToList();
                getCatalogResponse.ProductsEntities = query;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetCatalogFilterBySubCategory : ERROR : "+ex.Message);
                throw;
            }
            return getCatalogResponse;
        }

        public GetCatalogResponse GetCatalogFilterByPrice(GetCatalogRequest request)
        {   
            GetCatalogResponse getCatalogResponse = new GetCatalogResponse(); 
            try
            {  
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = context.ProductsEntity.Where 
                        (p => p.Stock > 0
                        && p.Price >= request.PriceMin
                        && p.Price <= request.PriceMax
                        ).ToList();
                getCatalogResponse.ProductsEntities = query;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetCatalogFilterByPrice : ERROR : "+ex.Message);
                throw;
            }
            return getCatalogResponse;
        }

        
        #endregion


        #region POST
        

        public void Insert(LoadProductRequest request)
        {   
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                ProductsEntity productEntity = new ProductsEntity()
                {
                    Description = request.Description,
                    Marca = request.Marca,
                    Stock = request.Stock,
                    Price = request.Price,
                    IdCategory = request.IdCategory,
                    IdSubCategory = request.IdSubCategory,
                    Recipe = request.Recipe,
                    IdResoruce = request.IdResoruce
                };
                context.ProductsEntity.Add(productEntity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.Insert : ERROR : "+ex.Message);
                throw;
            }
        }

        public void LoadCategory(LoadCategoryRequest request)
        {   
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                CategorysEntity categoryEntity = new CategorysEntity()
                {
                    Description = request.Description
                };
                context.CategorysEntity.Add(categoryEntity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.LoadCategory : ERROR : "+ex.Message);
                throw;
            }
        }

        public void LoadSubCategory(LoadSubCategoryRequest request)
        {   
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                SubCategorysEntity subCategoryEntity = new SubCategorysEntity()
                {
                    Description = request.Description
                };
                context.SubCategorysEntity.Add(subCategoryEntity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.LoadSubCategory : ERROR : "+ex.Message);
                throw;
            }
        }


        #endregion
    }
}
