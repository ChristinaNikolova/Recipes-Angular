namespace Recipes.Common
{
    public static class Messages
    {
        public const string IncorrectCredentials = "Incorrect e-mail or password.";

        public const string InvalidEmail = "This e-mail is already taken. Please try with another one.";

        public const string InvalidUsername = "This username is already taken. Please try with another one.";

        public const string UnknownError = "Something went wrong.";

        public const string SuccessfulLogin = "You have successfully logged in.";

        public const string SuccessfulRegister = "You have successfully registered.";

        public const string EmailError = "Please enter valid e-mail address.";

        public const string UsernameError = "Username should be at least 3 symbols long.";

        public const string PasswordError = "Password should be at least 5 symbols long.";

        public const string RequiredMinMaxLengthError = "The {0} must be at least {2} and at max {1} characters long.";

        public const string SuccessfullyAdded = "Successfully added.";

        public const string SuccessfullyUpdated = "Successfully updated.";

        public const string SuccessfullyDeleted = "Successfully deleted.";

        public const string AlreadyExistsRecipe = "Recipe with the given title already exists.";

        public const string AlreadyExistsCategory = "Category with the given name already exists.";

        public const string AlreadyExistsIngredient = "Ingredient with the given name already exists.";
    }
}
