namespace Recipes.Services.Ingredients
{
    using System.Threading.Tasks;

    public interface IIngredientsService
    {
        Task<string> CreateAsync(string name);

        Task<bool> IsAlreadyAddedAsync(string name);
    }
}
