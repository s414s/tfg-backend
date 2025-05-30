namespace Application.DTO.Base;

public record PagedRequest
{
    public int PageIndex { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
