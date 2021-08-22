using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJob.Models;

namespace TestJob.Data.Interfaces
{
    public interface ICitiesRepo : IRepoBase<Cities>
    {
        Task<Cities> GetByName(string cityName);
        Task DeleteCountryId(Guid qqw);
    }
}
