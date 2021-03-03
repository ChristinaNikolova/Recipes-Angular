namespace Recipes.Areas.Admin.Models.Ingredients.ViewModels
{
    using System.Linq;

    using AutoMapper;
    using Recipes.Data.Models;
    using Recipes.Services.Mapping;

    public class IngredientAdminViewModel : IMapFrom<Ingredient>, IHaveCustomMapping
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
