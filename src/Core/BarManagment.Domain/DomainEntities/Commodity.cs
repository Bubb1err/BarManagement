using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    //vodka, konyak, juice...
    public sealed class Commodity : BaseEntity
    {
        private Commodity(
            Guid id, 
            string title,
            decimal price, 
            string? description, 
            DefaultMeasure defaultMeasure,
            string companyCode)
            :base (id)
        {
            Title = title;
            Price = price;
            Description = description;
            DefaultMeasureId = defaultMeasure.Id;
            DefaultMeasure = defaultMeasure;
            CompanyCode = companyCode;
        }

        private Commodity() { }

        public string Title { get; private set; }

        public decimal Price { get; private set; }

        public string? Description { get; private set; }

        public Guid DefaultMeasureId { get; private set; }

        public DefaultMeasure DefaultMeasure { get; private set; }

        public string CompanyCode { get; private set; }

        public static Commodity Create(string title, decimal price, DefaultMeasure defaultMeasure, string? description, string companyCode)
        {
            return new Commodity(
                Guid.NewGuid(),
                title,
                price,
                description,
                defaultMeasure,
                companyCode);
        }

        public void Update(string title, decimal price, DefaultMeasure defaultMeasure, string? description)
        {
            Title = title;
            Price = price;
            Description = description;
            DefaultMeasure = defaultMeasure;
            DefaultMeasureId = defaultMeasure.Id;
        }
    }
}
