using BarManagment.Application.DTO.Coctail;
using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Coctails.Commands.UpdateCoctail
{
    public class UpdateCoctailCommand : IRequest<Coctail>
    {
        public UpdateCoctailCommand(
          Guid id,
          string name,
          string description,
          decimal price,
          IEnumerable<UpdateCoctailIngredientDTO> ingredients)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Ingredients = ingredients;
        }
        public Guid Id { get; set; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public IEnumerable<UpdateCoctailIngredientDTO> Ingredients { get; }
    }
}
