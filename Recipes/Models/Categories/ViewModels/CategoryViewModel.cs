namespace Recipes.Models.Categories.ViewModels
{
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public int RecipesCount { get; set; }
    }
}
