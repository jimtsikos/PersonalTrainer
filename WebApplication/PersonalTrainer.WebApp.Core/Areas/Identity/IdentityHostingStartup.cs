using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalTrainer.WebApp.Core.Areas.Identity.Data;
using PersonalTrainer.WebApp.Core.Models;

[assembly: HostingStartup(typeof(PersonalTrainer.WebApp.Core.Areas.Identity.IdentityHostingStartup))]
namespace PersonalTrainer.WebApp.Core.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                switch (context.Configuration.GetSection("DatabaseEngine").Value)
                {
                    case "MySQL":
                        services.AddDbContext<PersonalTrainerWebContext>(options =>
                            options.UseMySQL(
                                context.Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("PersonalTrainer.WebApp.Core")));
                        break;
                    default:
                        services.AddDbContext<PersonalTrainerWebContext>(options =>
                            options.UseSqlServer(
                                context.Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("PersonalTrainer.WebApp.Core")));
                        break;
                }
                
                services.AddDefaultIdentity<User>().AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<PersonalTrainerWebContext>();
            });
        }
    }
}
