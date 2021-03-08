namespace Recipes.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Recipes.Services.Data.Categories;
    using Recipes.Web.Models.Categories.ViewModels;

    [Route("api/[controller]/[action]")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> All()
        {
            var categories = await this.categoriesService.GetAllAsync<CategoryViewModel>();

            return new List<CategoryViewModel>(categories);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<CategoryNameViewModel>>> AllNames()
        {
            var categories = await this.categoriesService.GetAllAsync<CategoryNameViewModel>();

            return new List<CategoryNameViewModel>(categories);
        }
    }
}
