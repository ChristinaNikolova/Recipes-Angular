namespace Recipes.Web.Models.Recipes.ViewModels
{
    using System.Collections.Generic;

    public class AllRecipeBaseViewModel
    {
        public IEnumerable<RecipeBaseViewModel> Recipes { get; set; }
    }
}
