using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsAPI.Data.Request;
using ProductsAPI.Data.Context;
using ProductsAPI.Data.Context.Entitys;
using Microsoft.Extensions.Logging;

namespace ProductsAPI.Models
{

    public class RecipeDataAccess
    {

        public RecipeDataAccess()
        {
        }

        #region GET
        
        public GetRecipeDetailResponse GetRecipeDetail()
        {
            var response = new GetRecipeDetailResponse();
            return response;
        }
        
        public GetRecipeSummaryResponse GetRecipeSummary()
        {
            var response = new GetRecipeSummaryResponse();
            return response;
        }

        #endregion

        #region POST
        
        public void Insert(LoadRecipeRequest request)
        {
            try
            {
                MASFARMACIADEVContext context = new MASFARMACIADEVContext();
                RecipesEntity recipe = new RecipesEntity()
                {
                    Path = request.Path
                };
                context.RecipesEntity.Add(recipe);
                context.SaveChanges();   
            }
            catch (Exception ex)
            {
                Console.WriteLine("RecipeDataAccess.Insert : ERROR : "+ex.Message);
                throw;
            }
        }
        
        #endregion
         

    }
}
