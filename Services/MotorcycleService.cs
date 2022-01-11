using BilliWebApp.Data;
using BilliWebApp.Models.Motorcycle;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilliWebApp.Services
{
    public class MotorcycleService
    {
        private ApplicationDbContext _context;

        public MotorcycleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Motorcycle>> GetMotorcyclesAsync() 
        {
            return MotorcycleEntitiesToMotorcycleModels(_context.Motorcycles.ToList());
        }

        private List<Motorcycle> MotorcycleEntitiesToMotorcycleModels(List<Entities.Motorcycle> motorcycles)
        {
            return motorcycles.Select(m => new Motorcycle
            {
                ID = m.ID,
                Name = m.Name,
                Brand = m.Brand,
                Color = m.Color,
                Price = m.Price,
                Quantity = m.Quantity,
                Details = m.Details,
            }).ToList();
        }
    }
}
