using ChatApp.Application.Persistance.Contracts;
using ChatApp.Domain.Entities;
using ChatApp.Persistence.Configuration.Entities;
using ChatApp.Persistence.DatabaseContext;
using ChatApp.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace ChatApp.Persistence;

public static class DependancyInjection
{
    public static IServiceCollection ConfigurePersistenceService(this IServiceCollection services,IConfiguration
        configuration)
    {
        //Configure database
        services.AddDbContext<AppliactionDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString(name: "DefaultConnection"));
            });
        //Configure
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IMessageReopsitory, MessageRepository>();

        //Configure Token
        services.AddScoped<ITokenServices, TokenServices>();


        //config idenitty
        services.AddIdentity<AppUser, IdentityRole>()
        .AddEntityFrameworkStores<AppliactionDbContext>()
        .AddDefaultTokenProviders();
        services.AddMemoryCache();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[key: "Token:Key"])),
                        ValidIssuer = configuration[key: "Token:Issuer"]
                    };

                });

        return services;
    }
    public static async void ConfigMiddleware(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await IdentitySeed.SeedUserAsync(userManager, roleManager);

        }
    }




}
