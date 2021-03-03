namespace Recipes.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<string> GetIdByNameAsync(string categoryName);

        Task<bool> IsCategoryAlreadyExistingAsync(string name);

        Task CreateAsync(string name, string picture);
    }
}
