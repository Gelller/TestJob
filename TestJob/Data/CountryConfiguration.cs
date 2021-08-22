using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestJob.Models;

namespace TestJob.Data
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("country");
            builder
             .HasOne(country => country.City)
             .WithOne(city => city.Country)
              .HasForeignKey<Cities>(p => p.CountryId);
            builder
             .HasOne(country => country.Region)
             .WithMany(region => region.Country)
             .HasForeignKey("RegionId");
        }
    }
}