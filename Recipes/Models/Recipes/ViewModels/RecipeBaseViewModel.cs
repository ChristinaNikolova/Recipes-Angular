namespace Recipes.Models.Recipes.ViewModels
{
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;

    public class RecipeBaseViewModel : IMapFrom<Recipe>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }

        public string CategoryName { get; set; }

        public int RecipeLikesCount { get; set; }
    }
}
