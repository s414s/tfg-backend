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
        var messages = await _threadsRepository.Query
            .Where(x => x.Id == request.ThreadId)
            .Where(x => x.FromId == _activeUserInfo.User.Id || x.ToId == _activeUserInfo.User.Id)
            .Select(x => new
            {
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
                        IsRead = y.IsRead,
                    })
                    .ToList(),
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException($"Thread with id {request.ThreadId} could not be found");

        return messages.Messages;
    }
}

