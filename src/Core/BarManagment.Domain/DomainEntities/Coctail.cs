using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    public sealed class Coctail : BaseEntity
    {
        private Coctail(
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
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public IEnumerable<CoctailIngredient> Ingredients { get; private set; }

        public static Coctail Create(string name, string description, decimal price)
        {
            return new Coctail(Guid.NewGuid(), name, description, price);
        }

        public void Update(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
        public void AddIngredients(IEnumerable<CoctailIngredient> coctailIngredients)
        {
            Ingredients.ToList().AddRange(coctailIngredients);
        }
    }
}
