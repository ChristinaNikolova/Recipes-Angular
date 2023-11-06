namespace Recipes.Services.Data.RecipeIngredients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRecipeIngredientsService
    {
        Task CreateAsync(string ingredientId, string recipeId, string quantity);

        Task<IEnumerable<T>> GetIngredientByRecipeAsync<T>(string recipeId);

        Task DeleteAsync(string ingredientId, string recipeId);
    }
}
