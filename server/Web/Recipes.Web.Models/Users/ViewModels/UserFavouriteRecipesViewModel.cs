namespace Recipes.Web.Models.Users.ViewModels
{
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;

    public class UserFavouriteRecipesViewModel : IMapFrom<RecipeLike>
    {
        public string RecipeId { get; set; }

        public string RecipeTitle { get; set; }

        public string RecipePicture { get; set; }

        public string RecipeAuthorUserName { get; set; }

        public string RecipeCategoryName { get; set; }
    }
}
