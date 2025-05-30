using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Threads.Commands;

public sealed record DeleteThreadRequest(long ThreadId) : IRequest<bool> { }

internal sealed class DeleteThreadCommandHandler : IRequestHandler<DeleteThreadRequest, bool>
{
    private readonly IRepository<MessageThread> _messageThreadRepository;
    private readonly IUserInfo _activeUserInfo;

    public DeleteThreadCommandHandler(IUserInfo activeUserInfo, IRepository<MessageThread> messageThreadRepository)
    {
        _activeUserInfo = activeUserInfo;
        _messageThreadRepository = messageThreadRepository;
    }

    public async Task<bool> Handle(DeleteThreadRequest request, CancellationToken cancellationToken)
    {
        var thread = await _messageThreadRepository.Query
            .FirstOrDefaultAsync(x => x.Id == request.ThreadId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Thread));

        if (thread.CreatedBy != _activeUserInfo.User.Id)
        {
            throw new CustomException("You can not delete a thread that you did no create");
        }

        await _messageThreadRepository.RemoveAsync(thread.Id, cancellationToken);
        await _messageThreadRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}
