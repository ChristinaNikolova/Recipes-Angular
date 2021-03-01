namespace Recipes.Common
{
    public static class GlobalConstants
    {
        // admin
        public const string AdministratorRoleName = "Administrator";

        public const string AdminName = "Admin";

        public const string AdminEmail = "admin@recipes.com";

        public const string SystemPasswordHashed = "AQAAAAEAACcQAAAAECrjCD23cQQ28Tyci+UMuaGrFMDUb/trG4E0RbJa4McRVfWFJ6c5UG4NpbXDB6K5rQ==";

        // user
        public const string User = "User";

        // seeders path
        public const string CategorySeederPath = @"./Data/Data/Seeding/Data/Categories.json";

        public const string IngredientSeederPath = @"./Data/Data/Seeding/Data/Ingredients.json";

        // jwt
        public const int DefaultDaysExpiredToken = 7;
    }
}
