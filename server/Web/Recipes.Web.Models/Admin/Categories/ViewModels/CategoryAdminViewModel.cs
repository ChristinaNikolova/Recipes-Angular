namespace Recipes.Web.Models.Admin.Categories.ViewModels
{
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;

    public class CategoryAdminViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int RecipesCount { get; set; }
    }
}
