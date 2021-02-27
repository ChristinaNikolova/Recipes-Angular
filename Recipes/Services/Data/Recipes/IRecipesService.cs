namespace Recipes.Services.Data.Recipes
{
    using System.Threading.Tasks;

    public interface IRecipesService
    {
        Task CreateAsync(string title, string content, int portions, int preparationTime, int cookingTime, string categoryName, string pictureUrl, string userId);

        Task<bool> IsTitleAlreadyExistingAsync(string title);
    }
}
