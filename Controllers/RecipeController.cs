using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsAPI.Models;
using ProductsAPI.Data.Request;
using System.Text.Json;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        
        private readonly ILogger<RecipeController> _logger;
        private RecipeModel _recipeModel;

        public RecipeController(ILogger<RecipeController> logger)
        {
            _logger = logger;
            _recipeModel = new RecipeModel();
        }

        #region GET
        
        [HttpGet]
        public GetRecipeDetailResponse GetRecipeDetail(string request)
        {
            var getRecipeDetailRequest = JsonSerializer.Deserialize<GetRecipeDetailRequest>(request);
            return _recipeModel.GetRecipeDetail(getRecipeDetailRequest);
        }
        
        [HttpGet]
        public GetRecipeSummaryResponse GetRecipeSummary(string request)
        {
            var getRecipeSummaryRequest = JsonSerializer.Deserialize<GetRecipeSummaryRequest>(request);
            return _recipeModel.GetRecipeSummary(getRecipeSummaryRequest);
        }

        #endregion

        #region POST
        
        [HttpPost]
        public int Post(string request)
        {
            var loadRecipeRequest = JsonSerializer.Deserialize<LoadRecipeRequest>(request);
            return _recipeModel.Post(loadRecipeRequest);
        }
        
        #endregion
         

    }
}
