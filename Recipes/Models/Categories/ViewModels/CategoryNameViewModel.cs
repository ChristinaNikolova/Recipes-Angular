using Recipes.Data.Models;
using Recipes.Services.Mapping;

namespace Recipes.Models.Categories.ViewModels
{
    public class CategoryNameViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }
    }
}
