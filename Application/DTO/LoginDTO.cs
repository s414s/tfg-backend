namespace Application.DTO;

public record LoginRequestDTO(string Email, string Password);
public record LoginResponseDTO(string Token);
public record ChangePwdRequestDTO(string Email, string NewPassword, string NewPassword2);
