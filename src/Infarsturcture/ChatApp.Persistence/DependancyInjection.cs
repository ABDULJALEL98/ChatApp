using ChatApp.Application.Persistance.Contracts;
using ChatApp.Persistence.DatabaseContext;
using ChatApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        return services;
    }
}
