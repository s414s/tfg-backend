using Application.DTO;
using Application.DTO.Base;
using Application.Extensions;
using Domain.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Threads.Query;

public sealed record GetThreadsRequest() : PagedRequest, IRequest<PagedResults<ThreadDTO>> { }

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
            .Include(x => x.Messages.Where(m => !m.IsRead && m.UserId != _activeUserInfo.User.Id))
            .Where(x => x.ToId == _activeUserInfo.User.Id || x.FromId == _activeUserInfo.User.Id)
            .OrderByDescending(x => x.LastModified)
            .Select(x => new ThreadDTO
            {
                Id = x.Id,
                Subject = x.Subject,
                Teaser = x.Teaser,
                IsRead = !x.Messages.Any(m => m.UserId != _activeUserInfo.User.Id && !m.IsRead),
                Name = x.FromId == _activeUserInfo.User.Id ? x.To.Name : x.From.Name,
                Surname = x.FromId == _activeUserInfo.User.Id ? x.To.Surname : x.From.Surname,
                Email = x.From.Email,
                Date = x.LastModified.Date,
                AuthorId = x.CreatedBy,
            })
            .ToPagedResultsAsync(request.PageIndex, request.PageSize, cancellationToken);

        return threads;

        //var query = _activeUserInfo.User.Role == Domain.Enums.UserRoles.Admin
        //    ? _threadsRepository.Query.Where(x => x.DeletedDate != DateTime.MinValue)
        //    : _threadsRepository.Query.Where(x => x.DeletedDate != DateTime.MinValue && x.User.Id == _activeUserInfo.User.Id);
    }
}

