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
    public class CountryManager : ICountryManager
    {
        private readonly ICountryRepo _countryRepo;
        public CountryManager(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }
        public async Task<Country> GetItem(Guid id)
        {
            return await _countryRepo.GetItem(id);
        }
        public async Task<Guid> Create(Country item)
        {
            await _countryRepo.Add(item);
            return item.Id;
        }
        public async Task<IEnumerable<Country>> GetItems()
        {
            return await _countryRepo.GetItems();
        }
        public async Task Update(Guid id, Country item)
        {
            item.Id = id;
            await _countryRepo.Update(item);
        }
        public async Task Delete(Guid id)
        {
            await _countryRepo.Delete(id);
        }
    }  
}
