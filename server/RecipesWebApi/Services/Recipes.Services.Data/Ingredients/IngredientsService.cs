namespace Recipes.Services.Data.Ingredients
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using global::Recipes.Data.Common.Repositories;
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

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

        public async Task DeleteAsync(string id)
        {
            var ingredient = await this.GetByIdAsync(id);

            ingredient.IsDeleted = true;

            this.ingredientsRepository.Update(ingredient);
            await this.ingredientsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var ingredients = await this.ingredientsRepository
                .All()
                .OrderBy(i => i.Name)
                .To<T>()
                .ToListAsync();

            return ingredients;
        }

        public async Task<T> GetDetailsAsync<T>(string id)
        {
            var ingredient = await this.ingredientsRepository
                .All()
                .Where(i => i.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return ingredient;
        }

        public async Task<string> GetIdByNameAsync(string name)
        {
            var id = await this.ingredientsRepository
                .All()
                .Where(i => i.Name.ToLower() == name.ToLower())
                .Select(i => i.Id)
                .FirstOrDefaultAsync();

            return id;
        }

        public async Task<bool> IsAlreadyAddedAsync(string name)
        {
            var isAdded = await this.ingredientsRepository
                .All()
                .AnyAsync(i => i.Name.ToLower() == name.ToLower());

            return isAdded;
        }

        public async Task UpdateAsync(string id, string name)
        {
            var ingredient = await this.GetByIdAsync(id);

            ingredient.Name = name;

            this.ingredientsRepository.Update(ingredient);
            await this.ingredientsRepository.SaveChangesAsync();
        }

        private async Task<Ingredient> GetByIdAsync(string id)
        {
            return await this.ingredientsRepository
                .All()
                .FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
