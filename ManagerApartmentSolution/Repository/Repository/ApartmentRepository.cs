using ManagerApartment.Models;
using Repository.GenericRepository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<Apartment>> GetAllApartments()
        {
            var apartments = await _context.Apartments
                .ToListAsync();
            return apartments;
        }

        public async Task<Apartment> GetApartmentById(int id)
        {
            return  _context.Apartments.FirstOrDefault(r => r.ApartmentId == id);
        }
    }
}
