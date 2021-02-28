namespace Recipes.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Recipes.Data.Models;
    using Recipes.Models.Common;
    using Recipes.Models.Recipes.InputModels;
    using Recipes.Models.Recipes.ViewModels;
    using Recipes.Services.Data.RecipeLikes;
    using Recipes.Services.Data.Recipes;

    [Route("api/[controller]/[action]")]
    public class RecipesController : ApiController
    {
        private readonly IRecipesService recipesService;
        private readonly IRecipeLikesService recipeLikesService;
        private readonly UserManager<ApplicationUser> userManager;

        public RecipesController(
            IRecipesService recipesService,
            IRecipeLikesService recipeLikesService,
            UserManager<ApplicationUser> userManager)
        {
            this.recipesService = recipesService;
            this.recipeLikesService = recipeLikesService;
            this.userManager = userManager;
        }

        [HttpPost]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Create([FromBody] RecipeInputModel model)
        {
            var isTitleAlreadyExisting = await this.recipesService.IsTitleAlreadyExistingAsync(model.Title);

            if (isTitleAlreadyExisting)
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = "Recipe with the given name already exists.",
                });
            }

            try
            {
                var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

                await this.recipesService.CreateAsync(model.Title, model.Content, model.Portions, model.PreparationTime, model.CookingTime, model.CategoryName, model.Picture, user.Id);

                return this.Ok(new
                {
                    Message = "Recipe added successfully.",
                });
            }
            catch (Exception)
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = "Something went wrong.",
                });
            }
        }

        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
                    Message = "Something went wrong.",
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<RecipeDetailsViewModel>> Details(string id)
        {
            try
            {
                var recipe = await this.recipesService.GetDetailsAsync<RecipeDetailsViewModel>(id);

                var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

                recipe.IsFavourite = await this.recipeLikesService.IsFavouriteAsync(user.Id, id);

                return recipe;
            }
            catch (Exception)
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = "Something went wrong.",
                });
            }
        }

        [HttpPost("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Like(string id)
        {
            try
            {
                var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

                await this.recipeLikesService.LikeAsync(user.Id, id);

                return this.Ok(new
                {
                    Message = "Like added successfully.",
                });
            }
            catch (Exception)
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = "Something went wrong.",
                });
            }
        }

        [HttpPost("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Dislike(string id)
        {
            try
            {
                var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

                await this.recipeLikesService.DislikeAsync(user.Id, id);

                return this.Ok(new
                {
                    Message = "Like removed successfully.",
                });
            }
            catch (Exception)
            {
                return this.BadRequest(new BadRequestViewModel
                {
                    Message = "Something went wrong.",
                });
            }
        }

        [HttpGet("{query}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
                    Message = "Something went wrong.",
                });
            }
        }

        [HttpGet("{criteria}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
                    Message = "Something went wrong.",
                });
            }

        }
    }
}
