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

        services.AddTransient<IAddOnRepository, AddOnRepository>();
        services.AddTransient<AddOnService, AddOnImplement>();

        services.AddTransient<IApartmentRepository, ApartmentRepository>();
        services.AddTransient<ApartmentService, ApartmentImplement>();

        services.AddTransient<IApartmentTypeRepository, ApartmentTypeRepository>();
        services.AddTransient<ApartmentTypeService, ApartmentTypeImplement>();

        services.AddTransient<IAssetHistoryRepository, AssetHistoryRepository>();
        services.AddTransient<AssetHistoryService, AssetHistoryImplement>();

        services.AddTransient<IAssetRepository, AssetRepository>();
        services.AddTransient<AssetService, AssetImplement>();



        services.AddTransient<IBillRepository, BillRepository>();
        services.AddTransient<BillService, BillImplement>();

        services.AddTransient<IBuildingRepository, BuildingRepository>();
        services.AddTransient<BuildingService, BuildingImplement>();

        services.AddTransient<IContractRepository, ContractRepository>();
        services.AddTransient<ContractService, ContractImplement>();

        services.AddTransient<IContractDetailRepository, ContractDetailRepository>();
        services.AddTransient<ContractDetailService, ContractDetailImplement>();

        services.AddTransient<IOwnerRepository, OwnerRepository>();
        services.AddTransient<OwnerService, OwnerImplement>();

        services.AddTransient<IPackageRepository, PackageRepository>();
        services.AddTransient<PackageService, PackageImplement>();

        services.AddTransient<IPackageServiceDetailRepository, PackageServiceDetailRepository>();
        services.AddTransient<PackageServiceDetailService, PackageServiceDetailImplement>();

        services.AddTransient<IRequestRepository, RequestRepository>();
        services.AddTransient<RequestService, RequestImplement>();

        services.AddTransient<IRequestDetailRepository, RequestDetailRepository>();
        services.AddTransient<RequestDetailService, RequestDetailImplement>();

        services.AddTransient<IRequestLogRepository, RequestLogRepository>();
        services.AddTransient<RequestLogService, RequestLogImplement>();

        services.AddTransient<IServiceRepository, ServiceRepository>();
        services.AddTransient<ServiceService, ServiceImplement>();

        services.AddTransient<StaffService, StaffImplement>();
        services.AddTransient<IStaffRepository, StaffRepository>();

        services.AddTransient<IStaffDetailRepository, StaffDetailRepository>();
        services.AddTransient<StaffDetailService, StaffDetailImplement>();

        services.AddTransient<IStaffLogRepository, StaffLogRepository>();
        services.AddTransient<StaffLogService, StaffLogImplement>();

        services.AddTransient<ITennantRepository, TennantRepository>();
        services.AddTransient<TennantService, TennantImplement>();


        services.AddMvc().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


        //services.AddScoped(_ => {
        //    return new BlobServiceClient(azure);
        //});

        //AUTOMAPPER
        services.AddAutoMapper(typeof(ApplicationMapper).Assembly);

        return services;
    }
}