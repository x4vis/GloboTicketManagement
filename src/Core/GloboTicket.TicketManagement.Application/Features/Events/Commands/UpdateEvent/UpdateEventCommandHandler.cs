using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
  public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
  {
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Event> _eventRepository;

    public UpdateEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
    {
      _mapper = mapper;
      _eventRepository = eventRepository;
    }

    public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
      var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);
      _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));
      await _eventRepository.UpdateAsync(eventToUpdate);
      return Unit.Value;
    }
  }
}