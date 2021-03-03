namespace Recipes.Areas.Admin.Models.Categories.InputModels
{
    using Recipes.Data.Models;
    using Recipes.Services.Mapping;

    public class CategoryUpdateInputModel : CategoryInputModel, IMapFrom<Category>
    {
        public string Id { get; set; }
    }
}
