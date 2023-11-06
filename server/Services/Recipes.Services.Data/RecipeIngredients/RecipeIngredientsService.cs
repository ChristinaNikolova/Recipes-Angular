namespace Recipes.Services.Data.RecipeIngredients
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using global::Recipes.Data.Common.Repositories;
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class RecipeIngredientsService : IRecipeIngredientsService
    {
        private readonly IRepository<RecipeIngredient> recipeIngredientsRepository;

        public RecipeIngredientsService(IRepository<RecipeIngredient> recipeIngredientsRepository)
        {
            this.recipeIngredientsRepository = recipeIngredientsRepository;
        }

        public async Task CreateAsync(string ingredientId, string recipeId, string quantity)
        {
            var recipeIngredient = new RecipeIngredient()
            {
                IngredientId = ingredientId,
                RecipeId = recipeId,
                Quantity = quantity,
            };

            await this.recipeIngredientsRepository.AddAsync(recipeIngredient);
            await this.recipeIngredientsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string ingredientId, string recipeId)
        {
            var recipeIngredient = await this.recipeIngredientsRepository
                .All()
                .FirstOrDefaultAsync(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId);

            this.recipeIngredientsRepository.Delete(recipeIngredient);
            await this.recipeIngredientsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetIngredientByRecipeAsync<T>(string recipeId)
        {
            var ingredients = await this.recipeIngredientsRepository
                .All()
                .Where(ri => ri.RecipeId == recipeId)
                .OrderBy(ri => ri.Ingredient.Name)
                .To<T>()
                .ToListAsync();

            return ingredients;
        }
    }
}
