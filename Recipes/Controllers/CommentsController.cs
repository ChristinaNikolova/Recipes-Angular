namespace Recipes.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Recipes.Data.Models;
    using Recipes.Models.Comments.InputModels;
    using Recipes.Models.Comments.ViewModels;
    using Recipes.Models.Common;
    using Recipes.Services.Comments;

    [Route("api/[controller]/[action]")]
    public class CommentsController : ApiController
    {
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(
            ICommentsService commentsService,
            UserManager<ApplicationUser> userManager)
        {
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        [HttpPost]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Create([FromBody] CommentInputModel model)
        {
            try
            {
                var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

                await this.commentsService.CreateAsync(model.Content, model.RecipeId, user.Id);

                return this.Ok(new
                {
                    Message = "Successfully added.",
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

        [HttpGet("{recipeId}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CommentViewModel>>> All(string recipeId)
        {
            ;
            try
            {
                var comments = await this.commentsService.GetAllCurrentRecipeAsync<CommentViewModel>(recipeId);

                return new List<CommentViewModel>(comments);
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
