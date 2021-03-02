namespace Recipes.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Recipes.Common;
    using Recipes.Models.Common;
    using Recipes.Models.Ingredients.ViewModels;
    using Recipes.Services.Data.RecipeIngredients;

    [Route("api/[controller]/[action]")]
    public class IngredientsController : ApiController
    {
        private readonly IRecipeIngredientsService recipeIngredientsService;

        public IngredientsController(IRecipeIngredientsService recipeIngredientsService)
        {
            this.recipeIngredientsService = recipeIngredientsService;
        }

        [HttpGet("{recipeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<IngredientViewModel>>> GetByRecipe(string recipeId)
        {
            try
            {
                var ingredients = await this.recipeIngredientsService.GetIngredientByRecipeAsync<IngredientViewModel>(recipeId);

                return new List<IngredientViewModel>(ingredients);
            }
            catch (Exception)
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = Messages.UnknownError,
                });
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete([FromQuery] string ingredientId, string recipeId)
        {
            try
            {
                await this.recipeIngredientsService.DeleteAsync(ingredientId, recipeId);

                return this.Ok(new
                {
                    Message = Messages.SuccessfullyDeleted,
                });
            }
            catch (Exception)
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = Messages.UnknownError,
                });
            }
        }
    }
}
