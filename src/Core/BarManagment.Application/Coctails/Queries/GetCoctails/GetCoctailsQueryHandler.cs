using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Coctails.Queries.GetCoctails
{
    internal class GetCoctailsQueryHandler : IRequestHandler<GetCoctailsQuery, IEnumerable<Coctail>>
    {
        private readonly IRepository<Coctail> _coctailRepository;

        public GetCoctailsQueryHandler(IRepository<Coctail> coctailRepository)
        {
            _coctailRepository = coctailRepository;
        }
        public async Task<IEnumerable<Coctail>> Handle(GetCoctailsQuery request, CancellationToken cancellationToken)
        {
            var coctails = await _coctailRepository.GetAll(include: i => i.Include(c => c.Ingredients)).ToListAsync();
            return coctails;
        }
    }
}
