namespace Recipes.Models.Recipes.ViewModels
{
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;

    public class RecipeDetailsViewModel : RecipeBaseViewModel, IMapFrom<Recipe>
    {
        public int Portions { get; set; }

        public int PreparationTime { get; set; }

        public int CookingTime { get; set; }

        public string AuthorUserName { get; set; }

        public bool IsFavourite { get; set; }
    }
}
