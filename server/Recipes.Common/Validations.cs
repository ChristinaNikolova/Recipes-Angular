namespace Recipes.Common
{
    public static class Validations
    {
        // Recipe
        public const int RecipeTitleMinLenght = 3;

        public const int RecipeTitleMaxLenght = 50;

        public const int RecipeContentMinLenght = 3;

        public const int RecipeContentMaxLenght = 5000;

        public const string RecipePortionsMin = "1";

        public const string RecipePrepTimeMin = "1";

        public const string RecipeCookTimeMin = "1";

        public const string RecipeIntMaxValue = "2147483647";

        // Category
        public const int CategoryNameMinLenght = 3;

        public const int CategoryNameMaxLenght = 50;

        // Ingredient
        public const int IngredientNameMinLenght = 3;

        public const int IngredientNameMaxLenght = 50;

        // RepiceIngredient
        public const int RepiceIngredientQunatityMinLenght = 3;

        public const int RepiceIngredientQuantityMaxLenght = 50;

        // Comment
        public const int CommentContentMinLength = 3;

        public const int CommentContentMaxLenght = 500;

        // User
        public const int UserUsernameMinLength = 3;

        public const int UserPasswordMinLength = 5;
    }
}
