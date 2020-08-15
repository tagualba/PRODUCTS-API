using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsAPI.Data.Request;
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
        
        public int Post()
        {
            return 200;
        }
        
        #endregion
         

    }
}
