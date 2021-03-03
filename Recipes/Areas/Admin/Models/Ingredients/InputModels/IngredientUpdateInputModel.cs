namespace Recipes.Areas.Admin.Models.Ingredients.InputModels
{
    using Recipes.Data.Models;
    using Recipes.Models.Ingredients.InputModels;
    using Recipes.Services.Mapping;

    public class IngredientUpdateInputModel : IngredientCreateAdminInputModel, IMapFrom<Ingredient>
    {
        public string Id { get; set; }
    }
}
