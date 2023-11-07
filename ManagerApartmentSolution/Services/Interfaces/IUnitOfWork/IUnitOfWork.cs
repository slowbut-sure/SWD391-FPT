using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IAddOnRepository AddOn { get; }
        IApartmentRepository Apartment { get; }
        IApartmentTypeRepository ApartmentType { get; }
        IAssetHistoryRepository AssetHistory { get; }
        IAssetRepository Asset { get; }
        IBillRepository Bill { get; }
        IBuildingRepository Building { get; }
        IContractDetailRepository ContractDetail { get; }
        IContractRepository Contract { get; }
        IOwnerRepository Owner { get; }
        IPackageRepository Package { get; }
        IPackageServiceDetailRepository PackageServiceDetail { get; }
        IRequestDetailRepository RequestDetail { get; }
        IRequestLogRepository RequestLog { get; }
        IRequestRepository Request { get; }
        IServiceRepository Service { get; }
        IStaffDetailRepository StaffDetail { get; }
        IStaffLogRepository StaffLog { get; }
        IStaffRepository Staff { get; }
        ITennantRepository Tennant { get; }

        IDbContextTransaction StartTransaction(string name);
        void StopTransaction(IDbContextTransaction commit);
        void RollBack(IDbContextTransaction commit, string name);
        
        int Save();
    }
}
