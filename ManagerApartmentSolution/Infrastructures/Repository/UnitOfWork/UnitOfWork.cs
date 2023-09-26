using Application.IRepository;
using Application.IRepository.IUnitOfWork;
using ManagerApartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Manager_ApartmentContext _context;
        public UnitOfWork(Manager_ApartmentContext context)
        {
            _context = context;
            Apartment = new ApartmentRepository(_context);
            ApartmentType = new ApartmentTypeRepository(_context);
            AssetHistory = new AssetHistoryRepository(_context);
            Asset = new AssetRepository(_context);
            Bill = new BillRepository(_context);
            Building = new BuildingRepository(_context);
            Contract = new ContractRepository(_context);
            Owner = new OwnerRepository(_context);
            RequestLog = new RequestLogRepository(_context);
            Request = new RequestRepository(_context);
            ServiceDetail = new ServiceDetailRepository(_context);
            Service = new ServiceRepository(_context);
            StaffLog = new StaffLogRepository(_context);
            Staff = new StaffRepository(_context);
            Tennant = new TennantRepository(_context);
        }
        public IApartmentRepository Apartment { get; }
        public IApartmentTypeRepository ApartmentType { get; }
        public IAssetHistoryRepository AssetHistory { get; }
        public IAssetRepository Asset { get; }
        public IBillRepository Bill { get; }
        public IBuildingRepository Building { get; }
        public IContractRepository Contract { get; }
        public IOwnerRepository Owner { get; }
        public IRequestLogRepository RequestLog { get; }
        public IRequestRepository Request { get; }
        public IServiceDetailRepository ServiceDetail { get; }
        public IServiceRepository Service { get; }
        public IStaffLogRepository StaffLog { get; }
        public IStaffRepository Staff { get; }
        public ITennantRepository Tennant { get; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
