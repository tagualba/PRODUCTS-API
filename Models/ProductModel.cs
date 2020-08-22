using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using ProductsAPI.Data.Request;
using ProductsAPI.Data.Context;

namespace ProductsAPI.Models
{

    public class ProductModel
    {

        public ProductModel()
        {
        }


        #region GET
        

        public ProductResponse GetByID(GetProductRequest request)
        {
            ProductResponse productResponse = new ProductResponse();
            try
            {
                ProductDataAcess _dataAccess = new ProductDataAcess();
                productResponse = _dataAccess.GetByID(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductModel.GetByID : ERROR : "+ex.Message);
                throw;
            }
            return productResponse;
        }

        public GetCatalogResponse GetCatalogAll()
        {   
            GetCatalogResponse getCatalogResponse = new GetCatalogResponse();
            try
            {
                ProductDataAcess _dataAccess = new ProductDataAcess();
                getCatalogResponse = _dataAccess.GetCatalogAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductModel.GetCatalogAll : ERROR : "+ex.Message);
                throw;
            }
            return getCatalogResponse;
        }

        public GetCatalogResponse GetCatalogSearchBar(GetCatalogRequest request)
        {   
            GetCatalogResponse getCatalogResponse = new GetCatalogResponse();
            try
            {
                ProductDataAcess _dataAccess = new ProductDataAcess();
                getCatalogResponse = _dataAccess.GetCatalogSearchBar(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductModel.GetCatalogSearchBar : ERROR : "+ex.Message);
                throw;
            }
            return getCatalogResponse;
        }

        public GetCatalogResponse GetCatalogByFilter(GetCatalogRequest request)
        {   
            GetCatalogResponse getCatalogResponse = new GetCatalogResponse();
            try
            {
                ProductDataAcess _dataAccess = new ProductDataAcess();
                if (request.IdCategory != 0)
                {
                    getCatalogResponse = _dataAccess.GetCatalogFilterByCategory(request);
                }
                else if (request.IdSubCategory != 0)
                {
                    getCatalogResponse = _dataAccess.GetCatalogFilterBySubCategory(request);
                }
                else
                {
                    getCatalogResponse = _dataAccess.GetCatalogFilterByPrice(request);  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductModel.GetCatalogByFilter : ERROR : "+ex.Message);
                throw;
            }
            return getCatalogResponse;
        }


        #endregion


        #region POST


        public int Post(LoadProductRequest request)
        {   
            try
            {
                ProductDataAcess _dataAccess = new ProductDataAcess();
                _dataAccess.Insert(request);
                //Retorna 204: La peticion ha sido manejada con exito y la respuesta no tiene contenido
                return 204;  
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductModel.Post : ERROR : "+ex.Message);
                //Error interno del servidor
                return 500;
            }
        }

        public int LoadCategory(LoadCategoryRequest request)
        {   
            try
            {
                ProductDataAcess _dataAccess = new ProductDataAcess();
                _dataAccess.LoadCategory(request);
                //Retorna 204: La peticion ha sido manejada con exito y la respuesta no tiene contenido
                return 204;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductModel.LoadCategory : ERROR : "+ex.Message);
                //Error interno del servidor
                return 500;
            }
        }

        public int LoadSubCategory(LoadSubCategoryRequest request)
        {   
            try
            {
                ProductDataAcess _dataAccess = new ProductDataAcess();
                _dataAccess.LoadSubCategory(request);
                //Retorna 204: La peticion ha sido manejada con exito y la respuesta no tiene contenido
                return 204;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductModel.LoadSubCategory : ERROR : "+ex.Message);
                //Error interno del servidor
                return 500;
            }
        }


        #endregion
    }
}
