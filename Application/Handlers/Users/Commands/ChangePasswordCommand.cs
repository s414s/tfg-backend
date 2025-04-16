using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Users.Commands;

public sealed record ChangePasswordCommandRequest : IRequest<bool>
{
    public string Email { get; init; } = string.Empty;
    public string NewPassword { get; init; } = string.Empty;
}

public class ChangePasswordCommandRequestValdator : AbstractValidator<ChangePasswordCommandRequest>
{
    public ChangePasswordCommandRequestValdator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} can not be empty");
        RuleFor(x => x.NewPassword).NotEmpty().WithMessage("{PropertyName} can not be empty");
    }
}

internal sealed class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommandRequest, bool>
{
    private readonly IRepository<User> _usersRepository;
    private readonly IUserInfo _userInfo;

    public ChangePasswordCommandHandler(IRepository<User> usersRepository, IUserInfo userInfo)
    {
        _usersRepository = usersRepository;
        _userInfo = userInfo;
    }

    public async Task<bool> Handle(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
    {
        var currentUser = await _usersRepository.Query
            .FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(User));

        if (currentUser.Id != _userInfo.User.Id && _userInfo.User.Role != UserRoles.Admin)
            throw new CustomException("Not authorized");

        if (currentUser.Password == request.NewPassword)
            throw new CustomException("Incorrect credentials");

        await _usersRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}
