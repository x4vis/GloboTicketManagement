using System.Collections.Generic;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
  public class GetCategoriesListWithEventsQuery : IRequest<List<CategoryEventListViewModel>>
  {
    public bool IncludeHistory { get; set; }
  }
}