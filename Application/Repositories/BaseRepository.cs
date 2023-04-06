using Application.Intrefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thesis.Domain.Entities.Common;
using Thesis.Persistence;

namespace Application.Repositories
{
    public class BaseRepository<TKey,T> : IRepository<TKey,T>
        where T : BaseEntity<TKey>
    {
        private readonly ThesisDbContext _context;
        public BaseRepository(ThesisDbContext context) => _context = context;
        public async Task<TKey> CreateAsync(T entity)
        {
           
            if (entity == null)
            {
                throw new ArgumentNullException("Entity is null");
            }
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity is null");
            }
            _context.Set<T>().ExecuteDelete();
            await _context.SaveChangesAsync();
        }
        public Task GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsyncById(T id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
