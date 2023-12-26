
using BarManagment.Domain.Entities.Base;

namespace BarManagment.Domain.Entities
{
    public sealed class Supply : Entity
    {
        public Supply(
            Guid id, 
            string name, 
            double pricePerOne)
            : base (id)
        {
            Name = name;
            PricePerOne = pricePerOne;
        }
        public string Name { get; private set; }
        public double PricePerOne { get;  private set; }
    }
}
