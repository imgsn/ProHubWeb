using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProHub.Core.Services.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProHub.Core.Config;
using ProHub.Core.Helpers;
using ProHub.Core.Services.Establishments;
using ProHub.Core.Services.Jwt;
using ProHub.Data.UnitofWork;

namespace ProHub.Core.Extensions
{
    public static class StartupExtension
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection iServiceCollection)
        {
            iServiceCollection.AddHttpContextAccessor();

            iServiceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            iServiceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            iServiceCollection.AddTransient<IAccountServices, AccountServices>();
            iServiceCollection.AddTransient<IJwtServices, JwtServices>();
            iServiceCollection.AddTransient<IEstablishmentServices, EstablishmentServices>();


            return iServiceCollection;
        }

        public static IServiceCollection AddMapper(this IServiceCollection iServiceCollection)
        {
            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MapperHelper()));
            iServiceCollection.AddSingleton(mappingConfig.CreateMapper());
            return iServiceCollection;
        }


        public static IServiceCollection AddAuthorize(this IServiceCollection services, IConfiguration configuration)
        {
            var token = configuration.GetSection("Jwt").Get<JwtConfig>();

            services.AddAuthentication()
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddJwtBearer("api", x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)),
                        ValidIssuer = token.Issuer,
                        ValidAudience = token.Audience,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero,
                        RequireExpirationTime = true,
                    };
                });
            services.Configure<IdentityOptions>(options =>
             {
                 options.User.RequireUniqueEmail = true;
                 options.Password.RequireDigit = true;
                 options.Password.RequiredLength = 8;
                 options.Password.RequireNonAlphanumeric = false;
                 options.Password.RequireUppercase = false;
                 options.Password.RequireLowercase = false;
                 options.Password.RequiredUniqueChars = 1;
                 options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                 options.Lockout.MaxFailedAccessAttempts = 10;
                 options.SignIn.RequireConfirmedEmail = true;
             });
            //services.AddAuthentication(x =>
            //    {
            //        x.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    })
            //    .AddCookie("",CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(IdentityConstants.ApplicationScheme, options =>
            //    {
            //        options.AccessDeniedPath = "/Auth/AccessDenied";
            //        options.Cookie.Name = "trackHub";
            //        options.Cookie.HttpOnly = true;
            //        options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
            //        options.LoginPath = "/Auth/Login";
            //        // ReturnUrlParameter requires 
            //        //using Microsoft.AspNetCore.Authentication.Cookies;
            //        options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            //        options.SlidingExpiration = true;
            //    })
            //    .AddJwtBearer("api", x =>
            //    {
            //        x.RequireHttpsMetadata = false;
            //        x.SaveToken = true;
            //        x.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)),
            //            ValidIssuer = token.Issuer,
            //            ValidAudience = token.Audience,
            //            ValidateIssuer = false,
            //            ValidateAudience = false,
            //            ClockSkew = TimeSpan.Zero,
            //            RequireExpirationTime = true,
            //        };
            //    });



            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "proHubIdentity";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(50);
                options.LoginPath = "/Account/Login";
                //options.se = SameSiteMode.None;
                // ReturnUrlParameter requires 
                //using Microsoft.AspNetCore.Authentication.Cookies;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });





            return services;
        }
    }
}
