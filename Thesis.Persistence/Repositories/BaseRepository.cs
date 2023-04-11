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
using Thesis.Persistence.Intrefaces;

namespace Thesis.Persistence.Repositories
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

        public async Task<T?> GetByIdAsync(TKey id)
        {
            return await _dbset.FirstOrDefaultAsync(item => item.Id.Equals(id));
        }

        public async Task UpdateAsync(T entity)
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
