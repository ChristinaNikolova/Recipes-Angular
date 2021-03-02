namespace Recipes.Services.Data.Ingredients
{
    using System.Threading.Tasks;

    public interface IIngredientsService
    {
        Task<string> CreateAsync(string name);

        Task<bool> IsAlreadyAddedAsync(string name);

        Task<string> GetIdByNameAsync(string name);
    }
}
