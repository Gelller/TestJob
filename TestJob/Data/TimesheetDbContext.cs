using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJob.Models;

namespace TestJob.Data
{
    public class TimesheetDbContext : DbContext
    {      
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Country> Country { get; set; }

        public TimesheetDbContext(DbContextOptions<TimesheetDbContext> options) : base(options)
        {
   
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfiguration());        
            modelBuilder.Entity<Cities>().ToTable("cities");
            modelBuilder.Entity<Region>().ToTable("region");        
        }
    }
}
