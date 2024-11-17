using Application.Contracts;
using Application.DTO;
using MediatR;

namespace Application.Handlers.Users.Query;

public sealed record GetUserInformationRequest : IRequest<UserDTO> { }

internal sealed class GetUserInformationQueryHandler : IRequestHandler<GetUserInformationRequest, UserDTO>
{
    private readonly IAuthServices _authServices;

    public GetUserInformationQueryHandler(IAuthServices authServices)
    {
        _authServices = authServices;
    }

    public async Task<UserDTO> Handle(GetUserInformationRequest request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_authServices.GetUserInfo());
    }
}
