using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ZooManagement.Models
{
    public class SearchParameters
    {
        public string Species { get; set; }
        public string AnimalClassification { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfAcquisition { get; set; }
    }
}
