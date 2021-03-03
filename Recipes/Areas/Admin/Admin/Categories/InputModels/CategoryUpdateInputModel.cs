namespace Recipes.Areas.Admin.Admin.Categories.InputModels
{
    using Recipes.Data.Models;
    using Recipes.Services.Mapping;

    public class CategoryUpdateInputModel : CategoryInputModel, IMapFrom<Category>
    {
        public string Id { get; set; }
    }
}
