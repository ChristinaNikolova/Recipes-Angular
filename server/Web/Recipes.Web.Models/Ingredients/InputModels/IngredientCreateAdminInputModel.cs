namespace Recipes.Web.Models.Ingredients.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using global::Recipes.Common;

    public class IngredientCreateAdminInputModel
    {
        [Required]
        [StringLength(Validations.IngredientNameMaxLenght, ErrorMessage = Messages.RequiredMinMaxLengthError, MinimumLength = Validations.IngredientNameMinLenght)]
        public string Name { get; set; }
    }
}
