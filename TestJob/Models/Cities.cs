using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestJob.Models
{
    public class Cities
    {
        public Guid Id { get; set; }
        public string CitiesName { get; set; }
        public Guid? CountryId { get; set; }
        public Country Country { get; set; }
    }
}
