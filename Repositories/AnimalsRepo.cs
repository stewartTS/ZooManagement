using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooManagement.Models;
using ZooManagement.Models.API;
using ZooManagement.Models.Database;
using ZooManagement.Request;

namespace ZooManagement.Repositories
{
    public interface IAnimalsRepo
    {
        AnimalDbModel GetAnimalById(int id);
        void Create(CreateAnimalRequest newAnimal);

        List<string> GetAllSpecies();
        IEnumerable<AnimalDbModel> GetAnimals(AnimalParameters animalParameters, SearchParameters searchParameters);


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

        public IEnumerable<AnimalDbModel> GetAnimals(AnimalParameters animalParameters, SearchParameters searchParameters)
        {
            var query = _context.Animals
                .AsQueryable();

            if (searchParameters != null)
            {
                var earliestAge = DateTime.Now.AddYears(-searchParameters.Age - 1 ?? 0);
                var currentAge = DateTime.Now.AddYears(-searchParameters.Age ?? 0);
        
                query = query.Where(a => 
                    (string.IsNullOrEmpty(searchParameters.Species) || a.AnimalType.Species.ToLower() == searchParameters.Species.ToLower()) &&
                    (string.IsNullOrEmpty(searchParameters.Name) || a.Name.ToLower() == searchParameters.Name.ToLower()) &&
                    (searchParameters.AnimalClassification == null || a.AnimalType.AnimalClassification == searchParameters.AnimalClassification) &&
                    (searchParameters.Age == null || a.DateOfBirth <= currentAge && a.DateOfBirth > earliestAge) &&
                    (searchParameters.DateOfAcquisition == null || a.DateOfAcquisition == searchParameters.DateOfAcquisition)
                    );
            }
             

            return query
                .OrderBy(ap => ap.Name)
                .Include(a => a.AnimalType)
                .Skip((animalParameters.PageNumber - 1) * animalParameters.PageSize)
                .Take(animalParameters.PageSize)
                .ToList();


        }
    }
}

