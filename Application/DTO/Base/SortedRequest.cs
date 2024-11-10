namespace Application.DTO.Base;

public record SortedRequest : PagedRequest
{
    public string OrderBy { get; init; } = "";
    public bool IsDescending { get; init; }
}
