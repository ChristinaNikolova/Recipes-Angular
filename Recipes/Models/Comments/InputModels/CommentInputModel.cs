namespace Recipes.Models.Comments.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using global::Recipes.Common;
    using global::Recipes.Data.Common;

    public class CommentInputModel
    {
        [Required]
        [StringLength(Validations.Comment.ContentMaxLenght, ErrorMessage = Messages.RequiredMinMaxLengthError, MinimumLength = InputValidations.CommentContentMinimumLength)]
        public string Content { get; set; }

        [Required]
        public string RecipeId { get; set; }
    }
}
