using Application.DTO;
using Domain.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Settings.Query;

public sealed record GetSettingsRequest() : IRequest<SettingsDTO> { }

internal sealed class GetSettingsHandler : IRequestHandler<GetSettingsRequest, SettingsDTO>
{
    private readonly IRepository<SettingsEntity> _settingsRepository;

    public GetSettingsHandler(IRepository<SettingsEntity> settingsRepository)
    {
        _settingsRepository = settingsRepository;
    }

    public async Task<SettingsDTO> Handle(GetSettingsRequest request, CancellationToken cancellationToken)
    {
        return await _settingsRepository.Query
            .Select(x => new SettingsDTO
            {
                PricePerLiterFuel = x.PricePerLiterFuel,
                PricePerKilogram = x.PricePerKilogram,
                PricePerHourDriver = x.PricePerHourDriver,
            })
            .FirstAsync(cancellationToken);
    }
}
