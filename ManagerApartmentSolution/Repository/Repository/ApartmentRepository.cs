using ManagerApartment.Models;
using Repository.GenericRepository;
using Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(ManagerApartmentContext context) : base(context) { }
        public async Task<List<Apartment>> GetAllApartments()
        {
            var apartments = await _context.Apartments
                .Include(a => a.ApartmentType)
                .Include(a => a.Owner)
                .Include(a => a.Building)
                .ToListAsync();
            return apartments;
        }

        public async Task<Apartment> GetApartmentById(int id)
        {
            var apartments = _context.Apartments
                .Include(c => c.ApartmentType)
                .Include(c => c.Owner)
                .Include(c => c.Building)
                .FirstOrDefault(r => r.ApartmentId == id);
            return apartments;
        }
    }
}
