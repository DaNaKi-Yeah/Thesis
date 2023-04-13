using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thesis.Domain.Entities.Common;

namespace Thesis.Persistence.Intrefaces
{
    public interface IRepository<TKey,T>
        where T : BaseEntity<TKey>
    {
        public Task<TKey> CreateAsync(T entity) ;
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(TKey id);
        public IQueryable<T> GetQuery();
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(T entity);
    }
}
