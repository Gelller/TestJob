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
    public class CitiesManager : ICitiesManager
    {
        private readonly ICitiesRepo _citiesRepo;
        public CitiesManager(ICitiesRepo citiesRepo)
        {
            _citiesRepo = citiesRepo;
        }
        public async Task<Cities> GetItem(Guid id)
        {
            return await _citiesRepo.GetItem(id);
        }
        public async Task<Guid> Create(Cities item)
        {
            await _citiesRepo.Add(item);
            return item.Id;
        }
        public async Task<IEnumerable<Cities>> GetItems()
        {
            return await _citiesRepo.GetItems();
        }
        public async Task Update(Guid id, Cities item)
        {
            item.Id = id;
            await _citiesRepo.Update(item);
        }
        public async Task Delete(Guid id)
        {
            await _citiesRepo.Delete(id);
        }
        public async Task<Cities> GetByName(string cityName)
        {
              return await _citiesRepo.GetByName(cityName);
        }
        public async Task DeleteCountryId(Guid qqw)
        {
            await _citiesRepo.DeleteCountryId(qqw);
        }
    }
}
