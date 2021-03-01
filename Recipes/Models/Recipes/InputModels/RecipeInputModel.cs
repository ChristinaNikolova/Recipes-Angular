namespace Recipes.Models.Recipes.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using global::Recipes.Common;
    using global::Recipes.Data.Common;

    public class RecipeInputModel
    {
        [Required]
        [StringLength(Validations.Recipe.TitleMaxLenght, ErrorMessage = Messages.RequiredMinMaxLengthError, MinimumLength = InputValidations.RecipeTitleMinLenght)]
        public string Title { get; set; }

        [Required]
        [StringLength(Validations.Recipe.ContentMaxLenght, ErrorMessage = Messages.RequiredMinMaxLengthError, MinimumLength = InputValidations.RecipeContentMinLenght)]

        public string Content { get; set; }

        [Required]

        public string Picture { get; set; }

        [Range(typeof(int), InputValidations.RecipePortionsMin, InputValidations.IntMaxValue)]
        public int Portions { get; set; }

        [Range(typeof(int), InputValidations.RecipePrepTimeMin, InputValidations.IntMaxValue)]
        public int PreparationTime { get; set; }

        [Range(typeof(int), InputValidations.RecipeCookTimeMin, InputValidations.IntMaxValue)]
        public int CookingTime { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
