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

        public UpdateCoctailCommandHandler(
             IRepository<Coctail> coctailRepository,
            IRepository<CoctailIngredient> ingredientsRepository)
        {
            _coctailRepository = coctailRepository;
            _ingredientsRepository = ingredientsRepository;
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

            if (ingredientsToAdd != null && ingredientsToAdd.Any())
            {
                var ingredients = ingredientsToAdd.Select(ingredient => CoctailIngredient.Create(ingredient.CommodityId, ingredient.AmountInDefaultMeasure, coctail.Id));
                await _ingredientsRepository.AddRangeAsync(ingredients);
                coctail.AddIngredients(ingredients);
            }

            coctail.Update(request.Name, request.Description, request.Price);
            _coctailRepository.Update(coctail);
            await _coctailRepository.SaveChangesAsync();
            return coctail;
        }
    }
}
