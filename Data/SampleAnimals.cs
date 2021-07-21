using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ZooManagement.Enums;
using ZooManagement.Models.Database;
using ZooManagement.Request;

namespace ZooManagement.Data
{
    public class SampleAnimals
    {
        private static readonly IList<IList<object>> _animalTypeData = new List<IList<object>>
        {
            new List<object> { "ardvark", Classification.Mammal },
            new List<object> { "bear", Classification.Mammal },
            new List<object> { "boar", Classification.Mammal },
            new List<object> { "buffalo", Classification.Mammal },
            new List<object> { "cheetah", Classification.Mammal },
            new List<object> { "deer", Classification.Mammal },
            new List<object> { "dolphin", Classification.Mammal },
            new List<object> { "elephant", Classification.Mammal },
            new List<object> { "chicken", Classification.Bird },
            new List<object> { "crow", Classification.Bird },
            new List<object> { "dove", Classification.Bird },
            new List<object> { "seasnake", Classification.Reptile },
            new List<object> { "tortoise", Classification.Reptile },
            new List<object> { "clam", Classification.Invertebrate },
            new List<object> { "lobster", Classification.Invertebrate },
            new List<object> { "starfish", Classification.Invertebrate },
            new List<object> { "catfish", Classification.Fish },
            new List<object> { "haddock", Classification.Fish },
            new List<object> { "herring", Classification.Fish },
            new List<object> { "honeybee", Classification.Insect },
            new List<object> { "butterfly", Classification.Insect },
        };

        private static readonly IList<string> _animalData = new List<string>
        {
            "Adam",
            "Brian",
            "Cindy",
            "Daisy",
            "Edward",
            "Francis",
            "Giovanni",
            "Hannah",
            "Israel",
            "James",
            "Kye",
            "Laura",
            "Mike",
        };

        private static readonly IList<string> _suffixData = new List<string>
        {
            "Sr.",
            "Jr.",
            "I",
            "II",
            "III",
            "IV",
            "V",
        };

        public static IEnumerable<AnimalDbModel> GetAnimals() 
        {
            var animalTypes = _animalTypeData.Select(at => new AnimalTypeDbModel 
            {
                Species = (string)at[0],
                AnimalClassification = (Classification)at[1]
            }).ToList();

            var animalData = new List<AnimalDbModel>();

            for (var i = 0; i < 8; i++) { 
                animalData.AddRange( _animalData.Select(name => CreateRandomAnimal(name, animalTypes)));
            };

            return animalData;
        }

        private static AnimalDbModel CreateRandomAnimal(string name, List<AnimalTypeDbModel> animalTypes)
        {
            var rnd = new Random();
            var animal = new AnimalDbModel
            {
                Name = name,
                Sex = rnd.Next(0,2) == 1 ? "Male" : "Female",
                DateOfBirth = new DateTime(rnd.Next(2015, 2019), rnd.Next(1, 13), rnd.Next(1, 29)),
                DateOfAcquisition = new DateTime(2020, rnd.Next(1, 12), rnd.Next(1, 28)),
                AnimalType = animalTypes[rnd.Next(0, _animalTypeData.Count())]
 
            };

            return animal;
        }
    }
}

