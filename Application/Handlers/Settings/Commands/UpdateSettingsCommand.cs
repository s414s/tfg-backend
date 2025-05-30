using Application.DTO;
using Domain.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Settings.Commands;

public sealed record UpdateSettingsCommandRequest(SettingsDTO NewValues) : IRequest<Unit> { }

internal sealed class UpdateSettingsCommandHandler : IRequestHandler<UpdateSettingsCommandRequest, Unit>
{
    private readonly IRepository<SettingsEntity> _settingsRepository;

    public UpdateSettingsCommandHandler(IRepository<SettingsEntity> settingsRepository)
    {
        _settingsRepository = settingsRepository;
    }

    public async Task<Unit> Handle(UpdateSettingsCommandRequest request, CancellationToken cancellationToken)
    {
        var settings = await _settingsRepository.Query.FirstAsync(cancellationToken);

        settings.PricePerLiterFuel = request.NewValues.PricePerLiterFuel;
        settings.PricePerKilogram = request.NewValues.PricePerKilogram;
        settings.PricePerHourDriver = request.NewValues.PricePerHourDriver;

        await _settingsRepository.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
