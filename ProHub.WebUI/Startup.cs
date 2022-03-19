using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProHub.Domain;
using ProHub.Domain.Config;
using ProHub.Domain.Entities;
using ProHub.Domain.Extensions;
using ProHub.Domain.Helpers;
using ProHub.Local;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ProHub.WebUI
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

            services.AddDatabaseDeveloperPageExceptionFilter();


            services.AddDbContext<ProHubDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("HubConnection"),
                b => b.MigrationsAssembly("ProHub.Domain")));

            services.AddDefaultIdentity<Account>()
                .AddRoles<AccountRole>()
                .AddSignInManager<SignInManager<Account>>()
                .AddRoleManager<RoleManager<AccountRole>>()
                .AddEntityFrameworkStores<ProHubDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<SmtpConfig>(Configuration.GetSection("SmtpConfig"));
            services.Configure<JwtConfig>(Configuration.GetSection("Jwt"));


            services.AddAuthorize(Configuration);
            services.AddServiceDependencies();
            services.AddControllersWithViews();
            services.AddLocalization();


            services.AddSingleton<LocalService>();
            services.AddMvc()
           .AddViewLocalization()
           .AddDataAnnotationsLocalization(options => options.DataAnnotationLocalizerProvider = (type, factory) =>
           {
               var assemblyName = new AssemblyName(typeof(GlobalResource).GetTypeInfo().Assembly.FullName ?? "ProHub.Local");
               return factory.Create("GlobalResource", assemblyName.Name);
           });
            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    options.DefaultRequestCulture = new RequestCulture(culture: "ar-SA", uiCulture: "en-US");
                    options.SupportedCultures = CultureHelper.SupportedCultures;
                    options.SupportedUICultures = CultureHelper.SupportedCultures;
                    options.RequestCultureProviders = new List<IRequestCultureProvider>
        {
              new CookieRequestCultureProvider() { CookieName = ConstantHelper.CookiesName }
        };

                    options.AddInitialRequestCultureProvider(new CookieRequestCultureProvider() { CookieName = ConstantHelper.CookiesName });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hubLog/{Date}.txt"));
            app.UseRequestLocalization();
            //  app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>()?.Value);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //  app.UseMigrationsEndPoint();
                app.UseExceptionHandler(builder => builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "text/html";
                    var ex = context.Features.Get<IExceptionHandlerFeature>();
                    if (ex != null)
                    {
                        var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace}";
                        context.Response.Headers.Add("application-error", ex.Error.Message);
                        context.Response.Headers.Add("access-control-expose-headers", "application-error");
                        context.Response.Headers.Add("access-control-allow-origin", "*");
                        await context.Response.WriteAsync(err).ConfigureAwait(false);
                    }
                }));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
