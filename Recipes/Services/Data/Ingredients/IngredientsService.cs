namespace Recipes.Services.Data.Ingredients
{
    using System.Linq;
    using System.Threading.Tasks;

    using global::Recipes.Data.Common.Repositories;
    using global::Recipes.Data.Models;
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
    }
}
