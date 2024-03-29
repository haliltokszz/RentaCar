﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Entities.Filters;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetAllAsync(
            Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetAllAsync(PageFilter pageFilter,
            Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includeProperties);

        Task<List<T>> GetAllAsync(PageFilter pageFilter, IFilter filter = null,
            params Expression<Func<T, object>>[] includeProperties);
        
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> GetTotalCount();
    }
}