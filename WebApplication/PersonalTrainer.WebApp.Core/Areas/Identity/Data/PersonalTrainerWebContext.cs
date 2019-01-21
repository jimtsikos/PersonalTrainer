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
        }
    }
}
