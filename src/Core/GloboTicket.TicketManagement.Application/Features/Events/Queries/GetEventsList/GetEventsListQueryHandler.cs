using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using AutoMapper;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList
{
  public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListViewModel>>
  {
    private readonly IAsyncRepository<Event> _eventRepository;
    private readonly IMapper _mapper;

    public GetEventsListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
    {
      _mapper = mapper;
      _eventRepository = eventRepository;
    }

    public async Task<List<EventListViewModel>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
    {
      var allEvents = (await _eventRepository.ListAllAsync()).OrderBy(x => x.Date);
      return _mapper.Map<List<EventListViewModel>>(allEvents);
    }
  }
}