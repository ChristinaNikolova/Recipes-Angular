namespace Recipes.Models.Account.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using Recipes.Common;

    public class RegisterInputModel
    {
        [Required]
        [MinLength(InputValidations.UsernameMinimumLength, ErrorMessage = Messages.UsernameErrorMessage)]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = Messages.EmailErrorMessage)]
        public string Email { get; set; }

        [Required]
        [MinLength(InputValidations.PasswordMinimumLength, ErrorMessage = Messages.PasswordErrorMessage)]
        public string Password { get; set; }
    }
}
