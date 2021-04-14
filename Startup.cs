using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FagElGamous.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using FagElGamous.Services;
using FagElGamous.Models;
using FagElGamous.Controllers;

namespace FagElGamous
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.Configure<Settings>(Configuration.GetSection("TestApp:Settings"));
            services.AddAzureAppConfiguration();
            services.AddRazorPages();

            services.AddDbContext<FagElGamousContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:FagElGamousIdentityConnection"]));

            services.AddDbContext<PolicyRolesDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:PolicyRolesDbConnection"]));

            services.AddDbContext<BYUExcavationDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:BYUExcavationDbConnection"]));

            services.AddAuthentication()
                .AddGoogle(googleOptions =>
                    {
                        IConfigurationSection googleAuthNSection =
                            Configuration.GetSection("Authentication:Google");

                        googleOptions.ClientId = googleAuthNSection["ClientId"];
                        googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                    })
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                    facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                })
                .AddMicrosoftAccount(microsoftOptions =>
                {
                    microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ClientId"];
                    microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
                })
                .AddTwitter(twitterOptions =>
                {
                    twitterOptions.ConsumerKey = Configuration["Authentication:Twitter:ConsumerAPIKey"];
                    twitterOptions.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
                    twitterOptions.RetrieveUserDetails = true;
                })
                .AddGitHub(githubOptions =>
                {
                    githubOptions.ClientId = Configuration["Authentication:GitHub:ClientID"];
                    githubOptions.ClientSecret = Configuration["Authentication:GitHub:SecretID"];
                });

            PolicyRolesDbContext context = services.BuildServiceProvider().GetService<PolicyRolesDbContext>();
            if (context.WriteRoles.Any())
            {
                services.AddAuthorization(options =>
                {
                    options.AddPolicy("writepolicy",
                        builder => builder.RequireRole(Policy.GetWriteRoles(context)));
                });
            }
            else
            {
                context.WriteRoles.Add(new WriteRole { Role = "Admin" });
                context.SaveChanges();
                services.AddAuthorization(options =>
                {
                    options.AddPolicy("writepolicy",
                        builder => builder.RequireRole(Policy.GetWriteRoles(context)));
                });
            }
            if (context.DeleteRoles.Any())
            {
                services.AddAuthorization(options =>
                {
                    options.AddPolicy("deletepolicy",
                        builder => builder.RequireRole(Policy.GetDeleteRoles(context)));
                });
            }
            else
            {
                context.DeleteRoles.Add(new DeleteRole { Role = "Admin" });
                context.SaveChanges();
                services.AddAuthorization(options =>
                {
                    options.AddPolicy("deletepolicy",
                        builder => builder.RequireRole(Policy.GetDeleteRoles(context)));
                });
            }

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

        }
          
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAzureAppConfiguration();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("sex",
                    "Sex/{sex}",
                    new { action = "Index" });

                endpoints.MapControllerRoute("usertype",
                    "UserManager/UserType/{usertype}",
                    new { Controller = "UserManager", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
