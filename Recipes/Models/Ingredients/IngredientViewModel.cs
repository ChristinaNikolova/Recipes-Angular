namespace Recipes.Models.Ingredients
{
    using global::Recipes.Data.Models;

    using global::Recipes.Services.Mapping;

    public class IngredientViewModel : IMapFrom<RecipeIngredient>
    {
        public string IngredientName { get; set; }

        public string Quantity { get; set; }
    }
}
