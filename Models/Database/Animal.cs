using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooManagement.Models.Database
{
    public class Animal
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public AnimalClassification AnimalClassification { get; set; }
        //public int Quantity { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAcquisition { get; set; }



        



       
    }
}
