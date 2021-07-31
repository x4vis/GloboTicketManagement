using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
  public class GetCategoriesListWithEventsQueryHandler : IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListViewModel>>
  {
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesListWithEventsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
      _mapper = mapper;
      _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryEventListViewModel>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
    {
      var list = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
      return _mapper.Map<List<CategoryEventListViewModel>>(list);
    }
  }
}