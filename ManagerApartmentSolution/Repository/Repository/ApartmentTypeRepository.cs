using ManagerApartment.Models;
using Repository.GenericRepository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ApartmentTypeRepository : GenericRepository<ApartmentType>, IApartmentTypeRepository
    {
        public ApartmentTypeRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<ApartmentType>> GetAllApartmentTypes()
        {
            var apartmentTypes = await _context.ApartmentTypes
                .ToListAsync();
            return apartmentTypes;
        }

        public async Task<ApartmentType> GetApartmentTypeById(int id)
        {
            return  _context.ApartmentTypes.FirstOrDefault(r => r.ApartmentTypeId == id);
        }
    }
}
