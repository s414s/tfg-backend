namespace Application.DTO;

public record ShiftDTO(RouteDTO[] Routes, UserDTO Pilot, UserDTO Copilot);
