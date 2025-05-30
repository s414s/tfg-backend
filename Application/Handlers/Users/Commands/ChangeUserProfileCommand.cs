using Domain.Contracts;
using MediatR;

namespace Application.Handlers.Users.Commands;

public sealed record ChangeUserProfileCommand : IRequest<bool>
{
    public string Name { get; init; } = string.Empty;
    public string Surname { get; init; } = string.Empty;
}

internal sealed class ChangeUserProfileCommandHandler : IRequestHandler<ChangeUserProfileCommand, bool>
{
    private readonly IMediator _mediatr;
    private readonly IUserInfo _userInfo;

    public ChangeUserProfileCommandHandler(IUserInfo userInfo, IMediator mediatr)
    {
        _userInfo = userInfo;
        _mediatr = mediatr;
    }

    public async Task<bool> Handle(ChangeUserProfileCommand request, CancellationToken cancellationToken)
    {
        return await _mediatr.Send(new UpdateUserInfoCommand
        {
            UserId = _userInfo.User.Id,
            Name = request.Name,
            Surname = request.Surname,
        });
    }
}
