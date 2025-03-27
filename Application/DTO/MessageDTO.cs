namespace Application.DTO;

public sealed record MessageDTO
{
    public required long Id { get; init; }
    public required string Name { get; init; }
    public required string Surname { get; init; }
    public required string Email { get; init; }
    public required string Text { get; init; }
    public required DateTime Date { get; init; }
    public required bool IsRead { get; init; }
}

public sealed record ThreadDTO
{
    public required long Id { get; init; }
    public required string Name { get; init; }
    public required string Surname { get; init; }
    public required string Email { get; init; }
    public required string Subject { get; init; }
    public required string Teaser { get; init; }
    public required DateTime Date { get; init; }
    public required bool IsRead { get; init; }
    public IEnumerable<MessageDTO> Messages { get; init; } = [];
}
