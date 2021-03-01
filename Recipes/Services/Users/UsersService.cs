namespace Recipes.Services.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Recipes.Data.Common.Repositories;
    using Recipes.Data.Models;
    using Recipes.Services.Mapping;

    public class UsersService : IUsersService
    {
        private readonly IRepository<RecipeLike> recipeLikesRepository;

        public UsersService(IRepository<RecipeLike> recipeLikesRepository)
        {
            this.recipeLikesRepository = recipeLikesRepository;
        }

        public async Task<IEnumerable<T>> GetFavouriteRecipesAsync<T>(string userId)
        {
            var recipes = await this.recipeLikesRepository
                .All()
                .Where(r => r.UserId == userId)
                .OrderBy(rl => rl.Recipe.Title)
                .To<T>()
                .ToListAsync();

            return recipes;
        }
    }
}
