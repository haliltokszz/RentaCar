using System;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Extensions
{
    public static class OrderExtension
    {
        public static IQueryable<t> OrderByDynamic<t>(this IQueryable<t> query, string sortColumn, bool descending)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(t), "p");
            string command = "OrderBy";

            if (descending)
            {
                command = "OrderByDescending";
            }
            Expression resultExpression = null;

            System.Reflection.PropertyInfo property = typeof(t).GetProperty(sortColumn);
            MemberExpression propertyAccess = Expression.MakeMemberAccess(parameter, property);
            LambdaExpression orderByExpression = Expression.Lambda(propertyAccess, parameter);
            resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { typeof(t), property.PropertyType },
                query.Expression, Expression.Quote(orderByExpression));
            return query.Provider.CreateQuery<t>(resultExpression);
        }
    }
}