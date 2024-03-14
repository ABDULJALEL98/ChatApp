using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application;

public static class DependancyInjection
{
    public static IServiceCollection ConfigureApplicationService(this IServiceCollection services)

    {
        //Configure AutoMapper
        services.AddAutoMapper(typeof(MappingProfiles.MappingProfile));
        //Configure MediatR
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());


        return services;
    }
}
