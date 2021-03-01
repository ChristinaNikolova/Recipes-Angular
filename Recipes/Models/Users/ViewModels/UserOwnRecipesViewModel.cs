namespace Recipes.Models.Users.ViewModels
{
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;

    public class UserOwnRecipesViewModel : IMapFrom<Recipe>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Picture { get; set; }

        public string CategoryName { get; set; }
    }
}
