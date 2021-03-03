namespace Recipes.Models.Ingredients.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using global::Recipes.Common;
    using global::Recipes.Data.Common;

    public class IngredientCreateAdminInputModel
    {
        [Required]
        [StringLength(Validations.Ingredient.NameMaxLenght, ErrorMessage = Messages.RequiredMinMaxLengthError, MinimumLength = InputValidations.IngredientNameMinLenght)]
        public string Name { get; set; }
    }
}
