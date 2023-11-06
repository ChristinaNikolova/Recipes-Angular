namespace Recipes.Web.Models.Admin.Categories.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using global::Recipes.Common;

    public class CategoryInputModel
    {
        [Required]
        [StringLength(Validations.CategoryNameMaxLenght, ErrorMessage = Messages.RequiredMinMaxLengthError, MinimumLength = Validations.CategoryNameMinLenght)]
        public string Name { get; set; }

        [Required]
        public string Picture { get; set; }
    }
}
