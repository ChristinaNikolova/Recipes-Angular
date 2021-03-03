namespace Recipes.Common
{
    public static class GlobalConstants
    {
        // Admin
        //public const string AdministratorRoleName = "Administrator";

        public const string AdminName = "Admin";

        public const string AdminEmail = "admin@recipes.com";

        public const string SystemPasswordHashed = "AQAAAAEAACcQAAAAECrjCD23cQQ28Tyci+UMuaGrFMDUb/trG4E0RbJa4McRVfWFJ6c5UG4NpbXDB6K5rQ==";

        // User
        public const string User = "User";

        // Seeders path
        public const string CategorySeederPath = @"./Data/Data/Seeding/Data/Categories.json";

        public const string IngredientSeederPath = @"./Data/Data/Seeding/Data/Ingredients.json";

        // JWT
        public const int DefaultDaysExpiredToken = 7;

        // Criteria
        public const string OldCriteria = "old";

        public const string NewCriteria = "new";

        public const string LikesCountCriteria = "likes";

        public const string CommentsCountCriteria = "comments";
    }
}
