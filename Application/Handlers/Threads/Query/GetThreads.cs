using Application.DTO;
using Application.Extensions;
using Domain.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Threads.Query;

public sealed record GetThreadsRequest(int PageIndex, int PageSize) : IRequest<PagedResults<ThreadDTO>> { }

internal sealed class GetThreadMessagesQueryHandler : IRequestHandler<GetThreadsRequest, PagedResults<ThreadDTO>>
{
    private readonly IRepository<MessageThread> _threadsRepository;
    private readonly IUserInfo _activeUserInfo;

    public GetThreadMessagesQueryHandler(IRepository<MessageThread> threadsRepository, IUserInfo activeUserInfo)
    {
        _threadsRepository = threadsRepository;
        _activeUserInfo = activeUserInfo;
    }

    public async Task<PagedResults<ThreadDTO>> Handle(GetThreadsRequest request, CancellationToken cancellationToken)
    {
        var threads = await _threadsRepository.Query
            //.Include(x => x.Messages)
            .Include(x => x.Messages.Where(m => !m.IsRead && m.UserId != _activeUserInfo.User.Id))
            .Where(x => x.ToId == _activeUserInfo.User.Id || x.FromId == _activeUserInfo.User.Id)
            //.OrderByDescending(y => y.Messages.OrderByDescending(z => z.Date).First().Date)
            .Select(x => new ThreadDTO
            {
                Id = x.Id,
                Subject = x.Subject,
                Teaser = x.Teaser,
                IsRead = x.Messages.Count > 0,
                Name = x.From.Name,
                Surname = x.From.Surname,
                Email = x.From.Email,
                Date = x.Created.Date,
            })
            .ToPagedResultsAsync(request.PageIndex, request.PageSize, cancellationToken);

        return threads;

        //var query = _activeUserInfo.User.Role == Domain.Enums.UserRoles.Admin
        //    ? _threadsRepository.Query.Where(x => x.DeletedDate != DateTime.MinValue)
        //    : _threadsRepository.Query.Where(x => x.DeletedDate != DateTime.MinValue && x.User.Id == _activeUserInfo.User.Id);
    }
}

