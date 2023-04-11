﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thesis.Domain.Entities.Common;

namespace Application.Intrefaces
{
    public interface IRepository<TKey,T>
        where T : BaseEntity<TKey>
    {
        public Task<TKey> CreateAsync(T entity) ;
        public Task<List<T>> GetAll();
        public Task<T> GetAsync(T entity);
        public Task<T> GetAsyncById(TKey id);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(T entity);
    }
}