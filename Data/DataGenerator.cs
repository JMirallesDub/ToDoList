using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo_List.Models;

namespace Todo_List.Data
{
    public class DataGenerator
    {

        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            await EnsureTestAdminAsync(userManager);

            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any board games.
                if (context.Users.Any())
                {
                    return;   // Data was already seeded
                }

                context.Items.Add(
                    new TodoItem
                    {
                        Title = "Demo task",
                        Description = "Description demo task"
                    });

                context.SaveChanges();

            }
        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var alreadyExists = await roleManager.RoleExistsAsync(Constants.AdministratorRole);

            if (alreadyExists) return;

            await roleManager.CreateAsync(new IdentityRole(Constants.AdministratorRole));
        }

        private static async Task EnsureTestAdminAsync(UserManager<ApplicationUser> userManager)
        {
            var testAdmin = await userManager.Users
                .Where(x => x.UserName == "test@test.com")
                .SingleOrDefaultAsync();

            if (testAdmin != null) return;

            testAdmin = new ApplicationUser { UserName = "Test", Email = "test@test.com" };
            await userManager.CreateAsync(testAdmin, "Pwd_123");
            await userManager.AddToRoleAsync(testAdmin, Constants.AdministratorRole);
        }

    }
}
