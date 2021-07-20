using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public class SampleAnimals
    { 
         public static IEnumerable<AnimalType> GetAnimal()
        {
            yield return new AnimalType
            {
                Species = "Lion"
            };
        }



    }
}
