namespace Recipes.Web.Models.Comments.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using global::Recipes.Common;

    public class CommentInputModel
    {
        [Required]
        [StringLength(Validations.CommentContentMaxLenght, ErrorMessage = Messages.RequiredMinMaxLengthError, MinimumLength = Validations.CommentContentMinLength)]
        public string Content { get; set; }

        [Required]
        public string RecipeId { get; set; }
    }
}
