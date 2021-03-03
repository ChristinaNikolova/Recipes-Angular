namespace Recipes.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<string> GetIdByNameAsync(string categoryName);

        Task<bool> IsCategoryAlreadyExistingAsync(string name);

        Task<T> GetDetailsAsync<T>(string id);

        Task CreateAsync(string name, string picture);

        Task DeleteAsync(string id);

        Task UpdateAsync(string id, string name, string picture);
    }
}
