using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ManagerApartment.Models;
using Services.Interfaces.IUnitOfWork;
using Repository.UnitOfWork;
using Repository.Repository;
using Services.Interfaces;
using Services.AutoMappers;
using Services.Servicesss.Implement;
using Services.Servicesss;

namespace Infrastructures;

public static class DependencyInjection
{
    public static IServiceCollection RepositoryConfiguration(this IServiceCollection services, string connectionString, IConfiguration configuration, string azure)
    {
        //Add Database
        services.AddDbContext<ManagerApartmentContext>(options => {
            options.UseSqlServer(connectionString);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        //Add DI Container
        services.AddTransient<IUnitOfWork, UnitOfWork>();


        services.AddTransient<StaffService, StaffImplement>();
        services.AddTransient<IStaffRepository, StaffRepository>();

        services.AddMvc().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


        //services.AddScoped(_ => {
        //    return new BlobServiceClient(azure);
        //});

        //AUTOMAPPER
        services.AddAutoMapper(typeof(ApplicationMapper));

        return services;
    }
}