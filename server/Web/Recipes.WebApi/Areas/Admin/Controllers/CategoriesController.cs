namespace Recipes.WebApi.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Recipes.Common;
    using Recipes.Services.Data.Categories;
    using Recipes.Web.Models.Admin.Categories.InputModels;
    using Recipes.Web.Models.Admin.Categories.ViewModels;
    using Recipes.Web.Models.Common.ViewModels;
    using Recipes.WebApi.Controllers;

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
            if (this.User.Identity.Name == GlobalConstants.AdminName)
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<CategoryAdminViewModel>>> All()
        {
            if (this.User.Identity.Name == GlobalConstants.AdminName)
            {
                try
                {
                    var categories = await this.categoriesService.GetAllAsync<CategoryAdminViewModel>();

                    return new List<CategoryAdminViewModel>(categories);
                }
                catch (Exception ex)
                {
                    return this.BadRequest(new BadRequestViewModel
                    {
                        Message = ex.Message,
                    });
                }
            }

            return this.Unauthorized();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CategoryUpdateInputModel>> CategoryForUpdate(string id)
        {
            if (this.User.Identity.Name == GlobalConstants.AdminName)
            {
                try
                {
                    var category = await this.categoriesService.GetDetailsAsync<CategoryUpdateInputModel>(id);

                    return category;
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            if (this.User.Identity.Name == GlobalConstants.AdminName)
            {
                try
                {
                    await this.categoriesService.DeleteAsync(id);

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

            return this.Unauthorized();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(CategoryUpdateInputModel input)
        {
            if (this.User.Identity.Name == GlobalConstants.AdminName)
            {
                try
                {
                    await this.categoriesService.UpdateAsync(input.Id, input.Name, input.Picture);

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

            return this.Unauthorized();
        }
    }
}
