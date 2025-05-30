using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Threads.Commands;

public sealed record CreateThreadRequest : IRequest<long>
{
    public required string ToEmail { get; init; }
    public required string Text { get; init; }
    public required string Subject { get; init; }
}

internal sealed class CreateThreadCommandHandler : IRequestHandler<CreateThreadRequest, long>
{
    private readonly IRepository<MessageThread> _messageThreadRepository;
    private readonly IRepository<User> _usersRepository;
    private readonly IUserInfo _activeUserInfo;

    public CreateThreadCommandHandler(
        IUserInfo activeUserInfo,
        IRepository<MessageThread> messageThreadRepository,
        IRepository<User> usersRepository)
    {
        _activeUserInfo = activeUserInfo;
        _messageThreadRepository = messageThreadRepository;
        _usersRepository = usersRepository;
    }

    public async Task<long> Handle(CreateThreadRequest request, CancellationToken cancellationToken)
    {
        var toUser = await _usersRepository.Query
            .FirstOrDefaultAsync(x => x.Email == request.ToEmail.ToLower(), cancellationToken)
            ?? throw new EntityNotFoundException(nameof(User));

        if (_activeUserInfo.User.Id == toUser.Id)
            throw new CustomException("You can not send a message to your self");

        var newMessage = new Message
        {
            Text = request.Text,
            UserId = _activeUserInfo.User.Id,
        };

        var newThread = MessageThread.Create(
            author: _activeUserInfo.User.Id,
            to: toUser.Id,
            subject: request.Subject,
            message: newMessage
            );

        await _messageThreadRepository.AddAsync(newThread, cancellationToken);
        await _messageThreadRepository.SaveChangesAsync(cancellationToken);

        return newThread.Id;
    }
}

