namespace Recipes.Areas.Admin.Models.Categories.ViewModels
{
    using Recipes.Data.Models;
    using Recipes.Services.Mapping;

    public class CategoryAdminViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int RecipesCount { get; set; }
    }
}
