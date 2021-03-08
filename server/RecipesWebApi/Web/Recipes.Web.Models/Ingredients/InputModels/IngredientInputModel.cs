namespace Recipes.Web.Models.Ingredients.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using global::Recipes.Common;

    public class IngredientInputModel
    {
        [Required]
        [StringLength(Validations.IngredientNameMaxLenght, ErrorMessage = Messages.RequiredMinMaxLengthError, MinimumLength = Validations.IngredientNameMinLenght)]
        public string Name { get; set; }

        [Required]
        [StringLength(Validations.RepiceIngredientQuantityMaxLenght, ErrorMessage = Messages.RequiredMinMaxLengthError, MinimumLength = Validations.RepiceIngredientQunatityMinLenght)]
        public string Quantity { get; set; }
    }
}
