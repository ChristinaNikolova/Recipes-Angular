namespace Recipes.Services.Ingredients
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Recipes.Data.Common.Repositories;
    using Recipes.Data.Models;

    public class IngredientsService : IIngredientsService
    {
        private readonly IRepository<Ingredient> ingredientsRepository;

        public IngredientsService(IRepository<Ingredient> ingredientsRepository)
        {
            this.ingredientsRepository = ingredientsRepository;
        }

        public async Task<string> CreateAsync(string name)
        {
            var ingredient = new Ingredient()
            {
                Name = name,
            };

            await this.ingredientsRepository.AddAsync(ingredient);
            await this.ingredientsRepository.SaveChangesAsync();

            return ingredient.Id;
        }

        public async Task<bool> IsAlreadyAddedAsync(string name)
        {
            var isAdded = await this.ingredientsRepository
                .All()
                .AnyAsync(i => i.Name.ToLower() == name.ToLower());

            return isAdded;
        }
    }
}
