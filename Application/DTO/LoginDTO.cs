namespace Application.DTO;

public record LoginRequestDTO(string Username, string Password);
public record LoginResponseDTO(string Token);
