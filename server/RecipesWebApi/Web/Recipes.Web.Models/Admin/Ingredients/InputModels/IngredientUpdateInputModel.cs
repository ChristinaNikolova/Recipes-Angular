namespace Recipes.Web.Models.Admin.Ingredients.InputModels
{
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;
    using global::Recipes.Web.Models.Ingredients.InputModels;

    public class IngredientUpdateInputModel : IngredientCreateAdminInputModel, IMapFrom<Ingredient>
    {
        public string Id { get; set; }
    }
}
