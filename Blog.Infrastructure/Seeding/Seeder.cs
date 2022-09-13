using Blog.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure.Seeding
{
    public static class Seeder
    {
        public static async Task Initialize(IServiceProvider services, string adminName,
            string adminPassword, string adminEmail, string adminRoleName)
        {

            await Seeder.SeedUserAsAdministrator(adminName,
         adminPassword, adminEmail, adminRoleName, services);
        }

        public static async Task SeedUserAsAdministrator(string adminName,
            string adminPassword, string adminEmail,
            string adminRoleName, IServiceProvider services)
        {

            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            var adminUser = new User
            {
                FullName = adminName,
                Email = adminEmail,
                UserName = adminEmail
            };

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
