namespace Recipes.Web.Models.Recipes.InputModels
{
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;

    public class RecipeUpdateInputModel : RecipeInputModel, IMapFrom<Recipe>
    {
        public string Id { get; set; }
    }
}
