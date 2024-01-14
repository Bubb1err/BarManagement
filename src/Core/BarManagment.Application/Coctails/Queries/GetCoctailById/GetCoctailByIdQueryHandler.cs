using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Coctails.Queries.GetCoctailById
{
    internal class GetCoctailByIdQueryHandler : IRequestHandler<GetCoctailByIdQuery, Coctail>
    {
        private readonly IRepository<Coctail> _coctailRepository;

        public GetCoctailByIdQueryHandler(
            IRepository<Coctail> coctailRepository)
        {
            _coctailRepository = coctailRepository;
        }
        public Task<Coctail> Handle(GetCoctailByIdQuery request, CancellationToken cancellationToken)
        {
            var coctail = _coctailRepository.GetFirstOrDefaultAsync(c => c.Id == request.Id,
                include: i => i.Include(c => c.Ingredients));

            if (coctail == null)
            {
                throw new ExecutingException($"Coctail with id {request.Id} was not found.", System.Net.HttpStatusCode.NotFound);
            }
            return coctail;
        }
    }
}
