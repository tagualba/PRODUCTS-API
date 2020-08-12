using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsAPI.Data.Request;
using Microsoft.Extensions.Logging;

namespace ProductsAPI.Models
{

    public class RecipeModel
    {

        public RecipeModel()
        {
        }

        #region GET
        
        public GetRecipeDetailResponse GetRecipeDetail(GetRecipeDetailRequest request)
        {
            var response = new GetRecipeDetailResponse();
            return response;
        }
        
        public GetRecipeSummaryResponse GetRecipeSummary(GetRecipeSummaryRequest request)
        {
            var response = new GetRecipeSummaryResponse();
            return response;
        }

        #endregion

        #region POST
        
        public int Post(LoadRecipeRequest request)
        {
            return 200;
        }
        
        #endregion
         

    }
}
