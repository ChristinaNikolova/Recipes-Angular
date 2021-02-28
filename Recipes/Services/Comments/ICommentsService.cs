namespace Recipes.Services.Comments
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task CreateAsync(string content, string recipeId, string userId);
    }
}
