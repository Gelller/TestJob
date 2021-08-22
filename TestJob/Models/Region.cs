using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestJob.Models
{
    public class Region
    {
        public Guid Id { get; set; }
        public string RegionName { get; set; }

        public ICollection<Country> Country { get; set; } 
    }
}
