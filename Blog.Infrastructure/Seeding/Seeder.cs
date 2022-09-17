using Blog.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Blog.Infrastructure.Seeding
{
    public static class Seeder
    {
        public static async Task Initialize(IServiceProvider services, string adminName,
            string adminPassword, string adminEmail, string adminRoleName)
        {
            return;
            
            var userManager = services.GetRequiredService<UserManager<User>>();

            var adminUser = new User
            {
                FullName = adminName,
                Email = adminEmail,
                UserName = adminEmail
            };

            await Seeder.SeedUserAsAdministrator(
         adminPassword,adminRoleName, services, userManager,adminUser);
        }

        public static async Task SeedUserAsAdministrator(string adminPassword, string adminRoleName,
            IServiceProvider services, UserManager<User> userManager, User adminUser)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            var result = await userManager.CreateAsync(adminUser, adminPassword);

            if (!result.Succeeded)
            {
                throw new Exception("User is not created.");
            }

            await SeedAdminRole(adminRoleName, roleManager);

            await userManager.AddToRoleAsync(adminUser, adminRoleName);
        }

        private static async Task SeedAdminRole(string adminRoleName, RoleManager<IdentityRole> roleManager)
        {
            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (await roleManager.RoleExistsAsync(adminRoleName))
            {
                return;
            }

            var adminRole = new IdentityRole(adminRoleName);

            await roleManager.CreateAsync(adminRole);
        }
    }
}
