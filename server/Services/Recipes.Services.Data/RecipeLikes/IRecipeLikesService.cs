namespace Recipes.Services.Data.RecipeLikes
{
    using System.Threading.Tasks;

    public interface IRecipeLikesService
    {
        Task<bool> IsFavouriteAsync(string userId, string recipeId);

        Task LikeAsync(string userId, string recipeId);

        Task DislikeAsync(string userId, string recipeId);
    }
}
