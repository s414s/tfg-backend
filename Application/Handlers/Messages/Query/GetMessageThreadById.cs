using Application.DTO;
using Domain.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Messages.Query;

public sealed record GetMessageThreadById(long ThreadId) : IRequest<IEnumerable<MessageDTO>> { }

internal sealed class GetMessageByIdQueryHandler : IRequestHandler<GetMessageThreadById, IEnumerable<MessageDTO>>
{
    private readonly IRepository<Message> _messagesRepository;

    public GetMessageByIdQueryHandler(IRepository<Message> messagesRepository)
    {
        _messagesRepository = messagesRepository;
    }

    public async Task<IEnumerable<MessageDTO>> Handle(GetMessageThreadById request, CancellationToken cancellationToken)
    {
        return await _messagesRepository.Query
            .Where(x => x.Id == request.ThreadId && x.MessageThread.DeletedDate != DateTime.MinValue)
            .Select(x => new MessageDTO
            {
                Id = x.Id,
                Name = x.User.Name,
                Surname = x.User.Surname,
                Email = x.User.Email,
                Subject = x.MessageThread.Subject,
                Text = x.Text,
                Date = DateTime.Now,
                Teaser = x.MessageThread.Teaser,
                IsDeleted = false,
                IsRead = x.MessageThread.IsRead,
            })
            .ToListAsync(cancellationToken);
    }
}

