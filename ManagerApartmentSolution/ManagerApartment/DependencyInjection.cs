using System.Diagnostics;
using ManagerApartment;
//using Azure.Storage.Blobs;
using ManagerApartment.Configuration;

namespace ManagerApartment.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection ManagerApartmentConfiguration(this IServiceCollection services, string secretKey)
    {
        //services.SecurityConfiguration(secretKey);
        // ALLOW HTTP
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHealthChecks();

        services.AddSingleton<Stopwatch>();
        services.AddHttpContextAccessor();
        services.AddCors(option => option.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));

        services.ConfigureSwagger();


        return services;
    }
}