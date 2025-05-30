using Application.DTO;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
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
        //var messages = await _threadsRepository.Query
        //    .Where(x => x.Id == request.ThreadId)
        //    .Where(x => x.FromId == _activeUserInfo.User.Id || x.ToId == _activeUserInfo.User.Id)
        //    .Select(x => new
        //    {
        //        Messages = x.Messages
        //        .OrderByDescending(y => y.Date)
        //            .Select(y => new MessageDTO
        //            {
        //                Id = y.Id,
        //                Name = y.User.Name,
        //                Surname = y.User.Surname,
        //                Email = y.User.Email,
        //                Text = y.Text,
        //                Date = y.Date,
        //                IsRead = y.IsRead,
        //            })
        //            .ToList(),
        //    })
        //    .FirstOrDefaultAsync(cancellationToken)
        //    ?? throw new EntityNotFoundException(nameof(Message));
        //return messages.Messages;

        var thread = await _threadsRepository.Query
            .Where(x => x.Id == request.ThreadId && !x.DeletedDate.HasValue)
            .Where(x => x.FromId == _activeUserInfo.User.Id || x.ToId == _activeUserInfo.User.Id)
            .Include(x => x.Messages)
                .ThenInclude(x => x.User)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Message));

        // Mark as read
        foreach (var message in thread.Messages.Where(x => x.UserId != _activeUserInfo.User.Id))
        {
            message.IsRead = true;
        }

        await _threadsRepository.SaveChangesAsync(cancellationToken);

        return thread.Messages
            .OrderByDescending(x => x.Date)
            .Select(x => new MessageDTO
            {
                Id = x.Id,
                Name = x.User.Name,
                Surname = x.User.Surname,
                Email = x.User.Email,
                Text = x.Text,
                Date = x.Date,
                IsRead = x.IsRead,
            })
            .ToList();
    }
}
