namespace Recipes.Web.Models.Account.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using global::Recipes.Common;

    public class RegisterInputModel
    {
        [Required]
        [MinLength(Validations.UserUsernameMinLength, ErrorMessage = Messages.UsernameError)]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = Messages.EmailError)]
        public string Email { get; set; }

        [Required]
        [MinLength(Validations.UserPasswordMinLength, ErrorMessage = Messages.PasswordError)]
        public string Password { get; set; }
    }
}
