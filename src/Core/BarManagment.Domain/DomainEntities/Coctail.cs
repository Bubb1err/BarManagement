using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    public sealed class Coctail : BaseEntity
    {
        public Coctail(
            Guid id, 
            string name, 
            string description,
            decimal price)
            : base(id)
        {
            Name = name;
            Description = description;
            Price = price;
            Ingredients = new List<CoctailIngredient>();
        }
        private Coctail() { }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<CoctailIngredient> Ingredients { get; set; }
    }
}
