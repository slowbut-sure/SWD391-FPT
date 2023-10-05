using ManagerApartment.Models;
using Repository.Repository;
using Services.Interfaces;
using Services.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ManagerApartmentContext _context;
        public UnitOfWork(ManagerApartmentContext context)
        {
            _context = context;
            AddOn = new AddOnRepository(_context);
            Apartment = new ApartmentRepository(_context);
            ApartmentType = new ApartmentTypeRepository(_context);
            AssetHistory = new AssetHistoryRepository(_context);
            Asset = new AssetRepository(_context);
            Bill = new BillRepository(_context);
            Building = new BuildingRepository(_context);
            ContractDetail = new ContractDetailRepository(_context);
            Contract = new ContractRepository(_context);
            Owner = new OwnerRepository(_context);
            Package = new PackageRepository(_context);
            PackageServiceDetail = new PackageServiceDetailRepository(_context);
            RequestDetail = new RequestDetailRepository(_context);
            RequestLog = new RequestLogRepository(_context);
            Request = new RequestRepository(_context);
            Service = new ServiceRepository(_context);
            StaffDetail = new StaffDetailRepository(_context);
            StaffLog = new StaffLogRepository(_context);
            Staff = new StaffRepository(_context);
            Tennant = new TennantRepository(_context);
        }
        public IAddOnRepository AddOn { get; }
        public IApartmentRepository Apartment { get; }
        public IApartmentTypeRepository ApartmentType { get; }
        public IAssetHistoryRepository AssetHistory { get; }
        public IAssetRepository Asset { get; }
        public IBillRepository Bill { get; }
        public IBuildingRepository Building { get; }
        public IContractDetailRepository ContractDetail { get; }
        public IContractRepository Contract { get; }
        public IOwnerRepository Owner { get; }
        public IPackageRepository Package { get; }
        public IPackageServiceDetailRepository PackageServiceDetail { get; }
        public IRequestDetailRepository RequestDetail { get; }
        public IRequestLogRepository RequestLog { get; }
        public IRequestRepository Request { get; }
        public IServiceRepository Service { get; }
        public IStaffDetailRepository StaffDetail { get; }
        public IStaffLogRepository StaffLog { get; }
        public IStaffRepository Staff { get; }
        public ITennantRepository Tennant { get; }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
