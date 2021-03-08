namespace Recipes.Services.Data.RecipeLikes
{
    using System.Threading.Tasks;

    using global::Recipes.Data.Common.Repositories;
    using global::Recipes.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class RecipeLikesService : IRecipeLikesService
    {
        private readonly IRepository<RecipeLike> recipeLikesRepository;

        public RecipeLikesService(IRepository<RecipeLike> recipeLikesRepository)
        {
            this.recipeLikesRepository = recipeLikesRepository;
        }

        public async Task DislikeAsync(string userId, string recipeId)
        {
            var recipeLike = await this.recipeLikesRepository
                .All()
                .FirstOrDefaultAsync(rl => rl.RecipeId == recipeId && rl.UserId == userId);

            this.recipeLikesRepository.Delete(recipeLike);
            await this.recipeLikesRepository.SaveChangesAsync();
        }

        public async Task<bool> IsFavouriteAsync(string userId, string recipeId)
        {
            var isFavourite = await this.recipeLikesRepository
                .All()
                .AnyAsync(rl => rl.UserId == userId && rl.RecipeId == recipeId);

            return isFavourite;
        }

        public async Task LikeAsync(string userId, string recipeId)
        {
            var recipeLike = new RecipeLike()
            {
                RecipeId = recipeId,
                UserId = userId,
            };

            await this.recipeLikesRepository.AddAsync(recipeLike);
            await this.recipeLikesRepository.SaveChangesAsync();
        }
    }
}
