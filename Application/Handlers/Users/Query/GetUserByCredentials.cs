using Application.DTO;
using Domain.Contracts;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Users.Query;

public sealed record GetUserByCredentialsRequest(
    string Email,
    string Password
    ) : IRequest<UserDTO>
{ }

public class GetUserByCredentialsRequestValidator : AbstractValidator<GetUserByCredentialsRequest>
{
    public GetUserByCredentialsRequestValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("{PropertyName} must be a valid email.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("{PropertyName} can not be empty.");
    }
}

internal sealed class GetUserByCredentialsQueryHandler : IRequestHandler<GetUserByCredentialsRequest, UserDTO>
{
    private readonly IRepository<User> _usersRepository;

    public GetUserByCredentialsQueryHandler(IRepository<User> usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<UserDTO> Handle(GetUserByCredentialsRequest request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.Query
            .FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken)
            ?? throw new Exception("User or password incorrect");

        return new UserDTO
        {
            Name = user.Name,
            Surname = user.Surname,
            Role = user.Role,
        };
    }
}
