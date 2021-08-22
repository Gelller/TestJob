using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJob.Data.Interfaces;
using TestJob.Models;

namespace TestJob.Data.Implementation
{
    
    public class RegionRepo : IRegionRepo
    {
        
        private readonly TimesheetDbContext _context;
        public RegionRepo(TimesheetDbContext context)
        {
            _context = context;
        }
        public async Task<Region> GetItem(Guid id)
        {
            var result = await _context.Region.FindAsync(id);
            return result;
        }
        public async Task<Guid> Add(Region item)
        {
            await _context.Region.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }
        public async Task<IEnumerable<Region>> GetItems()
        {
            var result = await _context.Region.ToListAsync();
            return result;
        }
        public async Task Update(Region item)
        {
            _context.Region.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var item = await _context.Region.FindAsync(id);
            _context.Region.Remove(item);
            await _context.SaveChangesAsync();
        }
        public async Task<Region> GetByName(string regionName)
        {
            var result = await _context.Region.Where(x => x.RegionName == regionName)
                    .FirstOrDefaultAsync();
            return result;
        }  
    } 
}