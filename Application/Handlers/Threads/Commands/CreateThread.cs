using Domain.Contracts;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Threads.Commands;

public sealed record CreateThreadRequest : IRequest<long>
{
    public long ToId { get; init; }
    public string Text { get; init; } = "";
    public string Subject { get; init; } = "";
}

internal sealed class CreateThreadCommandHandler : IRequestHandler<CreateThreadRequest, long>
{
    private readonly IRepository<MessageThread> _messageThreadRepository;
    private readonly IUserInfo _activeUserInfo;

    public CreateThreadCommandHandler(IUserInfo activeUserInfo, IRepository<MessageThread> messageThreadRepository)
    {
        _activeUserInfo = activeUserInfo;
        _messageThreadRepository = messageThreadRepository;
    }

    public async Task<long> Handle(CreateThreadRequest request, CancellationToken cancellationToken)
    {
        var newMessage = new Message
        {
            Text = request.Text,
            UserId = _activeUserInfo.User.Id,
        };

        var newThread = MessageThread.Create(
            author: _activeUserInfo.User.Id,
            to: request.ToId,
            subject: request.Subject,
            message: newMessage
            );

        await _messageThreadRepository.AddAsync(newThread, cancellationToken);

        return newThread.Id;
    }
}

