using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StoreAppWeb.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAppWeb.Server
{
    public class Program
    {

        private static void CheckOrCreateAdminRole(RoleManager<IdentityRole> roleManager, string adminRole)
        {            
            var foundRole = roleManager.FindByNameAsync(adminRole)
                            .GetAwaiter()
                            .GetResult();
            if (foundRole == null)
            {
               var result = roleManager.CreateAsync(new IdentityRole(adminRole))
                                        .GetAwaiter()
                                        .GetResult();
                if (result != IdentityResult.Success)
                {
                    throw new Exception("Unable to create the default adminitstrator role");
                }
            }
        }
        private static void CreateDefaultAdmin(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminEmail = "admin@mail.com";
            var adminUser = "admin@mail.com";
            var adminRole = "Administrator";

            var user = new ApplicationUser 
            {
                Email = adminEmail,
                UserName = adminUser,
                EmailConfirmed = true
            };

            var foundAdmin = userManager.FindByEmailAsync(adminEmail)
                        .GetAwaiter()
                        .GetResult();
            
            if (foundAdmin == null)
            {
                CheckOrCreateAdminRole(roleManager, adminRole);
                var result = userManager.CreateAsync(user, "P@ssw0rd")
                           .GetAwaiter()
                           .GetResult();
                if (result != IdentityResult.Success)
                {                    
                    throw new Exception($"Failed to create user account: {result.ToString()}");
                }
                userManager.AddToRoleAsync(user, adminRole)
                           .GetAwaiter()
                           .GetResult();
                

            }
            if (!userManager.IsInRoleAsync(foundAdmin, adminRole).GetAwaiter().GetResult())
            {
                throw new Exception("Failed to configure the role");
            }
        }
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetService<RoleManager<IdentityRole>>();
                var userManager = services.GetService<UserManager<ApplicationUser>>();
                CreateDefaultAdmin(userManager, roleManager);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
