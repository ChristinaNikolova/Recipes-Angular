namespace Recipes.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using global::Recipes.Data.Common.Repositories;
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task CreateAsync(string name, string picture)
        {
            var category = new Category()
            {
                Name = name,
                Picture = picture,
            };

            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var categories = await this.categoriesRepository
                .All()
                .OrderBy(c => c.Name)
                .ThenBy(c => c.Recipes.Count)
                .To<T>()
                .ToListAsync();

            return categories;
        }

        public async Task<string> GetIdByNameAsync(string categoryName)
        {
            var categoryId = await this.categoriesRepository
                .All()
                .Where(c => c.Name == categoryName)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();

            return categoryId;
        }

        public async Task<bool> IsCategoryAlreadyExistingAsync(string name)
        {
            var isAdded = await this.categoriesRepository
                .All()
                .AnyAsync(c => c.Name.ToLower() == name.ToLower());

            return isAdded;
        }
    }
}
