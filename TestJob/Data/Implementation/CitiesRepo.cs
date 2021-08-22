using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJob.Data.Interfaces;
using TestJob.Models;

namespace TestJob.Data.Implementation
{
    public class CitiesRepo : ICitiesRepo
    {
        private readonly TimesheetDbContext _context;
        public CitiesRepo(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<Cities> GetItem(Guid id)
        {
            var result = await _context.Cities.FindAsync(id);
            return result;
        }
        public async Task<Guid> Add(Cities item)
        {
            await _context.Cities.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }
        public async Task<IEnumerable<Cities>> GetItems()
        {
            var result = await _context.Cities.ToListAsync();
            return result;
        }
        public async Task Update(Cities item)
        {
            _context.Cities.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var item = await _context.Cities.FindAsync(id);
            _context.Cities.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Cities> GetByName(string cityName)
        {
            var result = await _context.Cities.Where(x => x.CitiesName == cityName)
                    .FirstOrDefaultAsync();
            return result;
        }

        public async Task DeleteCountryId(Guid qqw)
        {
            var result =await _context.Cities.Where(x => x.Id == qqw).FirstOrDefaultAsync();
            result.CountryId = null;
            await _context.SaveChangesAsync();
        }
    }
}
