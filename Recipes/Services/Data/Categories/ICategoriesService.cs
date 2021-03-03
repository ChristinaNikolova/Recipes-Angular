namespace Recipes.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<string> GetIdByNameAsync(string categoryName);
    }
}
