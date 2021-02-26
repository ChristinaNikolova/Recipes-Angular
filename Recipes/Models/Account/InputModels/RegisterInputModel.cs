namespace Recipes.Models.Account.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterInputModel
    {
        //const
        private const int UsernameMinimumLength = 3;
        private const int PasswordMinimumLength = 5;

        private const string EmailErrorMessage = "Please enter valid e-mail address.";
        private const string UsernameErrorMessage = "Username should be at least 3 symbols long.";
        private const string PasswordErrorMessage = "Password should be at least 5 symbols long.";

        [Required]
        [MinLength(UsernameMinimumLength, ErrorMessage = UsernameErrorMessage)]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = EmailErrorMessage)]
        public string Email { get; set; }

        [Required]
        [MinLength(PasswordMinimumLength, ErrorMessage = PasswordErrorMessage)]
        public string Password { get; set; }
    }
}
