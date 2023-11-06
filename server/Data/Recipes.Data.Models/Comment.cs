﻿namespace Recipes.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Recipes.Common;
    using Recipes.Data.Common.BaseModels;

    public class Comment : BaseDeletableModel<string>
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(Validations.CommentContentMaxLenght)]
        public string Content { get; set; }

        [Required]
        public string ClientId { get; set; }

        public virtual ApplicationUser Client { get; set; }

        [Required]
        public string RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
