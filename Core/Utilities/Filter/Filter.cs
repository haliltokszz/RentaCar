using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Castle.Core.Internal;

namespace Core.Utilities.Filter
{
    public class Filter
    {
        public static Expression<Func<TDto, bool>> DynamicFilter<TDto, TFilterDto>(TFilterDto filter)
        {
            Expression propertyExp, someValue, containsMethodExp, combinedExp;
            Expression<Func<TDto, bool>> exp = c => true, oldExp;
            MethodInfo method;

            var parameterExp = Expression.Parameter(typeof(TDto), "type");
            var properties = filter.GetType().GetProperties();
            if (properties.All(p => p.GetValue(filter, null) == null)) return exp;

            var props = properties.FindAll(p => p.GetValue(filter, null) != null);
            foreach (var propertyInfo in props)
            {
                oldExp = exp;
                propertyExp = Expression.Property(parameterExp, propertyInfo.Name);
                method = typeof(object).GetMethod("Equals", new[] { typeof(object) });
                someValue = Expression.Constant(
                    filter.GetType().GetProperty(propertyInfo.Name)?.GetValue(filter, null), typeof(object));
                containsMethodExp = Expression.Call(propertyExp, method, someValue);
                exp = Expression.Lambda<Func<TDto, bool>>(containsMethodExp, parameterExp);
                combinedExp = Expression.AndAlso(exp.Body, oldExp.Body);
                exp = Expression.Lambda<Func<TDto, bool>>(combinedExp, exp.Parameters[0]);
            }
            return exp;
        }
    }
}