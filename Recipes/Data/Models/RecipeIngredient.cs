namespace Recipes.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Recipes.Data.Common;

    public class RecipeIngredient
    {
        [Required]
        public string RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        [Required]
        public string IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        [Required]
        [MaxLength(Validations.RepiceIngredient.QuantityMaxLenght)]
        public string Quantity { get; set; }
    }
}
