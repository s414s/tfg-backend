using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Users.Commands;

public sealed record UpdateUserInfoCommand() : IRequest<bool>
{
    public long UserId { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Surname { get; init; } = string.Empty;
}

internal sealed class UpdateUserInfoCommandHandler : IRequestHandler<UpdateUserInfoCommand, bool>
{
    private readonly IRepository<User> _usersRepository;
    private readonly IUserInfo _userInfo;

    public UpdateUserInfoCommandHandler(IRepository<User> usersRepository, IUserInfo userInfo)
    {
        _usersRepository = usersRepository;
        _userInfo = userInfo;
    }

    public async Task<bool> Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.Query
            .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(User));

        user.Name = string.IsNullOrEmpty(request.Name) ? user.Name : request.Name.ToLower();
        user.Surname = string.IsNullOrEmpty(request.Surname) ? user.Surname : request.Surname.ToLower();

        return await _usersRepository.SaveChangesAsync(cancellationToken);
    }
}


