using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Drinks.Commands.SaveDrink
{
    public class SaveDrinkCommand : IRequest<Drink>
    {
        public SaveDrinkCommand(
            string name,
            string description, 
            decimal price, 
            Guid commodityId,
            double amountInDefaultMeasure,
            Guid userId)
        {
            Name = name;
            Description = description;
            Price = price;
            CommodityId = commodityId;
            AmountInDefaultMeasure = amountInDefaultMeasure;
            UserId = userId;
        }

        public string Name { get; }

        public string Description { get; }

        public decimal Price { get; }

        public Guid CommodityId { get; }

        public double AmountInDefaultMeasure { get; }

        public Guid UserId { get; }
    }
}
