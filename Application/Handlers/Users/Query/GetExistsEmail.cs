using Domain.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Users.Query;

public sealed record GetExistsEmailRequest(string UserEmail) : IRequest<bool> { }

internal sealed class GetExistsEmailRequestHandler : IRequestHandler<GetExistsEmailRequest, bool>
{
    private readonly IRepository<User> _usersRepository;

    public GetExistsEmailRequestHandler(IRepository<User> usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<bool> Handle(GetExistsEmailRequest request, CancellationToken cancellationToken)
    {
        return await _usersRepository.Query
            .AnyAsync(x => x.Email == request.UserEmail.ToLower(), cancellationToken);
    }
}
