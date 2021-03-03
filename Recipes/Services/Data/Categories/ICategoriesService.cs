namespace Recipes.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<string>> GetAllNamesAsync();

        Task<string> GetIdByNameAsync(string categoryName);
    }
}
