namespace Recipes.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using global::Recipes.Data.Common.Repositories;
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly IRepository<RecipeLike> recipeLikesRepository;
        private readonly IRepository<Recipe> recipesRepository;

        public UsersService(
            IRepository<RecipeLike> recipeLikesRepository,
            IRepository<Recipe> recipesRepository)
        {
            this.recipeLikesRepository = recipeLikesRepository;
            this.recipesRepository = recipesRepository;
        }

        public async Task<IEnumerable<T>> GetFavouriteRecipesAsync<T>(string userId)
        {
            var recipes = await this.recipeLikesRepository
                .All()
                .Where(rl => rl.UserId == userId)
                .OrderBy(rl => rl.Recipe.Title)
                .To<T>()
                .ToListAsync();

            return recipes;
        }

        public async Task<IEnumerable<T>> GetOwnRecipesAsync<T>(string userId)
        {
            var recipes = await this.recipesRepository
                .All()
                .Where(r => r.AuthorId == userId)
                .OrderByDescending(r => r.CreatedOn)
                .ThenBy(r => r.Title)
                .To<T>()
                .ToListAsync();

            return recipes;
        }
    }
}
