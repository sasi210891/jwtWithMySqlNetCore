using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTDemo.Web
{
    public class SeedDB
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            try
            {
                var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

                context.Database.EnsureCreated();
                if (!context.Users.Any())
                {
                    ApplicationUser user = new ApplicationUser()
                    {
                        Email = "sasi.kiran16@gmail.com",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = "sasi.kiran16@gmail.com",
                    };

                    var identityResult = await userManager.CreateAsync(user, "Asd@123");
                    if (identityResult.Succeeded)
                    {
                        //Create Default Role
                        Role role = new Role()
                        {
                            Name = "Admin",
                            NormalizedName = "Admin"
                        };

                        await roleManager.CreateAsync(role);
                        var dbUser = await userManager.FindByEmailAsync(user.Email);
                        await userManager.AddToRoleAsync(dbUser, role.NormalizedName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
