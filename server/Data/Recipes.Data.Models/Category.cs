namespace Recipes.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Recipes.Common;
    using Recipes.Data.Common.BaseModels;

    public class Category : BaseDeletableModel<string>
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Recipes = new HashSet<Recipe>();
        }

        [Required]
        [MaxLength(Validations.CategoryNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        public string Picture { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
