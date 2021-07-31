using System.Linq;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
  public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListViewModel>>
  {
    private readonly IAsyncRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoriesListQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
    {
      _mapper = mapper;
      _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryListViewModel>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
    {
      var allCategories = (await _categoryRepository.ListAllAsync()).OrderBy(x => x.Name);
      return _mapper.Map<List<CategoryListViewModel>>(allCategories);
    }
  }
}