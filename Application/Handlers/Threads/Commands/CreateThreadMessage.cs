using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Application.Handlers.Threads.Commands;

public sealed record CreateThreadMessageRequest : IRequest<long>
{
    [JsonIgnore]
    public long ThreadId { get; init; }
    public required string Text { get; init; }
}

internal sealed class CreateThreadMessageCommandHandler : IRequestHandler<CreateThreadMessageRequest, long>
{
    private readonly IRepository<Message> _messagesRepository;
    private readonly IRepository<MessageThread> _messageThreadRepository;
    private readonly IUserInfo _activeUserInfo;

    public CreateThreadMessageCommandHandler(IRepository<Message> messagesRepository, IUserInfo activeUserInfo, IRepository<MessageThread> messageThreadRepository)
    {
        _messagesRepository = messagesRepository;
        _activeUserInfo = activeUserInfo;
        _messageThreadRepository = messageThreadRepository;
    }

    public async Task<long> Handle(CreateThreadMessageRequest request, CancellationToken cancellationToken)
    {
        if (!await _messageThreadRepository.Query
            .AnyAsync(x => x.Id == request.ThreadId && (x.FromId == _activeUserInfo.User.Id || x.ToId == _activeUserInfo.User.Id)))
        {
            throw new EntityNotFoundException(nameof(MessageThread));
        }

        var newMessage = new Message()
        {
            MessageThreadId = request.ThreadId,
            Text = request.Text,
            IsRead = false,
            UserId = _activeUserInfo.User.Id,
        };

        await _messagesRepository.AddAsync(newMessage, cancellationToken);
        await _messagesRepository.SaveChangesAsync(cancellationToken);
        return newMessage.Id;
    }
}

