using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJob.Data.Interfaces;
using TestJob.Domain.Interfaces;
using TestJob.Models;
using TestJob.Models.Dto;

namespace TestJob.Data.Implementation
{
    
    public class CountryRepo : ICountryRepo
    {
        private readonly IRegionManager _regionManager;
        private readonly ICitiesManager _citiesManager;    
        private readonly IMapper _mapper;

        private readonly TimesheetDbContext _context;
        public CountryRepo(TimesheetDbContext context, IMapper mapper, ICitiesManager citiesManager, IRegionManager regionManager)
        {
            _context = context;
            _mapper = mapper;
            _citiesManager = citiesManager;
            _regionManager = regionManager;         
        }

        public async Task<Country> GetItem(Guid id)
        {
            var result = await _context.Country.FindAsync(id);
            return result;
        }
        public async Task<IEnumerable<Country>> GetItems()
        {
            var result = await _context.Country.ToListAsync();
            return result;
        }
        public async Task<Guid> Add(Country item)
        {
            var cities = await _citiesManager.GetByName(item.CityName);
            var region = await _regionManager.GetByName(item.RegionName);
            var countrAdded = await GetByCountryCode(item.CodeСountry);
            if (countrAdded == null)
            {
                await AddCityOrRegion(item, cities, region);          
                await _context.Country.AddAsync(item);
                await _context.SaveChangesAsync();
                return item.Id;
            }
            else
            {
                countrAdded.СountryName = item.СountryName;
                countrAdded.Area = item.Area;
                countrAdded.Population = item.Population;
                countrAdded.RegionName = item.RegionName;
                countrAdded.CityName = item.CityName;

                await _citiesManager.DeleteCountryId(cities.Id);      
                await AddCityOrRegion(countrAdded, cities, region);
                await _context.SaveChangesAsync();

                return countrAdded.Id;
            }
        }
        private async Task AddCityOrRegion(Country item, Cities cities, Region region)
        {
            if (cities != null)
            {
                item.City = cities;
            }
            else
            {
                Cities newCity = new Cities
                {
                    CitiesName = item.CityName,
                    CountryId = item.Id,
                };
                item.City = newCity;
            }

            if (region != null)
            {
                item.Region = region;
            }
            else
            {
                Region newRegion = new Region
                {
                    RegionName = item.RegionName,
                };
                item.Region = newRegion;
            }
            await _context.SaveChangesAsync();
        }
        public async Task Update(Country item)
        {
            _context.Country.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            var item = await _context.Country.FindAsync(id);
            _context.Country.Remove(item);
            await _context.SaveChangesAsync();
        }
        private async Task<Country> GetByCountryCode(string codeСountry)
        {
           var result = await _context.Country.Where(x => x.CodeСountry == codeСountry).FirstOrDefaultAsync();
           return result;
        }
    }
    
}

