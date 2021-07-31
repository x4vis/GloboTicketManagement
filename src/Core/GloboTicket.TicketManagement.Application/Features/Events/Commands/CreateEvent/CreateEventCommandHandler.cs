using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
  public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
  {
    private readonly IMapper _mapper;
    private readonly IEventRepository _eventRepository;

    public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
    {
      _mapper = mapper;
      _eventRepository = eventRepository;
    }

    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
      var @event = _mapper.Map<Event>(request);
      @event = await _eventRepository.AddAsync(@event);
      return @event.EventId;
    }
  }
}