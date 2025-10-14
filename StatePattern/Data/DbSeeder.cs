using Microsoft.AspNetCore.Identity;
using StatePattern.Models;

namespace StatePattern.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            // ------------------ Seed Roles ------------------
            string[] roles = new[] { "Admin", "User" };

            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole<Guid>
                    {
                        Name = roleName,
                        NormalizedName = roleName.ToUpper()
                    });
                }
            }

            // ------------------ Seed Admin User ------------------
            string adminUserName = "admin";
            string adminEmail = "admin@example.com";
            string adminPassword = "Admin123!"; // Change in production

            if (await userManager.FindByNameAsync(adminUserName) == null)
            {
                var adminUser = new User
                {
                    UserName = adminUserName,
                    Email = adminEmail,
                    Role = "Admin"
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
                else
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception($"Failed to create admin user: {errors}");
                }
            }
        }
    }
}
