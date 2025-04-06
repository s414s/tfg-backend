using Domain.Contracts;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Users.Query;

public sealed record GetCurrentUserInformationRequest : IRequest<ActiveUserInfo> { }

internal sealed class GetUserInformationQueryHandler : IRequestHandler<GetCurrentUserInformationRequest, ActiveUserInfo>
{
    private readonly IUserInfo _user;

    public GetUserInformationQueryHandler(IUserInfo user)
    {
        _user = user;
    }

    public async Task<ActiveUserInfo> Handle(GetCurrentUserInformationRequest request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_user.User);
    }
}
