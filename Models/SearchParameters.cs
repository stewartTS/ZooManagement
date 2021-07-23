using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooManagement.Enums;

namespace ZooManagement.Models
{
    public class SearchParameters
    {
        public string Species { get; set; }
        
        public Classification? AnimalClassification { get; set; }
        public int? Age { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfAcquisition { get; set; }
        public Enclosure? AnimalEnclosure { get; set; }
    }
}
