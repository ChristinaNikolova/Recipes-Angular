namespace Recipes.Web.Models.Categories.ViewModels
{
    using global::Recipes.Data.Models;
    using global::Recipes.Services.Mapping;

    public class CategoryNameViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }
    }
}
