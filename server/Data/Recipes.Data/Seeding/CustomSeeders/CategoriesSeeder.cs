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

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Categories.Any())
            {
                var categoriesData = JsonConvert
                    .DeserializeObject<List<CategoryDto>>(File.ReadAllText(GlobalConstants.CategorySeederPath))
                    .ToList();

                List<Category> categories = new List<Category>();

                foreach (var currentCategoryData in categoriesData)
                {
                    var category = new Category()
                    {
                        Name = currentCategoryData.Name,
                        Picture = currentCategoryData.Picture,
                    };

                    categories.Add(category);
                }

                await dbContext.Categories.AddRangeAsync(categories);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
