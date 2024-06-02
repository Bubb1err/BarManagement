using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Coctails.Queries.SearchCoctails
{
    internal sealed class SearchCoctailsQueryHandler : IRequestHandler<SearchCoctailsQuery, IEnumerable<Coctail>>
    {
        private readonly IRepository<Coctail> _coctailsRepository;
        private readonly IRepository<User> _usersRepository;

        public SearchCoctailsQueryHandler(IRepository<Coctail> coctailsRepository, IRepository<User> usersRepository)
        {
            _coctailsRepository = coctailsRepository;
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<Coctail>> Handle(SearchCoctailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetFirstOrDefaultAsync(u => u.Id == request.UserId);
            var coctails = await _coctailsRepository.GetAll(c => c.Name.ToLower().Contains(request.Search.ToLower()) && c.CompanyCode == user.CompanyCode).ToListAsync();
            return coctails;
        }
    }
}
