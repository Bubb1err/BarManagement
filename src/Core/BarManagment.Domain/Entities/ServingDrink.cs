using BarManagment.Domain.Entities.Base;

namespace BarManagment.Domain.Entities
{
    public sealed class ServingDrink : Entity
    {
        public ServingDrink(
            Guid id, 
            string title, 
            string description, 
            double serveAmountMl, 
            double price, 
            bool isAlcohol)
            : base(id)
        {
            Title = title;
            Description = description;
            ServeAmountMl = serveAmountMl;
            Price = price;
            IsAlcohol = isAlcohol;
        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public double ServeAmountMl { get; private set; }
        public double Price { get; private set; }
        public bool IsAlcohol { get; private set; }

    }
}
