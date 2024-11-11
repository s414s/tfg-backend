using Application.Contracts;
using Application.DTO;
using Application.Exceptions;
using Domain.Contracts;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Users.Query;

public sealed record CreateUserTokenRequest(
    string Email,
    string Password
    ) : IRequest<LoginResponseDTO>
{ }

public class CreateUserTokenRequestValidator : AbstractValidator<CreateUserTokenRequest>
{
    public CreateUserTokenRequestValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("{PropertyName} must be a valid email.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("{PropertyName} can not be empty.");
    }
}

internal sealed class CreateUserTokenQueryHandler : IRequestHandler<CreateUserTokenRequest, LoginResponseDTO>
{
    private readonly IRepository<User> _usersRepository;
    private readonly IAuthServices _authServices;

    public CreateUserTokenQueryHandler(IRepository<User> usersRepository, IAuthServices authServices)
    {
        _usersRepository = usersRepository;
        _authServices = authServices;
    }

    public async Task<LoginResponseDTO> Handle(CreateUserTokenRequest request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.Query
            .Where(x => x.Email == request.Email && x.Password == request.Password)
            .Select(x => new UserDTO
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Role = x.Role,
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException("User or password incorrect");

        return new LoginResponseDTO(_authServices.GenerateJWT(user));
    }
}
