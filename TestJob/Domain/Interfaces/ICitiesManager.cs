using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestJob.Models;

namespace TestJob.Domain.Interfaces
{
    public interface ICitiesManager
    {
        Task<Cities> GetItem(Guid id);
        Task<IEnumerable<Cities>> GetItems();
        Task<Guid> Create(Cities cities);
        Task Update(Guid id, Cities cities);
        Task Delete(Guid id);

        Task<Cities> GetByName(string cityName);
        Task DeleteCountryId(Guid qqw);
    }
}
