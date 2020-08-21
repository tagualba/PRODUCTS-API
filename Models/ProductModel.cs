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
            ProductResponse response = new ProductResponse();
            try
            {
                ProductDataAcess _dataAccess = new ProductDataAcess();
                response = _dataAccess.GetByID(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductModel.GetByID : ERROR : "+ex.Message);
                throw;
            }
            return response;
        }

        public getCatalogResponse GetCatalogAll()
        {   
            getCatalogResponse response = new getCatalogResponse();
            try
            {
                ProductDataAcess _dataAccess = new ProductDataAcess();
                response = _dataAccess.GetCatalogAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductModel.GetCatalogAll : ERROR : "+ex.Message);
                throw;
            }
            return response;
        }

        public getCatalogResponse GetCatalogSearchBar(GetCatalogRequest request)
        {   
            getCatalogResponse response = new getCatalogResponse();
            try
            {
                ProductDataAcess _dataAccess = new ProductDataAcess();
                response = _dataAccess.GetCatalogSearchBar(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductModel.GetCatalogSearchBar : ERROR : "+ex.Message);
                throw;
            }
            return response;
        }

        public getCatalogResponse GetCatalogByFilter(GetCatalogRequest request)
        {   
            getCatalogResponse response = new getCatalogResponse();
            try
            {
                ProductDataAcess _dataAccess = new ProductDataAcess();
                if (request.IdCategory != 0)
                {
                    response = _dataAccess.GetCatalogFilterByCategory(request);
                }
                else if (request.IdSubCategory != 0)
                {
                    response = _dataAccess.GetCatalogFilterBySubCategory(request);
                }
                else
                {
                    response = _dataAccess.GetCatalogFilterByPrice(request);  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ProductModel.GetCatalogByFilter : ERROR : "+ex.Message);
                throw;
            }
            return response;
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
