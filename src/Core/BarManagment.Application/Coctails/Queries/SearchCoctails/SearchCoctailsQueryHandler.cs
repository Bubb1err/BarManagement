using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Coctails.Queries.SearchCoctails
{
    internal sealed class SearchCoctailsQueryHandler : IRequestHandler<SearchCoctailsQuery, IEnumerable<Coctail>>
    {
        private readonly IRepository<Coctail> _coctailsRepository;

        public SearchCoctailsQueryHandler(IRepository<Coctail> coctailsRepository)
        {
            _coctailsRepository = coctailsRepository;
        }

        public async Task<IEnumerable<Coctail>> Handle(SearchCoctailsQuery request, CancellationToken cancellationToken)
        {
            var coctails = await _coctailsRepository.GetAll(c => c.Name.ToLower().Contains(request.Search.ToLower())).ToListAsync();
            return coctails;
        }
    }
}
