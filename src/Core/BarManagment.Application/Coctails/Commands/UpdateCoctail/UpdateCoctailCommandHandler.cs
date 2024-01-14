using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Exceptions;
using MediatR;

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
            Guid[] ids = request.Ingredients.Select(ingredient => ingredient.Id).ToArray();
            var ingredients = _ingredientsRepository.GetAll(ingedient => ids.Contains(ingedient.Id));

            var coctail = await _coctailRepository.GetFirstOrDefaultAsync(c => c.Id == request.Id);
            if ( coctail == null)
            {
                throw new ExecutingException($"Coctail with id {request.Id} was not found.", System.Net.HttpStatusCode.NotFound);
            }

            coctail.Update(request.Name, request.Description, request.Price, ingredients);
            _coctailRepository.Update(coctail);
            await _coctailRepository.SaveChangesAsync();
            return coctail;
        }
    }
}
