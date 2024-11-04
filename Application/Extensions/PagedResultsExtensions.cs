using Microsoft.EntityFrameworkCore;

namespace Application.Extensions;

public class PagedResults<TEntity>
{
    public List<TEntity> Data { get; set; }
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
    public long TotalResults { get; set; }

    public PagedResults()
    {
        Data = [];
        PageSize = 0;
        PageIndex = 0;
        TotalResults = 0;
    }

    public PagedResults(List<TEntity> data, int pageSize, int pageIndex)
    {
        Data = data.Skip(pageIndex + pageSize).ToList();
        TotalResults = data.Count;
        PageSize = pageSize;
        PageIndex = pageIndex;
    }

    public PagedResults(List<TEntity> data, int pageSize, int pageIndex, long totalResults)
    {
        Data = data;
        PageSize = pageSize;
        PageIndex = pageIndex;
        TotalResults = totalResults;
    }
}

public static class PagedResultsExtensions
{
    public static async Task<PagedResults<TEntity>> ToPagedResultsAsync<TEntity>(this IQueryable<TEntity> query, int PageIndex, int PageSize, CancellationToken cancellationToken = default)
    {
        return new PagedResults<TEntity>(
            await query.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToListAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false),
            PageSize,
            PageIndex,
            await query.CountAsync(cancellationToken));
    }
}
