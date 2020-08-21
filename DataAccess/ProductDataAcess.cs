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
            ProductResponse response = new ProductResponse();
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = context.ProductsEntity.Find(request.IdProduct);
                ProductResponse productResponse = new ProductResponse()
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
                response = productResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetByID : ERROR : "+ex.Message);
                throw;
            }
            return response;
        }

        public getCatalogResponse GetCatalogAll()
        {   
            getCatalogResponse response = new getCatalogResponse(); 
            try
            {  
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = context.ProductsEntity.ToList();
                response.catalog = query;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetCatalogAll : ERROR : "+ex.Message);
                throw;
            }
            return response;
        }

        public getCatalogResponse GetCatalogSearchBar(GetCatalogRequest request)
        {   
            getCatalogResponse response = new getCatalogResponse(); 
            try
            {  
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = context.ProductsEntity.Where 
                        (p => p.Description.Contains(request.Description)
                        || p.Marca.Contains(request.Marca)
                        && p.Stock > 0
                        ).ToList();
                response.catalog = query;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetCatalogSearchBar : ERROR : "+ex.Message);
                throw;
            }
            return response;
        }

        public getCatalogResponse GetCatalogFilterByCategory(GetCatalogRequest request)
        {   
            getCatalogResponse response = new getCatalogResponse(); 
            try
            {  
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = context.ProductsEntity.Where 
                        (p => p.IdCategory == request.IdCategory
                        && p.Stock > 0
                        && p.Price >= request.PriceMin
                        && p.Price <= request.PriceMax
                        ).ToList();
                response.catalog = query;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetCatalogFilterByCategory : ERROR : "+ex.Message);
                throw;
            }
            return response;
        }

        public getCatalogResponse GetCatalogFilterBySubCategory(GetCatalogRequest request)
        {   
            getCatalogResponse response = new getCatalogResponse(); 
            try
            {  
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = context.ProductsEntity.Where 
                        (p => p.IdSubCategory == request.IdSubCategory
                        && p.Stock > 0
                        && p.Price >= request.PriceMin
                        && p.Price <= request.PriceMax
                        ).ToList();
                response.catalog = query;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetCatalogFilterBySubCategory : ERROR : "+ex.Message);
                throw;
            }
            return response;
        }

        public getCatalogResponse GetCatalogFilterByPrice(GetCatalogRequest request)
        {   
            getCatalogResponse response = new getCatalogResponse(); 
            try
            {  
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = context.ProductsEntity.Where 
                        (p => p.Stock > 0
                        && p.Price >= request.PriceMin
                        && p.Price <= request.PriceMax
                        ).ToList();
                response.catalog = query;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetCatalogFilterByPrice : ERROR : "+ex.Message);
                throw;
            }
            return response;
        }

        
        #endregion


        #region POST
        

        public void Insert(LoadProductRequest request)
        {   
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                ProductsEntity product = new ProductsEntity()
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
                context.ProductsEntity.Add(product);
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
                CategorysEntity category = new CategorysEntity()
                {
                    Description = request.Description
                };
                context.CategorysEntity.Add(category);
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
                SubCategorysEntity subCategory = new SubCategorysEntity()
                {
                    Description = request.Description
                };
                context.SubCategorysEntity.Add(subCategory);
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
