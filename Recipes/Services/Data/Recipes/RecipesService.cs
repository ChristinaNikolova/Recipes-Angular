namespace Recipes.Services.Data.Recipes
{
    using System.Threading.Tasks;

    using global::Recipes.Data.Common.Repositories;
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Data.Categories;
    using Microsoft.EntityFrameworkCore;

    public class RecipesService : IRecipesService
    {
        private readonly IRepository<Recipe> recipesRepository;
        private readonly ICategoriesService categoriesService;

        public RecipesService(
            IRepository<Recipe> recipesRepository,
            ICategoriesService categoriesService)
        {
            this.recipesRepository = recipesRepository;
            this.categoriesService = categoriesService;
        }

        public async Task CreateAsync(string title, string content, int portions, int preparationTime, int cookingTime, string categoryName, string pictureUrl, string userId)
        {
            var categoryId = await this.categoriesService.GetIdByNameAsync(categoryName);

            var recipe = new Recipe()
            {
                Title = title,
                Content = content,
                CategoryId = categoryId,
                Portions = portions,
                CookingTime = cookingTime,
                PreparationTime = preparationTime,
                AuthorId = userId,
                Picture = pictureUrl,
            };

            await this.recipesRepository.AddAsync(recipe);
            await this.recipesRepository.SaveChangesAsync();
        }

        public async Task<bool> IsTitleAlreadyExistingAsync(string title)
        {
            var isExisting = await this.recipesRepository
                .All()
                .AnyAsync(r => r.Title == title);

            return isExisting;
        }
    }
}
