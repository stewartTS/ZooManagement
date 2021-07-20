using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooManagement.Models.Database;
using ZooManagement.Request;

namespace ZooManagement.Repositories
{
    public interface IAnimalsRepo
    {
        AnimalDbModel GetAnimalById(int id);
        void Create(CreateAnimalRequest newAnimal);

        List<string> GetAllSpecies();
    }

    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooManagementDbContext _context;

        public AnimalsRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public AnimalDbModel GetAnimalById(int id)
        {
            return _context.Animals
                .Single(animal => animal.Id == id);
        }

        public void Create(CreateAnimalRequest newAnimal)
        {
            var existingAnimalType = _context.AnimalType
                .SingleOrDefault(at => at.Species == newAnimal.Species && at.AnimalClassification == newAnimal.AnimalClassification)
                ?? new AnimalTypeDbModel 
                { 
                    Species = newAnimal.Species,
                    AnimalClassification = newAnimal.AnimalClassification
                };

            var animal = new AnimalDbModel
            {
                Id = newAnimal.Id,
                Sex = newAnimal.Sex,
                Name = newAnimal.Name,
                DateOfBirth = newAnimal.DateOfBirth,
                DateOfAcquisition = newAnimal.DateOfAcquisition,
                AnimalType = existingAnimalType
            };

            _context.Animals.Add(animal);
            _context.SaveChanges();
        }

        public List<string> GetAllSpecies()
        {
            return _context.AnimalType.Select(at => at.Species).ToList();
        }
    }
}
