using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJob.Models;

namespace TestJob.Data.Interfaces
{
    public interface IRegionRepo :IRepoBase<Region>
    {
        Task<Region> GetByName(string regionName);
    }
}
