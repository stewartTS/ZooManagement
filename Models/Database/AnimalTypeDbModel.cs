using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZooManagement.Enums;

namespace ZooManagement.Models.Database
{
    public class AnimalTypeDbModel
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public Classification AnimalClassification { get; set; }
        public List<AnimalDbModel> Animals { get; set; } = new List<AnimalDbModel>();

    }

}
