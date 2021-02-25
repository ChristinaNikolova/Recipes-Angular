namespace Recipes.Data.Common
{
    public static class Validations
    {
        public static class Recipe
        {
            public const int TitleMaxLenght = 50;

            public const int ContentMaxLenght = 5000;
        }

        public static class Category
        {
            public const int NameMaxLenght = 50;
        }

        public static class Ingredient
        {
            public const int NameMaxLenght = 50;
        }

        public static class RepiceIngredient
        {
            public const int QuantityMaxLenght = 50;
        }

        public static class Comment
        {
            public const int ContentMaxLenght = 500;
        }
    }
}
