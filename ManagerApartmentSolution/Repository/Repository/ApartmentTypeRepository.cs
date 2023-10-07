using ManagerApartment.Models;
using Repository.GenericRepository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ApartmentTypeRepository : GenericRepository<ApartmentType>, IApartmentTypeRepository
    {
        public ApartmentTypeRepository(ManagerApartmentContext context) : base(context) { }    
    }
}
