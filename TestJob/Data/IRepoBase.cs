using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestJob.Models;

namespace TestJob.Data
{ 
        public interface IRepoBase<T>
        {
            Task<T> GetItem(Guid id);
            Task<IEnumerable<T>> GetItems();
            Task<Guid> Add(T item);
            Task Update(T item);
            Task Delete(Guid id);
        } 
}
