namespace Recipes.Data.Data.Seeding.CustomSeeders
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Recipes.Common;
    using Recipes.Data.Models;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedUserAsync(userManager, GlobalConstants.AdminEmail, GlobalConstants.AdminName);
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, string userEmail, string userName)
        {
            var user = await userManager.Users
                .FirstOrDefaultAsync(x => x.Email == userEmail);

            if (user == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = userName,
                    Email = userEmail,
                    EmailConfirmed = true,
                    PasswordHash = GlobalConstants.SystemPasswordHashed,
                };

                var creationResult = await userManager.CreateAsync(admin);
            }
        }
    }
}
