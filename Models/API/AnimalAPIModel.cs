using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooManagement.Enums;
using ZooManagement.Models.Database;

namespace ZooManagement.Models.API
{
    public class AnimalAPIModel
    {
        private readonly AnimalDbModel _animal;

        public AnimalAPIModel(AnimalDbModel animal)
        {
            _animal = animal;
        }

        public int Id => _animal.Id;
        public string Name => _animal.Name;
        public string Sex => _animal.Sex;
        public Enclosure AnimalEnclosure => _animal.AnimalEnclosure;
        public DateTime DateOfBirth => _animal.DateOfBirth;
        public DateTime DateOfAcquisition => _animal.DateOfAcquisition;
        public string Species => _animal.AnimalType.Species;
        public Classification AnimalClassification => _animal.AnimalType.AnimalClassification;
    }
}
