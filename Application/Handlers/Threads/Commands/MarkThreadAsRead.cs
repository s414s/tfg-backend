using Domain.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Threads.Commands;

public sealed record MarkThreadAsReadRequest(long ThreadId) : IRequest<bool> { }

internal sealed class MarkThreadAsReadCommandHandler : IRequestHandler<MarkThreadAsReadRequest, bool>
{
    private readonly IRepository<Message> _messagesRepository;
    private readonly IUserInfo _activeUserInfo;

    public MarkThreadAsReadCommandHandler(IUserInfo activeUserInfo, IRepository<Message> messagesRepository)
    {
        _activeUserInfo = activeUserInfo;
        _messagesRepository = messagesRepository;
    }

    public async Task<bool> Handle(MarkThreadAsReadRequest request, CancellationToken cancellationToken)
    {
        var messages = await _messagesRepository.Query
            .Where(x => x.MessageThreadId == request.ThreadId)
            .Where(x => x.UserId != _activeUserInfo.User.Id)
            .ToListAsync(cancellationToken);

        foreach (var message in messages)
        {
            message.IsRead = true;
        }

        await _messagesRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}

