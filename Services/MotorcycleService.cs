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

        // returneaza un model de tip motorcycle dupa id-ul introdus

        public Motorcycle GetMotorcycle(string id)
        {
            var result = _context.Motorcycles.FirstOrDefault(x => Equals(x.ID, id));
            if (result == default)
            {
                // motorcycle not found
                return null;
            }

            return MotorcycleEntityToMotorcycleModel(result);
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

        private Motorcycle MotorcycleEntityToMotorcycleModel(Entities.Motorcycle motorcycle)
        {
            return new Motorcycle
            {
                ID = motorcycle.ID,
                Name = motorcycle.Name,
                Brand = motorcycle.Brand,
                Color = motorcycle.Color,
                Price = motorcycle.Price,
                Quantity = motorcycle.Quantity,
                Details = motorcycle.Details,
            };
        }
    }
}
