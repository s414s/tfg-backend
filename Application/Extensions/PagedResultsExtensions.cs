using Microsoft.EntityFrameworkCore;

namespace Application.Extensions;

public class PagedResults<TEntity>
{
    public IReadOnlyList<TEntity> Data { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public long TotalResults { get; set; }

    public int TotalPages { get => (int)Math.Ceiling((double)TotalResults / PageSize); }
    public bool HasNextPage { get => (PageIndex * PageSize) < TotalResults; }
    public bool HasPreviousPage { get => PageIndex > 1; }

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
        PageSize = pageSize;
        PageIndex = pageIndex;
        TotalResults = data.Count;
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
        int totalCount = await query.CountAsync(cancellationToken);
        List<TEntity> items = await query
            .Skip((PageIndex - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        return new PagedResults<TEntity>(items, PageSize, PageIndex, totalCount);
    }
}
