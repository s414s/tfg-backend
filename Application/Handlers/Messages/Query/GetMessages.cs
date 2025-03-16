using Application.DTO;
using Application.Extensions;
using Domain.Contracts;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Messages.Query;

public sealed record GetMessagesRequest : IRequest<PagedResults<MessageDTO>> { }

internal sealed class GetMessagesQueryHandler : IRequestHandler<GetMessagesRequest, PagedResults<MessageDTO>>
{
    private readonly IRepository<MessageThread> _threadsRepository;
    private readonly IUserInfo _activeUserInfo;

    public GetMessagesQueryHandler(IRepository<MessageThread> threadsRepository, IUserInfo activeUserInfo)
    {
        _threadsRepository = threadsRepository;
        _activeUserInfo = activeUserInfo;
    }

    public async Task<PagedResults<MessageDTO>> Handle(GetMessagesRequest request, CancellationToken cancellationToken)
    {
        var messages = new List<MessageDTO>
        {
            new MessageDTO
            {
                Id = 1,
                Name = "John",
                Surname = "Doe",
                Email = "john.doe@example.com",
                Subject = "Welcome to our service",
                Teaser = "Hello John, welcome!",
                Text = "Hi John, we are excited to have you on board. Enjoy our service.",
                Date = DateTime.Now.AddDays(-2),
                IsDeleted = false,
                IsRead = true
            },
            new MessageDTO
            {
                Id = 2,
                Name = "Jane",
                Surname = "Smith",
                Email = "jane.smith@example.com",
                Subject = "Your account update",
                Teaser = "Update regarding your account",
                Text = "Dear Jane, please review the recent changes made to your account settings.",
                Date = DateTime.Now.AddDays(-1),
                IsDeleted = false,
                IsRead = false
            },
            new MessageDTO
            {
                Id = 3,
                Name = "Alice",
                Surname = "Johnson",
                Email = "alice.johnson@example.com",
                Subject = "Monthly Newsletter",
                Teaser = "Highlights for this month",
                Text = "Hello Alice, check out the top stories and updates in our monthly newsletter.",
                Date = DateTime.Now,
                IsDeleted = false,
                IsRead = true
            }
        };

        var pagR = messages.ToPagedResultsAsync(1, 10);

        var query = _activeUserInfo.User.Role == Domain.Enums.UserRoles.Admin
            ? _threadsRepository.Query.Where(x => x.DeletedDate != DateTime.MinValue)
            : _threadsRepository.Query.Where(x => x.DeletedDate != DateTime.MinValue && x.User.Id == _activeUserInfo.User.Id);

        return pagR;

        // return await query.Select(x => new MessageDTO
        //    {
        //        Id = x.Id,
        //        Name = x.User.Name,
        //        Surname = x.User.Surname,
        //        Email = x.User.Email,
        //        Subject = x.Subject,
        //        Text = x.Text,
        //        Date = DateTime.Now,
        //        Teaser = x.Teaser,
        //        IsDeleted = false,
        //        IsRead = x.IsRead,
        //    })
        //    .ToPagedResultsAsync(1, 10, cancellationToken); // TODO
    }
}

