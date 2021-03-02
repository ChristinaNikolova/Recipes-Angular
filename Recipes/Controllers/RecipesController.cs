namespace Recipes.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Recipes.Common;
    using Recipes.Data.Models;
    using Recipes.Models.Common;
    using Recipes.Models.Ingredients.InputModels;
    using Recipes.Models.Recipes.InputModels;
    using Recipes.Models.Recipes.ViewModels;
    using Recipes.Services.Data.RecipeIngredients;
    using Recipes.Services.Data.RecipeLikes;
    using Recipes.Services.Data.Recipes;

    [Route("api/[controller]/[action]")]
    public class RecipesController : ApiController
    {
        private readonly IRecipesService recipesService;
        private readonly IRecipeLikesService recipeLikesService;
        private readonly IRecipeIngredientsService recipeIngredientsService;
        private readonly UserManager<ApplicationUser> userManager;

        public RecipesController(
            IRecipesService recipesService,
            IRecipeLikesService recipeLikesService,
            IRecipeIngredientsService recipeIngredientsService,
            UserManager<ApplicationUser> userManager)
        {
            this.recipesService = recipesService;
            this.recipeLikesService = recipeLikesService;
            this.recipeIngredientsService = recipeIngredientsService;
            this.userManager = userManager;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Create([FromBody] RecipeInputModel model)
        {
            var isTitleAlreadyExisting = await this.recipesService.IsTitleAlreadyExistingAsync(model.Title);

            if (isTitleAlreadyExisting)
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = Messages.AlreadyExistsRecipe,
                });
            }

            try
            {
                var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

                await this.recipesService.CreateAsync(model.Title, model.Content, model.Portions, model.PreparationTime, model.CookingTime, model.CategoryName, model.Picture, model.Ingredients, user.Id);

                return this.Ok(new
                {
                    Message = Messages.SuccessfullyAdded,
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<RecipeBaseViewModel>>> All()
        {
            try
            {
                var recipes = await this.recipesService.GetAllAsync<RecipeBaseViewModel>();

                return new List<RecipeBaseViewModel>(recipes);
            }
            catch (Exception)
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = Messages.UnknownError,
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<RecipeDetailsViewModel>> Details(string id)
        {
            try
            {
                var recipe = await this.recipesService.GetDetailsAsync<RecipeDetailsViewModel>(id);

                var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

                recipe.IsFavourite = await this.recipeLikesService.IsFavouriteAsync(user.Id, id);
                recipe.Ingredients = await this.recipeIngredientsService.GetIngredientByRecipeAsync<BaseIngredientViewModel>(id);

                return recipe;
            }
            catch (Exception)
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = Messages.UnknownError,
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<RecipeUpdateInputModel>> RecipeForUpdate(string id)
        {
            try
            {
                var recipe = await this.recipesService.GetDetailsAsync<RecipeUpdateInputModel>(id);

                return recipe;
            }
            catch (Exception)
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = Messages.UnknownError,
                });
            }
        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Like(string id)
        {
            try
            {
                var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

                await this.recipeLikesService.LikeAsync(user.Id, id);

                return this.Ok(new
                {
                    Message = Messages.SuccessfullyAdded,
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

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Dislike(string id)
        {
            try
            {
                var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

                await this.recipeLikesService.DislikeAsync(user.Id, id);

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

        [HttpGet("{query}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<RecipeBaseViewModel>>> Search(string query)
        {
            try
            {
                var recipes = await this.recipesService.GetSearchedAsync<RecipeBaseViewModel>(query);

                return new List<RecipeBaseViewModel>(recipes);
            }
            catch (Exception)
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = Messages.UnknownError,
                });
            }
        }

        [HttpGet("{criteria}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<RecipeBaseViewModel>>> Order(string criteria)
        {
            try
            {
                var recipes = await this.recipesService.GetOrderAsync<RecipeBaseViewModel>(criteria);

                return new List<RecipeBaseViewModel>(recipes);
            }
            catch (Exception)
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = Messages.UnknownError,
                });
            }
        }

        [HttpDelete("{recipeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string recipeId)
        {
            try
            {
                await this.recipesService.DeleteAsync(recipeId);

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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(RecipeUpdateInputModel input)
        {
            try
            {
                await this.recipesService.UpdateAsync(input.Id, input.Title, input.Content, input.CategoryName, input.CookingTime, input.PreparationTime, input.Portions, input.Picture);

                return this.Ok(new
                {
                    Message = Messages.SuccessfullyUpdated,
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
