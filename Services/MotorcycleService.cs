using BilliWebApp.Data;
using BilliWebApp.Models.Motorcycle;
using System;
using System.Collections.Generic;
using System.IO;
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

        public string GetImage(string id)
        {
            var tmp = _context.MotorcycleImages.FirstOrDefault(x => Equals(x.ID, id));
            if (tmp == default)
            {
                return "";
            }

            return string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(tmp.Image));
        }

        public async Task<bool> AddMotorcycle(AddMotorcycle model)
        {
            if (!ValidateAddMotorcycleModel(model))
            {
                return false;
            }

            if(!await CreateMotorcycle(model))
            {
                return false;
            }

            return true;
        }

        private async Task<bool> CreateMotorcycle(AddMotorcycle model)
        {
            // generate motorcycleID 
            string motorcycleID = Guid.NewGuid().ToString();
            var motorcycleEntity = AddMotorcycleModelToMotorcycleEntity(model);
            var motorcycleImageEntity = AddMotorcycleModelToMotorcycleImageEntity(model);

            // set id to entities
            motorcycleEntity.ID = motorcycleID;
            motorcycleImageEntity.ID = motorcycleID;

            // add entities to database
            _context.Motorcycles.Add(motorcycleEntity);
            if(!await _context.SaveAsync())
            {
                return false;
            }
            _context.MotorcycleImages.Add(motorcycleImageEntity);
            if(!await _context.SaveAsync())
            {
                return false;
            }

            return true;
        }

        // converters
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
                ImgURL = GetImage(m.ID)
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
                ImgURL = GetImage(motorcycle.ID)
            };
        }

        //
        private Entities.Motorcycle AddMotorcycleModelToMotorcycleEntity(AddMotorcycle model)
        {
            return new Entities.Motorcycle
            {
                Name = model.Name,
                Brand = model.Brand,
                Color = model.Color,
                Quantity = model.Quantity,
                Price = model.Price,
                Details = model.Details
            };
        }

        private Entities.MotorcycleImage AddMotorcycleModelToMotorcycleImageEntity(AddMotorcycle model)
        {
            var entity = new Entities.MotorcycleImage();
            // convert image
            using (var stream = new MemoryStream())
            {
                model.Img.CopyTo(stream);
                entity.Image = stream.ToArray();
            }
            return entity;
        }

        // validators
        private bool ValidateAddMotorcycleModel(AddMotorcycle model)
        {
            if(model == null)
            {
                // invalid data
                return false;
            }

            if (
                string.IsNullOrEmpty(model.Name) || 
                string.IsNullOrEmpty(model.Brand)) // la fel si pt restul stringurilor care nu s optionale
            {
                // invalid data
                return false;
            }

            if(model.Img == null)
            {
                return false;
            }

            return true;
        }
    }
}
