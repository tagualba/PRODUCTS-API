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
        

        public List<ProductDataAccessResponse> GetFilters()
        {
            List<ProductDataAccessResponse> _dataAccessResponse = new List<ProductDataAccessResponse>();
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = from p in context.ProductsEntity 
                            join cat in context.CategorysEntity on p.IdCategory equals cat.IdCategory
                            join subcat in context.SubCategorysEntity on p.IdSubCategory equals subcat.IdSubCategory
                            join m in context.MarcasEntity on p.IdMarca equals m.IdMarca
                            where (p.Stock > 0)
                            select new
                            {
                                ProductDataAccessResponse = new ProductDataAccessResponse
                                    {
                                    CategoryUsed = new CategorysEntity
                                    {
                                        IdCategory = p.IdCategory,
                                        Description = cat.Description
                                    },
                                    SubCategoryUsed = new SubCategorysEntity
                                    {
                                        IdSubCategory = p.IdSubCategory,
                                        Description = subcat.Description,
                                        IdCategory = subcat.IdCategory
                                    },
                                    MarcaUsed = new MarcasEntity
                                    {
                                        IdMarca = p.IdMarca,
                                        Description = m.Description
                                    }
                                }
                            };
                if (query != null)
                {   
                    foreach (var obj in query)
                    {
                        _dataAccessResponse.Add(obj.ProductDataAccessResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetFilters : ERROR : "+ex.Message);
                throw;
            }
            return _dataAccessResponse;
        }

        public ProductResponse GetByID(GetProductRequest request)
        {
            ProductResponse productResponse = new ProductResponse();
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = from p in context.ProductsEntity
                            where (p.IdCategory == request.IdProduct)
                            join path in context.ResourcesEntity on p.IdResoruce equals path.IdResource
                            join marca in context.MarcasEntity on p.IdMarca equals marca.IdMarca
                            select new
                            {
                                productEntity = new ProductResponse()
                                {
                                    IdProduct = p.IdProduct,
                                    Description = p.Description,
                                    Name = p.Name,
                                    IdMarca = p.IdMarca,
                                    Marca = marca.Description,
                                    Stock = p.Stock,
                                    Price = p.Price,
                                    IdCategory = p.IdCategory,
                                    IdSubCategory = p.IdSubCategory,
                                    Recipe = p.Recipe,
                                    Path = path.Path
                                }
                            };
                if (query != null)
                {
                    var firstQueryItem = query.FirstOrDefault();
                    productResponse = firstQueryItem.productEntity;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetByID : ERROR : "+ex.Message);
                throw;
            }
            return productResponse;
        }

        public List<ProductDataAccessResponse> GetCatalogAll()
        {   
            List<ProductDataAccessResponse> _dataAccessResponse = new List<ProductDataAccessResponse>();
            try
            {  
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = from p in context.ProductsEntity
                            join m in context.MarcasEntity on p.IdMarca equals m.IdMarca
                            join path in context.ResourcesEntity on p.IdResoruce equals path.IdResource
                            join cat in context.CategorysEntity on p.IdCategory equals cat.IdCategory
                            join subcat in context.SubCategorysEntity on p.IdSubCategory equals subcat.IdSubCategory
                            where (p.Stock > 0)
                            select new
                            {
                                ProductDataAccessResponse = new ProductDataAccessResponse
                                    {
                                    ProductCard = new ProductCardResponse
                                    {
                                        IdProduct = p.IdProduct,
                                        Name = p.Name,
                                        Price = p.Price,
                                        Path = path.Path
                                    },
                                    CategoryUsed = new CategorysEntity
                                    {
                                        IdCategory = p.IdCategory,
                                        Description = cat.Description
                                    },
                                    SubCategoryUsed = new SubCategorysEntity
                                    {
                                        IdSubCategory = p.IdSubCategory,
                                        Description = subcat.Description,
                                        IdCategory = subcat.IdCategory
                                    },
                                    MarcaUsed = new MarcasEntity
                                    {
                                        IdMarca = m.IdMarca,
                                        Description = m.Description
                                    }
                                }
                            };
                if (query != null)
                {
                    foreach (var obj in query)
                    {
                        _dataAccessResponse.Add(obj.ProductDataAccessResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetCatalogAll : ERROR : "+ex.Message);
                throw;
            }
            return _dataAccessResponse;
        }

        public List<ProductDataAccessResponse> GetCatalogSearchBar(GetSearchBarRequest request)
        {   
            List<ProductDataAccessResponse> _dataAccessResponse = new List<ProductDataAccessResponse>(); 
            try
            {  
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = from p in context.ProductsEntity
                            join m in context.MarcasEntity on p.IdMarca equals m.IdMarca
                            join path in context.ResourcesEntity on p.IdResoruce equals path.IdResource
                            join cat in context.CategorysEntity on p.IdCategory equals cat.IdCategory
                            join subcat in context.SubCategorysEntity on p.IdSubCategory equals subcat.IdSubCategory
                            where (m.Description.Contains(request.SearchBarText) || p.Description.Contains(request.SearchBarText)) && p.Stock > 0
                            select new
                            {
                                ProductDataAccessResponse = new ProductDataAccessResponse
                                    {
                                    ProductCard = new ProductCardResponse
                                    {
                                        IdProduct = p.IdProduct,
                                        Name = p.Name,
                                        Price = p.Price,
                                        Path = path.Path
                                    },
                                    CategoryUsed = new CategorysEntity
                                    {
                                        IdCategory = p.IdCategory,
                                        Description = cat.Description
                                    },
                                    SubCategoryUsed = new SubCategorysEntity
                                    {
                                        IdSubCategory = p.IdSubCategory,
                                        Description = subcat.Description,
                                        IdCategory = subcat.IdCategory
                                    },
                                    MarcaUsed = new MarcasEntity
                                    {
                                        IdMarca = m.IdMarca,
                                        Description = m.Description
                                    }
                                }
                            };
                if (query != null)
                {
                    foreach (var obj in query)
                    {
                        _dataAccessResponse.Add(obj.ProductDataAccessResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetCatalogSearchBar : ERROR : "+ex.Message);
                throw;
            }
            return _dataAccessResponse;
        }

        public List<ProductDataAccessResponse> GetCatalogFilter(GetCatalogRequest request)
        {   
            List<ProductDataAccessResponse> _dataAccessResponse = new List<ProductDataAccessResponse>();
            try
            {  
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                var query = from p in context.ProductsEntity
                            join m in context.MarcasEntity on p.IdMarca equals m.IdMarca
                            join path in context.ResourcesEntity on p.IdResoruce equals path.IdResource
                            join cat in context.CategorysEntity on p.IdCategory equals cat.IdCategory
                            join subcat in context.SubCategorysEntity on p.IdSubCategory equals subcat.IdSubCategory
                            where (p.Price > request.PriceMin && p.Price < request.PriceMax && p.Stock > 0)
                            select new
                            {
                                ProductDataAccessResponse = new ProductDataAccessResponse
                                    {
                                    ProductCard = new ProductCardResponse
                                    {
                                        IdProduct = p.IdProduct,
                                        Name = p.Name,
                                        Price = p.Price,
                                        Path = path.Path
                                    },
                                    CategoryUsed = new CategorysEntity
                                    {
                                        IdCategory = p.IdCategory,
                                        Description = cat.Description
                                    },
                                    SubCategoryUsed = new SubCategorysEntity
                                    {
                                        IdSubCategory = p.IdSubCategory,
                                        Description = subcat.Description,
                                        IdCategory = subcat.IdCategory
                                    },
                                    MarcaUsed = new MarcasEntity
                                    {
                                        IdMarca = m.IdMarca,
                                        Description = m.Description
                                    }
                                }
                            };
                if (query != null)
                {
                    foreach (var obj in query)
                    {
                        _dataAccessResponse.Add(obj.ProductDataAccessResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.GetCatalogAll : ERROR : "+ex.Message);
                throw;
            }
            return _dataAccessResponse;
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
                    Name = request.Name,
                    IdMarca = request.idMarca,
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

        public void LoadMarca(LoadMarcaRequest request)
        {   
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                MarcasEntity marcaEntity = new MarcasEntity()
                {
                    Description = request.Description
                };
                context.MarcasEntity.Add(marcaEntity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductDataAccess.LoadMarca : ERROR : "+ex.Message);
                throw;
            }
        }


        #endregion


    }
}
