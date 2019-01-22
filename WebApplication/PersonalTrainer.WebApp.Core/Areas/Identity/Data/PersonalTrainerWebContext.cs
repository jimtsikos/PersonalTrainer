using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalTrainer.WebApp.Core.Areas.Identity.Data;

namespace PersonalTrainer.WebApp.Core.Models
{
    public class PersonalTrainerWebContext : IdentityDbContext<User>
    {
        public PersonalTrainerWebContext(DbContextOptions<PersonalTrainerWebContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string adminId = Convert.ToString(Guid.NewGuid());
            string roleId = Convert.ToString(Guid.NewGuid());

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "System Administrator",
                NormalizedName = "System Administrator"
            });

            List<string> roleNames = new List<string>()
            {
                "Administrator",
                "Moderator",
                "Trainer",
                "Student"
            };

            roleNames.ForEach(x =>
            {
                builder.Entity<IdentityRole>().HasData(new IdentityRole
                {
                    Id = Convert.ToString(Guid.NewGuid()),
                    Name = x,
                    NormalizedName = x
                });
            });

            var hasher = new PasswordHasher<User>();
            var user = new User
            {
                Id = adminId,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = string.Empty
            };
            user.PasswordHash = hasher.HashPassword(user, "P@ssw0rd");

            builder.Entity<User>().HasData(user);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
