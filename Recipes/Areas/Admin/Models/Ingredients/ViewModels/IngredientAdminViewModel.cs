namespace Recipes.Areas.Admin.Models.Ingredients.ViewModels
{
    using Recipes.Data.Models;
    using Recipes.Services.Mapping;

    public class IngredientAdminViewModel : IMapFrom<Ingredient>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
