namespace Recipes.Services.Data.RecipeIngredients
{
    using System.Threading.Tasks;

    public interface IRecipeIngredientsService
    {
        Task CreateAsync(string ingredientId, string recipeId, string quantity);
    }
}
