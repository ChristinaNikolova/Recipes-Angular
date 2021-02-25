namespace Recipes.Data.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Recipes.Data.Models;

    public class RecipeLikeConfiguration : IEntityTypeConfiguration<RecipeLike>
    {
        public void Configure(EntityTypeBuilder<RecipeLike> recipeLike)
        {
            recipeLike
                .HasKey(rl => new { rl.RecipeId, rl.UserId });
        }
    }
}
