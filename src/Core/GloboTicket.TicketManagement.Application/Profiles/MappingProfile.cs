using AutoMapper;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;

namespace GloboTicket.TicketManagement.Application.Profiles
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Event, EventListViewModel>().ReverseMap();
      CreateMap<Event, EventDetailViewModel>().ReverseMap();
      CreateMap<Category, CategoryDTO>();
      CreateMap<Category, CategoryListViewModel>();
      CreateMap<Category, CategoryEventListViewModel>();
      CreateMap<Event, CreateEventCommand>().ReverseMap();
    }
  }
}