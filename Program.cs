using FagElGamous.Areas.Identity.Data;
using FagElGamous.Data;
using FagElGamous.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace FagElGamous
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<FagElGamousContext>();
                    var userManager = services.GetRequiredService<UserManager<AppUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await ContextSeed.SeedRolesAsync(userManager, roleManager);
                    await ContextSeed.SeedAdminAsync(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                     {
                         var settings = config.Build();
                         config.AddAzureAppConfiguration(options =>
                         {
                             options.Connect(settings["ConnectionStrings:AppConfig"])
                                    .ConfigureRefresh(refresh =>
                                    {
                                        refresh.Register("TestApp:Settings:Message", refreshAll: true)
                                               .SetCacheExpiration(new TimeSpan(0, 0, 60));
                                    });
                         });
                     })
                    .UseStartup<Startup>();
                });

    }
}
