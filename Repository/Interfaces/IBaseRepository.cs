using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        public Task<T> FindByIdAsync(int id);
        public Task<IEnumerable<T>> FindManyAsync(int limit = 10, int page = 0);
        public Task<T> CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(T entity);
    }
}