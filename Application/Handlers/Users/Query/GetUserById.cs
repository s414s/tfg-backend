using Application.DTO;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Users.Query;

public sealed record GetUserByIdRequest(long UserId) : IRequest<UserDTO> { }

internal sealed class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, UserDTO>
{
    private readonly IRepository<User> _usersRepository;
    private readonly IRepository<Freight> _freightsRepository;

    public GetUserByIdRequestHandler(IRepository<User> usersRepository, IRepository<Freight> freightsRepository)
    {
        _usersRepository = usersRepository;
        _freightsRepository = freightsRepository;
    }

    public async Task<UserDTO> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        return await _usersRepository.Query
            .Where(x => x.Id == request.UserId)
            .Select(x => new UserDTO
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Role = x.Role,
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException(nameof(User));
    }
}
