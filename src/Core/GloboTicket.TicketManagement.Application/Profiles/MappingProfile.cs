using AutoMapper;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Application.Features.Events;

namespace GloboTicket.TicketManagement.Application.Profiles
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Event, EventListViewModel>().ReverseMap();
      CreateMap<Event, EventDetailViewModel>().ReverseMap();
      CreateMap<Category, CategoryDTO>();
    }
  }
}