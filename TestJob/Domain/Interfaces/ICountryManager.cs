using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJob.Models;

namespace TestJob.Domain.Interfaces
{
    public interface ICountryManager
    {
        Task<Country> GetItem(Guid id);
        Task<IEnumerable<Country>> GetItems();
        Task<Guid> Create(Country country);
        Task Update(Guid id, Country country);
        Task Delete(Guid id);
    } 
}
