﻿using Domain.Entities;

namespace Application.DTO;

public record RouteDTO
{
    public string Origin { get; init; }
    public string Destination { get; init; }
    public decimal Distance { get; init; }
};

public record RouteWithPathDTO : RouteDTO
{
    public IReadOnlyList<GeographicCoordinates> Path { get; init; }
}

public record RouteWithScheduleDTO : RouteDTO
{
    public DateTime ETS { get; init; }
    public DateTime ETA { get; init; }
};
