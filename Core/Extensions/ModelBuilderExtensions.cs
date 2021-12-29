using System;
using System.Linq;
using System.Reflection;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Core.Extensions
{
    public static class ModelBuilderExtensions
    {
        private static readonly MethodInfo SetSoftDeleteFilterMethod = typeof(ModelBuilderExtensions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(t => t.IsGenericMethod && t.Name == "SetSoftDeleteFilter");

        public static void AddGlobalFilter(this ModelBuilder modelBuilder)
        {
            /*
                Model içerisindeki tüm Entity tiplerine bak ve içerisinde AuditableEntity olanları bul ve
                SetSoftDeleteFilter method'unu çağır.
            */
            foreach (var type in modelBuilder.Model.GetEntityTypes())
                if (typeof(AuditableEntity).IsAssignableFrom(type.ClrType))
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
        }

        public static void SetSoftDeleteFilter(this ModelBuilder modelBuilder, Type entityType)
        {
            SetSoftDeleteFilterMethod.MakeGenericMethod(entityType)
                .Invoke(null, new object[] { modelBuilder });
        }

        public static void SetSoftDeleteFilter<TEntity>(this ModelBuilder modelBuilder)
            where TEntity : AuditableEntity
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(x => !x.Deleted);
        }
    }
}