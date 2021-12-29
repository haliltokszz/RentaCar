using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EfEntityRepositoryBase()
        {
            var builder = new ContainerBuilder();
            using (var container = builder.Build())
            {
                _httpContextAccessor = container.Resolve<IHttpContextAccessor>();
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                (addedEntity as AuditableEntity).CreatedTime = DateTime.UtcNow;
                (addedEntity as AuditableEntity).CreatedBy =
                    _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                await context.SaveChangesAsync(); //remove for UoW
                return entity;
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                (deletedEntity as AuditableEntity).Deleted = true;
                (deletedEntity as AuditableEntity).DeletedTime =
                    DateTime.UtcNow;
                await context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                var props = typeof(TEntity).GetProperties();
                var query = GetQuery().Where(filter);
                foreach (var property in props)
                {
                    query = query.Include(property.Name);
                }
                return await query.SingleOrDefaultAsync();
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetQuery().Where(filter);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.SingleOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await (filter == null
                ? GetQuery().ToListAsync()
                : GetQuery().Where(filter).ToListAsync());
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IEnumerable<TEntity> entities = await GetAllAsync(filter);
            var query = entities.AsQueryable().AsNoTracking();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                (updatedEntity as AuditableEntity).ModifiedBy = _httpContextAccessor.HttpContext.User
                    .FindFirst(ClaimTypes.NameIdentifier).Value;
                (updatedEntity as AuditableEntity).ModifiedTime =
                    DateTime.UtcNow;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        private IQueryable<TEntity> GetQuery()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().AsQueryable().AsNoTracking();
            }
        }
    }
}