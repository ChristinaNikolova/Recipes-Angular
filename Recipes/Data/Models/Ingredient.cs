namespace Recipes.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Recipes.Data.Common;
    using Recipes.Data.Common.Base;

    public class Ingredient : BaseDeletableModel<string>
    {
        public Ingredient()
        {
            this.Id = Guid.NewGuid().ToString();
            this.RepiceIngredients = new HashSet<RecipeIngredient>();
        }

        [Required]
        [MaxLength(Validations.Ingredient.NameMaxLenght)]
        public string Name { get; set; }

        public virtual ICollection<RecipeIngredient> RepiceIngredients { get; set; }
    }
}
