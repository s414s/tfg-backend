using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Users.Commands;

public sealed record CreateUserCommandRequest : IRequest<long>
{
    public string Name { get; init; } = string.Empty;
    public string Surname { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public DateTime Birthday { get; init; }
}

public class CreateUserCommandRequestValidator : AbstractValidator<CreateUserCommandRequest>
{
    public CreateUserCommandRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} can not be empty");
        RuleFor(x => x.Surname).NotEmpty().WithMessage("{PropertyName} can not be empty");
        RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} can not be empty");
        RuleFor(x => x.Birthday).NotEmpty().WithMessage("{PropertyName} can not be empty");
    }
}

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, long>
{
    private readonly IRepository<User> _usersRepository;

    public CreateUserCommandHandler(IRepository<User> usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<long> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        if (await _usersRepository.Query.AnyAsync(x => x.Email == request.Email))
            throw new Exception(); // TODO

        var newUser = new User
        {
            Name = request.Name,
            Surname = request.Surname,
            Email = request.Email,
            Birthday = request.Birthday,
            Password = "TODO", // TODO - password generator
            Role = UserRoles.Driver,
        };

        await _usersRepository.AddAsync(newUser, cancellationToken);
        await _usersRepository.SaveChangesAsync(cancellationToken);

        return newUser.Id;
    }
}
