namespace Recipes.Common
{
    public static class InputValidations
    {
        // User
        public const int UsernameMinimumLength = 3;

        public const int PasswordMinimumLength = 5;

        // Comment
        public const int CommentContentMinimumLength = 3;

        // Recipe
        public const int RecipeTitleMinLenght = 3;

        public const int RecipeContentMinLenght = 3;

        public const string RecipePortionsMin = "1";

        public const string RecipePrepTimeMin = "1";

        public const string RecipeCookTimeMin = "1";

        public const string IntMaxValue = "2147483647";
    }
}
