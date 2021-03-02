namespace Recipes.Services.Data.RecipeIngredients
{
    using System.Threading.Tasks;

    using global::Recipes.Data.Common.Repositories;
    using global::Recipes.Data.Models;

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
    }
}
