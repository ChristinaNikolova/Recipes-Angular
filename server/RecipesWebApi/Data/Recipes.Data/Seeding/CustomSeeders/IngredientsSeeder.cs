namespace Recipes.Data.Seeding.CustomSeeders
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using Recipes.Common;
    using Recipes.Data.Models;
    using Recipes.Data.Seeding.Dtos;

    public class IngredientsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Ingredients.Any())
            {
                var ingredientsData = JsonConvert
                    .DeserializeObject<List<IngredientDto>>(File.ReadAllText(GlobalConstants.IngredientSeederPath))
                    .ToList();

                List<Ingredient> ingredients = new List<Ingredient>();

                foreach (var currentIngredientData in ingredientsData)
                {
                    var ingredient = new Ingredient()
                    {
                        Name = currentIngredientData.Name,
                    };

                    ingredients.Add(ingredient);
                }

                await dbContext.Ingredients.AddRangeAsync(ingredients);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
