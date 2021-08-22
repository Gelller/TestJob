using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJob.Models;

namespace TestJob.Domain.Interfaces
{ 
    public interface IRegionManager
    {
        Task<Region> GetItem(Guid id);
        Task<IEnumerable<Region>> GetItems();
        Task<Guid> Create(Region region);
        Task Update(Guid id, Region region);
        Task Delete(Guid id);
        Task<Region> GetByName(string regionName);
    }   
}
