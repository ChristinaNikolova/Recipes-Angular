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
    using Recipes.Models.Users.ViewModels;
    using Recipes.Services.Data.Users;

    [Route("api/[controller]/[action]")]
    public class UsersController : ApiController
    {
        private readonly IUsersService usersService;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(
            IUsersService usersService,
            UserManager<ApplicationUser> userManager)
        {
            this.usersService = usersService;
            this.userManager = userManager;
        }

        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UserFavouriteRecipesViewModel>>> Favourite()
        {
            try
            {
                var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

                var recipes = await this.usersService.GetFavouriteRecipesAsync<UserFavouriteRecipesViewModel>(user.Id);

                return new List<UserFavouriteRecipesViewModel>(recipes);
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UserOwnRecipesViewModel>>> Own()
        {
            try
            {
                var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);

                var recipes = await this.usersService.GetOwnRecipesAsync<UserOwnRecipesViewModel>(user.Id);

                return new List<UserOwnRecipesViewModel>(recipes);
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
