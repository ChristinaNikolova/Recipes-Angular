namespace Recipes.Services.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        Task<IEnumerable<T>> GetFavouriteRecipesAsync<T>(string userId);
    }
}
