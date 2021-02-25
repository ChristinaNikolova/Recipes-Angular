namespace Recipes.Data.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Recipes.Data.Models;

    public class RepiceIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> repiceIngredient)
        {
            repiceIngredient
                .HasKey(ri => new { ri.IngredientId, ri.RecipeId });
        }
    }
}
