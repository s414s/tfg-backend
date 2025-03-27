using Application.DTO;
using Application.Exceptions;
using Domain.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Messages.Query;

public sealed record GetThreadMessagesRequest(long ThreadId) : IRequest<List<MessageDTO>> { }

internal sealed class GetThreadMessagesQueryHandler : IRequestHandler<GetThreadMessagesRequest, List<MessageDTO>>
{
    private readonly IRepository<MessageThread> _threadsRepository;
    private readonly IUserInfo _activeUserInfo;

    public GetThreadMessagesQueryHandler(IRepository<MessageThread> threadsRepository, IUserInfo activeUserInfo)
    {
        _threadsRepository = threadsRepository;
        _activeUserInfo = activeUserInfo;
    }

    public async Task<List<MessageDTO>> Handle(GetThreadMessagesRequest request, CancellationToken cancellationToken)
    {
        var messges = await _threadsRepository.Query
            .AsNoTracking()
            .Where(x => x.Id == request.ThreadId && (x.FromId == _activeUserInfo.User.Id || x.ToId == _activeUserInfo.User.Id))
            .Select(x => new ThreadDTO
            {
                Id = x.Id,
                Subject = x.Subject,
                Teaser = x.Teaser,
                IsRead = x.Messages.Any(m => !m.IsRead && m.UserId != _activeUserInfo.User.Id),
                Name = x.From.Name,
                Surname = x.From.Surname,
                Email = x.From.Email,
                Date = x.Created.Date,
                Messages = x.Messages
                    .OrderByDescending(y => y.Date)
                    .Select(y => new MessageDTO
                    {
                        Id = y.Id,
                        Name = y.User.Name,
                        Surname = y.User.Surname,
                        Email = y.User.Email,
                        Text = y.Text,
                        Date = y.Date,
                        IsRead = _activeUserInfo.User.Id == y.UserId || y.IsRead,
                    }),
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException($"Thread with id {request.ThreadId} could not be found");

        var messages = new List<MessageDTO>
         {
            new() {
                Id = 1,
                Name = "John",
                Surname = "Doe",
                Email = "john.doe@example.com",
                Text = "Hi John, we are excited to have you on board. Enjoy our service.",
                Date = DateTime.Now.AddDays(-2),
                IsRead = true
            },
            new() {
                Id = 2,
                Name = "Jane",
                Surname = "Smith",
                Email = "jane.smith@example.com",
                Text = "Dear Jane, please review the recent changes made to your account settings.",
                Date = DateTime.Now.AddDays(-1),
                IsRead = false
            },
            new()
            {
                Id = 3,
                Name = "Alice",
                Surname = "Johnson",
                Email = "alice.johnson@example.com",
                Text = "Hello Alice, check out the top stories and updates in our monthly newsletter.",
                Date = DateTime.Now,
                IsRead = true
            }
         };

        var thread = new ThreadDTO
        {
            Id = 1,
            Name = "John",
            Surname = "Doe",
            Email = "john.doe@example.com",
            Subject = "Welcome to our service",
            Teaser = "Hello John, welcome!",
            Date = DateTime.Now.AddDays(-2),
            IsRead = true,
            Messages = messages,
        };

        return messages;
    }
}

