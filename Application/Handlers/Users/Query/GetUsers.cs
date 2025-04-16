using Application.DTO;
using Application.DTO.Base;
using Application.Extensions;
using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using MediatR;

namespace Application.Handlers.Users.Query;

public sealed record GetUsersRequest : PagedRequest, IRequest<PagedResults<UserDTO>>
{
    public UserRoles? Role { get; init; }
    public string? Email { get; init; }
    public string? Name { get; init; }
    public string? Surname { get; init; }
}

public class GetUsersRequestValidator : AbstractValidator<GetUsersRequest>
{
    public GetUsersRequestValidator()
    {
        RuleFor(x => x.Role)
          .IsInEnum()
          .When(x => x.Role.HasValue)
          .WithMessage("{PropertyName} is not a valid role");
    }
}

internal sealed class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, PagedResults<UserDTO>>
{
    private readonly IRepository<User> _usersRepository;

    public GetUsersRequestHandler(IRepository<User> usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<PagedResults<UserDTO>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        return await _usersRepository.Query
            .Where(x => request.Email == null || x.Email.Contains(request.Email))
            .Where(x => request.Name == null || x.Name.Contains(request.Name))
            .Where(x => request.Surname == null || x.Surname.Contains(request.Surname))
            .Where(x => request.Role == null || x.Role == request.Role)
            .Select(x => new UserDTO
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Role = x.Role,
            })
            .ToPagedResultsAsync(request.PageIndex, request.PageSize, cancellationToken);
    }
}
