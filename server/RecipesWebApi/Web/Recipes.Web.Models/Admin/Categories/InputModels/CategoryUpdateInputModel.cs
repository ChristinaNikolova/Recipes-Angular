namespace Recipes.Web.Models.Admin.Categories.InputModels
{
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;

    public class CategoryUpdateInputModel : CategoryInputModel, IMapFrom<Category>
    {
        public string Id { get; set; }
    }
}
