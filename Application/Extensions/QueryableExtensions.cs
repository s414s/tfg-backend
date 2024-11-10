using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace Application.Extensions;

public static class QueryableExtensions
{
    private static readonly ConcurrentDictionary<string, LambdaExpression> ExpressionCache = new();

    public static IQueryable<TEntity> ApplyOrder<TEntity>(this IQueryable<TEntity> query, string? orderBy, bool isDescending)
    {
        if (string.IsNullOrWhiteSpace(orderBy))
            return query;

        var propertyMatch = typeof(TEntity)
            .GetProperties()
            .FirstOrDefault(x => x.Name.Equals(orderBy, StringComparison.InvariantCultureIgnoreCase));

        if (propertyMatch == null)
            return query;

        // Create parameter for the lambda expression
        var lambdaParameter = Expression.Parameter(typeof(TEntity), "x");
        var propertyAccess = Expression.Property(lambdaParameter, propertyMatch);
        // Convert the property access to object type to handle any property type
        var conversion = Expression.Convert(propertyAccess, typeof(object));
        var lambda = Expression.Lambda<Func<TEntity, object>>(conversion, lambdaParameter);

        // Apply ordering
        return isDescending
            ? query.OrderByDescending(lambda)
            : query.OrderBy(lambda);
    }

    /// <summary>
    /// The cached version:
    /// Stores compiled expressions in a thread-safe dictionary
    /// Avoids reflection overhead on subsequent calls
    /// Still maintains all the functionality of the original version
    /// Is more performant for repeated calls with the same property names
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="query"></param>
    /// <param name="orderBy"></param>
    /// <param name="isDescending"></param>
    /// <returns></returns>
    public static IQueryable<TEntity> ApplyOrderCached<TEntity>(this IQueryable<TEntity> query, string? orderBy, bool isDescending)
    {
        if (string.IsNullOrWhiteSpace(orderBy))
            return query;

        var cacheKey = $"{typeof(TEntity).FullName}.{orderBy}";
        var lambda = ExpressionCache.GetOrAdd(cacheKey, _ =>
        {
            var propertyInfo = typeof(TEntity)
                .GetProperties()
                .FirstOrDefault(x => x.Name.Equals(orderBy, StringComparison.InvariantCultureIgnoreCase));

            if (propertyInfo == null)
                return null;

            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var propertyAccess = Expression.Property(parameter, propertyInfo);
            var conversion = Expression.Convert(propertyAccess, typeof(object));

            return Expression.Lambda<Func<TEntity, object>>(conversion, parameter);
        });

        if (lambda == null)
            return query;

        return isDescending
            ? query.OrderByDescending((Expression<Func<TEntity, object>>)lambda)
            : query.OrderBy((Expression<Func<TEntity, object>>)lambda);
    }
}
