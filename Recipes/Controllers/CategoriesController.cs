namespace Recipes.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Recipes.Models.Categories.ViewModels;
    using Recipes.Services.Data.Categories;

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
        public async Task<ActionResult<IEnumerable<string>>> AllNames()
        {
            var categories = await this.categoriesService.GetAllNamesAsync();

            return new List<string>(categories);
        }
    }
}
