using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Coctails.Commands.UpdateCoctail
{
    internal class UpdateCoctailCommandHandler : IRequestHandler<UpdateCoctailCommand, Coctail>
    {
        private readonly IRepository<Coctail> _coctailRepository;
        private readonly IRepository<CoctailIngredient> _ingredientsRepository;
        private readonly IRepository<Commodity> _commodityRepository;

        public UpdateCoctailCommandHandler(
             IRepository<Coctail> coctailRepository,
            IRepository<CoctailIngredient> ingredientsRepository,
            IRepository<Commodity> commodityRepository)
        {
            _coctailRepository = coctailRepository;
            _ingredientsRepository = ingredientsRepository;
            _commodityRepository = commodityRepository;
        }
        public async Task<Coctail> Handle(UpdateCoctailCommand request, CancellationToken cancellationToken)
        {
            var coctail = await _coctailRepository.GetFirstOrDefaultAsync(c => c.Id == request.Id, 
                include: i => i.Include(c => c.Ingredients));
            if (coctail is null)
            {
                throw new ExecutingException($"Coctail with id {request.Id} was not found.", System.Net.HttpStatusCode.NotFound);
            }

            var ingredientsToAdd = request.Ingredients.Where(ingredient => ingredient.Id is null);

            if (ingredientsToAdd is not null && ingredientsToAdd.Any())
            {
                List<CoctailIngredient> ingredientsList = new();

                foreach (var ingredient in ingredientsToAdd)
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

            coctail.Update(request.Name, request.Description, request.Price);
            _coctailRepository.Update(coctail);
            await _coctailRepository.SaveChangesAsync();
            return coctail;
        }
    }
}
