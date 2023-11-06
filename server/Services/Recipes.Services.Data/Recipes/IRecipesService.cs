﻿namespace Recipes.Services.Data.Recipes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using global::Recipes.Web.Models.Ingredients.InputModels;

    public interface IRecipesService
    {
        Task CreateAsync(string title, string content, int portions, int preparationTime, int cookingTime, string categoryName, string pictureUrl, IEnumerable<IngredientInputModel> ingredients, string userId);

        Task<bool> IsTitleAlreadyExistingAsync(string title);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetAllByCategoryAsync<T>(string categoryId);

        Task<T> GetDetailsAsync<T>(string id);

        Task<IEnumerable<T>> GetSearchedAsync<T>(string query);

        Task<IEnumerable<T>> GetOrderAsync<T>(string criteria);

        Task DeleteAsync(string recipeId);

        Task UpdateAsync(string id, string title, string content, string categoryName, int cookingTime, int preparationTime, int portions, IEnumerable<IngredientInputModel> ingredients, string picture);
    }
}
