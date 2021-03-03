namespace Recipes.Areas.Admin.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Recipes.Areas.Admin.Admin.Categories.InputModels;
    using Recipes.Common;
    using Recipes.Controllers;
    using Recipes.Models.Common;
    using Recipes.Services.Data.Categories;

    [Route("api/admin/[controller]/[action]")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Create([FromBody] CategoryInputModel input)
        {
            ;
            if (this.User.IsInRole(GlobalConstants.AdminName))
            {
                var isCategoryAlreadyExisting = await this.categoriesService.IsCategoryAlreadyExistingAsync(input.Name);

                if (isCategoryAlreadyExisting)
                {
                    return this.BadRequest(new BadRequestViewModel
                    {
                        Message = Messages.AlreadyExistsCategory,
                    });
                }

                try
                {
                    await this.categoriesService.CreateAsync(input.Name, input.Picture);

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

            return this.Unauthorized();
        }
    }
}
