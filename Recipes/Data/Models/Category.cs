namespace Recipes.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Recipes.Data.Common;
    using Recipes.Data.Common.BaseModels;

    public class Category : BaseDeletableModel<string>
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Recipes = new HashSet<Recipe>();
        }

        [Required]
        [MaxLength(Validations.Category.NameMaxLenght)]
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
