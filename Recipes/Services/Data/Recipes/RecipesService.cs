namespace Recipes.Services.Data.Recipes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using global::Recipes.Common;
    using global::Recipes.Data.Common.Repositories;
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Data.Categories;
    using global::Recipes.Services.Mapping;
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

        public async Task DeleteAsync(string recipeId)
        {
            var recipe = await this.GetByIdAsync(recipeId);

            recipe.IsDeleted = true;

            this.recipesRepository.Update(recipe);
            await this.recipesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var recipes = await this.recipesRepository
                .All()
                .OrderByDescending(r => r.CreatedOn)
                .To<T>()
                .ToListAsync();

            return recipes;
        }

        public async Task<T> GetDetailsAsync<T>(string id)
        {
            var recipe = await this.recipesRepository
                .All()
                .Where(r => r.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return recipe;
        }

        public async Task<IEnumerable<T>> GetOrderAsync<T>(string criteria)
        {
            var criteriaToLower = criteria.ToLower();

            var query = this.recipesRepository
                .All();

            if (criteriaToLower == GlobalConstants.OldCriteria)
            {
                query = query
                    .OrderBy(r => r.CreatedOn);
            }
            else if (criteriaToLower == GlobalConstants.NewCriteria)
            {
                query = query
                    .OrderByDescending(r => r.CreatedOn);
            }
            else if (criteriaToLower == GlobalConstants.LikesCountCriteria)
            {
                query = query
                   .OrderByDescending(r => r.RecipeLikes.Count);
            }
            else if (criteriaToLower == GlobalConstants.CommentsCountCriteria)
            {
                query = query
                   .OrderByDescending(r => r.Comments.Count);
            }

            var recipes = await query
                .To<T>()
                .ToListAsync();

            return recipes;
        }

        public async Task<IEnumerable<T>> GetSearchedAsync<T>(string query)
        {
            var recipes = await this.recipesRepository
                .All()
                .Where(r => r.Title.ToLower().Contains(query.ToLower()))
                .OrderByDescending(r => r.CreatedOn)
                .To<T>()
                .ToListAsync();

            return recipes;
        }

        public async Task<bool> IsTitleAlreadyExistingAsync(string title)
        {
            var isExisting = await this.recipesRepository
                .All()
                .AnyAsync(r => r.Title == title);

            return isExisting;
        }

        public async Task UpdateAsync(string id, string title, string content, string categoryName, int cookingTime, int preparationTime, int portions, string picture)
        {
            var recipe = await this.GetByIdAsync(id);

            var categoryId = await this.categoriesService.GetIdByNameAsync(categoryName);

            recipe.Title = title;
            recipe.Content = content;
            recipe.CategoryId = categoryId;
            recipe.CookingTime = cookingTime;
            recipe.PreparationTime = preparationTime;
            recipe.Portions = portions;
            recipe.Picture = picture;

            this.recipesRepository.Update(recipe);
            await this.recipesRepository.SaveChangesAsync();
        }

        private async Task<Recipe> GetByIdAsync(string id)
        {
            return await this.recipesRepository
                            .All()
                            .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
