using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooManagement.Enums;
using ZooManagement.Models.Database;

namespace ZooManagement.Models.API
{
    public class AnimalTypeAPIModel
    {
        private readonly AnimalTypeDbModel _animalType;

        public AnimalTypeAPIModel(AnimalTypeDbModel animalType)
        {
            _animalType = animalType;
        }

        public int Id => _animalType.Id;
        public string Species => _animalType.Species;
        public Classification AnimalClassification => _animalType.AnimalClassification;
        public List<AnimalDbModel> Animals => _animalType.Animals;
        public int Quantity => _animalType.Animals.Count;

    }
}
