using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJob.Models;
using TestJob.Data.Implementation;
using TestJob.Data.Interfaces;
using TestJob.Data;
using TestJob.Domain.Interfaces;

namespace TestJob.Domain.Implementation
{
    public class RegionManager : IRegionManager
    {
        private readonly IRegionRepo _regionRepo;
        public RegionManager(IRegionRepo regionRepo)
        {
            _regionRepo = regionRepo;
        }
        public async Task<Region> GetItem(Guid id)
        {
            return await _regionRepo.GetItem(id);
        }
        public async Task<Guid> Create(Region item)
        {
            await _regionRepo.Add(item);
            return item.Id;
        }
        public async Task<IEnumerable<Region>> GetItems()
        {
            return await _regionRepo.GetItems();
        }
        public async Task Update(Guid id, Region item)
        {
            item.Id = id;
            await _regionRepo.Update(item);
        }
        public async Task Delete(Guid id)
        {
            await _regionRepo.Delete(id);
        }
        public async Task<Region> GetByName(string regionName)
        {
            return await _regionRepo.GetByName(regionName);

        }
    }  
}
