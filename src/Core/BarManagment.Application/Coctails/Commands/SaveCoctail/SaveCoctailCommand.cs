using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Coctails.Commands.SaveCoctail
{
    public class SaveCoctailCommand : IRequest<Coctail>
    {
        public SaveCoctailCommand(
            string name,
            string description,
            decimal price,
            IEnumerable<CoctailIngredient> ingredients)
        {
            Name = name;
            Description = description;
            Price = price;
            Ingredients = ingredients;
        }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public IEnumerable<CoctailIngredient> Ingredients { get; }
    }
}
