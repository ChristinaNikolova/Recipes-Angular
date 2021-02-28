namespace Recipes.Services.Comments
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task CreateAsync(string content, string recipeId, string userId);

        Task<IEnumerable<T>> GetAllCurrentRecipeAsync<T>(string recipeId);
    }
}
