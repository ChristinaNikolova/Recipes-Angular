namespace Recipes.Services.Data.Ingredients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IIngredientsService
    {
        Task<string> CreateAsync(string name);

        Task UpdateAsync(string id, string name);

        Task<bool> IsAlreadyAddedAsync(string name);

        Task<string> GetIdByNameAsync(string name);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetDetailsAsync<T>(string id);

        Task DeleteAsync(string id);
    }
}
