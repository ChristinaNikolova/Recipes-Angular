namespace Recipes.Models.Ingredients.ViewModels
{
    using global::Recipes.Data.Models;
    using global::Recipes.Models.Ingredients.InputModels;
    using global::Recipes.Services.Mapping;

    public class IngredientViewModel : BaseIngredientViewModel, IMapFrom<RecipeIngredient>
    {
        public string RecipeId { get; set; }

        public string IngredientId { get; set; }
    }
}
