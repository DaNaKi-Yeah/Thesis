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
        private readonly DbSet<T> _dbset;

        public BaseRepository(ThesisDbContext context)
        {
            _context = context;
            if (_context.Set<T>() == default(DbSet<T>))
            {
                throw new ArgumentNullException(nameof(T));
            }

            _dbset = context.Set<T>();
        }


        public async Task<TKey> CreateAsync(T entity)
        {
            TKey result = (await _dbset.AddAsync(entity)).Entity.Id;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        //не пон как должно работать
        public async Task<T> GetAsync(T entity)
        {
            T result =  _dbset.FirstOrDefault(entity);
            return result;
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            T result = _dbset.FirstOrDefault(item => item.Id.Equals(id));
            return result;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
