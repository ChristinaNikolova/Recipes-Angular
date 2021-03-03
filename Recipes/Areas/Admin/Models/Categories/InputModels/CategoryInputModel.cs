namespace Recipes.Areas.Admin.Models.Categories.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using Recipes.Common;
    using Recipes.Data.Common;

    public class CategoryInputModel
    {
        [Required]
        [StringLength(Validations.Category.NameMaxLenght, ErrorMessage = Messages.RequiredMinMaxLengthError, MinimumLength = InputValidations.CategoryNameMinLenght)]
        public string Name { get; set; }

        [Required]
        public string Picture { get; set; }
    }
}
