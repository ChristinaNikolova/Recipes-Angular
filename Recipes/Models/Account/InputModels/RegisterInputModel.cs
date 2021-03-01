namespace Recipes.Models.Account.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using global::Recipes.Common;

    public class RegisterInputModel
    {
        [Required]
        [MinLength(InputValidations.UsernameMinimumLength, ErrorMessage = Messages.UsernameError)]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = Messages.EmailError)]
        public string Email { get; set; }

        [Required]
        [MinLength(InputValidations.PasswordMinimumLength, ErrorMessage = Messages.PasswordError)]
        public string Password { get; set; }
    }
}
