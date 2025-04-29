using Domain.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Users.Query;

public sealed record GetUsersEmailsRequest : IRequest<IEnumerable<string>> { }

internal sealed class GetUsersEmailsRequestHandler : IRequestHandler<GetUsersEmailsRequest, IEnumerable<string>>
{
    private readonly IRepository<User> _usersRepository;

    public GetUsersEmailsRequestHandler(IRepository<User> usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<IEnumerable<string>> Handle(GetUsersEmailsRequest request, CancellationToken cancellationToken)
    {
        return await _usersRepository.Query
            .Select(x => x.Email.ToLower())
            .ToListAsync(cancellationToken);
    }
}
