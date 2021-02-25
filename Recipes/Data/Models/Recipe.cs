namespace Recipes.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Recipes.Data.Common;
    using Recipes.Data.Common.Base;

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
        [MaxLength(Validations.Recipe.TitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MaxLength(Validations.Recipe.ContentMaxLenght)]

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

        public virtual ICollection<RecipeIngredient> RepiceIngredients { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<RecipeLike> RecipeLikes { get; set; }
    }
}
