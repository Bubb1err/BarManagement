

using BarManagment.Domain.Entities.Base;

namespace BarManagment.Domain.Entities
{
    public sealed class MeasureType : Entity
    {
        public MeasureType(
            Guid id, 
            string name, 
            double defaultAmount)
            : base(id)
        {
            Name = name;
            DefaultAmount = defaultAmount;
        }
        public string Name { get; private set; }
        public double DefaultAmount { get; private set; }
    }
}
