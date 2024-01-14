using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Coctails.Commands.SaveCoctail
{
    internal class SaveCoctailCommandHandler : IRequestHandler<SaveCoctailCommand, Coctail>
    {
        private readonly IRepository<Coctail> _coctailRepository;
        private readonly IRepository<CoctailIngredient> _ingredientsRepository;

        public SaveCoctailCommandHandler(
            IRepository<Coctail> coctailRepository,
            IRepository<CoctailIngredient> ingredientsRepository)
        {
            _coctailRepository = coctailRepository;
            _ingredientsRepository = ingredientsRepository;
        }
        public async Task<Coctail> Handle(SaveCoctailCommand request, CancellationToken cancellationToken)
        {
           Guid[] ids = request.Ingredients.Select(ingredient => ingredient.Id).ToArray();
           var ingredients = _ingredientsRepository.GetAll(ingedient => ids.Contains(ingedient.Id));

            var coctail = Coctail.Create(request.Name, request.Description, request.Price, ingredients);
            await _coctailRepository.AddAsync(coctail);

            await _coctailRepository.SaveChangesAsync();
            return coctail;
        }
    }
}
