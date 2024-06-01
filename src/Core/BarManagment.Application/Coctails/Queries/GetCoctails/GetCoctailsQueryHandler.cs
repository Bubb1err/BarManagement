using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Coctails.Queries.GetCoctails
{
    internal class GetCoctailsQueryHandler : IRequestHandler<GetCoctailsQuery, IEnumerable<Coctail>>
    {
        private readonly IRepository<Coctail> _coctailRepository;
        private readonly IRepository<User> _usersRepository;

        public GetCoctailsQueryHandler(IRepository<Coctail> coctailRepository, IRepository<User> usersRepository)
        {
            _coctailRepository = coctailRepository;
            _usersRepository = usersRepository;
        }
        public async Task<IEnumerable<Coctail>> Handle(GetCoctailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetFirstOrDefaultAsync(u => u.Id == request.UserId);

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var coctails = await _coctailRepository.GetAll(c => c.Name.ToLower().Contains(request.Search.ToLower()) && c.CompanyCode == user.CompanyCode,
                    include: i => i.Include(c => c.Ingredients)).ToListAsync();
                return coctails;
            }
            else
            {
                var coctails = await _coctailRepository.GetAll(c => c.CompanyCode == user.CompanyCode,
                    include: i => i.Include(c => c.Ingredients)).ToListAsync();
                return coctails;
            }
        }
    }
}
