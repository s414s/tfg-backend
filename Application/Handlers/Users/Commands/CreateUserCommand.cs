using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Application.Handlers.Users.Commands;

public sealed record CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
{
    public string Name { get; init; } = string.Empty;
    public string Surname { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public DateTime DateOfBirth { get; init; }
}

public class CreateUserCommandRequestValidator : AbstractValidator<CreateUserCommandRequest>
{
    public CreateUserCommandRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} can not be empty");
        RuleFor(x => x.Surname).NotEmpty().WithMessage("{PropertyName} can not be empty");
        RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} can not be empty");
    }
}

public sealed record CreateUserCommandResponse
{
    public required long Id { get; init; }
    public required string Password { get; init; }
}

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IRepository<User> _usersRepository;

    public CreateUserCommandHandler(IRepository<User> usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        if (await _usersRepository.Query.AnyAsync(x => x.Email == request.Email))
            throw new CustomException("Email already exists.");

        if (DateTime.UtcNow - request.DateOfBirth < TimeSpan.FromDays(18 * 365))
            throw new CustomException("User must be over 18 years old.");

        var newUser = new User
        {
            Name = request.Name,
            Surname = request.Surname,
            Email = request.Email,
            Birthday = request.DateOfBirth,
            Password = GenerateRandomPassword(5),
            Role = UserRoles.Driver,
        };

        await _usersRepository.AddAsync(newUser, cancellationToken);
        await _usersRepository.SaveChangesAsync(cancellationToken);

        return new CreateUserCommandResponse { Id = newUser.Id, Password = newUser.Password };
    }

    private static string GenerateRandomPassword(int length)
    {
        const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        char[] passwordChars = new char[length];

        using (var rng = RandomNumberGenerator.Create())
        {
            byte[] randomBytes = new byte[length];
            // Fill the array with secure random bytes.
            rng.GetBytes(randomBytes);

            // Map each random byte to a character in allowedChars.
            for (int i = 0; i < length; i++)
            {
                int index = randomBytes[i] % allowedChars.Length;
                passwordChars[i] = allowedChars[index];
            }
        }

        return new string(passwordChars);
    }
}
