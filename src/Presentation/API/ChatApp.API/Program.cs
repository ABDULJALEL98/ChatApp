using ChatApp.Application;
using ChatApp.Persistence;
using Microsoft.OpenApi.Models;
namespace ChatApp.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(s =>

        {
            var securtiySchema = new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Description = "JWT Auth Bearer",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                Reference = new OpenApiReference()
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            };
            s.AddSecurityDefinition(name: "Bearer", securtiySchema);
            var securityRequirement = new OpenApiSecurityRequirement { { securtiySchema, new[] { "Bearer" } }};
            s.AddSecurityRequirement(securityRequirement);
        });
            
              

        //Configure Exteral Poject(dll)
        builder.Services.ConfigureApplicationService();
        builder.Services.ConfigurePersistenceService(builder.Configuration);

        //Enable Cors
        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", p =>
            {
                p.AllowAnyHeader()
                .AllowCredentials()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:4200");
            });
        });




        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors(policyName:"CorsPolicy");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        ChatApp.Persistence.DependancyInjection.ConfigMiddleware(app);


        app.Run();
    }
}
