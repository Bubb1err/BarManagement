using BarManagment.Contracts.Coctails;
using BarManagment.Domain.Abstractions.Repository;
using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Coctails.Queries.GetCoctailById
{
    internal class GetCoctailByIdQueryHandler : IRequestHandler<GetCoctailByIdQuery, GetCoctailDetailsViewModel>
    {
        private readonly IRepository<Coctail> _coctailRepository;
        private readonly IReceiptRepository _receiptRepository;

        public GetCoctailByIdQueryHandler(
            IRepository<Coctail> coctailRepository, 
            IReceiptRepository receiptRepository)
        {
            _coctailRepository = coctailRepository;
            _receiptRepository = receiptRepository;
        }
        public async Task<GetCoctailDetailsViewModel> Handle(GetCoctailByIdQuery request, CancellationToken cancellationToken)
        {
            var coctail = await _coctailRepository.GetFirstOrDefaultAsync(c => c.Id == request.Id,
                include: i => i.Include(c => c.Ingredients).ThenInclude(i => i.Commodity).ThenInclude(c => c.DefaultMeasure));

            if (coctail == null)
            {
                throw new ExecutingException($"Coctail with id {request.Id} was not found.", System.Net.HttpStatusCode.NotFound);
            }

            var coctailsRating = _receiptRepository.GetCoctailsRating();

            int totalCoctailsCount = coctailsRating.Count();
            int coctailIndex = coctailsRating.FindIndex(i => i == request.Id);

            var getCoctailsVM = new GetCoctailDetailsViewModel
            {
                Id = coctail.Id,
                Name = coctail.Name,
                Description = coctail.Description,
                Price = coctail.Price,
                Ingredients = coctail.Ingredients,
                TotalCoctailsCount = totalCoctailsCount,
                CoctailRating = coctailIndex + 1
            };

            return getCoctailsVM;
        }
    }
}
