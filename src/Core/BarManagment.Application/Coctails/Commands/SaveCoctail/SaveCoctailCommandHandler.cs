using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Exceptions;
using MediatR;

namespace BarManagment.Application.Coctails.Commands.SaveCoctail
{
    internal class SaveCoctailCommandHandler : IRequestHandler<SaveCoctailCommand, Coctail>
    {
        private readonly IRepository<Coctail> _coctailRepository;
        private readonly IRepository<CoctailIngredient> _ingredientsRepository;
        private readonly IRepository<Commodity> _commodityRepository;

        public SaveCoctailCommandHandler(
            IRepository<Coctail> coctailRepository,
            IRepository<CoctailIngredient> ingredientsRepository,
            IRepository<Commodity> commodityRepository)
        {
            _coctailRepository = coctailRepository;
            _ingredientsRepository = ingredientsRepository;
            _commodityRepository = commodityRepository;
        }
        public async Task<Coctail> Handle(SaveCoctailCommand request, CancellationToken cancellationToken)
        {
            var coctail = Coctail.Create(request.Name, request.Description, request.Price);

            var commodityIds = request.Ingredients.Select(ingredient => ingredient.CommodityId);

            if (request.Ingredients != null && request.Ingredients.Any())
            {
                List<CoctailIngredient> ingredientsList = new();

                foreach (var ingredient in request.Ingredients)
                {
                    var commodity = await _commodityRepository.GetFirstOrDefaultAsync(commodity => commodity.Id == ingredient.CommodityId);
                    if (commodity is null)
                    {
                        throw new ExecutingException($"Commodity with id {ingredient.CommodityId} does not exist.", System.Net.HttpStatusCode.BadRequest);
                    }

                    ingredientsList.Add(CoctailIngredient.Create(commodity, ingredient.AmountInDefaultMeasure, coctail.Id));
                }

                await _ingredientsRepository.AddRangeAsync(ingredientsList);
                coctail.AddIngredients(ingredientsList);
            }

            await _coctailRepository.AddAsync(coctail);

            await _coctailRepository.SaveChangesAsync();
            return coctail;
        }
    }
}
