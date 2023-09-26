using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IApartmentRepository Apartment { get; }
        IApartmentTypeRepository ApartmentType { get; }
        IAssetHistoryRepository AssetHistory { get; }
        IAssetRepository Asset { get; }
        IBillRepository Bill { get; }
        IBuildingRepository Building { get; }
        IContractRepository Contract { get; }
        IOwnerRepository Owner { get; }
        IRequestLogRepository RequestLog { get; }
        IRequestRepository Request { get; }
        IServiceDetailRepository ServiceDetail { get; }
        IServiceRepository Service { get; }
        IStaffLogRepository StaffLog { get; }
        IStaffRepository Staff { get; }
        ITennantRepository Tennant { get; }
        void Save();
    }
}
