

using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    //vodka, konyak, juice...
    public sealed class Commodity : BaseEntity
    {
        public Commodity(
            Guid id, 
            string title,
            decimal price, 
            string description, 
            DefaultMeasure defaultMeasure)
            :base (id)
        {
            Title = title;
            Price = price;
            Description = description;
            DefaultMeasureId = defaultMeasure.Id;
        }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public string? Description { get; private set; }
        public Guid DefaultMeasureId { get; private set; }
    }
}
