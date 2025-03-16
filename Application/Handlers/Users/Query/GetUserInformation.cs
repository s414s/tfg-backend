using Domain.Contracts;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Users.Query;

public sealed record GetUserInformationRequest : IRequest<ActiveUserInfo> { }

internal sealed class GetUserInformationQueryHandler : IRequestHandler<GetUserInformationRequest, ActiveUserInfo>
{
    private readonly IUserInfo _user;

    public GetUserInformationQueryHandler(IUserInfo user)
    {
        _user = user;
    }

    public async Task<ActiveUserInfo> Handle(GetUserInformationRequest request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_user.User);
    }
}
