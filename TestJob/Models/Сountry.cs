using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJob.Models;

namespace TestJob.Models
{
    
    public class Country
    {
        public Guid Id { get; set; }
        public string СountryName { get; set; }
        public string CodeСountry { get; set; }
        public float Area { get; set; }
        public int Population { get; set; }
        public string RegionName { get; set; }
        public string CityName { get; set; }


        public Region Region { get; set; }
        public Cities City { get; set; }
    }
    
}

