using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Users.Commands;

public sealed record RemoveUserCommandRequest(long UserId) : IRequest<bool> { }


internal sealed class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommandRequest, bool>
{
    private readonly IRepository<User> _usersRepository;
    private readonly IUserInfo _userInfo;

    public RemoveUserCommandHandler(IRepository<User> usersRepository, IUserInfo userInfo)
    {
        _usersRepository = usersRepository;
        _userInfo = userInfo;
    }

    public async Task<bool> Handle(RemoveUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.Query
            .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(User));

        if (_userInfo.User.Role != UserRoles.Admin)
            throw new CustomException("Not authorized");

        return await _usersRepository.RemoveAsync(user.Id, cancellationToken);
    }
}

