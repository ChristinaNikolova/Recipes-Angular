namespace Recipes.Web.Models.Recipes.InputModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using global::Recipes.Common;
    using global::Recipes.Web.Models.Ingredients.InputModels;

    public class RecipeInputModel
    {
        [Required]
        [StringLength(Validations.RecipeTitleMaxLenght, ErrorMessage = Messages.RequiredMinMaxLengthError, MinimumLength = Validations.RecipeTitleMinLenght)]
        public string Title { get; set; }

        [Required]
        [StringLength(Validations.RecipeContentMaxLenght, ErrorMessage = Messages.RequiredMinMaxLengthError, MinimumLength = Validations.RecipeContentMinLenght)]

        public string Content { get; set; }

        [Required]

        public string Picture { get; set; }

        [Range(typeof(int), Validations.RecipePortionsMin, Validations.RecipeIntMaxValue)]
        public int Portions { get; set; }

        [Range(typeof(int), Validations.RecipePrepTimeMin, Validations.RecipeIntMaxValue)]
        public int PreparationTime { get; set; }

        [Range(typeof(int), Validations.RecipeCookTimeMin, Validations.RecipeIntMaxValue)]
        public int CookingTime { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public IEnumerable<IngredientInputModel> Ingredients { get; set; }
    }
}
