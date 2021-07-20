using System;
using System.ComponentModel.DataAnnotations;
using ZooManagement.Enums;
using ZooManagement.Models.Database;

namespace ZooManagement.Request
{
    public class CreateAnimalRequest
    {
        [Required]
        public int Id { get; set; }
       
        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [Required]
        [StringLength(70)]
        public string Sex { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public DateTime DateOfAcquisition { get; set; }

        [Required]
        [StringLength(70)]
        public string Species { get; set; }

        [Required]
        public Classification AnimalClassification { get; set; }
    }
}

