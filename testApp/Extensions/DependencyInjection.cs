using System;
using Dadata;
using Serilog;
using AutoMapper;
using Dadata.Model;
using testApp.DaData;
using testApp.Models;

namespace testApp.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSerilog(o =>
        {
            o.WriteTo.Console();
        });
        var token = configuration.GetRequiredSection("ApiToken").Value;
        var secret = configuration.GetRequiredSection("SecretKey").Value;
        services.AddScoped<ICleanClientSync>(sp => new CleanClientSync(token, secret));
        services.AddScoped(sp => new MapperConfiguration(mc =>
        {
            mc.CreateMap<Address, AddressDTO>();
        }).CreateMapper());

        services.AddScoped<ICleaner<DaDataPackageCleaner>>();
        services.AddScoped<ICleaner<DaDataHttpCleaner>>();

        return services;
    }
}

