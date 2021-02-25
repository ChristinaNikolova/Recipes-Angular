namespace Recipes.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Recipes = new HashSet<Recipe>();
            this.Comments = new HashSet<Comment>();
            this.RecipeLikes = new HashSet<RecipeLike>();
        }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<RecipeLike> RecipeLikes { get; set; }
    }
}
