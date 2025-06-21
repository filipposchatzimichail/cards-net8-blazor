using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Logicea.Cards.DataAccess
{
    public static class DbInitializer
    {
        public static async Task SeedUsersAndRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // 1. Create roles if they don't exist
            string[] roles = { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    try
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                    catch (Exception) { }
                    
                }
            }

            // 2. Seed Admin User
            await CreateUserWithRoleAsync(userManager, "admin@logicea.com", "Admin123!", "Admin");

            // 3. Seed Normal Users
            await CreateUserWithRoleAsync(userManager, "user1@logicea.com", "User123!", "User");
            await CreateUserWithRoleAsync(userManager, "user2@logicea.com", "User123!", "User");
        }

        private static async Task CreateUserWithRoleAsync(UserManager<IdentityUser> userManager, string email, string password, string role)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                try
                {
                    var result = await userManager.CreateAsync(user, password);
                }
                catch (Exception)
                {
                }                
            }

            // Ensure the user is in the role
            if (!(await userManager.IsInRoleAsync(user, role)))
            {
                try
                {
                    await userManager.AddToRoleAsync(user, role);
                }
                catch (Exception)
                {
                }                
            }
        }

    }
}
