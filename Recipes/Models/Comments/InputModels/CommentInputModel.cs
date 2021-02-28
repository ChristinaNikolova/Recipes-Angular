namespace Recipes.Models.Comments.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using global::Recipes.Data.Common;

    public class CommentInputModel
    {
        [Required]
        [StringLength(Validations.Comment.ContentMaxLenght, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Content { get; set; }

        [Required]
        public string RecipeId { get; set; }
    }
}
