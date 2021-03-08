namespace Recipes.Web.Models.Admin.Ingredients.ViewModels
{
    using System.Linq;

    using AutoMapper;
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;

    public class IngredientAdminViewModel : IMapFrom<Ingredient>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int RecipeIngredientsCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Ingredient, IngredientAdminViewModel>().ForMember(
                m => m.RecipeIngredientsCount,
                opt => opt.MapFrom(x => x.RepiceIngredients.Count()));
        }
    }
}
