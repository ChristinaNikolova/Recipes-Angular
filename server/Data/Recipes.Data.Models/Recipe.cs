namespace Recipes.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Recipes.Common;
    using Recipes.Data.Common.BaseModels;

    public class Recipe : BaseDeletableModel<string>
    {
        public Recipe()
        {
            this.Id = Guid.NewGuid().ToString();
            this.RepiceIngredients = new HashSet<RecipeIngredient>();
            this.Comments = new HashSet<Comment>();
            this.RecipeLikes = new HashSet<RecipeLike>();
        }

        [Required]
        [MaxLength(Validations.RecipeTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MaxLength(Validations.RecipeContentMaxLenght)]

        public string Content { get; set; }

        [Required]

        public string Picture { get; set; }

        public int Portions { get; set; }

        public int PreparationTime { get; set; }

        public int CookingTime { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<RecipeLike> RecipeLikes { get; set; }

        public virtual ICollection<RecipeIngredient> RepiceIngredients { get; set; }
    }
}
