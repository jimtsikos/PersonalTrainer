using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainer.WebApp.Core.Areas.Identity.Data
{
    public class PersonalTrainerWebDbInitializer
    {
        public void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            List<string> roleNames = new List<string>()
            {
                "System Administrator",
                "Administrator",
                "Moderator",
                "Trainer",
                "Student"
            };

            roleNames.ForEach(x =>
            {
                if (!roleManager.RoleExistsAsync(x).Result)
                {
                    IdentityRole identityRole = new IdentityRole
                    {
                        Name = x,
                        NormalizedName = x
                    };
                }
            });
        }

        public void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@admin.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    Email = "admin@admin.com",
                    NormalizedEmail = "admin@admin.com",
                    EmailConfirmed = true,
                    SecurityStamp = string.Empty
                };

                IdentityResult result = userManager.CreateAsync(user, "admin").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "System Administrator").Wait();
                }
            }
        }
    }
}
