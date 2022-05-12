using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Filter;
using Core.Utilities.IoC;
using Entities.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : AuditableEntity, new()
        where TContext : DbContext, new()
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TContext _context;

        public EfEntityRepositoryBase()
        {
            _context = new TContext();
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                addedEntity.Entity.CreatedTime = DateTime.UtcNow;
                addedEntity.Entity.CreatedBy =
                    _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                await context.SaveChangesAsync(); //remove for UoW
                return entity;
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                //deletedEntity.State = EntityState.Deleted; #soft-delete
                deletedEntity.State = EntityState.Modified;
                deletedEntity.Entity.Deleted = true;
                deletedEntity.Entity.DeletedTime =
                    DateTime.UtcNow;
                await context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                var props = typeof(TEntity).GetProperties();
                var query = GetQuery().Where(filter);
                foreach (var property in props)
                {
                    if (property.GetType() == typeof(IEntity)) query = query.Include(property.Name);
                }

                return await query.SingleOrDefaultAsync();
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetQuery().Where(filter);
            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query,
                    (current, include) => current.Include(include));
            }

            return await query.SingleOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetQuery();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query,
                    (current, include) => current.Include(include));
            }

            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(PageFilter pageFilter,
            Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetQuery();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = query.OrderByDynamic(pageFilter.Column, pageFilter.Descending)
                .Skip((pageFilter.PageNumber - 1) * pageFilter.PageSize).Take(pageFilter.PageSize);

            foreach (var includeProperty in includeProperties) query = query.Include(includeProperty);

            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(PageFilter pageFilter, IFilter filter = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await (filter == null
                ? GetAllAsync(pageFilter, filter, includeProperties)
                : GetAllAsync(pageFilter, Filter.DynamicFilter<TEntity, IFilter>(filter), includeProperties));
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                updatedEntity.Entity.ModifiedBy = _httpContextAccessor.HttpContext.User
                    .FindFirst(ClaimTypes.NameIdentifier).Value;
                updatedEntity.Entity.ModifiedTime =
                    DateTime.UtcNow;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        private IQueryable<TEntity> GetQuery()
        {
            return _context.Set<TEntity>().AsQueryable().AsNoTracking();
        }

        public async Task<int> GetTotalCount()
        {
            return await _context.Set<TEntity>().AsQueryable().AsNoTracking().CountAsync();
        }
    }
}