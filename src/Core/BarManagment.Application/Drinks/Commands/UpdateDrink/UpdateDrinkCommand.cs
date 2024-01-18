using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Drinks.Commands.UpdateDrink
{
    public class UpdateDrinkCommand : IRequest<Drink>
    {
        public UpdateDrinkCommand(
            Guid id,
            string name,
            string description,
            decimal price,
            Guid commodityId,
            double amountInDefaultMeasure)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CommodityId = commodityId;
            AmountInDefaultMeasure = amountInDefaultMeasure;
        }
        public Guid Id {  get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public Guid CommodityId { get; }
        public double AmountInDefaultMeasure { get; }
    }
}
