using Application.Intrefaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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


        public BaseRepository(ThesisDbContext context)
        {
            _context = context;
            if (_context.Set<T>() == default(DbSet<T>))
            {
                throw new ArgumentNullException(nameof(T));
            }
        }


        public async Task<TKey> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<List<T>> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> GetAsync(T entity)
        {
            T result =  _context.Set<T>().FirstOrDefault(entity);
            return result;
        }

        public async Task<T> GetAsyncById(TKey id)
        {
            T result = _context.Set<T>().FirstOrDefault(item => item.Id.Equals(id));
            return result;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
